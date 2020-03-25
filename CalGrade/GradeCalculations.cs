using System;
using System.Collections.Generic;
using System.Text;

namespace CalGrade
{
	public class GradeCalculations : IGradeCalculations
	{
		public string CalGrade(int number)
		{

			string Grade;

			if (number >= 91 && number <= 100)
			{
				Grade = "A";
			}
			else if (number >= 81 && number <= 90)
			{
				Grade = "B";
			}
			else if(number >= 71 && number <= 80)
			{
				Grade = "C";
			}
			else if(number >= 61 && number <= 70)
			{
				Grade = "D";
			}
			else if(number >= 0 && number <= 60)
			{
				Grade = "F";
			}
			else
			{
				Grade = "Out of Range";
			}

			return Grade;
		}

		public void DisplayGrade(string Grade)
		{
			Console.WriteLine("==========================");
			Console.WriteLine($"Result Grade: {Grade}");
			Console.WriteLine("==========================");
		}
	}
}
