using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class FalseCommandTests
	{
		[TestMethod]
		public void Test()
		{
			int expected = 1;
			MyBash.MyBash bash = new MyBash.MyBash();
			FalseCommand False = new FalseCommand(bash,new List<string>(), (_) => true);
			False.Execute();
			var result = bash.LastOutputStatus;
			Assert.AreEqual(expected, result);
		}
	}
}