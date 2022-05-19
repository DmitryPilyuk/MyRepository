using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBash.Commands
{
	internal class PWDCommand : Command
	{
		internal PWDCommand()
		{

		}

		public void Execute(MyBash bash)
		{
			bash.Output += bash.Path + "\n\n";

			foreach (var fileName in Directory.GetFileSystemEntries(bash.Path))
			{
				bash.Output += fileName.Skip(bash.Path.Length).ToString() + "\n";
			}
			bash.LastOutputStatus = MyBash.True;
		}
	}
}
