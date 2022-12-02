var lines = File.ReadLines("input.txt");

var score = lines.CalculateScore().Sum();

Console.WriteLine(score);

// PART 2

var score2 = lines.CalculateScorePart2().Sum();

Console.WriteLine(score2);

static class IEnumerableExtensions
{
    public static IEnumerable<int> CalculateScore(this IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var opponentChoose = line[0]-'A'+1;
            var meChoose = line[2]-'X'+1;

            yield return meChoose + scoreTable[opponentChoose-1,meChoose-1];
        }
    }

    static int[,] scoreTable = new int[3, 3] {
        { 3, 6, 0 },
        { 0, 3, 6 },
        { 6, 0, 3 },
    };

    public static IEnumerable<int> CalculateScorePart2(this IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var opponentChoose = line[0] - 'A' + 1;
            var roundResult = (line[2] - 'X') * 3;

            yield return roundResult + meChooseTable[opponentChoose-1, roundResult/3];
        }
    }

    static int[,] meChooseTable = new int[3, 3] {
        { 3, 1, 2 },
        { 1, 2, 3 },
        { 2, 3, 1 },
    };
}