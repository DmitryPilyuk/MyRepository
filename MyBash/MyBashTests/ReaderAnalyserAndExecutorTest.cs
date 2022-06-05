using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using MyBash;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class ReaderAndAnalyserAndExecutorTest
	{
		[TestMethod]
		public void WrongTest()
		{
			string expected = "MyBash: Переменная NoneVar не найдена\r\nMyBash: команда NoneCommand не существует\r\nMyBash: Файл NoneFile.txt не найден\r\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			Reader reader = new Reader(bash, "cat $NoneVar ; NoneCommand || echo < NoneFile.txt");
			reader.ReadAndParse();
			AnalyserAndExecutor executeAll = new AnalyserAndExecutor(bash);
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				executeAll.ExecuteString();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
		}

		[TestMethod]
		public void ConnectorsTest()
		{
			string expected = "MyBash: cd: NoneDir: Нет такого файла или каталога\r\n1echo command executed\n2echo command executed\nMyBash: cd: Аргументы не переданы\r\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			Reader reader = new Reader(bash, "cd NoneDir || echo 1echo command executed && echo 2echo command executed || echo This text not shown ; cd && echo This text not shown");
			reader.ReadAndParse();
			AnalyserAndExecutor executeAll = new AnalyserAndExecutor(bash);
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				executeAll.ExecuteString();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
		}

		[TestMethod]
		public void InputRedirectingTest()
		{
			string expected = "This text is expected in cat test\r\nAnd some strings to wc test\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			bash.Path = $"{Directory.GetCurrentDirectory()}\\testFiles";
			Reader reader = new Reader(bash, "echo < testFile1.txt");
			reader.ReadAndParse();
			AnalyserAndExecutor executeAll = new AnalyserAndExecutor(bash);
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				executeAll.ExecuteString();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(0, bash.LastOutputStatus);
			}
		}

		[TestMethod]
		public void OutputRedirectingTest()
		{
			string expected = "Text to test\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			Reader reader = new Reader(bash, $"echo Text to test > {Directory.GetCurrentDirectory()}\\testFiles\\testWrite.txt");
			reader.ReadAndParse();
			AnalyserAndExecutor executeAll = new AnalyserAndExecutor(bash);
			executeAll.ExecuteString();
			Assert.AreEqual(expected, File.ReadAllText("testFiles\\testWrite.txt"));
			Assert.AreEqual(0, bash.LastOutputStatus);

			expected = "Text to test\nAppended text\n";
			reader = new Reader(bash, $"echo Appended text >> {Directory.GetCurrentDirectory()}\\testFiles\\testWrite.txt");
			reader.ReadAndParse();
			executeAll.ExecuteString();
			Assert.AreEqual(expected, File.ReadAllText("testFiles\\testWrite.txt"));
			Assert.AreEqual(0, bash.LastOutputStatus);

			expected = "Previous text disapeared\n";
			reader = new Reader(bash, $"echo Previous text disapeared > {Directory.GetCurrentDirectory()}\\testFiles\\testWrite.txt");
			reader.ReadAndParse();
			executeAll.ExecuteString();
			Assert.AreEqual(expected, File.ReadAllText("testFiles\\testWrite.txt"));
			Assert.AreEqual(0, bash.LastOutputStatus);
		}
	}
}
