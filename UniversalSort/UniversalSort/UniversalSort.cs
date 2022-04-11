using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniversalSort
{
	public static class UniversalSort
	{
		public delegate void SortFunc<T>(T[] array, int startIndex, int endIndex, Comparison<T> comparison);
		public delegate void SortFuncComp<T>(T[] array, int startIndex, int endIndex);

		public static T[] Sort<T>(IEnumerable<T> array, SortFunc<T> sortFunc, Comparison<T> comparison, int? startIndex = null, int? endIndex = null)
		{
			T[] result = array.ToArray();
			if (result.Length == 0) return result;
			if (startIndex == null)
			{
				startIndex = 0;
			}
			if (endIndex == null)
			{
				endIndex = result.Length - 1;
			}
			sortFunc(result, (int)startIndex, (int)endIndex, comparison);
			return result;
		}

		public static T[] Sort<T>(IEnumerable<T> array, SortFuncComp<T> sortFunc, int? startIndex = null, int? endIndex = null) where T : IComparable
		{
			T[] result = array.ToArray();
			if (result.Length == 0) return result;
			if (startIndex == null)
			{
				startIndex = 0;
			}
			if (endIndex == null)
			{
				endIndex = result.Length - 1;
			}
			sortFunc(result, (int)startIndex, (int)endIndex);
			return result;
		}

		public static void QuickSort<T>(T[] array, int startIndex, int endIndex, Comparison<T> comparison)
		{
			int left = startIndex;
			int right = endIndex;
			T middle = array[(left + right) / 2];
			do
			{
				while (comparison(array[left], middle) < 0) ++left;
				while (comparison(array[right], middle) > 0) --right;
				if (left <= right)
				{
					if (left < right)
					{
						T tmp = array[left];
						array[left] = array[right];
						array[right] = tmp;
					}
					++left;
					--right;
				}
			}
			while (left <= right);
			if (startIndex < right)
				QuickSort(array, startIndex, right, comparison);
			if (left < endIndex)
				QuickSort(array, left, endIndex, comparison);
		}

		public static void QuickSort<T>(T[] array, int startIndex, int endIndex) where T : IComparable
		{
			int left = startIndex;
			int right = endIndex;
			T middle = array[(left + right) / 2];
			do
			{
				while (array[left].CompareTo(middle) < 0) ++left;
				while (array[right].CompareTo(middle) > 0) --right;
				if (left <= right)
				{
					if (left < right)
					{
						T tmp = array[left];
						array[left] = array[right];
						array[right] = tmp;
					}
					++left;
					--right;
				}
			}
			while (left <= right);
			if (startIndex < right)
				QuickSort(array, startIndex, right);
			if (left < endIndex)
				QuickSort(array, left, endIndex);
		}
		
		public static void BubbleSort<T>(T[] array, int startIndex, int endIndex, Comparison<T> comparison)
		{
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int i = startIndex; i < endIndex; i++)
				{
					if (comparison(array[i], array[i + 1]) > 0)
					{
						flag = true;
						var tmp = array[i];
						array[i] = array[i + 1];
						array[i + 1] = tmp;
					}
				}
			}
		}

		public static void BubbleSort<T>(T[] array, int startIndex, int endIndex) where T : IComparable
		{
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int i = startIndex; i < endIndex-1; i++)
				{
					if (array[i].CompareTo(array[i + 1]) > 0)
					{
						flag = true;
						var tmp = array[i];
						array[i] = array[i + 1];
						array[i + 1] = tmp;
					}
				}
			}
		}

		public static string ArrayToString<T>(T[] array)
		{
			string result = "{";
			for (int i = 0; i < array.Length; i++)
			{
				if(i != array.Length - 1) result += array[i].ToString() + ", ";
				else result += array[i].ToString();
			}
			result += "}";
			return result;
		}
	}
}
