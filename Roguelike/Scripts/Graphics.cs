using Roguelike.Assets;

namespace Roguelike.Scripts
{
	public class Graphics
	{
		public const short HEIGHT = 20;
		private const short WIDTH = HEIGHT * 2;

		public char[,] buffer { get; private set; } = new char[WIDTH, HEIGHT];

		public void Begin()
		{
			Reset(Symbols.EMPTY);
			Console.SetCursorPosition(0, 0);
		}

		public void DrawField(char[,] field)
		{
			for (int j = 0; j < HEIGHT; j++)
				for (int i = 0; i < WIDTH; i++)
					buffer[i, j] = field[i, j];
		}

		public void Draw(char symbol, Vector2 position, ConsoleColor color) => buffer[position.X, position.Y] = symbol;

		public void End()
		{
			for (int j = 0; j < HEIGHT; j++)
			{
				for (int i = 0; i < WIDTH; i++)
					Console.Write(buffer[i, j]);

				Console.WriteLine();
			}
		}

		private void Reset(char bgChar)
		{
			for (int i = 0; i < WIDTH; i++)
				for (int j = 0; j < HEIGHT; j++)
					buffer[i, j] = bgChar;
		}
	}
}