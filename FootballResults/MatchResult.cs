using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballResults
{
    internal class MatchResult
    {
        public MatchResult(string hostTeam, string opponentTeam, string result)
        {
            HostTeam = hostTeam;
            OpponentTeam = opponentTeam;
            Result = result;
        }

        public string HostTeam { get; set; }
        public string OpponentTeam { get; set; }
        public string Result { get; set; }
    }
}
