var junctions = File.ReadAllLines("8a.input")
    .Select(line => line.Split(","))
    .Select(parts => new Coordinate(
        X: int.Parse(parts[0]),
        Y: int.Parse(parts[1]),
        Z: int.Parse(parts[2])))
    .ToList();

var connections = junctions
    .SelectMany(j1 => junctions.Where(j2 => j1 != j2)
        .Select(j2 => new Connection(
            From: j1,
            To: j2,
            Distance: Math.Sqrt(
                Math.Pow(j1.X - j2.X, 2) +
                Math.Pow(j1.Y - j2.Y, 2) +
                Math.Pow(j1.Z - j2.Z, 2)))))
    .OrderBy(d => d.Distance)
    .ToList();

var circuits = new List<List<Coordinate>>();

foreach (var connection in connections)
{
    List<Coordinate> fromCircuit = null;
    List<Coordinate> toCircuit = null;
    foreach (var circuit in circuits)
    {
        if (circuit.Contains(connection.From))
        {
            fromCircuit = circuit;
        }

        if (circuit.Contains(connection.To))
        {
            toCircuit = circuit;
        }
    }

    if (fromCircuit != null && fromCircuit == toCircuit)
    {
        continue;
    }

    if (fromCircuit != null && toCircuit != null)
    {
        fromCircuit.AddRange(toCircuit);
        circuits.Remove(toCircuit);
        if (circuits.Count() == 1)
        {
            if (junctions.All(j => circuits[0].Contains(j)))
            {
                var answer = connection.From.X * connection.To.X;
                Console.WriteLine($"Answer: {answer}");
                break;
            }
        }

        continue;
    }

    if (fromCircuit != null)
    {
        fromCircuit.Add(connection.To);
        if (circuits.Count() == 1)
        {
            if (junctions.All(j => circuits[0].Contains(j)))
            {
                var answer = connection.From.X * connection.To.X;
                Console.WriteLine($"Answer: {answer}");
                break;
            }
        }
        
        continue;
    }

    if (toCircuit != null)
    {
        toCircuit.Add(connection.From);
        if (circuits.Count() == 1)
        {
            if (junctions.All(j => circuits[0].Contains(j)))
            {
                var answer = connection.From.X * connection.To.X;
                Console.WriteLine($"Answer: {answer}");
                break;
            }
        }
        continue;
    }

    circuits.Add(new List<Coordinate>() { connection.From, connection.To });
}

record Coordinate(int X, int Y, int Z);
record Connection(Coordinate From, Coordinate To, double Distance);
