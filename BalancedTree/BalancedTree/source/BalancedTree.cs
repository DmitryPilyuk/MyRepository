using System;
using System.Collections.Generic;
using System.Collections;


namespace BalancedTree
{
	public class BalancedTree<T> : IEnumerable<T> where T : IComparable<T>
	{
		public BalancedTreeNode<T> Root;
		public BalancedTreeNode<T> First
		{
			get
			{
				var current = Root;
				while (current.left != null)
				{
					current = current.left;
				}
				return current;
			}
		}
		public BalancedTreeNode<T> Last
		{
			get
			{
				var current = Root;
				while (current.right != null)
				{
					current = current.right;
				}
				return current;
			}
		}
		public int Count;

		public BalancedTree()
		{
				Root = null;
				Count = 0;
		}
		public BalancedTree(IEnumerable<T> elements)
		{
			Root = null;
			Count = 0;
			foreach (var elem in elements)
			{
				this.Add(elem);
			}
		}

		public void Add(object obj)
		{
			if (obj is T data)
			{
				var newNode = new BalancedTreeNode<T>(data);
				Root = BalancedTreeNode<T>.Add(Root, newNode);
				Count++;
			}
			else if (obj is BalancedTreeNode<T> node)
			{
				Root = BalancedTreeNode<T>.Add(Root, node);
				Count++;
			}
			else
			{
				throw new ArgumentException();
			}
		}

		public bool Remove(object obj)
		{
			if (obj is T data)
			{
				if (this.Contains(data))
				{
					var newNode = new BalancedTreeNode<T>(data);
					Root = BalancedTreeNode<T>.Remove(Root, newNode);
					Count--;
					return true;
				}
				else
				{
					return false;
				}
			}
			else if (obj is BalancedTreeNode<T> node)
			{
				if (this.Contains(node.Data))
				{
					Root = BalancedTreeNode<T>.Remove(Root, node);
					Count--;
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				throw new ArgumentException();
			}
		}

		public void Clear()
		{
			Root = null;
			Count = 0;
		}

		public bool Contains(T data)
		{
			BalancedTreeNode<T> current = Root;
			while (current != null && !current.Data.Equals(data))
			{
				if (data.CompareTo(current.Data) < 0)
				{
					current = current.left;
				}
				else
				{
					current = current.right;
				}
			}
			return current != null;
		}

		public BalancedTreeNode<T> Find(T data)
		{
			BalancedTreeNode<T> current = Root;
			while (!current.Data.Equals(data) && current != null)
			{
				if (data.CompareTo(current.Data) < 0)
				{
					current = current.left;
				}
				else
				{
					current = current.right;
				}
			}
			return current;
		}

		public void PostOrder(Action<T> function)
		{
			Root.PostOrder(function);
		}

		public void InOrder(Action<T> function)
		{
			Root.InOrder(function);
		}

		public void PreOrder(Action<T> function)
		{
			Root.PreOrder(function);
		}

		public override bool Equals(object obj)
		{
			if (obj is BalancedTree<T> tree)
			{
				if (Count != tree.Count)
				{
					return false;
				}
				else
				{
					IEnumerator thisEnumerator = this.GetEnumerator();
					IEnumerator treeEnumerator = tree.GetEnumerator();

					while (thisEnumerator.MoveNext() && treeEnumerator.MoveNext())
					{
						if (!thisEnumerator.Current.Equals(treeEnumerator.Current))
						{
							return false;
						}
					}
					return true;
				}
			}
			else return false;
		}

		public new Type GetType()
		{
			return base.GetType();
		}

		public IEnumerator<T> GetEnumerator()
		{
			List<T> nodes = new();
			InOrder(nodes.Add);
			return new TreeEnumerator<T>(nodes, Count);
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public void CopyTo(T[] array, int index)
		{
			List<T> nodes = new();
			InOrder(nodes.Add);
			foreach (var data in nodes)
			{
				array[index] = data;
				++index;
			}
		}

		public override string ToString()
		{
			List<T> nodes = new();
			InOrder(nodes.Add);
			string result = "";
			for (int i = 0; i < Count; i++)
			{
				if (i != Count - 1) result += nodes[i].ToString() + "; ";
				else result += nodes[i].ToString();
			}

			return result;
		}

	}
}
