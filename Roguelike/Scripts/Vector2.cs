using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Scripts
{
	[Serializable]
	public struct Vector2
	{
		public short X { get; set; }
		public short Y { get; set; }

		public Vector2()
		{
			X = 0;
			Y = 0;
		}

		public Vector2(int x, int y)
		{
			this.X = (short)x;
			this.Y = (short)y;
		}

		public void SetPosition(int x, int y)
		{
			this.X = (short)x;
			this.Y = (short)y;
		}

		#region Operators
		public static Vector2 operator +(Vector2 left, Vector2 right)
		{
			return new(left.X + right.X, left.Y + right.Y);
		}

		public static Vector2 operator -(Vector2 left, Vector2 right)
		{
			return new(left.X - right.X, left.Y - right.Y);
		}

		public static Vector2 operator *(Vector2 left, Vector2 right)
		{
			return new(left.X * right.X, left.Y * right.Y);
		}

		public static Vector2 operator /(Vector2 left, Vector2 right)
		{
			return new(left.X / right.X, left.Y / right.Y);
		}

		public static Vector2 operator *(Vector2 left, int right)
		{
			return new(left.X * right, left.Y * right);
		}

		public static Vector2 operator /(Vector2 left, int right)
		{
			return new(left.X / right, left.Y / right);
		}

		public static bool operator !=(Vector2 left, Vector2 right)
		{
			return left.X != right.X || left.Y != right.Y;
		}

		public static bool operator ==(Vector2 left, Vector2 right)
		{
			return left.X == right.X && left.Y == right.Y;
		}

		public static bool operator >(Vector2 left, Vector2 right)
		{
			return left.X > right.X && left.Y > right.Y;
		}

		public static bool operator <(Vector2 left, Vector2 right)
		{
			return left.X < right.X && left.Y < right.Y;
		}

		public static bool operator >=(Vector2 left, Vector2 right)
		{
			return left.X >= right.X && left.Y >= right.Y;
		}

		public static bool operator <=(Vector2 left, Vector2 right)
		{
			return left.X <= right.X && left.Y <= right.Y;
		}
		#endregion
	}
}