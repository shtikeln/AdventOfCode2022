var lines = File.ReadLines("input.txt");

int sumOfPriorities = 0;

bool[] buffer;

foreach (var line in lines)
{
    buffer = new bool[52];
    int indexHalf = line.Length / 2;
    var first = line[0..(indexHalf)];
    var second = line[indexHalf..];

    foreach (var firstChar in first)
    {
        foreach (var secondChar in second)
        {
            var priority = firstChar <= 'Z' ? (firstChar - 'A') + 27 : (firstChar - 'a' + 1);
            if (firstChar == secondChar && !buffer[priority - 1])
            {
                buffer[priority - 1] = true;
                sumOfPriorities += priority;
            }
        }
    }
}

Console.WriteLine(sumOfPriorities);

// PART 2

sumOfPriorities= 0;
var linesArray = lines.ToArray();
for (var groupIndex = 0; groupIndex < linesArray.Length -1; groupIndex += 3)
{
    buffer = new bool[52];
    var first = linesArray[groupIndex];
    var second = linesArray[groupIndex+1];
    var third = linesArray[groupIndex+2];

    foreach (var firstChar in first)
    {
        foreach (var secondChar in second)
        {
            foreach (var thirdChar in third)
            {
                var priority = firstChar <= 'Z' ? (firstChar - 'A') + 27 : (firstChar - 'a' + 1);
                if (firstChar == secondChar && thirdChar == secondChar && !buffer[priority - 1])
                {
                    buffer[priority - 1] = true;
                    sumOfPriorities += priority;
                }
            }                
        }
    }
}

Console.WriteLine(sumOfPriorities);