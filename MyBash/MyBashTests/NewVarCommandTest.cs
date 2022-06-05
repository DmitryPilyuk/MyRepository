using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class NewVarCommandTest
	{
		[TestMethod]
		public void TestWithCorrectArgs()
		{
			var variableValue = new List<string> { "cat", "testFile1.txt" };
			var expected = new Dictionary<string, List<string>> { {"variable", variableValue } };
			MyBash.MyBash bash = new MyBash.MyBash();
			NewVarCommand newVarC = new NewVarCommand(bash, variableValue, (_) => true, "variable" );
			newVarC.Execute();
			var result = bash.Variables;
			Assert.AreEqual(expected["variable"], result["variable"]);
			Assert.AreEqual(0, bash.LastOutputStatus);
		}

		[TestMethod]
		public void TestWithIncorrectArgs()
		{
			string expected = "MyBash: В переменную Variable не передано аргументов\r\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			NewVarCommand newVarC = new NewVarCommand(bash, new List<string> (), (_) => { return true; }, "Variable");
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				newVarC.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
		}
	}
}

