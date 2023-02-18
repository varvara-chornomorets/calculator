namespace Calculator;

public class ArrayList
{
    private int[] _array = new int[10];
    private int _pointer = 0;

    public void Add(int value)
    {
        _array[_pointer] = value;
        _pointer++;
        if (_pointer == _array.Length)
        {
            int[] ExtendedArray = new int[_array.Length * 2];
            for (int i = 0; i < _array.Length; i++)
            {
                ExtendedArray[i] = _array[i];
            }

            _array = ExtendedArray;
        }
    }

    public int GetLenght()
    {
        return _pointer;
    }
    
    public void Remove(int value)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i] == value)
            {
                for (int k = i; k < _array.Length - 1; k++)
                {
                    _array[k] = _array[k + 1];
                }

                _pointer--;
                break;
            }
        }
        {
            
        }
    }
}