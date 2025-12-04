var map = System.IO.File.ReadAllLines("4a.input")
    .Select(line => line.Select(c => c == '@').ToArray())
    .ToArray();

var directions = new (int dx, int dy)[] { (0, -1), (0, 1), (-1, 0), (1, 0), (-1, -1), (1, -1), (-1, 1), (1, 1) };

var maxX = map[0].Length;
var maxY = map.Length;

bool get(int x, int y)
{
    return (x >= 0 && x < maxX && y >= 0 && y < maxY) ? map[y][x] : false;
}

var count = 0;
var queue = new List<(int x, int y)>();
var repeat = true;
while (repeat)
{
    repeat = false;
    queue.Clear();
    for (int y = 0; y < maxY; y++)
    {
        for (int x = 0; x < maxX; x++)
        {
            var free = directions.Count(d => !get(x + d.dx, y + d.dy));
            if (free > 4 && get(x, y))
            {
                queue.Add((x, y));
                repeat = true;
                count++;
            }
        }
    }

    foreach (var (x, y) in queue)
    {
        map[y][x] = false;
    }
}

System.Console.WriteLine(count);
