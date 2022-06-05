using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class CatCommandTests
	{
		[TestMethod]
		public void TestWithCorrectArgs()
		{
			string expected = "This text is expected in cat test\r\nAnd some strings to wc test\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			bash.Path = $"{Directory.GetCurrentDirectory()}\\testFiles";
			CatCommand cat = new CatCommand(bash, new List<string> { "testFile1.txt" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				cat.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(0, bash.LastOutputStatus);
			}
			expected = "This text from testFile2\nThis text is expected in cat test\r\nAnd some strings to wc test\n";
			cat = new CatCommand(bash, new List<string> { "testFile2.txt", "testFile1.txt" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				cat.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(0, bash.LastOutputStatus);
			}
		}

		[TestMethod]
		public void TestWithIncorrectArgs()
		{
			string expected = "MyBash: cat: Файл None.txt не найден\r\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			bash.Path = $"{Directory.GetCurrentDirectory()}\\testFiles";
			CatCommand cat = new CatCommand(bash, new List<string> { "None.txt" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				cat.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
			expected = "MyBash: cat: Аргументы не переданы\r\n";
			cat = new CatCommand(bash, new List<string>(), (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				cat.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
		}
	}
}