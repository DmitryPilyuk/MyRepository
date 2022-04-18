using System.Collections;
using System.Collections.Generic;


namespace BalancedTree
{
	class TreeEnumerator<T> : IEnumerator<T>
	{
		private List<T> nodes;
		private int pos;
		private int count;


		public TreeEnumerator(List<T> nodes, int count)
		{
			this.nodes = nodes;
			this.count = count;
			pos = -1;
		}

		public T Current
		{
			get
			{
				return nodes[pos];
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (pos < count - 1)
			{
				pos++;
				return true;
			}
			else
				return false;
		}

		public void Reset()
		{
			pos=-1;
		}
	}
}
