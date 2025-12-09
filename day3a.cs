var batteries = File.ReadAllLines("3.txt")
    .Select(line => line.Select(c => c - '0').ToArray())
    .ToArray();

var sum = 0;

foreach (var battery in batteries)
{
    var max = battery.SkipLast(1).Max();
    var indexOfMax = Array.IndexOf(battery, max);
    var max2 = battery.Skip(indexOfMax + 1).Max();
    sum += max * 10 + max2;
}

Console.WriteLine(sum);
