namespace Algorithms.Structures;

public class BinaryHeap
{
    private int[] _array;
    private int _pointer;

    public BinaryHeap(int size)
    {
        _array = new int[size];
        _pointer = 0;
    }

    public void Insert(int value)
    {
        if (_pointer >= _array.Length)
        {
            var newArray = new int[_array.Length * 2];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }

        _array[_pointer] = value;
        _pointer++;
        SiftUp(_pointer - 1);
    }

    public int ExtractMin()
    {
        var min = _array[0];
        _pointer--;
        _array[0] = _array[_pointer];
        SiftDown(0);
        return min;
    }

    private void SiftUp(int index)
    {
        while (index > 0)
        {
            var parentIndex = (index - 1) / 2;
            if (_array[parentIndex] <= _array[index])
                break;
            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void SiftDown(int index)
    {
        while (true)
        {
            var leftChildrenIndex = 2 * index + 1;
            var rightChildrenIndex = 2 * index + 2;
            var smallestIndex = index;
            if (leftChildrenIndex < _pointer && _array[leftChildrenIndex] < _array[smallestIndex])
                smallestIndex = leftChildrenIndex;
            if (rightChildrenIndex < _pointer && _array[rightChildrenIndex] < _array[smallestIndex])
                smallestIndex = rightChildrenIndex;
            if (smallestIndex == index)
                break;
            Swap(smallestIndex, index);
            index = smallestIndex;
        }
    }

    private void Swap(int index1, int index2)
    {
        var temp = _array[index1];
        _array[index1] = _array[index2];
        _array[index2] = temp;
    }
}