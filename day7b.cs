var input = File.ReadAllLines("7a.input");

var beams = input[0].ToCharArray().Select(c => c == 'S' ? 1L : 0).ToArray();

var tachyon = input.Select(line => line.ToCharArray().Select(c => c == '^').ToArray()).ToArray();

var timelines = 1L;

foreach (var row in tachyon)
{
    for (var col = 0; col < row.Length; col++)
    {
        if (row[col] && beams[col] > 0)
        {
            timelines += beams[col];
            beams[col - 1] += beams[col];
            beams[col + 1] += beams[col];
            beams[col] = 0;
        }
    }
}

Console.WriteLine(timelines);