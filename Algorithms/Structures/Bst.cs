namespace Algorithms.Structures;

public sealed class Node<T>(T value)
{
    public T Value { get; set; } = value;
    public Node<T>? Left { get; set; }
    public Node<T>? Right { get; set; }

    public override string ToString()
    {
        return $"Val:{Value?.ToString()}, Lt:{Left?.Value?.ToString()}, Rt:{Right?.Value?.ToString()}";
    }
}

public class Bst<T> where T : IComparable<T>
{
    private Node<T>? _root;

    public Node<T> Search(T value)
    {
        return Search(_root, value);
    }

    private static Node<T> Search(Node<T>? node, T value)
    {
        if (node == null)
            throw new KeyNotFoundException();

        var compered = value.CompareTo(node.Value);

        return compered switch
        {
            0 => node,
            -1 => Search(node.Left, value),
            _ => Search(node.Right, value)
        };
    }

    public void Add(T value)
    {
        _root = Add(_root, value);
    }

    private static Node<T> Add(Node<T>? node, T value)
    {
        if (node == null)
            return new Node<T>(value);
        var compered = value.CompareTo(node.Value);

        switch (compered)
        {
            case -1:
                node.Left = Add(node.Left, value);
                break;
            case 1:
                node.Right = Add(node.Right, value);
                break;
        }

        return node;
    }

    public void Remove(T value)
    {
        _root = Remove(_root, value);
    }

    private static Node<T>? Remove(Node<T>? node, T value)
    {
        if (node == null)
            return null;
        var compered = value.CompareTo(node.Value);

        switch (compered)
        {
            case -1:
                node.Left = Remove(node.Left, value);
                break;
            case 1:
                node.Right = Remove(node.Right, value);
                break;
            default:
            {
                if (node.Left == null)
                    return node.Right;
                if (node.Right == null)
                    return node.Left;
                var succ = MinNode(node.Right);
                node.Value = succ.Value;
                node.Right = Remove(node.Right, succ.Value);
                break;
            }
        }

        return node;
    }

    public Node<T>? MinNode()
    {
        return MinNode(_root);
    }

    private static Node<T>? MinNode(Node<T>? node)
    {
        var temp = node;
        while (temp?.Left != null)
            temp = temp.Left;
        return temp;
    }

    public int Height()
    {
        return Height(_root);
    }

    private static int Height(Node<T>? node)
    {
        if (node == null)
            return -1;
        return Math.Max(Height(node.Left), Height(node.Right)) + 1;
    }
}