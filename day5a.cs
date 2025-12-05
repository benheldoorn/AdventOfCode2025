var ranges = File.ReadAllLines("5a.input")
    .TakeWhile(line => !string.IsNullOrWhiteSpace(line))
    .Select(line => line.Split("-"))
    .Select(parts => (Start: long.Parse(parts[0]), End: long.Parse(parts[1])))
    .ToList();

var ids = File.ReadAllLines("5a.input")
    .SkipWhile(line => !string.IsNullOrWhiteSpace(line))
    .Skip(1)
    .Select(line => long.Parse(line))
    .ToHashSet();

var count = ids.Count(id => ranges.Any(range => id >= range.Start && id <= range.End)); 

Console.WriteLine(count);