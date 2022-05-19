using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBash
{
	internal class MyBash
	{
		internal const int True = 0;
		internal const int False = 1;
		internal string Path { get; set; }
		internal List<string> Errors { get; set; }
		internal string Output { get; set; }
		internal List<Command> Commands { get; private set; }
		internal int LastOutputStatus { get; set; }
		internal MyBash()
		{
			Output = "";
			LastOutputStatus = 0;
		}


	}
}