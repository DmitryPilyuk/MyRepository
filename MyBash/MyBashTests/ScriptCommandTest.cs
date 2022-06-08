using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;
namespace MyBashTests
{
	[TestClass]
	public class ScriptCommandTest
	{
		[TestMethod]
		public void TestWithCorrectArgs()
		{
			string expected = "Script started\nC:\\2term\\MyRepository\\MyBash\\MyBashTest\\bin\\Release\\net6.0\\testFiles\nscript.txt\ntestFile1.txt\ntestFile2.txt\ntestWrite.txt\nThis text from testFile2\n2 13 62 testFile1.txt\n1 4 24 testFile2.txt\n3 17 86 итого\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			bash.Path =  $"{Directory.GetCurrentDirectory()}\\testFiles";
			ScriptCommand script = new ScriptCommand(bash, $"{Directory.GetCurrentDirectory()}\\testFiles\\script.txt", (_) => true);
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				script.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
			}
		}
	}
}
