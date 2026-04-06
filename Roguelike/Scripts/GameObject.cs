using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Scripts
{
	public class GameObject
	{
		public Vector2 position = new();

		public GameObject()
		{
			this.position.X = 0;
			this.position.Y = 0;
		}

		public GameObject(short x, short y)
		{
			this.position.X = x;
			this.position.Y = y;
		}

		public GameObject(short x, short y, char symbol,
			ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
		{
			this.position.X = x;
			this.position.Y = y;
		}

		public virtual void Update() { }

		//public virtual char Draw() { return sprite.symbol; }
	}
}