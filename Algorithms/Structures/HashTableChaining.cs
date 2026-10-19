namespace Algorithms.Structures;

/// <summary>
/// Хеш-таблица по методу цепочек
/// </summary>
public class HashTableChaining<TKey, TValue>
    where TKey : notnull
{
    private sealed class Node(TKey key, TValue value, Node? next)
    {
        public TKey Key { get; } = key;
        public TValue Value { get; set; } = value;
        public Node? Next { get; set; } = next;
    }

    private const double MaxLoadFactor = 0.75;

    private Node?[] _table;
    private int _currentSize;

    public HashTableChaining(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);
        _table = new Node[capacity];
    }
    
    private int GetHash(TKey key)
    {
        ArgumentNullException.ThrowIfNull(key);
        return (key.GetHashCode() & 0x7FFFFFFF) % _table.Length;
    }

    public TValue Get(TKey key)
    {
        var node = _table[GetHash(key)];
        while (node is not null)
        {
            if (node.Key.Equals(key))
                return node.Value;
            node = node.Next;
        }
        throw new KeyNotFoundException($"Key {key} not found");
    }

    public void Put(TKey key, TValue value)
    {
        var index = GetHash(key);
        var node = _table[index];
        while (node is not null)
        {
            if (node.Key.Equals(key))
            {
                node.Value = value;
                return;
            }
            node = node.Next;
        }
        _table[index] = new Node(key, value, _table[index]);

        _currentSize++;
        if (_currentSize >= _table.Length * MaxLoadFactor)
            Resize(2 * _table.Length);
    }

    private void Resize(int newSize)
    {
        var oldTable = _table;
        _table = new Node[newSize];
        _currentSize = 0;
        foreach (var node in oldTable)
        {
            var tmpNode = node;
            while (tmpNode is not null)
            {
                Put(tmpNode.Key, tmpNode.Value);
                tmpNode = tmpNode.Next;
            }
        }
    }

    public TValue Remove(TKey key)
    {
        var index = GetHash(key);
        Node? previous = null;
        Node? current = _table[index];
        while (current is not null)
        {
            if (current.Key.Equals(key))
            {
                if (previous is null)
                    _table[index] = current.Next;
                else
                    previous.Next = current.Next;
                _currentSize--;
                return current.Value;
            }
            previous = current;
            current = current.Next;
        }
        throw new KeyNotFoundException($"Key {key} not found");
    }
    
    public int Size()
        =>  _currentSize;

    public bool ContainsKey(TKey key)
    {
        var node = _table[GetHash(key)];
        while (node is not null)
        {
            if (node.Key.Equals(key))
                return true;
            node = node.Next;
        }
        return false;
    }
}