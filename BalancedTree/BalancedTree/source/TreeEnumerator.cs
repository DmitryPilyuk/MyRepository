using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			pos++;
			return pos < count;
		}

		public void Reset()
		{
			pos=-1;
		}
	}
}
