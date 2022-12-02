var lines = File.ReadLines("input.txt");

var maxCallories = lines
    .CalculateCallories()
    .Max();

Console.WriteLine(maxCallories);

// PART 2
var top3Sum = lines
    .CalculateCallories()
    .OrderDescending()
    .Take(3)
    .Sum();

Console.WriteLine(top3Sum);

static class IEnumerableExtensions
{
    public static IEnumerable<int> CalculateCallories(this IEnumerable<string> lines)
    {
        var currentElfCallories = 0;
        foreach (var line in lines)
        {
            if (int.TryParse(line, out int currentCallory))
            {
                currentElfCallories += currentCallory;
                continue;
            }
            int result = currentElfCallories;
            currentElfCallories = 0;
            yield return result;
        }
    }
}