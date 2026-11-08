namespace Algorithms.Structures;

// Первый вошёл, первый вышел
public class Queue<T>
{
    private Node<T>? Head { get; set; } // голова (начало)
    private Node<T>? Tail { get; set; } // хвост (конец)

    public void Enqueue(T item)
    {
        if (Head == null)
        {
            Head = new Node<T> { Value = item, Next = null };
            Tail = Head;
        }
        else
        {
            var newNode = new Node<T> { Value = item, Next = null };
            Tail?.Next = newNode;
            Tail = newNode;
        }
    }

    public T Dequeue()
    {
        if (Head == null)
            throw new InvalidOperationException("Queue is empty");

        var node = Head;
        Head = Head.Next;

        if (Head == null)
            Tail = null;

        return node.Value;
    }

    public T Peek()
    {
        if (Head == null)
            throw new InvalidOperationException("Queue is empty");

        return Head.Value;
    }
    
    public bool IsEmpty() 
        => Head == null;

    private class Node<T>
    {
        public T? Value { get; set; }
        public Node<T>? Next { get; set; }
    }
}