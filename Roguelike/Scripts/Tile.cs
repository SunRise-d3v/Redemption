using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Scripts
{
	[Serializable]
	public struct Tile
	{
		public char Symbol { get; set; }
		public ConsoleColor Foreground { get; set; }
		public ConsoleColor Background { get; set; }

		public Tile(char symbol,
			ConsoleColor fg = ConsoleColor.White,
			ConsoleColor bg = ConsoleColor.Black)
		{
			this.Symbol = symbol;

			Foreground = fg;
			Background = bg;
		}

		public void Draw(int x, int y)
		{
			var defaultFg = Console.ForegroundColor;
			var defaultBg = Console.BackgroundColor;

			Console.ForegroundColor = Foreground;
			Console.BackgroundColor = Background;

			Console.SetCursorPosition(x, y);
			Console.Write(Symbol);

			Console.ForegroundColor = defaultFg;
			Console.BackgroundColor = defaultBg;
		}
	}
}