using System;

namespace BalancedTree
{
	public class BalancedTreeNode<T> where T : IComparable<T> 
	{
		public T Data { get; set; }
		internal int height;
		internal BalancedTreeNode<T> left;
		internal BalancedTreeNode<T> right;

		public BalancedTreeNode(T data, BalancedTreeNode<T> left = null, BalancedTreeNode<T> right = null, int height = 1)
		{
			this.Data = data;
			this.left = left;
			this.right = right;
			this.height = height;
		}

		public int CompareTo(object obj)
		{
			if (obj is BalancedTreeNode<T> item)
			{
				return Data.CompareTo(item.Data);
			}
			else
			{
				throw new ArgumentException("The types do not match");
			}
		}

		internal static BalancedTreeNode<T> Add(BalancedTreeNode<T> root, BalancedTreeNode<T> node)
		{
			if (root == null)
			{
				return node;
			}
			if (node.CompareTo(root) < 0)
			{
				root.left = Add(root.left, node);
			}
			else
			{
				root.right = Add(root.right, node);
			}
			return ToBalance(root);
		}

		private static int GetHeight(BalancedTreeNode<T> node)
		{
			return node != null ? node.height : 0;
		}

		private void UpdateHeight()
		{
			int heightRight = GetHeight(this.right);
			int heightLeft = GetHeight(this.left);
			this.height = (heightRight >= heightLeft ? heightRight : heightLeft) + 1;
		}

		private static int BalanceFactor(BalancedTreeNode<T> node)
		{
			return GetHeight(node.right) - GetHeight(node.left);
		}

		private static BalancedTreeNode<T> RotateRight(BalancedTreeNode<T> node)
		{
			BalancedTreeNode<T> newNode = node.left;
			node.left = newNode.right;
			newNode.right = node;
			node.UpdateHeight();
			newNode.UpdateHeight();
			return newNode;
		}

		private static BalancedTreeNode<T> RotateLeft(BalancedTreeNode<T> node)
		{
			BalancedTreeNode<T> newNode = node.right;
			node.right = newNode.left;
			newNode.left = node;
			node.UpdateHeight();
			newNode.UpdateHeight();
			return newNode;
		}

		private static BalancedTreeNode<T> ToBalance(BalancedTreeNode<T> node)
		{
			if (BalanceFactor(node) == 2)
			{
				if (BalanceFactor(node.right) < 0)
				{
					node.right = RotateRight(node.right);
				}
				return RotateLeft(node);
			}
			if (BalanceFactor(node) == -2)
			{
				if (BalanceFactor(node.left) > 0)
				{
					node.left = RotateLeft(node.left);
				}
				return RotateRight(node);
			}
			node.UpdateHeight();
			return node;
		}

		private static BalancedTreeNode<T> FindMin(BalancedTreeNode<T> node)
		{
			return (node.left == null) ? node : FindMin(node.left);
		}

		private static BalancedTreeNode<T> RemoveMin(BalancedTreeNode<T> node)
		{
			if (node.left == null)
			{
				return node.right;
			}
			node.left = RemoveMin(node.left);
			return ToBalance(node);
		}

		internal static BalancedTreeNode<T> Remove(BalancedTreeNode<T> root, BalancedTreeNode<T> node)
		{
			if ( root == null)
			{
				return null;
			}

			if (node.CompareTo(root) < 0)
			{
				root.left = Remove(root.left, node);
			}
			else if (node.CompareTo(root) > 0)
			{
				root.right = Remove(root.right, node);
			}
			else
			{
				BalancedTreeNode<T> rightNode = root.right;
				BalancedTreeNode<T> leftNode = root.left;
				if (rightNode == null)
				{
					return leftNode;
				}
				BalancedTreeNode<T> min = FindMin(rightNode);
				min.right = RemoveMin(rightNode);
				min.left = leftNode;
				return ToBalance(min);
			}
			return ToBalance(root);
		}

		internal void PostOrder(Action<T> function)
		{
			if (left != null) left.PostOrder(function);
			if (right != null) right.PostOrder(function);
			function(Data);
		}

		internal void PreOrder(Action<T> function)
		{
			function(Data);
			if (left != null) left.PreOrder(function);
			if (right != null) right.PreOrder(function);
		}

		internal void InOrder(Action<T> function)
		{
			if (left != null) left.InOrder(function);
			function(Data);
			if (right != null) right.InOrder(function);
		}
	}
}
