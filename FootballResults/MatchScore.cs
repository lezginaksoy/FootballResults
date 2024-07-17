using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballResults
{
    internal class MatchScore
    {
        public string TeamName { get; set; }
        public int TotalMatches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public MatchScore()
        {            
        }

        public MatchScore(string name)
        {
            TeamName = name;
        }

        public void Win()
        {
            TotalMatches++;
            Wins++;
        }

        public void Draw()
        {
            TotalMatches++;
            Draws++;
        }

        public void Lose()
        {
            TotalMatches++;
            Losses++;
        }

        public double GetWinPercentage()
        {
            if (TotalMatches == 0)
                return 0;

            var percentage = (double)Wins / TotalMatches * 100;

            return percentage;
        }

        public int GetScores()
        {
            return Wins * 3 + Draws;
        }

        public List<MatchScore> GetMatchesScores(List<MatchResult> matches)
        {
            var results = new List<MatchScore>();

            foreach (var match in matches)
            {
                var host = results.Find(x => x.TeamName.Equals(match.HostTeam));
                var oppo = results.Find(x => x.TeamName.Equals(match.OpponentTeam));

                if (host is null)
                {
                    host = new MatchScore(match.HostTeam);
                    results.Add(host);
                }

                if (oppo is null)
                {
                    oppo = new MatchScore(match.OpponentTeam);
                    results.Add(oppo);
                }

                switch (match.Result)
                {
                    case "win":
                        host.Win();
                        oppo.Lose();
                        break;
                    case "loss":
                        host.Lose();
                        oppo.Win();
                        break;
                    case "draw":
                        host.Draw();
                        oppo.Draw();
                        break;
                    default: break;
                }
            }

            return results;
        }

    }
}