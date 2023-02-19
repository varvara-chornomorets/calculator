namespace Calculator;

public class Queue
{
    private int _pointer = 0;
    private static int _capacity = 50;
    private int[] _array = new int[_capacity];

    public void Enque(int value)
    {
        if (_pointer == _capacity)
        {
            throw new Exception("queue is overloaded");
        }

        _array[_pointer] = value;
        _pointer++;

    }

    public void Deque()
    {
        if (_pointer == 0)
        {
            throw new Exception("queue is empty, but you try to take an element out");
        }
        int result = _array[0];
        _pointer--;
        for (int i = 0; i < _pointer && _pointer < 49; i++ )
        {
            _array[i] = _array[i + 1];
        }
    }

    public void Print()
    {
        foreach (var number in _array)
        {
            Console.WriteLine(number);
        }
    }

}