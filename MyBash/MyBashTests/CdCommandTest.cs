using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class CDCommandTests
	{
		[TestMethod]
		public void TestWithCorrectArgs()
		{
			string expected = $"{Directory.GetCurrentDirectory()}";
			MyBash.MyBash bash = new MyBash.MyBash();
			CdCommand cd = new CdCommand(bash, new List<string> { $"{Directory.GetCurrentDirectory()}" }, (_) => { return true; });
			cd.Execute();
			var result = bash.Path;
			Assert.AreEqual(expected, result);
			Assert.AreEqual(0, bash.LastOutputStatus);

			expected = $"{Directory.GetCurrentDirectory()}\\testFiles";
			cd = new CdCommand(bash, new List<string> { "testFiles" }, (_) => { return true; });
			cd.Execute();
			result = bash.Path;
			Assert.AreEqual(expected, result);
			Assert.AreEqual(0, bash.LastOutputStatus);
		}

		[TestMethod]
		public void TestWithIncorrectArgs()
		{
			string expected = "MyBash: cd: NoneDir: Нет такого файла или каталога\r\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			CdCommand cd = new CdCommand(bash, new List<string> { "NoneDir" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				cd.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
			expected = "MyBash: cd: Аргументы не переданы\r\n";
			cd = new CdCommand(bash, new List<string>(), (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				cd.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
			expected = "MyBash: cd: Слишком много аргументов\r\n";
			cd = new CdCommand(bash, new List<string> { "C:\\2term\\MyRepository\\MyBash\\MyBashTests", "C:" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				cd.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
		}
	}
}