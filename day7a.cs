var input = File.ReadAllLines("7.txt");

var beams = input[0].ToCharArray().Select(c => c == 'S').ToArray();

var tachyon = input[1..].Select(line => line.ToCharArray().Select(c => c == '^').ToArray()).ToArray();

var splits = 0;

foreach (var row in tachyon)
{
    for (var col = 0; col < row.Length; col++)
    {
        if (row[col] && beams[col])
        {
            splits++;
            beams[col - 1] = true;
            beams[col + 1] = true;
            beams[col] = false;
        }
    }
}

Console.WriteLine(splits);
