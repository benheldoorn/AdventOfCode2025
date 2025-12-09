var lines = File.ReadAllLines("1.txt");

int count = 0;
var dail = 50;

foreach (var line in lines)
{
    var ticks = int.Parse(line[1..]);
    dail += line[0] == 'R' ? ticks : -ticks;

    while (dail < 0)
    {
        dail += 100;
    }

    while (dail >= 100)
    {
        dail -= 100;
    }

    if (dail == 0)
    {
        count++;
    }
}

Console.WriteLine(count);
