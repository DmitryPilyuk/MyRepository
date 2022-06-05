using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class LastStatusCommandTests
	{
		[TestMethod]
		public void Test()
		{
			string expected = "true\r\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			LastStatusCommand lastStatus = new LastStatusCommand(bash, new List<string>(), (_) => true);
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				lastStatus.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
			}

			expected = "false\r\n";
			bash.LastOutputStatus = MyBash.MyBash.False;
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				lastStatus.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
			}
		}
	}
}