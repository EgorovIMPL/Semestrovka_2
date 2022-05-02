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

    public void PrintTree()
    {
        Console.WriteLine(String.Join(" ",array));
    }
}