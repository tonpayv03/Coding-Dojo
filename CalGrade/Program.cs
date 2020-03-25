using Microsoft.Extensions.DependencyInjection;
using System;

namespace CalGrade
{
	class Program
	{
		static void Main(string[] args)
		{
			string exit = "1";
			int number;
			var serviceProvider = new ServiceCollection()
			.AddSingleton<IGradeCalculations, GradeCalculations>()
			.BuildServiceProvider();

			var gradeCal = serviceProvider.GetService<IGradeCalculations>();

			while (exit != "0")
			{
				Console.Write("Please Enter Score: ");


				string inputValue = Console.ReadLine();

				bool isnumeric = int.TryParse(inputValue, out number);

				if (isnumeric)
				{
					string Grade = gradeCal.CalGrade(number);
					gradeCal.DisplayGrade(Grade);

					Console.WriteLine("Exit: 0 , Again: Some Key");
					exit = Console.ReadLine();
				}

				Console.Clear();
			}
		}
	}
}
