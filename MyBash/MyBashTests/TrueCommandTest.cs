using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class TrueCommandTests
	{
		[TestMethod]
		public void Test()
		{
			int expected = 0;
			MyBash.MyBash bash = new MyBash.MyBash();
			TrueCommand True = new TrueCommand(bash,new List<string>(), (_) => true);
			True.Execute();
			var result = bash.LastOutputStatus;
			Assert.AreEqual(expected, result);
		}
	}
}