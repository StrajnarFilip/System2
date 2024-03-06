using System2.DataStructures;

namespace System2.Test;

public class TreeNodeTest
{
    private static readonly TreeNode<int> ExampleTreeNode =
        new(
            1,
            new[]
            {
                new TreeNode<int>(2),
                new TreeNode<int>(
                    3,
                    new TreeNode<int>[]
                    {
                        new TreeNode<int>(5),
                        new TreeNode<int>(
                            6,
                            new[]
                            {
                                new TreeNode<int>(8),
                                new TreeNode<int>(9),
                                new TreeNode<int>(10),
                                new TreeNode<int>(
                                    11,
                                    new TreeNode<int>[] { new TreeNode<int>(12), }
                                ),
                            }
                        ),
                        new TreeNode<int>(7),
                    }
                ),
                new TreeNode<int>(4),
            }
        );

    [Fact]
    public void TestDepthFirst()
    {
        var result = ExampleTreeNode.DepthFirstSearch(v => v.ChildNodes, v => v.CurrentNode == 12);
        Assert.Equal(12, result.CurrentNode);
    }

    [Fact]
    public void TestBreadthFirst()
    {
        var result = ExampleTreeNode.BreadthFirstSearch(
            v => v.ChildNodes,
            v => v.CurrentNode == 12
        );
        Assert.Equal(12, result.CurrentNode);
    }
}
