namespace Algorithms.Structures;

public class Stack<T>
{
    private readonly List<T> _items = [];
    private int Count => _items.Count;

    public void Push(T item)
    {
        _items.Add(item);
    }

    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty");
        
        var item = _items[Count - 1];
            
        _items.RemoveAt(Count - 1);
        
        return item;
    }

    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty");
        
        return _items[Count - 1];
    }
}