namespace Semestrovka_2;

public class SegmentTree
{
    private int[] array;

    private void GrowTree()
    {
        for(int i = array.Length-1; i > 0; --i)
        {
            int parent = (i - 1)/2;
            array[parent] += array[i];
        }
    }
    public SegmentTree(int[] array)
    {
        array = CheckLenght(array);
        this.array = new int[array.Length*2-1];
        array.CopyTo(this.array, array.Length-1);
        GrowTree();
    }

    private int Query(int root,int cleft,int cright,int left, int right)
    {
        if (root > array.Length - 1 || cleft > right || cright < left) return 0;
        if (cleft>=left && cright <= right)
            return array[root];
        int mid = cleft + (cright - cleft)/2;
        return Query(root*2 + 1, cleft, mid, left, right) + Query(root*2 + 2, mid+1,cright,left,right);                 
    }

    public int Query(int left,int right)
    {
        return Query(0,0,(array.Length+1)/2-1,left, right);
    }

    public int Find(int number)
    {
        foreach (var el in array)
            if (el == number)
                return number;
        return Int32.MaxValue;
    }
    
    public string PrintTree()
    {
        return String.Join(" ", array);
    }

    public void Add(int number)
    {
        var array1 = array[(array.Length/2)..array.Length].Where(x => x != 0).Append(number).ToArray();
        array1 = CheckLenght(array1);
        array = new int[array1.Length*2-1];
        array1.CopyTo(array, array1.Length-1);
        GrowTree();
    }

    public void Remove(int number)
    {
        var array1 = array[(array.Length/2)..array.Length].Where(x => (x != 0) && (x!=number)).ToArray();
        array1 = CheckLenght(array1);
        array = new int[array1.Length*2-1];
        array1.CopyTo(array, array1.Length-1);
        GrowTree();
    }
    private int[] CheckLenght(int[] array)
    {
        int count = 1;
        int l = array.Length;
        while (count < l)
            count *= 2;
        var newArray = new int[count];
        array.CopyTo(newArray,0);
        return newArray;
    }
}