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
				number = Convert.ToInt32(Console.ReadLine());

				gradeCal.CalGrade(number);

				Console.WriteLine("Exit: 0 , Again: Some Key");
				exit = Console.ReadLine().ToString();

				Console.Clear();
			}
		}
	}
}
