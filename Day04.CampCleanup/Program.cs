var lines = File.ReadLines("input.txt");

int assignments = 0;
// PART 2
int overlap = 0;

foreach (var line in lines)
{
    var pairs = line.Split(',')
        .Select(s => s.Split('-'))
        .Select(s => (int.Parse(s[0]), int.Parse(s[1])))
        .ToArray();

    var joinedPair = pairs
        .Select(x => new int[] { x.Item1, x.Item2 })
        .SelectMany(x => x);

    var minSection = joinedPair.Min();
    var maxSection = joinedPair.Max();

    if ((pairs[0].Item1 == minSection && pairs[0].Item2 == maxSection)
        || (pairs[1].Item1 == minSection && pairs[1].Item2 == maxSection))
    {
        assignments++;
    }
    // PART 2
    if (pairs[0].GetRange().Intersect(pairs[1].GetRange()).Any())
    {
        overlap++;
    }
}

Console.WriteLine(assignments);
// PART 2
Console.WriteLine(overlap);

static class Extensions
{
    public static IEnumerable<int> GetRange(this (int x, int y) pair)
    {
        return Enumerable.Range(pair.x, pair.y - pair.x + 1);
    }
}