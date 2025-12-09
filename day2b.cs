var pairs = File.ReadAllText("2.txt")
    .Split(',')
    .Select(pair => pair.Split('-'))
    .Select(parts => (start: long.Parse(parts[0]), end: long.Parse(parts[1])))
    .ToArray();

var max = pairs.Max(p => p.end);
var maxLength = max.ToString().Length;
var sequenceLengthMax = maxLength / 2;

var values = new List<long>();

for (var sequenceLength = 1; sequenceLength <= sequenceLengthMax; sequenceLength++)
{
    var iStart = (long)Math.Pow(10, sequenceLength - 1);
    var iEnd = (long)Math.Pow(10, sequenceLength) - 1;

    while (iStart <= iEnd)
    {
        var valString = iStart.ToString() + iStart.ToString();
        var val = long.Parse(valString);
        while (val <= max)
        {
            if (pairs.Any(p => val >= p.start && val <= p.end))
            {
                values.Add(val);
            }

            valString += iStart.ToString();
            val = long.Parse(valString);
        }

        iStart++;
    }
}

var sum = values.Distinct().Sum();

Console.WriteLine(sum);
