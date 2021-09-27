using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Text.RegularExpressions;
using System.Threading;
using Jail_Plugin;

[assembly: AssemblyTitle("JailPriority Plugin")]
[assembly: AssemblyVersion("2.0.0.0")]

namespace ACT_Plugin {
    public class JailPriority : UserControl, IActPluginV1 {
        private System.Windows.Forms.Integration.ElementHost elementHost;
        private readonly FFXIVbridge bridge;
        private readonly TitanUI UI;
        private readonly List<string> orderPlayers = new List<string>();// list of players matched in logLine
        private readonly string[] order = new string[8]; // priority list
        private readonly string[] players = new string[8]; // party list
        private const string regex = ":(.*)?:2B6(B|C):.*?:.*?:"; // regex for jails
        private int countMatches = 0;// number of matchups to the regex
        private readonly int[] mapping = new int[8];
        private readonly System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        private Label lblStatus;    // The status label that appears in ACT's Plugin tab
        private readonly string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\TitanJails.config.xml");

        #region Designer Created Code (Avoid editing)
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // elementHost
            // 
            this.elementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost.Location = new System.Drawing.Point(0, 0);
            this.elementHost.Margin = new System.Windows.Forms.Padding(0);
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size(150, 150);
            this.elementHost.TabIndex = 1;
            this.elementHost.Child = null;
            // 
            // JailPriority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.elementHost);
            this.Name = "JailPriority";
            this.ResumeLayout(false);

        }


        #endregion

        #endregion
        public JailPriority() {
            InitializeComponent();
            UI = new TitanUI(this);
            elementHost.Child = UI;
            bridge = new FFXIVbridge();
        }

        #region IActPluginV1 Members
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText) {
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space
            LoadSettings();
            ActGlobals.oFormActMain.OnLogLineRead += OFormActMain_OnLogLineRead;
            UpdateMapping();
            lblStatus.Text = "Plugin started, have fun!";
        }

        private void OFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo) {
            if (isImport)
                return;
            Match match = Regex.Match(logInfo.logLine, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
                return;
            if (stopwatch.ElapsedMilliseconds > 1000)//if elapsed time since 1st matchup > 1 second. reset stopwatch
            {
                UI.Log("\r\n" + "=======[RESET]=======");
                stopwatch.Reset();
                countMatches = 0;
                orderPlayers.Clear();
            }
            UI.Log(logInfo.logLine);
            stopwatch.Start();
            for (int i = 0; i < players.Length; i++) {
                if (logInfo.logLine.Contains(players[i]))
                    orderPlayers.Add(players[i]);
            }
            countMatches++;
            if (countMatches != 3)
                return;
            if (countMatches != orderPlayers.Count) {
                UI.Log("-[Incorrect name/s in priority list!]-");
                return;
            }
            for (int i = 0; i < order.Length; i++) {
                if (orderPlayers.Contains(order[i])) {
                    UI.Log("---[" + (i + 1) + "]---[" + order[i] + "]------>-----" + (mapping[i] + 1) + "---<--");
                    KeyPresser.Combo(mapping[i]);
                }
            }
            Thread thread = new Thread(new ThreadStart(()=> {
                Thread.Sleep(11000);
                KeyPresser.Combo(8);
            }));
            thread.Start(); //clear markers
        }

        public void DeInitPlugin() {
            // Unsubscribe from any events you listen to when exiting!
            ActGlobals.oFormActMain.OnLogLineRead -= OFormActMain_OnLogLineRead;
            SaveSettings();
            lblStatus.Text = "Plugin Exited";
        }
        #endregion


        public void LoadSettings() {
            if (File.Exists(settingsFile)) {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);
                try {
                    int i = 0; int j = 0;
                    while (xReader.Read()) {
                        if (xReader.NodeType == XmlNodeType.Element) {
                            switch (xReader.Name) {
                                case "Player":
                                    players[i++] = xReader.ReadElementContentAsString();
                                    break;
                                case "Order":
                                    order[j++] = xReader.ReadElementContentAsString();
                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
                xReader.Close();
            }
            UI.Update(players, order);
        }
        private void SaveSettings() {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8) {
                Formatting = Formatting.Indented,
                Indentation = 1,
                IndentChar = '\t'
            };
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");    // <Config>
            foreach (string player in players) {
                xWriter.WriteStartElement("Player");
                xWriter.WriteValue(player);
                xWriter.WriteEndElement();
            }
            foreach (string prio in order) {
                xWriter.WriteStartElement("Order");
                xWriter.WriteValue(prio);
                xWriter.WriteEndElement();
            }
            xWriter.WriteEndElement();  // </Config>
            xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
            xWriter.Flush();    // Flush the file buffer to disk
            xWriter.Close();
        }


        public void UpdatePlayers(System.Windows.Controls.TextBox[] Players) {
            for (int i = 0; i < players.Length; i++)
                players[i] = Players[i].Text;
            UpdateMapping();
        }

        public void UpdatePrio(System.Windows.Controls.TextBox[] Order) {
            for (int i = 0; i < order.Length; i++)
                order[i] = Order[i].Text;
            UpdateMapping();
        }


        private void UpdateMapping() {
            for (int i = 0; i < players.Length; i++) 
                for (int j = 0; j < order.Length; j++)
                    if (players[i] == order[j]) {
                        mapping[j] = i;
                        continue;
                    }
        }

        public bool CheckLists() {
            for (int i = 0; i < players.Length; i++)
                if (order[i] != players[mapping[i]])
                    return false;
            return true;
        }

        public bool AutoFill() {
            List<string> FFprio = bridge.get_prio();
            List<string> FForder = bridge.get_order();
            if (FFprio.Count != 8 || FForder.Count != 8) return false;
            for (int i = 0; i < FFprio.Count; i++)
                order[i] = FFprio[i];
            for (int i = 0; i < FForder.Count; i++)
                players[i] = FForder[i];
            UI.Update(players, order);
            return true;
        }

    }
}
