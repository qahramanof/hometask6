

using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp.Bulilders;

public class CustomBuilder
{
    private char[] _arr;
    private int _capacity = 16;
    private int _length = 0;

    public CustomBuilder()
    {
        _arr = new char[_capacity];
    }

    public int Length
    {
        get
        {
            return _length;
        }
        set
        {
            if (value < _length)
            {
                throw new Exception($"Length must be more than {_length}");
            }
            if (value > _capacity && value <= 2 * _capacity)
            {
                Capacity *= 2;
            }
            if (value > 2 * _capacity)
            {
                Capacity = value;
            }
            _length = value;
        }
    }
    public int Capacity
    {
        get
        {
            return _capacity;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value cannot be less than zero");
            }
            if (value < Length)
            {
                throw new Exception($"Capacity must be more than {Length}");
            }
            _capacity = value;
            Array.Resize(ref _arr, _capacity);
        }
    }

    public void Append(char item)
    {
        if (Length == Capacity)
        {
            Capacity *= 2;
        }
        _arr[Length] = item;
        Length++;
    }

    public string ToString()
    {
        string result = string.Empty;
        foreach (char item in _arr)
        {
            result += item;
        }
        return result;
    }
    public char[] GetValue()
    {
        return _arr;
    }

    public void Replacechar( char oldChar, char newChar)
    {
        for (int i = 0; i < Length; i++)
        {
            if (_arr[i] == oldChar)
            {
                _arr[i] = newChar;
            }
        }
    }
    public void RemoveIndex(int index,int count )
    {
        char[] array = new char[Length];
        int j = 0;
        if (index < 0 || index >= Length)
        {
            throw new ArgumentOutOfRangeException("index is wrong");
        }
        for (int i = 0; i < Length; i++)
        {
            if (i < index || i >= index + count)
            {
                array[j] = _arr[i];
                j++;
            }
        }
            _arr = array;
    }

}
