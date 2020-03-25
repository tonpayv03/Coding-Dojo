using System;
using System.Collections.Generic;
using System.Text;

namespace CalGrade
{
	public interface IGradeCalculations
	{
		string CalGrade(int number);
		void DisplayGrade(string grade);
	}
}
