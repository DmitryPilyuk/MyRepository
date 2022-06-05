using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class PwdCommandTests
	{
		[TestMethod]
		public void TestWithCorrectArgs()
		{
			string expected = $"{Directory.GetCurrentDirectory()}\\testFiles\nscript.txt\ntestFile1.txt\ntestFile2.txt\ntestWrite.txt\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			bash.Path = $"{Directory.GetCurrentDirectory()}\\testFiles";
			PwdCommand pwd = new PwdCommand(bash, new List<string>(), (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				pwd.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(0, bash.LastOutputStatus);
			}
		}
	}
}