namespace Semestrovka_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SegmentTree st = new SegmentTree(new[] {1, 2, 3, 4, 5, 6, 7, 8});
            st.PrintTree();
        }
    }
}