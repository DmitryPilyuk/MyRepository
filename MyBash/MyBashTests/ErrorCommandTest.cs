using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBashTests
{
	[TestClass]
	public class ErrorCommandTests
	{
		[TestMethod]
		public void Test()
		{
			string expected = "Сообщение об ошибке\r\n";
			MyBash.MyBash bash = new MyBash.MyBash();
			ErrorCommand error = new ErrorCommand(bash, "Сообщение об ошибке");
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);
				error.Execute();
				var result = sw.ToString();
				Assert.AreEqual(expected, result);
				Assert.AreEqual(1, bash.LastOutputStatus);
			}
		}
	}
}