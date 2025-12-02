var lines = System.IO.File.ReadAllLines("1a.input");
int count = 0;
var dail = 50;
foreach (var line in lines)
{
    bool startFromZero = dail == 0;
    var ticks = int.Parse(line[1..]);
    dail += line[0] == 'R' ? ticks : -ticks;

    if (startFromZero && dail < 0)
    {
        count--;
    }

    while (dail < 0)
    {
        dail += 100;
        count++;
    }

    if (dail == 0) count++;

    while (dail >= 100)
    {
        dail -= 100;
        count++;
    }
}

System.Console.WriteLine(count);