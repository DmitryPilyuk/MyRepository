using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBash.Commands
{
	internal interface Command
	{
		public void Execute(MyBash bash);
	}
}
