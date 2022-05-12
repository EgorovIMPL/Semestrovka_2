using Xunit;
using System;
using Semestrovka_2;
namespace TestProject3;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        SegmentTree st = new SegmentTree(new[] {1, 4, 8, 9, 5});
        SegmentTree tr = new SegmentTree(new[] {1, 4, 8, 9, 5,6});
        st.Add(6);
        Assert.Equal(tr.PrintTree(),st.PrintTree());
    }
    [Fact]
    public void Test2()
    {
        SegmentTree st = new SegmentTree(new[] {1, 4, 8, 9, 5});
        SegmentTree tr = new SegmentTree(new[] {1, 4, 8, 9});
        st.Remove(5);
        Assert.Equal(tr.PrintTree(),st.PrintTree());
    }
}