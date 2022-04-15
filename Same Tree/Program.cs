using System;
using System.Collections.Generic;

namespace Same_Tree
{
  class Program
  {
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
      {
        this.val = val;
        this.left = left;
        this.right = right;
      }
    }
    static void Main(string[] args)
    {
      TreeNode p = new TreeNode(1);
      p.left = new TreeNode(2);
      p.right = new TreeNode(3);

      TreeNode q = new TreeNode(1);
      q.left = new TreeNode(2);
      q.right = new TreeNode(3);

      Program prog = new Program();
      Console.WriteLine(prog.IsSameTree(p, q));
    }

    public bool IsSameTree(TreeNode p, TreeNode q)
    {
      if (p == null && q == null) return true;
      Queue<(TreeNode, TreeNode)> queue = new Queue<(TreeNode, TreeNode)>();
      queue.Enqueue((p, q));
      while (queue.Count > 0)
      {
        var (pp, qq) = queue.Dequeue();
        if (pp == null && qq == null) continue;
        if (pp != null && qq != null && pp.val != qq.val)
        {
          return false;
        }
        else if (pp == null || qq == null)
        {
          return false;
        }
        queue.Enqueue((pp?.left, qq?.left));
        queue.Enqueue((pp?.right, qq?.right));
      }
      return true;
    }
  }
}
