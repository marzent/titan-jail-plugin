using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

[assembly: AssemblyTitle("JailPriority Plugin")]
[assembly: AssemblyVersion("1.1.0.1")]

namespace ACT_Plugin
{
    public class JailPriority : UserControl, IActPluginV1
    {

        InputSimulator sim = new InputSimulator();
        private Label Label1;
        private PictureBox pictureBox1;

        #region Designer Created Code (Avoid editing)
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JailPriority));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.player1TextBox = new System.Windows.Forms.TextBox();
            this.player2TextBox = new System.Windows.Forms.TextBox();
            this.player3TextBox = new System.Windows.Forms.TextBox();
            this.player4TextBox = new System.Windows.Forms.TextBox();
            this.player5TextBox = new System.Windows.Forms.TextBox();
            this.player6TextBox = new System.Windows.Forms.TextBox();
            this.player7TextBox = new System.Windows.Forms.TextBox();
            this.player8TextBox = new System.Windows.Forms.TextBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.party8 = new System.Windows.Forms.TextBox();
            this.party7 = new System.Windows.Forms.TextBox();
            this.party6 = new System.Windows.Forms.TextBox();
            this.party5 = new System.Windows.Forms.TextBox();
            this.party4 = new System.Windows.Forms.TextBox();
            this.party1 = new System.Windows.Forms.TextBox();
            this.party2 = new System.Windows.Forms.TextBox();
            this.party3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.logsTextBox = new System.Windows.Forms.TextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.player1TextBox);
            this.panel1.Controls.Add(this.player2TextBox);
            this.panel1.Controls.Add(this.player3TextBox);
            this.panel1.Controls.Add(this.player4TextBox);
            this.panel1.Controls.Add(this.player5TextBox);
            this.panel1.Controls.Add(this.player6TextBox);
            this.panel1.Controls.Add(this.player7TextBox);
            this.panel1.Controls.Add(this.player8TextBox);
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 211);
            this.panel1.TabIndex = 8;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(5, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(38, 13);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Priority";
            // 
            // player1TextBox
            // 
            this.player1TextBox.Location = new System.Drawing.Point(49, 8);
            this.player1TextBox.Name = "player1TextBox";
            this.player1TextBox.Size = new System.Drawing.Size(164, 20);
            this.player1TextBox.TabIndex = 8;
            this.player1TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player2TextBox
            // 
            this.player2TextBox.Location = new System.Drawing.Point(49, 34);
            this.player2TextBox.Name = "player2TextBox";
            this.player2TextBox.Size = new System.Drawing.Size(164, 20);
            this.player2TextBox.TabIndex = 9;
            this.player2TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player3TextBox
            // 
            this.player3TextBox.Location = new System.Drawing.Point(49, 60);
            this.player3TextBox.Name = "player3TextBox";
            this.player3TextBox.Size = new System.Drawing.Size(164, 20);
            this.player3TextBox.TabIndex = 10;
            this.player3TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player4TextBox
            // 
            this.player4TextBox.Location = new System.Drawing.Point(49, 86);
            this.player4TextBox.Name = "player4TextBox";
            this.player4TextBox.Size = new System.Drawing.Size(164, 20);
            this.player4TextBox.TabIndex = 11;
            this.player4TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player5TextBox
            // 
            this.player5TextBox.Location = new System.Drawing.Point(49, 112);
            this.player5TextBox.Name = "player5TextBox";
            this.player5TextBox.Size = new System.Drawing.Size(164, 20);
            this.player5TextBox.TabIndex = 12;
            this.player5TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player6TextBox
            // 
            this.player6TextBox.Location = new System.Drawing.Point(49, 138);
            this.player6TextBox.Name = "player6TextBox";
            this.player6TextBox.Size = new System.Drawing.Size(164, 20);
            this.player6TextBox.TabIndex = 13;
            this.player6TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player7TextBox
            // 
            this.player7TextBox.Location = new System.Drawing.Point(49, 164);
            this.player7TextBox.Name = "player7TextBox";
            this.player7TextBox.Size = new System.Drawing.Size(164, 20);
            this.player7TextBox.TabIndex = 14;
            this.player7TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player8TextBox
            // 
            this.player8TextBox.Location = new System.Drawing.Point(49, 188);
            this.player8TextBox.Name = "player8TextBox";
            this.player8TextBox.Size = new System.Drawing.Size(164, 20);
            this.player8TextBox.TabIndex = 15;
            this.player8TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.Color.Black;
            this.exportButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.exportButton.Location = new System.Drawing.Point(130, 244);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportPriorityList);
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.Color.Black;
            this.importButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.importButton.Location = new System.Drawing.Point(3, 244);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 10;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.importPriorityList);
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.BackColor = System.Drawing.Color.Transparent;
            this.instructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.Location = new System.Drawing.Point(460, 16);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(200, 96);
            this.instructionLabel.TabIndex = 11;
            this.instructionLabel.Text = "1. Write priority list.\r\n2. Write your Party List in order.\r\n3. Set up CTRL+ SHIF" +
    "T + F{1-8}\r\n    macros in order.\r\n\r\nyou can export/import priority list.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.party8);
            this.panel2.Controls.Add(this.party7);
            this.panel2.Controls.Add(this.party6);
            this.panel2.Controls.Add(this.party5);
            this.panel2.Controls.Add(this.party4);
            this.panel2.Controls.Add(this.party1);
            this.panel2.Controls.Add(this.party2);
            this.panel2.Controls.Add(this.party3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(237, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 211);
            this.panel2.TabIndex = 13;
            // 
            // party8
            // 
            this.party8.Location = new System.Drawing.Point(54, 188);
            this.party8.Name = "party8";
            this.party8.Size = new System.Drawing.Size(163, 20);
            this.party8.TabIndex = 10;
            this.party8.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // party7
            // 
            this.party7.Location = new System.Drawing.Point(54, 164);
            this.party7.Name = "party7";
            this.party7.Size = new System.Drawing.Size(163, 20);
            this.party7.TabIndex = 9;
            this.party7.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // party6
            // 
            this.party6.Location = new System.Drawing.Point(54, 138);
            this.party6.Name = "party6";
            this.party6.Size = new System.Drawing.Size(163, 20);
            this.party6.TabIndex = 8;
            this.party6.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // party5
            // 
            this.party5.Location = new System.Drawing.Point(54, 112);
            this.party5.Name = "party5";
            this.party5.Size = new System.Drawing.Size(163, 20);
            this.party5.TabIndex = 7;
            this.party5.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // party4
            // 
            this.party4.Location = new System.Drawing.Point(54, 86);
            this.party4.Name = "party4";
            this.party4.Size = new System.Drawing.Size(163, 20);
            this.party4.TabIndex = 6;
            this.party4.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // party1
            // 
            this.party1.Location = new System.Drawing.Point(54, 8);
            this.party1.Name = "party1";
            this.party1.Size = new System.Drawing.Size(163, 20);
            this.party1.TabIndex = 3;
            this.party1.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // party2
            // 
            this.party2.Location = new System.Drawing.Point(54, 34);
            this.party2.Name = "party2";
            this.party2.Size = new System.Drawing.Size(163, 20);
            this.party2.TabIndex = 4;
            this.party2.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // party3
            // 
            this.party3.Location = new System.Drawing.Point(54, 60);
            this.party3.Name = "party3";
            this.party3.Size = new System.Drawing.Size(163, 20);
            this.party3.TabIndex = 5;
            this.party3.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Party";
            // 
            // logsTextBox
            // 
            this.logsTextBox.Location = new System.Drawing.Point(6, 284);
            this.logsTextBox.MaxLength = 1000000;
            this.logsTextBox.Multiline = true;
            this.logsTextBox.Name = "logsTextBox";
            this.logsTextBox.ReadOnly = true;
            this.logsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logsTextBox.Size = new System.Drawing.Size(632, 148);
            this.logsTextBox.TabIndex = 14;
            this.logsTextBox.Text = "Started..";
            this.logsTextBox.WordWrap = false;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoLabel.Location = new System.Drawing.Point(0, 480);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(199, 13);
            this.infoLabel.TabIndex = 15;
            this.infoLabel.Text = "made by Usagi Shiro / McReduce#4334";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(501, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 41);
            this.button1.TabIndex = 16;
            this.button1.Text = "Check lists";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(969, 493);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // JailPriority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.logsTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Name = "JailPriority";
            this.Size = new System.Drawing.Size(969, 493);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        #endregion
        public JailPriority()
        {
            InitializeComponent();
        }
        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\TitanJail.config.xml");
        private Panel panel1;
        private TextBox player8TextBox;
        private TextBox player7TextBox;
        private TextBox player6TextBox;
        private TextBox player5TextBox;
        private TextBox player4TextBox;
        private TextBox player3TextBox;
        private TextBox player2TextBox;
        private TextBox player1TextBox;
        private Button exportButton;
        private Button importButton;
        private Label instructionLabel;
        private Label label2;
        private Panel panel2;
        private Label label5;
        private TextBox party3;
        private TextBox party2;
        private TextBox party1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox logsTextBox;
        private Label infoLabel;
        private TextBox party8;
        private TextBox party7;
        private TextBox party6;
        private TextBox party5;
        private TextBox party4;
        private Button button1;
        SettingsSerializer xmlSettings;


        #region IActPluginV1 Members
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space
            xmlSettings = new SettingsSerializer(this); // Create a new settings serializer and pass it this instance
            LoadSettings();
            ActGlobals.oFormActMain.OnLogLineRead += OFormActMain_OnLogLineRead;
            lblStatus.Text = "Plugin started, have fun!";
        }


        List<String> orderPlayers = new List<string>();// list of players matched in logLine
        List<String> order = new List<String>(); // List of TTS Callouts
        List<String> players = new List<String>(); // All players in priority list
        String regex = ":(.*)?:2B6(B|C):.*?:.*?:"; // regex for jails
        int countMatches = 0;// number of matchups to the regex
        int[] mapping = new int[8];
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        private void OFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            var match = Regex.Match(logInfo.logLine, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
                return;
            if (stopwatch.ElapsedMilliseconds > 1000)//if elapsed time since 1st matchup > 1 second. reset stopwatch
            {
                logsTextBox.AppendText("\r\n\r\n" + "=======[RESET]=======");
                stopwatch.Reset();
                countMatches = 0;
                orderPlayers.Clear();
            }
            logsTextBox.AppendText("\r\n" + logInfo.logLine);
            stopwatch.Start();
            for (int i = 0; i < players.Count; i++)
            {
                if (logInfo.logLine.Contains(players[i]))
                    orderPlayers.Add(players[i]);
            }
            countMatches++;
            if (countMatches != 3)
                return;
            if (countMatches != orderPlayers.Count)
            {
                logsTextBox.AppendText("\r\n" + "-[Incorrect name/s in priority list!]-");
                return;
            }
            for (int i = 0; i < players.Count; i++)
            {
                if (orderPlayers.Contains(players[i]))
                {
                    logsTextBox.AppendText("\r\n" + "---[" + (i + 1) + "]---[" + players[i] + "]------>-----" + (mapping[i] + 1) + "---<--");
                    simulate_key(mapping[i]);
                }
            }
            Thread thread = new Thread(new ThreadStart(clear_markers));
            thread.Start();
        }

    private void clear_markers()
        {
            Thread.Sleep(11000);
            simulate_key(8);
        }

        public void DeInitPlugin()
        {
            // Unsubscribe from any events you listen to when exiting!
            ActGlobals.oFormActMain.OnLogLineRead -= OFormActMain_OnLogLineRead;
            SaveSettings();
            lblStatus.Text = "Plugin Exited";
        }
        #endregion


        void LoadSettings()
        {

            if (File.Exists(settingsFile))
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);
                TextBox[] Players = panel1.Controls.OfType<TextBox>().ToArray();
                TextBox[] Order = panel2.Controls.OfType<TextBox>().ToArray();
                try
                {
                    int i = 0;
                    int j = 0;
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.Name == "Player")
                            {
                                String line = xReader.ReadElementContentAsString();
                                players.Add(line);
                                Players[i].Text = line;
                                i++;
                            }
                            if (xReader.Name == "Order")
                            {
                                String line = xReader.ReadElementContentAsString();
                                order.Add(line);
                                Order[j].Text = line;
                                j++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
                xReader.Close();
            }
            else
            {
                updateMapping();
            }
        }
        void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
            TextBox[] Players = panel1.Controls.OfType<TextBox>().ToArray();
            TextBox[] Order = panel2.Controls.OfType<TextBox>().ToArray();
            xWriter.Formatting = Formatting.Indented;
            xWriter.Indentation = 1;
            xWriter.IndentChar = '\t';
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");    // <Config>
            xWriter.WriteStartElement("You");
            xWriter.WriteValue(0);
            xWriter.WriteEndElement();
            for (int i = 0; i < Players.Length; i++)
            {
                xWriter.WriteStartElement("Player");
                xWriter.WriteValue(Players[i].Text);
                xWriter.WriteEndElement();
            }
            for (int i = 0; i < Order.Length; i++)
            {
                xWriter.WriteStartElement("Order");
                xWriter.WriteValue(Order[i].Text);
                xWriter.WriteEndElement();
            }
            xWriter.WriteEndElement();  // </Config>
            xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
            xWriter.Flush();    // Flush the file buffer to disk
            xWriter.Close();
        }

        private void exportPriorityList(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "Priority.xml";
            // set filters - this can be done in properties as well
            savefile.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";
            savefile.RestoreDirectory = true;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(savefile.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
                        TextBox[] Players = panel1.Controls.OfType<TextBox>().ToArray();
                        xWriter.Formatting = Formatting.Indented;
                        xWriter.Indentation = 1;
                        xWriter.IndentChar = '\t';
                        xWriter.WriteStartDocument(true);
                        xWriter.WriteStartElement("Priority");
                        for (int i = 0; i < Players.Length; i++)
                        {
                            xWriter.WriteStartElement("Player");
                            xWriter.WriteValue(Players[i].Text);
                            xWriter.WriteEndElement();
                        }
                        xWriter.WriteEndElement();
                        xWriter.WriteEndDocument();
                        xWriter.Flush();
                        xWriter.Close();
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error Exporting File: " + ex.Message;
                }
            }
        }
        private void importPriorityList(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    try
                    {
                        FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        TextBox[] Players = panel1.Controls.OfType<TextBox>().ToArray();
                        XmlTextReader xReader = new XmlTextReader(fs);
                        int i = 0;
                        while (xReader.Read())
                        {
                            if (xReader.NodeType == XmlNodeType.Element)
                            {
                                if (xReader.Name == "Player")
                                {
                                    Players[i].Text = xReader.ReadElementContentAsString();
                                    i++;
                                }
                            }
                        }
                        xReader.Close();
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Error Importing File: " + ex.Message;
                    }

                }
            }
        }

        private void updatePlayers(object sender, EventArgs e)
        {
            players.Clear();
            TextBox[] Players = panel1.Controls.OfType<TextBox>().OrderBy(c => c.Name).ToArray();
            for (int i = 0; i < Players.Length; i++)
                players.Add(Players[i].Text);
            updateMapping();
        }

        private void updateTSS(object sender, EventArgs e)
        {
            order.Clear();
            TextBox[] Order = panel2.Controls.OfType<TextBox>().OrderBy(c => c.Name).ToArray();
            for (int i = 0; i < Order.Length; i++)
                order.Add(Order[i].Text);
            updateMapping();
        }
        private void updateMapping()
        {
            for (int i = 0; i < order.Count; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (order[i] == players[j])
                    {
                        mapping[j] = i;
                        continue;
                    }
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (check_lists())
                logsTextBox.AppendText("\r\n" + "-[SUCCESS! Priority and party lists match]-");
            else
                logsTextBox.AppendText("\r\n" + "-[FAILURE! Priority and party lists do not match, check your input!]-");
        }

        private bool check_lists()
        {
            for (int i = 0; i < 8; i++)
                if (players[i] != order[mapping[i]])
                        return false;
            return true;
        }

        private void simulate_key(int key)
        {
                const int delay = 5;
                sim.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
                Thread.Sleep(delay);
                sim.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
                Thread.Sleep(delay);
                sim.Keyboard.KeyDown(VirtualKeyCode.F1 + key);
                Thread.Sleep(delay);
                sim.Keyboard.KeyUp(VirtualKeyCode.F1 + key);
                Thread.Sleep(delay);
                sim.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
                Thread.Sleep(delay);
                sim.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
                Thread.Sleep(delay*2);
        }
    }
}
