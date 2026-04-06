using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Scripts;

namespace Roguelike.Assets
{
	public static class Tiles
	{
		public static readonly Tile Dot = new('.');
		public static readonly Tile Wall = new('#');
		public static readonly Tile Door = new('+');
		public static readonly Tile Empty = new(' ');
	}
}