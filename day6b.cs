var input = File.ReadAllLines("6.txt")
    .Select(line => line.ToCharArray())
    .ToArray();

var rowLength = input[0].Length;
var columnLength = input.Length;

var rotated = new char[rowLength][];
for (var i = 0; i < rowLength; i++)
{
    rotated[i] = new char[columnLength];
}

for (var row = 0; row < columnLength; row++)
{
    for (var column = 0; column < rowLength; column++)
    {
        rotated[column][row] = input[row][column];
    }
}

var concatenated = rotated
    .Select(chars => new string(chars))
    .ToList();

concatenated.Add(string.Empty);

var total = 0L;
var @operator = ' ';
var operands = new List<long>();
foreach (var line in concatenated)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        if (@operator == '+')
        {
            total += operands.Sum();
        }

        if (@operator == '*')
        {
            total += operands.Aggregate(1L, (acc, val) => acc * val);
        }

        operands.Clear();
        @operator = ' ';
        continue;
    }

    if (line.Contains('*'))
    {
        @operator = '*';
    }

    if (line.Contains('+'))
    {
        @operator = '+';
    }

    operands.Add(long.Parse(line.Replace('*', ' ')
        .Replace('+', ' ')));
}


Console.WriteLine(total);
