using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class EchoCommandTests
	{
		[TestMethod]
		public void TestWithCorrectArgs()
		{
			string expected = "Hello World!\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			EchoCommand echo = new EchoCommand(bash, new List<string> { "Hello", "World!" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				echo.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(0, bash.LastOutputStatus);
			}

			expected = "BASH\n";
			echo = new EchoCommand(bash, new List<string> { "BASH" }, (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				echo.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(0, bash.LastOutputStatus);
			}

			expected = "\n";
			echo = new EchoCommand(bash, new List<string>(), (_) => { return true; });
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				echo.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(0, bash.LastOutputStatus);
			}
		}
	}
}