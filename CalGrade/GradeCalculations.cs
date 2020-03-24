using System;
using System.Collections.Generic;
using System.Text;

namespace CalGrade
{
	public class GradeCalculations : IGradeCalculations
	{
		private string Grade { get; set; }
		public GradeCalculations()
		{

		}
		public void CalGrade(int number)
		{
			if (number > 90 && number <= 100)
			{
				Grade = "A";
			}
			else if (number > 80 && number <= 90)
			{
				Grade = "B";
			}
			else if(number > 70 && number <= 80)
			{
				Grade = "C";
			}
			else if(number > 60 && number <= 70)
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

			DisplayGrade();
		}

		private void DisplayGrade()
		{
			Console.WriteLine("==========================");
			Console.WriteLine($"Result Grade: {Grade}");
			Console.WriteLine("==========================");
		}
	}
}
