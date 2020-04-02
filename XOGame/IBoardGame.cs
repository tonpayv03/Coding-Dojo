using System;
using System.Collections.Generic;
using System.Text;

namespace XOGame
{
	public interface IBoardGame
	{
		string GetWinner();
		bool TakeSlot(bool isX, int row, int column);
	}
}
