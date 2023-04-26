namespace HandmadeBaseLibrary;

public class List<T>
{
    public const int BaseCount = 4;
    
    private T[] Body { get; set; }
    
    public int Count { get; private set; }

    public int Capacity => Body.Length;
    
    public List(int capacity = BaseCount)
    {
        if (capacity < 0) capacity = BaseCount;
        Body = new T[capacity];
    }
    
    public T this[int index]
    {
        get => Body[index];
        set => Body[index] = value;
    }

    public void Add(T element)
    {
        if (Body.Length == Count) ExpandBody();

        Body[Count] = element;
        Count++;
    }

    public bool Insert(int index, T element)
    {
        // Exception
        if (index < 0 || index > Count) return false;
        if (Count == Body.Length) ExpandBody();
        
        for (var i = Count; i > index; i--)
            Body[i] = Body[i - 1];
        
        Body[index] = element;
        Count++;
        return true;
    }
    
    public bool Remove(int index)
    {
        // Exception
        if (index < 0 || index >= Count) return false;

        for (var i = index; i < Count; i++)
            Body[i] = Body[i + 1];

        Count--;
        return true;
    }

    private void ExpandBody()
    {
        var newBody = new T[2 * Body.Length];
        
        for (var i = 0; i < Body.Length; i++)
            newBody[i] = Body[i];
        
        Body = newBody;
    }
}