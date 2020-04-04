using System;
using System.Collections.Generic;
using System.Text;

namespace XOGame
{
	public class BoardManage
	{
		internal string[] Slot { get; set; }
		public BoardManage()
		{
			Slot = new string[9];
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

		public void ShowScore(int xScore, int oScore, int drawScore)
		{
			Console.WriteLine($"Score of X: {xScore.ToString()}");
			Console.WriteLine($"Score of O: {oScore.ToString()}");
			Console.WriteLine($"Score of Draw: {drawScore.ToString()}");
		}

		private string DisplayXO(int index)
		{
			return (!string.IsNullOrEmpty(Slot[index]) ? string.Format($" {Slot[index]} ") : $"[{index + 1}]");
		}
	}
}
