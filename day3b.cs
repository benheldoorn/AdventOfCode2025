var batteries = File.ReadAllLines("3a.input")
    .Select(line => line.Select(c => c - '0').ToArray())
    .ToArray();

var total = 0L;

foreach (var battery in batteries)
{
    var sum = 0L;
    var indexOfMax = -1;
    for (int i = 1; i <= 12; i++)
    {
        var skip = indexOfMax + 1;
        var max = battery.Skip(skip).SkipLast(12 - i).Max();
        indexOfMax = Array.IndexOf([.. battery.Skip(skip)], max) + skip;
        sum = sum * 10 + max;
    }

    total += sum;
}

Console.WriteLine(total);