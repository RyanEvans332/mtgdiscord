using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using mtgdiscord;
using Newtonsoft.Json;

namespace mtgdiscord.Rules
{
    public class RuleService
    {
        private Dictionary<string, string> abilityRules = new();
        private Dictionary<string, string> actionRules = new();

        private static RuleService instance = null;

        //stupid singleton pattern.
        public static RuleService Instance { 
            get{ 
                if(instance == null)
                {
                    instance = new RuleService();
                }
                return instance; 
            } 
        }

        //TODO: Move rule generation to init fnc. Invalidate rules.json on regular cadence and fetch from remote source.
        private RuleService()
        {
            ConsoleEx.WriteLine("Initializing rules dict");
            string json = "";
            try
            {
                json = System.IO.File.ReadAllText("Rules/rules.json");
            }
            catch (Exception ex)
            {
                ConsoleEx.WriteLine($"Failed to load rules. Will not display rules in this session. ex:{ex.Message}");
            }

            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            foreach (var pair in obj.abilities)
            {
                abilityRules.Add(pair.Name, pair.Value.ToString());
            }

            foreach (var pair in obj.actions)
            {
                actionRules.Add(pair.Name, pair.Value.ToString());
            }

        }

        public RuleSet getRules(List<string> keywords)
        { 
            RuleSet res = new RuleSet();
            foreach (string keyword in keywords)
            {
                if (abilityRules.ContainsKey(keyword))
                {
                    if (!string.IsNullOrEmpty(abilityRules[keyword])) 
                    {
                        res.abilities.Add(keyword, abilityRules[keyword]);
                    }                }
                else if (actionRules.ContainsKey(keyword))
                {
                    if (!string.IsNullOrEmpty(actionRules[keyword]))
                    {
                        res.actions.Add(keyword, actionRules[keyword]);
                    }
                }
                else
                {
                    ConsoleEx.WriteLine($"Could not find any rule with name: {keyword}. This rule may be new.");
                }
            }

            return res;
        }
    }

    public class RuleSet
    {
        public static RuleSet operator +(RuleSet a, RuleSet b)
        {
            foreach(var ability in b.abilities)
            {
                a.abilities.TryAdd(ability.Key, ability.Value);
            }
            foreach (var action in b.actions)
            {
                a.abilities.TryAdd(action.Key, action.Value);
            }

            return a;
        }

        public override string ToString()
        {
            string res = "";

            if (abilities.Count > 0)
            {
                res += "**__Abilities__** \n";

                foreach (var rule in abilities)
                {
                    res += $"***{rule.Key}***: *{rule.Value}*\n";
                }

                if(actions.Count > 0)
                {
                    res += '\n';
                }
            }
            

            if (actions.Count > 0)
            {
                res += "**__Actions__** \n";

                foreach (var rule in actions)
                {
                    res += $"***{rule.Key}***: *{rule.Value}*\n";
                }
            }

            return res;
        }

        public Dictionary<string, string> abilities = new();
        public Dictionary<string, string> actions = new();
    }
}
