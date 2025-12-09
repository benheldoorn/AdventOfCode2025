var ranges = File.ReadAllLines("5.txt")
    .TakeWhile(line => !string.IsNullOrWhiteSpace(line))
    .Select(line => line.Split("-"))
    .Select(parts => new RangeType() { Start = long.Parse(parts[0]), End = long.Parse(parts[1]) })
    .ToList();

var newRanges = new List<RangeType>(ranges.Count);

var repeat = true;
while (repeat)
{
    repeat = false;
    foreach (var oldRange in ranges)
    {
        bool isOverlapping = false;
        foreach (var newRange in newRanges)
        {
            if (oldRange.Start >= newRange.Start && oldRange.End <= newRange.End)
            {
                isOverlapping = true;
                break;
            }

            if (oldRange.Start >= newRange.Start && oldRange.Start <= newRange.End)
            {
                newRange.End = oldRange.End;
                isOverlapping = true;
                break;
            }

            if (oldRange.End >= newRange.Start && oldRange.End <= newRange.End)
            {
                newRange.Start = oldRange.Start;
                isOverlapping = true;
                break;
            }

            if (oldRange.Start < newRange.Start && oldRange.End > newRange.End)
            {
                newRange.Start = oldRange.Start;
                newRange.End = oldRange.End;
                isOverlapping = true;
                break;
            }
        }

        if (!isOverlapping)
        {
            newRanges.Add(oldRange);
        }
        else
        {
            repeat = true;
        }
    }

    if (repeat)
    {
        ranges.Clear();
        ranges.AddRange(newRanges);
        newRanges.Clear();
    }
}

var answer = newRanges.Select(ranges => ranges.End - ranges.Start + 1).Sum();

Console.WriteLine(answer);

class RangeType
{
    public long Start;
    public long End;
}
