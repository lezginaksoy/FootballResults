using FootballResults;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var file = @"..\..\..\Data\matchResults.txt";
            var parsedMatchesResult = ReadMatchResultsFile(file);
            var scores = new MatchScore().GetMatchesScores(parsedMatchesResult);
            PrintResults(scores);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred, " + ex.Message);
        }
    }

    static List<MatchResult> ReadMatchResultsFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new Exception();

        var allRes = File.ReadAllLines(filePath);
        if (allRes is null || allRes.Length == 0)
            throw new Exception();

        var splitRes = allRes.Select(line => line.Split(';'));
        var parseRes = splitRes.Select(res => new MatchResult(res[0], res[1], res[2])).ToList();
        return parseRes;
    }

    static void PrintResults(List<MatchScore> scores)
    {
        var sortedScores = scores.OrderByDescending(x => x.GetScores()).ThenBy(x => x.TeamName).ToList();

        Console.WriteLine("Team               | MP | W  | D  | L  | P  | Win % ");
        foreach (var sc in sortedScores)
        {
            Console.WriteLine($"{sc.TeamName,-18} | {sc.TotalMatches,2} | {sc.Wins,2} | {sc.Draws,2} | {sc.Losses,2} | {sc.GetScores(),2} | {sc.GetWinPercentage(),6:F2}");
        }
    }
}