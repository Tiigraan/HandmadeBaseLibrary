namespace HandmadeBaseLibraryTests;

using HandmadeBaseLibrary;

public class ListTests
{
    #region Init
    [Fact]
    public void InitList()
    {
        var list = new List<int>();
        Assert.Equal(0, list.Count);
        Assert.Equal(4, list.Capacity);
    }
    
    [Fact]
    public void InitListWithCapacity()
    {
        var capacity = 10;
        var list = new List<int>(capacity);
        Assert.Equal(0, list.Count);
        Assert.Equal(capacity, list.Capacity);
    }
    
    [Fact]
    public void InitListWithNegativeCapacity()
    {
        var capacity = -10;
        var list = new List<int>(capacity);
        Assert.Equal(0, list.Count);
        Assert.Equal(List<int>.BaseCount, list.Capacity);
    }
    #endregion

    #region Add
    [Fact]
    public void AddElement()
    {
        var list = new List<int>();
        var element = 1;
        list.Add(element);
        Assert.Equal(element, list[0]);
        Assert.Equal(1, list.Count);
    }
    #endregion

    #region Remove
    [Fact]
    public void RemoveElement()
    {
        var list = new List<int>();
        list.Add(1);
        Assert.Equal(1, list.Count);
        var result = list.Remove(list.Count - 1);
        Assert.True(result);
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void RemoveElementWithNegativeIndex()
    {
        var list = new List<int>();
        list.Add(1);
        var count = list.Count;
        var result = list.Remove(-1);
        
        Assert.False(result);
        Assert.Equal(count, list.Count);
    }
    
    [Fact]
    public void RemoveElementWithOverIndex()
    {
        var list = new List<int>();
        list.Add(1);
        var count = list.Count;
        var result = list.Remove(count + 1);
        
        Assert.False(result);
        Assert.Equal(count, list.Count);
    }
    #endregion

    #region Insert
    [Fact]
    public void Insert()
    {
        var list = new List<int>();
        var count = list.Count;
        
        list.Insert(0, 1);
        
        Assert.Equal(count + 1, list.Count);
        Assert.Equal(1, list[0]);
    }

    [Fact]
    public void InsertIntoNegativeIndex()
    {
        var list = new List<int>();
        var count = list.Count;

        var result = list.Insert(-1, 1);
        
        Assert.False(result);
        Assert.Equal(count, list.Count);
    }
    
    [Fact]
    public void InsertIntoOverIndex()
    {
        var list = new List<int>();
        var count = list.Count;

        var result = list.Insert(count + 1, 1);
        
        Assert.False(result);
        Assert.Equal(count, list.Count);
    }
    
    [Fact]
    public void InsertIntoIndexBeforeExpend()
    {
        var arr = new[] {1,2, 3, 4};
        
        var list = new List<int>();
        foreach (var element in arr)
            list.Add(element);
        
        var count = list.Count;
        var capacity = list.Capacity;
        var newElement = 5;
        var result = list.Insert(list.Count, newElement);
        
        Assert.True(result);
        Assert.NotEqual(capacity, list.Capacity);
        Assert.Equal(count + 1, list.Count);
        
        for(var i = 0; i < arr.Length; i++)
            Assert.Equal(arr[i], list[i]);
        Assert.Equal(newElement, list[count]);
    }
    #endregion
    
    // Index..
}