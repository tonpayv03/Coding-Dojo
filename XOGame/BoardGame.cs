using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGame
{
	public class BoardGame : BoardManage, IBoardGame
	{
		public int OScore { get; set; }
		public int XScore { get; set; }
		public int DrawScore { get; set; }
		public string CurrentTurn { get; set; }

		public BoardGame() : base()
		{

		}

		#region Method Section

		#region Public Method
		public string GetWinner()
		{
			return CheckWin();
		}

		public bool TakeSlot(bool isX, int row, int column)
		{
			int index;
			bool canTakeSlot = VerifyInput(row, column, out index) && CheckSlotCanPlace(index);

			if (!canTakeSlot)
			{
				return false;
			}
			Slot[index] = CurrentTurn = CheckCurrentTurn() ? "X" : "O";
			return true;
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
			bool checkInput = (row != 99 && column != 99);

			if (checkInput)
			{
				index = 3 * (row) + (column);
			}
			return checkInput;
		}

		private string CheckWin()
		{
			string check = " ";

			if (IsHorizontalLine(0) || IsHorizontalLine(3) || IsHorizontalLine(6) ||
				IsLine(0, 4) || IsLine(2, 2) ||
				IsVerticalLine(0) || IsVerticalLine(1) || IsVerticalLine(2))
			{
				check = $"{CurrentTurn} Is Win";

				bool shouldUpdateScore = (CurrentTurn == "X") ? true : false;
				if (shouldUpdateScore)
				{
					XScore++;
				}
				else
				{
					OScore++;
				}
			}
			else
			{
				var shouldReset = (Slot.Count(s => s != null) == 9) && IsDraw();
				if (shouldReset)
				{
					DrawScore++;
				}
				check = shouldReset ? null : check;
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

