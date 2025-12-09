var pairs = File.ReadAllText("2.txt").Split(',');

var sum = 0L;

foreach (var pair in pairs)
{
    var parts = pair.Split('-');
    var start = long.Parse(parts[0]);
    var end = long.Parse(parts[1]);

    var startString = start.ToString();
    var even = startString.Length % 2 == 0;
    var iStart = even
        ? long.Parse(startString[..(startString.Length / 2)])
        : (long)Math.Pow(10, startString.Length / 2);

    var val = long.Parse(iStart.ToString() + iStart.ToString());
    while (val < start)
    {
        iStart++;
        val = long.Parse(iStart.ToString() + iStart.ToString());
    }

    while (val <= end)
    {
        sum += val;
        iStart++;
        val = long.Parse(iStart.ToString() + iStart.ToString());
    }
}

Console.WriteLine(sum);
