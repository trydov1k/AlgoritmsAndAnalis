using Algorithms.Structures;

namespace Tests.StructuresTests;

public class HashTableChainingTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_NonPositiveCapacity_Throws(int capacity)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new HashTableChaining<int, string>(capacity));
    }

    [Fact]
    public void NewTable_IsEmpty()
    {
        var table = new HashTableChaining<int, string>(4);

        Assert.Equal(0, table.Size());
        Assert.False(table.ContainsKey(1));
    }

    [Fact]
    public void Put_NewKey_StoresValue()
    {
        var table = new HashTableChaining<int, string>(4);

        table.Put(1, "one");

        Assert.Equal("one", table.Get(1));
        Assert.True(table.ContainsKey(1));
        Assert.Equal(1, table.Size());
    }

    [Fact]
    public void Put_ExistingKey_UpdatesValueWithoutChangingSize()
    {
        var table = new HashTableChaining<int, string>(4);

        table.Put(1, "old");
        table.Put(1, "new");

        Assert.Equal("new", table.Get(1));
        Assert.Equal(1, table.Size());
    }

    [Fact]
    public void MissingKey_GetAndRemoveThrow_ContainsKeyReturnsFalse()
    {
        var table = new HashTableChaining<int, string>(4);
        table.Put(1, "one");

        Assert.Throws<KeyNotFoundException>(() => table.Get(2));
        Assert.Throws<KeyNotFoundException>(() => table.Remove(2));
        Assert.False(table.ContainsKey(2));
        Assert.Equal(1, table.Size());
        Assert.Equal("one", table.Get(1));
    }

    [Fact]
    public void Collisions_AllValuesRemainAccessible()
    {
        var table = new HashTableChaining<CollisionKey, string>(16);

        for (var i = 0; i < 5; i++)
            table.Put(new CollisionKey(i), $"value-{i}");

        for (var i = 0; i < 5; i++)
        {
            Assert.Equal($"value-{i}", table.Get(new CollisionKey(i)));
            Assert.True(table.ContainsKey(new CollisionKey(i)));
        }

        Assert.False(table.ContainsKey(new CollisionKey(99)));
        Assert.Equal(5, table.Size());
    }

    [Fact]
    public void Put_ExistingKeyInsideChain_UpdatesOnlyThatValue()
    {
        var table = new HashTableChaining<CollisionKey, string>(16);
        table.Put(new CollisionKey(1), "one");
        table.Put(new CollisionKey(2), "two");
        table.Put(new CollisionKey(3), "three");

        table.Put(new CollisionKey(2), "updated");

        Assert.Equal("one", table.Get(new CollisionKey(1)));
        Assert.Equal("updated", table.Get(new CollisionKey(2)));
        Assert.Equal("three", table.Get(new CollisionKey(3)));
        Assert.Equal(3, table.Size());
    }

    [Theory]
    [InlineData(3)] // Голова цепочки
    [InlineData(2)] // Середина
    [InlineData(1)] // Конец
    public void Remove_FromChain_PreservesOtherElements(int removedId)
    {
        var table = new HashTableChaining<CollisionKey, string>(16);
        for (var i = 1; i <= 3; i++)
            table.Put(new CollisionKey(i), $"value-{i}");

        var removedValue = table.Remove(new CollisionKey(removedId));

        Assert.Equal($"value-{removedId}", removedValue);
        Assert.Equal(2, table.Size());
        Assert.False(table.ContainsKey(new CollisionKey(removedId)));
        Assert.Throws<KeyNotFoundException>(() => table.Get(new CollisionKey(removedId)));

        for (var i = 1; i <= 3; i++)
            if (i != removedId)
                Assert.Equal($"value-{i}", table.Get(new CollisionKey(i)));
    }

    [Fact]
    public void Remove_OnlyElement_LeavesTableReusable()
    {
        var table = new HashTableChaining<int, string>(4);
        table.Put(1, "one");

        Assert.Equal("one", table.Remove(1));
        Assert.Equal(0, table.Size());
        Assert.False(table.ContainsKey(1));
        Assert.Throws<KeyNotFoundException>(() => table.Remove(1));

        table.Put(1, "new");

        Assert.Equal("new", table.Get(1));
        Assert.Equal(1, table.Size());
    }

    [Fact]
    public void Put_ManyKeys_PreservesValuesAfterResizing()
    {
        var table = new HashTableChaining<int, string>(1);

        for (var i = 0; i < 100; i++)
            table.Put(i, $"value-{i}");

        Assert.Equal(100, table.Size());

        for (var i = 0; i < 100; i++)
            Assert.Equal($"value-{i}", table.Get(i));

        for (var i = 0; i < 100; i += 2)
            Assert.Equal($"value-{i}", table.Remove(i));

        Assert.Equal(50, table.Size());

        for (var i = 0; i < 100; i++)
        {
            Assert.Equal(i % 2 != 0, table.ContainsKey(i));
            if (i % 2 != 0)
                Assert.Equal($"value-{i}", table.Get(i));
        }
    }

    [Fact]
    public void Resize_WithCollisions_PreservesEntireChain()
    {
        var table = new HashTableChaining<CollisionKey, int>(2);

        for (var i = 0; i < 50; i++)
            table.Put(new CollisionKey(i), i * 10);

        Assert.Equal(50, table.Size());

        for (var i = 0; i < 50; i++)
            Assert.Equal(i * 10, table.Get(new CollisionKey(i)));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void NegativeHashCode_OperationsWork(int hashCode)
    {
        var table = new HashTableChaining<FixedHashKey, string>(4);
        var key = new FixedHashKey(1, hashCode);

        table.Put(key, "value");

        Assert.Equal("value", table.Get(key));
        Assert.True(table.ContainsKey(key));
        Assert.Equal("value", table.Remove(key));
        Assert.Equal(0, table.Size());
    }

    [Fact]
    public void NullValue_KeyStillExists()
    {
        var table = new HashTableChaining<int, string?>(4);

        table.Put(1, null);

        Assert.True(table.ContainsKey(1));
        Assert.Null(table.Get(1));
        Assert.Equal(1, table.Size());

        Assert.Null(table.Remove(1));
        Assert.False(table.ContainsKey(1));
        Assert.Equal(0, table.Size());
    }

    private sealed class CollisionKey(int id)
    {
        private int Id => id;

        public override int GetHashCode()
        {
            return 1;
        }

        public override bool Equals(object? obj)
        {
            return obj is CollisionKey other && id == other.Id;
        }
    }

    private sealed record FixedHashKey(int Id, int Hash)
    {
        public override int GetHashCode()
        {
            return Hash;
        }
    }
}