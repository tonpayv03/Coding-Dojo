using System;
using System.Collections.Generic;
using System.Text;

namespace XOGame
{
	public static class ConvertHelper
	{
		public static void ConvertNumberOfSlotToRowAndColumn(int number, out int row, out int column)
		{
			row = 0;
			column = 0;
			switch (number)
			{
				case 1:
					row = 0;
					column = 0;
					break;
				case 2:
					row = 0;
					column = 1;
					break;
				case 3:
					row = 0;
					column = 2;
					break;
				case 4:
					row = 1;
					column = 0;
					break;
				case 5:
					row = 1;
					column = 1;
					break;
				case 6:
					row = 1;
					column = 2;
					break;
				case 7:
					row = 2;
					column = 0;
					break;
				case 8:
					row = 2;
					column = 1;
					break;
				case 9:
					row = 2;
					column = 2;
					break;
				default:
					row = 99;
					column = 99;
					break;
			}
		}
	}
}
