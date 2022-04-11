using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using static UniversalSort.UniversalSort;

namespace Test
{
	public static class Test
	{
		public static void Test1()
		{
			Console.WriteLine("Сортировка пузырьком для массива int");
			int[] test1;
			int[] test2;
			int[] test3;
			int[] test4;

			string path = "Test1.txt";
			using StreamReader testFile = new StreamReader(path);
			string str1 = testFile.ReadLine();
			if (str1.Length != 0) test1 = str1.Split(' ').Select(x => int.Parse(x)).ToArray();
			else test1 = new int[] { };
			string str2 = testFile.ReadLine();
			if (str2.Length != 0) test2 = str2.Split(' ').Select(x => int.Parse(x)).ToArray();
			else test2 = new int[] { };
			string str3 = testFile.ReadLine();
			if (str3.Length != 0) test3 = str3.Split(' ').Select(x => int.Parse(x)).ToArray();
			else test3 = new int[] { };
			string str4 = testFile.ReadLine();
			if (str4.Length != 0) test4 = str4.Split(' ').Select(x => int.Parse(x)).ToArray();
			else test4 = new int[] { };
			testFile.Close();

			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test1)}: {ArrayToString(Sort(test1, BubbleSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test2)}: {ArrayToString(Sort(test2, BubbleSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test3)}: {ArrayToString(Sort(test3, BubbleSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test4)}: {ArrayToString(Sort(test4, BubbleSort))}");
		}

		public static void Test2()
		{
			Console.WriteLine("Quicksort для массива char");
			char[] test1;
			char[] test2;
			char[] test3;
			char[] test4;

			string path = "Test2.txt";
			using StreamReader testFile = new StreamReader(path);
			string str1 = testFile.ReadLine();
			if (str1.Length != 0) test1 = str1.Split(' ').Select(x => char.Parse(x)).ToArray();
			else test1 = new char[] { };
			string str2 = testFile.ReadLine();
			if (str2.Length != 0) test2 = str2.Split(' ').Select(x => char.Parse(x)).ToArray();
			else test2 = new char[] { };
			string str3 = testFile.ReadLine();
			if (str3.Length != 0) test3 = str3.Split(' ').Select(x => char.Parse(x)).ToArray();
			else test3 = new char[] { };
			string str4 = testFile.ReadLine();
			if (str4.Length != 0) test4 = str4.Split(' ').Select(x => char.Parse(x)).ToArray();
			else test4 = new char[] { };
			testFile.Close();

			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test1)}: {ArrayToString(Sort(test1, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test2)}: {ArrayToString(Sort(test2, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test3)}: {ArrayToString(Sort(test3, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test4)}: {ArrayToString(Sort(test4, QuickSort))}");
		}

		public static void Test3()
		{
			Console.WriteLine("Quicksort для массива string в указанном диапазоне");
			string[] test1;
			string[] test2;
			string[] test3;
			string[] test4;

			string path = "Test3.txt";
			using StreamReader testFile = new StreamReader(path);
			string str1 = testFile.ReadLine();
			if (str1.Length != 0) test1 = str1.Split(' ');
			else test1 = new string[] { };
			string str2 = testFile.ReadLine();
			if (str2.Length != 0) test2 = str2.Split(' ');
			else test2 = new string[] { };
			string str3 = testFile.ReadLine();
			if (str3.Length != 0) test3 = str3.Split(' ');
			else test3 = new string[] { };
			string str4 = testFile.ReadLine();
			if (str4.Length != 0) test4 = str4.Split(' ');
			else test4 = new string[] { };
			testFile.Close();

			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test1)}: {ArrayToString(Sort(test1, QuickSort, 1, 7))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test2)}: {ArrayToString(Sort(test2, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test3)}: {ArrayToString(Sort(test3, QuickSort, 0, 3))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test4)}: {ArrayToString(Sort(test4, QuickSort, 1, 4))}");
		}
		public static void Test4()
		{
			Console.WriteLine("Сортировка пузырьком для массива int с использованием компаратора");
			int[] test1;
			int[] test2;
			int[] test3;
			int[] test4;

			string path = "Test4.txt";
			using StreamReader testFile = new StreamReader(path);
			string str1 = testFile.ReadLine();
			if (str1.Length != 0) test1 = str1.Split(' ').Select(x => int.Parse(x)).ToArray();
			else test1 = new int[] { };
			string str2 = testFile.ReadLine();
			if (str2.Length != 0) test2 = str2.Split(' ').Select(x => int.Parse(x)).ToArray();
			else test2 = new int[] { };
			string str3 = testFile.ReadLine();
			if (str3.Length != 0) test3 = str3.Split(' ').Select(x => int.Parse(x)).ToArray();
			else test3 = new int[] { };
			string str4 = testFile.ReadLine();
			if (str4.Length != 0) test4 = str4.Split(' ').Select(x => int.Parse(x)).ToArray();
			else test4 = new int[] { };
			testFile.Close();

			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test1)}: {ArrayToString(Sort(test1, BubbleSort, ReverseComparison))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test2)}: {ArrayToString(Sort(test2, BubbleSort, ReverseComparison))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test3)}: {ArrayToString(Sort(test3, BubbleSort, ReverseComparison))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test4)}: {ArrayToString(Sort(test4, BubbleSort, ReverseComparison))}");
		}


		public static void Test5()
		{
			Console.WriteLine("Quicksort для массива bool");
			bool[] test1;
			bool[] test2;
			bool[] test3;
			bool[] test4;

			string path = "Test5.txt";
			using StreamReader testFile = new StreamReader(path);
			string str1 = testFile.ReadLine();
			if (str1.Length != 0) test1 = str1.Split(' ').Select(x => bool.Parse(x)).ToArray();
			else test1 = new bool[] { };
			string str2 = testFile.ReadLine();
			if (str2.Length != 0) test2 = str2.Split(' ').Select(x => bool.Parse(x)).ToArray();
			else test2 = new bool[] { };
			string str3 = testFile.ReadLine();
			if (str3.Length != 0) test3 = str3.Split(' ').Select(x => bool.Parse(x)).ToArray();
			else test3 = new bool[] { };
			string str4 = testFile.ReadLine();
			if (str4.Length != 0) test4 = str4.Split(' ').Select(x => bool.Parse(x)).ToArray();
			else test4 = new bool[] { };
			testFile.Close();

			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test1)}: {ArrayToString(Sort(test1, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test2)}: {ArrayToString(Sort(test2, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test3)}: {ArrayToString(Sort(test3, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test4)}: {ArrayToString(Sort(test4, QuickSort))}");
		}

		public static void Test6()
		{
			Console.WriteLine("Quicksort для массива Person");
			Person[] test1 = new Person[] {new Person("Alex", 1000), new Person("Tom", 300), new Person("John", 550), new Person("May", 700)};
			Person[] test2 = new Person[] { };
			Person[] test3 = new Person[] { new Person("Alex", 1000), new Person("Tom", 2000), new Person("John", 3000), new Person("May", 4000) };
			Person[] test4 = new Person[] { new Person("Alex", 700), new Person("Tom", 600), new Person("John", 200), new Person("May", 50) }; ;

			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test1)}: {ArrayToString(Sort(test1, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test2)}: {ArrayToString(Sort(test2, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test3)}: {ArrayToString(Sort(test3, QuickSort))}");
			Console.WriteLine($"Результат сортировки для массива{ArrayToString(test4)}: {ArrayToString(Sort(test4, QuickSort))}");
		}

		public static void RunTests()
		{
			Test1();
			Console.WriteLine();
			Console.WriteLine();
			Test2();
			Console.WriteLine();
			Console.WriteLine();
			Test3();
			Console.WriteLine();
			Console.WriteLine();
			Test4();
			Console.WriteLine();
			Console.WriteLine();
			Test5();
			Console.WriteLine();
			Console.WriteLine();
			Test6();
			Console.WriteLine();
			Console.WriteLine();
		}

		private static int ReverseComparison(int x, int y)
		{
			return y - x;
		}
	}

	class Person : IComparable
	{
		public int salary;
		public string name;

		public Person(string name, int salary)
		{
			this.name = name;
			this.salary = salary;
		}

		public int CompareTo(object obj)
		{
			if (obj is Person other) return salary - other.salary;
			else throw new InvalidCastException();
		}

		public override string ToString()
		{
			return $"{name}: {salary}";
		}
	}
}
