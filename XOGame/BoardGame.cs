using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGame
{
	public class BoardGame : IBoardGame
	{
		public int OScore { get; set; }
		public int XScore { get; set; }
		public string[] Slot { get; set; }
		public string CurrentTurn { get; set; }

		public BoardGame()
		{
			Slot = new string[9];
		}

		#region Method Section

		#region Public Method
		public string GetWinner()
		{
			return CheckWin();
		}

		public bool TakeSlot(bool isX, int row, int column)
		{
			bool currentTurn = false;
			int index;

			bool isProcess = VerifyInput(row, column, out index) ? true : false;

			if (isProcess)
			{
				currentTurn = CheckCurrentTurn();
				if (CheckSlotCanPlace(index)) // ถ้าเป็น null และเป็นตาที่ถูกต้อง ให้ลงได้
				{
					Slot[index] = CurrentTurn = currentTurn ? "X" : "O";
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public void Board()
		{
			Console.WriteLine("______Choie: 1-9_______");

			Console.WriteLine("       |       |        ");

			Console.WriteLine($"  {DisplayXO(0)}  |  {DisplayXO(1)}  |  {DisplayXO(2)}");

			Console.WriteLine("_______|_______|_______ ");

			Console.WriteLine("       |       |        ");

			Console.WriteLine($"  {DisplayXO(3)}  |  {DisplayXO(4)}  |  {DisplayXO(5)}");

			Console.WriteLine("_______|_______|_______ ");

			Console.WriteLine("       |       |        ");

			Console.WriteLine($"  {DisplayXO(6)}  |  {DisplayXO(7)}  |  {DisplayXO(8)}");

			Console.WriteLine("       |       |        ");
			Console.WriteLine("_______________________ ");

		}

		public void ClearBoard()
		{
			Slot = new string[9];
		}

		public void ShowScore()
		{
			Console.WriteLine($"Score of X: {XScore.ToString()}");
			Console.WriteLine($"Score of O: {OScore.ToString()}");
		}

		#endregion

		#region Private Method
		private bool CheckSlotCanPlace(int index)
		{
			return (Slot[index] == null);
		}

		private bool CheckCurrentTurn()
		{
			return Slot.Cast<string>().Count(va => va != null) % 2 == 0; // ถ้าลงตัว = เป็นตาของ X ถ้าไม่ = เป็นตาของ O
		}

		private bool VerifyInput(int row, int column, out int index)
		{
			index = 0;
			bool check = false;

			if (row != 99 && column != 99)
			{
				index = 3 * (row) + (column);
				check = true;
			}
			else
			{
				check = false;
			}

			return check;
		}

		private string DisplayXO(int index)
		{
			return (!string.IsNullOrEmpty(Slot[index]) ? string.Format($" {Slot[index]} ") : $"[{index + 1}]");
		}

		private string CheckWin()
		{
			string check = " ";

			if (IsHorizontalLine(0) || IsHorizontalLine(3) || IsHorizontalLine(6) ||
				IsLine(0, 4) || IsLine(2, 2) ||
				IsVerticalLine(0) || IsVerticalLine(1) || IsVerticalLine(2))
			{
				check = $"{CurrentTurn} Is Win";

				_ = (CurrentTurn == "X") ? XScore++ : OScore++;
			}

			if (Slot.Count(s => s != null) == 9)
			{
				if (IsDraw())
				{
					check = null;
				}
			}

			return check;
		}

		private bool IsDraw()
		{
			return Array.Exists(Slot, element => element != "0");
		}
		private bool IsMatch(int index0, int index1, int index2)
		{
			return Slot[index0] == CurrentTurn && Slot[index1] == CurrentTurn && Slot[index2] == CurrentTurn;
		}

		private bool IsLine(int start, int step)
		{
			return IsMatch(start, start + step, start + step + step);
		}

		private bool IsHorizontalLine(int startindex)
		{
			return IsLine(startindex, 1);
		}

		private bool IsVerticalLine(int startindex)
		{
			return IsLine(startindex, 3);
		}

		#endregion

		#endregion
	}
}

