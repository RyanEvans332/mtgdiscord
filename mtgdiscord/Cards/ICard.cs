using mtgdiscord.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgdiscord.Cards
{
    public abstract class ICard
    {
        public abstract string getCardName();
        public abstract List<string> getCardImageURIs();
        public abstract RuleSet getCardRules();
    }
}
