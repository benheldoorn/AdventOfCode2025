var input = File.ReadAllLines("6.txt");

var operands = input[..^1]
    .Select(line => line
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList())
    .ToList();

var operaters = input[^1]
    .Where(c => c == '+' || c == '*')
    .ToList();

long total = 0;

for (var i = 0; i < operaters.Count; i++)
{
    var @operator = operaters[i];
    long result = @operator == '*' ? 1 : 0;

    for (var j = 0; j < operands.Count; j++)
    {
        var operand = operands[j][i];
        
        if (@operator == '+')
        {
            result += operand;
        }

        if (@operator == '*')
        {
            result *= operand;
        }
    }

    total += result;
}

Console.WriteLine(total);
