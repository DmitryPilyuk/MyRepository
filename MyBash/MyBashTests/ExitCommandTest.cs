using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class ExitCommandTests
	{
		[TestMethod]
		public void Test()
		{
			bool expected = false;
			MyBash.MyBash bash = new MyBash.MyBash();
			ExitCommand exit = new ExitCommand(bash);
			exit.Execute();
			var result = bash.IsWorking;
			Assert.AreEqual(expected, result);
		}
	}
}