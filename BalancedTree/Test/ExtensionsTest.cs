using System;
using BalancedTree;

namespace Test
{
	class ExtensionsTest
	{
		public static void AnyTest()
		{
			Console.WriteLine("Тест Any");
			string[] testStrArr = new string[] { "Ball", "Car", "Field", "House" };
			int[] testIntArr = new int[] { 14, 15, 5, 29 };
			int[] testEmptyArr = new int[] { };
			Console.WriteLine("Тест для массива:");
			foreach (var item in testStrArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.WriteLine($"Array.Any(): {testStrArr.Any()}");
			Console.WriteLine($"Array.Any(p => p == \"Ball\"): {testStrArr.Any(p => p == "Ball")}");
			
			Console.WriteLine("Тест для массива:");
			foreach (var item in testIntArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.WriteLine($"Array.Any(): {testIntArr.Any()}");
			Console.WriteLine($"Array.Any(p => p < 4): {testIntArr.Any(p => p < 4)}");

			Console.WriteLine("Тест для пустого массива:");
			Console.WriteLine($"Array.Any(): {testEmptyArr.Any()}");
		}

		public static void CountTest()
		{
			Console.WriteLine("Тест Count");
			string[] testStrArr = new string[] { "Ball", "Car", "Field", "House" };
			int[] testIntArr = new int[] { 14, 15, 5, 29, 5, 16, 12, 5, 5};
			int[] testEmptyArr = new int[] { };
			Console.WriteLine("Тест для массива:");
			foreach (var item in testStrArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.WriteLine($"Array.Count(): {testStrArr.Count()}");
			Console.WriteLine($"Array.Count(p => p == \"Man\"): {testStrArr.Count(p => p == "Man")}");

			Console.WriteLine("Тест для массива:");
			foreach (var item in testIntArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.WriteLine($"Array.Count(): {testIntArr.Count()}");
			Console.WriteLine($"Array.Count(p => p > 15): {testIntArr.Count(p => p > 15)}");

			Console.WriteLine("Тест для пустого массива:");
			Console.WriteLine($"Array.Count(): {testEmptyArr.Count()}");
		}

		public static void AllTest()
		{
			Console.WriteLine("Тест All");
			string[] testStrArr = new string[] { "Ball", "Car", "Field", "House" };
			int[] testIntArr = new int[] { 14, 15, 5, 29, 13, 123, 2, 12 };
			Console.WriteLine("Тест для массива:");
			foreach (var item in testStrArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.WriteLine($"Array.All(p => p.Length > 2): {testStrArr.All(p => p.Length > 2)}");

			Console.WriteLine("Тест для массива:");
			foreach (var item in testIntArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.WriteLine($"Array.All(p => p % 2 == 1): {testIntArr.All(p => p % 2 == 1)}");
		}

		public static void FirstLastTest()
		{
			Console.WriteLine("Тест First и Last");
			string[] testStrArr = new string[] { "Ball", "Car", "Field", "House" };
			int[] testEmptyArr = new int[] { };
			Console.WriteLine("Тест для массива:");
			foreach (var item in testStrArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.WriteLine($"Array.First(): {testStrArr.First()}");
			Console.WriteLine($"Array.Last(): {testStrArr.LastOrDefault()}");

			Console.WriteLine("Тест для пустого массива:");
			Console.WriteLine($"Array.FirstOrDefault(): {testEmptyArr.FirstOrDefault()}");
			Console.WriteLine($"Array.LastOrDefault(): {testEmptyArr.LastOrDefault()}");
		}

		public static void MinMaxTest()
		{
			Console.WriteLine("Тест Max и Min");
			int[] testIntArr = new int[] { 56, 107, 8 , 16, 12, 18, 24 };
			Console.WriteLine("Тест для массива:");
			foreach (var item in testIntArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.WriteLine($"Array.Min(): {testIntArr.Min()}");
			Console.WriteLine($"Array.Max(): {testIntArr.Max()}");

		}

		public static void ReverseTest()
		{
			Console.WriteLine("Тест Reverse");
			string[] testStrArr = new string[] { "Ball", "Car", "Field", "House" };
			int[] testIntArr = new int[] { 14, 15, 5, 29 };
			int[] testEmptyArr = new int[] { };
			Console.WriteLine("Тест для массива:");
			foreach (var item in testStrArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.Write("Array.Reverse(): ");
			foreach (var item in testStrArr.Reverse())
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");

			Console.WriteLine("Тест для массива:");
			foreach (var item in testIntArr)
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
			Console.Write("Array.Reverse(): ");
			foreach (var item in testIntArr.Reverse())
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");

			Console.WriteLine("Тест для пустого массива:");
			Console.Write($"Array.Reverse(): ");
			foreach (var item in testEmptyArr.Reverse())
			{
				Console.Write($"{item} ");
			}
			Console.Write("\n");
		}

		public static void RunExtensionsTests()
		{
			AnyTest();
			Console.WriteLine();
			AllTest();
			Console.WriteLine();
			CountTest();
			Console.WriteLine();
			FirstLastTest();
			Console.WriteLine();
			MinMaxTest();
			Console.WriteLine();
			ReverseTest();
		}
	}
}
