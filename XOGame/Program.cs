using System;

namespace XOGame
{
	class Program
	{
		static void Main(string[] args)
		{
			XOGame();
		}

		public static void XOGame()
		{
			BoardGame board = new BoardGame();

			int row = 0;
			int column = 0;
			bool isX = true;
			int input;
			bool isPlaying = true;

			while (isPlaying)
			{
				board.Board();

				Console.Write("Choose number: ");

				if (int.TryParse(Console.ReadLine(), out input))
				{
					ConvertHelper.ConvertNumberOfSlotToRowAndColumn(input, out row, out column);
				}

				bool canPlace = board.TakeSlot(isX, row, column);

				if (!canPlace)
				{
					Console.Clear();
					Console.WriteLine("You selected the wrong number. Please select again.");
				}
				else
				{
					isX = !canPlace;
				}

				string result = board.GetWinner();

				if (!string.IsNullOrEmpty(result) && result.Contains("Win"))
				{
					Console.Clear();
					Console.Write("***********");
					Console.Write(result);
					Console.WriteLine("***********");
					board.Board();
					isPlaying = false;
				}
				else if (string.IsNullOrEmpty(result))
				{
					Console.Clear();
					Console.Write("***********");
					Console.Write("IsDraw");
					Console.WriteLine("***********");
					board.Board();
					isPlaying = false;
				}
				
				if (!isPlaying)
				{
					Console.Write("Play Again: Press Other Key || Exit: Press X --> ");
					if (Console.ReadLine() == "X")
					{
						isPlaying = false;
					}
					else
					{
						isPlaying = true;
					}
					board.ClearBoard();
					Console.Clear();
				}
				else
				{
					Console.Clear();
				}
			}

			board.ShowScore(board.XScore,board.OScore,board.DrawScore);
		}
	}
}
