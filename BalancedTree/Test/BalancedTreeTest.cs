using System;
using System.Collections.Generic;
using BalancedTree;

namespace Test
{
	class BalancedTreeTest
	{
		public static void Test1()
		{
			Console.WriteLine("Test 1");
			var tree1 = new BalancedTree<int>(); //Создание пустого дерева целых чисел
			var tree2 = new BalancedTree<int>(new int[] { 16, 108, 1, 28, 45, 7, 15, 2, 61 }); //Создание дерева целых чисел по переданному массиву

			tree1.Add(16);						//Добавление узлов, прердавая значение или узел
			tree1.Add(new BalancedTreeNode<int>(108));
			tree1.Add(1);
			tree1.Add(28);
			tree1.Add(45);
			tree1.Add(7);
			tree1.Add(15);
			tree1.Add(new BalancedTreeNode<int>(2));
			tree1.Add(61);
			foreach (var item in tree1)   //Печать дерева с помощью интерфейса IEnumerable<T>
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
			foreach (var item in tree2)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
			Console.WriteLine($"Деревья одинаковые? : {tree1.Equals(tree2)}"); //Проверка на равенство деревьев

			tree1.Remove(28);				//Удаление узлов деревьев
			tree2.Remove(new BalancedTreeNode<int>(45));
			Console.WriteLine(tree1);
			Console.WriteLine(tree2);

			Console.WriteLine($"Теперь деревья одинаковые? : {tree1.Equals(tree2)}"); //Повторная проверка на равенство деревьев

			Console.WriteLine($"Содержит ли первое дерево 28? : {tree1.Contains(28)}");
			Console.WriteLine($"Содержит ли первое дерево 7? : {tree1.Contains(7)}");
			tree1.Clear();
			tree2.Clear();
		}

		public static void Test2()
		{
			Console.WriteLine("Test 1");
			var studentsTree = new BalancedTree<Student>(); //Создаем и заполняем список студентов
			studentsTree.Add(new Petya());
			studentsTree.Add(new Ann());
			studentsTree.Add(new John());
			studentsTree.Add(new Dave());
			studentsTree.Add(new Vasya());
			Console.WriteLine(studentsTree); //Работа метода ToString
			studentsTree.Find(new Petya()).Data.math++; //Находим узел Petya и увеличиваем math


			List<Student> preOrderList = new();
			List<Student> postOrderList = new();

			studentsTree.PreOrder(preOrderList.Add); //Заполнение списка префиксным обходом дерева
			studentsTree.PostOrder(postOrderList.Add); //Заполнение списка постфиксным обходом дерева

			foreach (var student in preOrderList)
			{
				Console.Write($"{student}  ");
			}
			Console.WriteLine();

			foreach (var student in postOrderList)
			{
				Console.Write($"{student}  ");
			}
			Console.WriteLine();

			Student[] students = new Student[5];
			studentsTree.CopyTo(students, 0); //Использование CopyTo и вывод массива в консоль
			studentsTree.Clear();
			foreach(var student in students)
			{
				Console.Write($"{student}  ");
			}
		}

		public static void RunBalancedTreeTests()
		{
			Test1();
			Console.WriteLine();
			Console.WriteLine();
			Test2();
		}
	}

	public class Student : IComparable<Student>
	{
		public string name;
		public uint math;
		public uint physics;

		public override bool Equals(object obj)
		{
			if (obj is Student student)
			{
				return name.Equals(student.name);
			}
			return false;
		}
		public override string ToString()
		{
			return $"{name}: math-{math}, physics-{physics}";
		}

		public int CompareTo(Student other)
		{
			return name.CompareTo(other.name);
		}
	}

	public class John : Student
	{
		public John()
		{
			name = "John";
			math = 4;
			physics = 3;
		}
	}
	public class Ann : Student
	{
		public Ann()
		{
			name = "Ann";
			math = 3;
			physics = 3;
		}
	}
	public class Vasya : Student
	{
		public Vasya()
		{
			name = "Vasya";
			math = 5;
			physics = 5;
		}
	}
	public class Petya : Student
	{
		public Petya()
		{
			name = "Petya";
			math = 2;
			physics = 3;
		}
	}
	public class Dave : Student
	{
		public Dave()
		{
			name = "Dave";
			math = 4;
			physics = 5;
		}
	}
}
