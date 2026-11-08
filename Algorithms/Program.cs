using Algorithms.Structures;

namespace Algorithms;

public class Program
{
    public static void Main(string[] args)
    {
        var directedGraph = CreateDirectedGraph();
        /*        A
         *       / \
         *      B   E
         *     / \
         *    C   D
         */
        
        PrintBFS(directedGraph);
        
        PrintDFS(directedGraph);
            
        PrintAdjacencyMatrix(directedGraph);

        var undirectedGraph = CreateUndirectedGraph();
        
        /*        A
         *       / \
         *      B - C
         *       \ /
         *        D
         */

        PrintMinimumSpanningTree(undirectedGraph);
    }

    private static Graph CreateDirectedGraph()
    {
        var directedGraph = new Graph(true);

        directedGraph.AddNodesFromAToB('A', 'E');

        directedGraph.AddEdge("A", "B");
        directedGraph.AddEdge("A", "E");
        directedGraph.AddEdge("B", "C");
        directedGraph.AddEdge("B", "D");
        
        /*        A
         *       / \
         *      B   E
         *     / \
         *    C   D
         */
        
        return directedGraph;
    }

    private static Graph CreateUndirectedGraph()
    {
        var undirectedGraph = new Graph(false);
        undirectedGraph.AddNodesFromAToB('A', 'D');
        undirectedGraph.AddEdge("A", "B", 3);
        undirectedGraph.AddEdge("A", "C", 1);
        undirectedGraph.AddEdge("B", "C", 2);
        undirectedGraph.AddEdge("B", "D", 4);
        undirectedGraph.AddEdge("C", "D", 6);
        
        /*        A
         *       / \
         *      B - C
         *       \ /
         *        D
         */
        
        return undirectedGraph;
    }

    private static void PrintBFS(Graph graph)
    {
        var bfs = graph.BreadthFirstSearch("A")
            .ToList().Select(node => node.Name);
        Console.WriteLine("BFS: " + string.Join(", ", bfs));
        Console.WriteLine();
    }
    
    private static void PrintDFS(Graph graph)
    {
        var dfs = graph.DepthFirstSearch("A")
            .ToList().Select(node => node.Name);
        Console.WriteLine("DFS: " + string.Join(", ", dfs));
        Console.WriteLine();
    }

    private static void PrintAdjacencyMatrix(Graph graph)
    {
        var (nodes, matrix) = graph.GetAdjacencyMatrix();
        Console.WriteLine("  " + string.Join(' ', nodes.Select(n => n.Name)));
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            var line = Enumerable.Range(0, matrix.GetLength(0)).Select(y => matrix[i, y]).Select(b => b ? 1 : 0).ToArray();
            Console.WriteLine(nodes[i].Name + " " + string.Join(' ', line));
        }

        Console.WriteLine();
    }

    private static void PrintMinimumSpanningTree(Graph graph)
    {
        var tree = graph.GetMinimumSpanningTree();

        foreach (var edge in tree.Edges)
            Console.WriteLine($"{edge.SourceNode.Name} — {edge.DestinationNode.Name}");
        
        Console.WriteLine();
    }
}