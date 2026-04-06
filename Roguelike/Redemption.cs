using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Roguelike.Assets;
using Roguelike.ConsoleEngine;
using Roguelike.Scripts;

namespace Roguelike
{
	internal class Redemption : Game
	{
		public const short HEIGHT = 20;
		private const short WIDTH = HEIGHT * 2;

		private char[,] map = new char[WIDTH, HEIGHT];

		private  readonly Graphics _graphics = new Graphics();
		
		private GameObject _player;

		public override void Initialize(byte w, byte h, string title, bool fullscreen)
		{
			base.Initialize(w, h, "Redemption", false);

			_player = new();

			GenerateMap();
			SpawnPlayer();
		}

		public override void Update()
		{
			base.Update();

			if (!Console.KeyAvailable)
				return;

			var keyChar = Console.ReadKey(true).Key;
			switch (keyChar)
			{
				case ConsoleKey.Escape:
					IsRunning = false;
					break;

				case ConsoleKey.NumPad8:
				case ConsoleKey.W:
					if (_player.position.Y > 0)
						_player.position.Y--;
					break;

				case ConsoleKey.NumPad4:
				case ConsoleKey.A:
					if (_player.position.X > 0)
						_player.position.X--;
					break;

				case ConsoleKey.NumPad2:
				case ConsoleKey.S:
					if (_player.position.Y < HEIGHT - 1)
						_player.position.Y++;
					break;

				case ConsoleKey.NumPad6:
				case ConsoleKey.D:
					if (_player.position.X < WIDTH - 1)
						_player.position.X++;
					break;

				case ConsoleKey.NumPad7:
					if (_player.position.X > 0)
						_player.position.X--;
					if (_player.position.Y > 0)
						_player.position.Y--;
					break;

				case ConsoleKey.NumPad9:
					if (_player.position.X < WIDTH - 1)
						_player.position.X++;
					if (_player.position.Y > 0)
						_player.position.Y--;
					break;

				case ConsoleKey.NumPad1:
					if (_player.position.X > 0)
						_player.position.X--;
					if (_player.position.Y < HEIGHT - 1)
						_player.position.Y++;
					break;

				case ConsoleKey.NumPad3:
					if (_player.position.X < WIDTH - 1)
						_player.position.X++;
					if (_player.position.Y < HEIGHT - 1)
						_player.position.Y++;
					break;
			}
		}

		public override void Draw()
		{
			base.Draw();

			_graphics.Begin();
			_graphics.DrawField(map);

			_graphics.Draw(Symbols.PLAYER, _player.position, ConsoleColor.White);
			
			_graphics.End();
		}

		public void GenerateMap()
		{
			for (int x = 0; x < map.GetLength(0); x++)
			{
				for (int y = 0; y < map.GetLength(1); y++)
				{
					map[x, y] = Symbols.DOT;
				}
			}

			var rand = new Random();
			byte iteration = 99;

			for (int i = 0; i < iteration; i++)
			{
				int x = rand.Next(WIDTH);
				int y = rand.Next(HEIGHT);

				map[x, y] = Symbols.WALL;
			}
		}

		public void SpawnPlayer()
		{
			var rand = new Random();
			_player.position.X = (short)rand.Next(WIDTH);
			_player.position.Y = (short)rand.Next(HEIGHT);
		}
	}
}