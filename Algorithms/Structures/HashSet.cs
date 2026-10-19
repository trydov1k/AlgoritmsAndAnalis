namespace Algorithms.Structures;

public class HashSet<TValue>
where TValue : notnull
{
    private readonly HashTableChaining<TValue, bool> _table = new(16);

    public bool Add(TValue value)
    {
        if (_table.ContainsKey(value))
            return false;
        
        _table.Put(value, true);
        return true;
    }

    public bool Remove(TValue value)
    {
        if (!_table.ContainsKey(value))
            return false;
        _table.Remove(value);
        return true;
    }
    
    public bool Contains(TValue item) => _table.ContainsKey(item);

    public int Count => _table.Size();
    public TValue[] ToArray() => _table.GetKeys().ToArray();
}