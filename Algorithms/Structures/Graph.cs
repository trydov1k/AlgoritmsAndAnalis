namespace Algorithms.Structures;

public class Graph
{
    private readonly List<GraphEdge> _edges = new();
    private readonly Dictionary<string, GraphNode> _nodes = new();

    public Graph(bool directed)
    {
        Directed = directed;
    }

    public bool Directed { get; }

    public IEnumerable<GraphEdge> Edges => _edges;
    public IEnumerable<GraphNode> Nodes => _nodes.Values;

    public GraphNode AddNode(string name)
    {
        if (!_nodes.TryGetValue(name, out var result))
            _nodes.Add(name, result = new GraphNode(name));
        return result;
    }

    public GraphEdge AddEdge(string sourceNodeName, string destinationNodeName, double weight = 1)
    {
        if (!_nodes.TryGetValue(sourceNodeName, out var sourceNode))
            throw new ArgumentException($"Node {sourceNodeName} not found");
        
        if (!_nodes.TryGetValue(destinationNodeName, out var destinationNode))
            throw new ArgumentException($"Node {destinationNodeName} not found");
        
        sourceNode.Neighbours.Add(destinationNode);
        
        if (!Directed)
            destinationNode.Neighbours.Add(sourceNode);
        
        var result = new GraphEdge(sourceNode, destinationNode, weight);
        _edges.Add(result);
        return result;
    }

    public IEnumerable<GraphNode> BreadthFirstSearch(string startNodeName)
    {
        if (!_nodes.TryGetValue(startNodeName, out var startNode))
            throw new ArgumentException($"Node {startNodeName} not found");
        
        var queue = new Queue<GraphNode>();
        var visited = new HashSet<GraphNode>();
        
        queue.Enqueue(startNode);
        visited.Add(startNode);

        while (!queue.IsEmpty())
        {
            var node = queue.Dequeue();

            yield return node;

            foreach (var neighbour in node.Neighbours)
            {
                if (visited.Add(neighbour))  // true, если еще не посещали, false, если уже посетили
                    queue.Enqueue(neighbour);
            }
        }
    }

    public IEnumerable<GraphNode> DepthFirstSearch(string startNodeName)
    {
        if (!_nodes.TryGetValue(startNodeName, out var startNode))
            throw new ArgumentException($"Node {startNodeName} not found");
        
        var visited = new HashSet<GraphNode>();
        var stack = new Stack<GraphNode>();
        
        stack.Push(startNode);
        visited.Add(startNode);

        while (stack.Count != 0)
        {
            var node = stack.Pop();
            
            yield return node;

            foreach (var neighbour in node.Neighbours.GetReversed())
            {
                if (visited.Add(neighbour))
                    stack.Push(neighbour);
            }
        }
    }
    
    public (GraphNode[] Nodes, bool[,] Matrix) GetAdjacencyMatrix()
    {
        var nodes = _nodes.Values.ToArray();
        var indices = new Dictionary<GraphNode, int>();  // Node: index

        for (var i = 0; i < nodes.Length; i++)
            indices.Add(nodes[i], i);

        var matrix = new bool[nodes.Length, nodes.Length];

        foreach (var edge in _edges)
        {
            var source = indices[edge.SourceNode];
            var destination = indices[edge.DestinationNode];

            matrix[source, destination] = true;

            if (!Directed)
                matrix[destination, source] = true;
        }

        return (nodes, matrix);
    }

    public Graph GetMinimumSpanningTree()  // используем алгоритм Прима
    {
        if (Directed)
            throw new InvalidOperationException(
                "Граф должен быть неориентированным.");

        var tree = new Graph(false);
        var visited = new HashSet<GraphNode>();

        if (_nodes.Count == 0)
            return tree;

        var start = _nodes.Values.First();

        tree.AddNode(start.Name);
        visited.Add(start);

        while (visited.Count < _nodes.Count)
        {
            GraphEdge? cheapestEdge = null;

            foreach (var edge in _edges)
            {
                var sourceVisited = visited.Contains(edge.SourceNode);
                var destinationVisited = visited.Contains(edge.DestinationNode);

                // Нужны рёбра, у которых ровно один конец уже в дереве.
                if (sourceVisited == destinationVisited)
                    continue;

                if (cheapestEdge is null ||
                    edge.Weight < cheapestEdge.Weight)
                {
                    cheapestEdge = edge;
                }
            }

            if (cheapestEdge is null)
                throw new InvalidOperationException(
                    "Граф несвязный: остовного дерева не существует.");

            // Выбираем ещё не добавленный конец ребра.
            var newNode = visited.Contains(cheapestEdge.SourceNode)
                ? cheapestEdge.DestinationNode
                : cheapestEdge.SourceNode;

            visited.Add(newNode);
            tree.AddNode(newNode.Name);

            tree.AddEdge(
                cheapestEdge.SourceNode.Name,
                cheapestEdge.DestinationNode.Name,
                cheapestEdge.Weight);
        }

        return tree;
    }
}

public class GraphEdge
{
    public GraphEdge(GraphNode sourceNode, GraphNode destinationNode, double weight)
    {
        SourceNode = sourceNode;
        DestinationNode = destinationNode;
        Weight = weight;
    }

    public GraphNode DestinationNode { get; }
    public GraphNode SourceNode { get; }
    public double Weight { get; }
}

public class GraphNode
{
    public GraphNode(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public List<GraphNode> Neighbours { get; } = [];
}

public static class GraphExtensions
{
    public static IEnumerable<GraphNode> GetReversed(this List<GraphNode> nodes)
    {
        for (var i = nodes.Count - 1; i >= 0; i--)
            yield return nodes[i];
    }

    public static void AddNodesFromAToB(this Graph graph, char a, char b)
    {
        for (var i = (int)a; i <= (int)b; i++)
        {
            graph.AddNode(((char)i).ToString());
        }
    }
}