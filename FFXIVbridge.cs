using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using Advanced_Combat_Tracker;
using FFXIV_ACT_Plugin.Common;

namespace Jail_Plugin {
    internal class FFXIVbridge {

        private IDataRepository repository;

        private IDataRepository get_repository() {
            if (repository != null) return repository;
            ActPluginData FFXIV = ActGlobals.oFormActMain.ActPlugins.FirstOrDefault(x => x.lblPluginTitle.Text == "FFXIV_ACT_Plugin.dll");
            if (FFXIV != null && FFXIV.pluginObj != null) {
                try {
                    repository = (IDataRepository)FFXIV.pluginObj.GetType().GetProperty("DataRepository").GetValue(FFXIV.pluginObj);
                }
                catch (Exception) { }
            }
            return repository;
        }

        public uint playerID() {
            try {
                var repo = get_repository();
                if (repo == null) return 0;

                return repo.GetCurrentPlayerID();
            }
            catch (FileNotFoundException) {
                // The FFXIV plugin isn't loaded
                return 0;
            }
        }


        public string playerName() {
            try {
                var repo = get_repository();
                if (repo == null) return null;

                var playerId = repo.GetCurrentPlayerID();

                var playerInfo = repo.GetCombatantList().FirstOrDefault(x => x.ID == playerId);
                if (playerInfo == null) return null;

                return playerInfo.Name;
            }
            catch (FileNotFoundException) {
                // The FFXIV plugin isn't loaded
                return null;
            }
        }

        public ReadOnlyCollection<FFXIV_ACT_Plugin.Common.Models.Combatant> GetCombatants() {
            var repo = get_repository();
            if (repo == null) return null;
            return repo.GetCombatantList();
        }

        public static string job_string(FFXIV_ACT_Plugin.Common.Models.Combatant c) {
            switch (c.Job) {
                case 33: return "AST"; //ast
                case 23: return "BRD"; //brd
                case 25: return "BLM"; //blm
                case 36: return "BLU"; //blu
                case 38: return "DNC"; //dnc
                case 32: return "DRK"; //drk
                case 22: return "DRG"; //drg
                case 37: return "GNB"; //gnb
                case 31: return "MCH"; //mch
                case 20: return "MNK"; //mnk
                case 30: return "NIN"; //nin
                case 19: return "PLD"; //pld
                case 35: return "RDM"; //rdm
                case 34: return "SAM"; //sam
                case 28: return "SCH"; //sch
                case 27: return "SMN"; //smn
                case 21: return "WAR"; //war
                case 24: return "WHM";
                default: return "???";
            }
        }

        public static byte job_prio(string job) {
            switch (job) {
                // JOBS
                case "MNK": return 1;
                case "DRG": return 2;
                case "SAM": return 3;
                case "NIN": return 4;
                case "WAR": return 5;
                case "GNB": return 6;
                case "DRK": return 7;
                case "PLD": return 8;
                case "RDM": return 9;
                case "DNC": return 10;
                case "BRD": return 11;
                case "MCH": return 12;
                case "SMN": return 13;
                case "BLM": return 14;
                case "AST": return 15;
                case "SCH": return 16;
                case "WHM": return 17;
                default: return 18;
            }
        }

        public static byte job_order(string job) {
            switch (job) {
                // JOBS
                case "PLD": return 1;
                case "WAR": return 2;
                case "DRK": return 3;
                case "GNB": return 4;
                case "WHM": return 5;
                case "SCH": return 6;
                case "AST": return 7;
                case "MNK": return 8;
                case "DRG": return 9;
                case "NIN": return 10;
                case "SAM": return 11;
                case "BRD": return 12;
                case "MCH": return 13;
                case "DNC": return 14;
                case "BLM": return 15;
                case "SMN": return 16;
                case "RDM": return 17;
                default: return 18;
            }
        }

        public List<String> get_order() {
            var combatants = GetCombatants().OrderBy(x => job_order(job_string(x))).ToList();
            combatants.RemoveAll(x => job_string(x) == "???");
            combatants.RemoveAll(x => x.ID == playerID());
            List<String> result = (from player in combatants select player.Name).ToList();
            result.Insert(0, playerName());
            if (result[0] == null) return result.Take(0).ToList();
            return result.Take(8).ToList();
        }

        public List<String> get_prio() {
            var combatants = GetCombatants().OrderBy(x => job_prio(job_string(x))).ToList();
            combatants.RemoveAll(x => job_string(x) == "???");
            return (from player in combatants select player.Name).Take(8).ToList();
        }
    }

}
