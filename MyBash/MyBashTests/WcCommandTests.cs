using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class WcCommandTests
	{
		[TestMethod]
		public void TestWithCorrectArgs()
		{
			string expected = "2 13 62 testFile1.txt\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			bash.Path = $"{Directory.GetCurrentDirectory()}\\testFiles";
			WcCommand wc = new WcCommand(bash, new List<string> { "testFile1.txt" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				wc.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(0, bash.LastOutputStatus);
			}
			expected = "1 4 24 testFile2.txt\n2 13 62 testFile1.txt\n3 17 86 итого\n";
			wc = new WcCommand(bash, new List<string> { "testFile2.txt", "testFile1.txt" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				wc.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(0, bash.LastOutputStatus);
			}
		}

		[TestMethod]
		public void TestWithIncorrectArgs()
		{
			string expected = "MyBash: wc: Файл None.txt не найден\r\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			bash.Path = $"{Directory.GetCurrentDirectory()}\\testFiles";
			WcCommand wc = new WcCommand(bash, new List<string> { "None.txt" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				wc.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
			expected = "MyBash: wc: Аргументы не переданы\r\n";
			wc = new WcCommand(bash, new List<string>(), (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				wc.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
		}
	}
}