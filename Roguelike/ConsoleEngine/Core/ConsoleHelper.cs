using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.ConsoleEngine.Core
{
	public static class ConsoleHelper
	{
		private const int STD_INPUT_HANDLE = -10;
		private const uint ENABLE_QUICK_EDIT = 0x0040;
		private const uint ENABLE_EXTENDED_FLAGS = 0x0080;

		[DllImport("kernel32.dll")]
		private static extern nint GetStdHandle(int nStdHandle);

		[DllImport("kernel32.dll")]
		private static extern bool GetConsoleMode(nint hConsoleHandle, out uint mode);

		[DllImport("kernel32.dll")]
		private static extern bool SetConsoleMode(nint hConsoleHandle, uint mode);

		public static void DisableQuickEdit()
		{
			nint handle = GetStdHandle(STD_INPUT_HANDLE);

			GetConsoleMode(handle, out uint mode);

			mode &= ~ENABLE_QUICK_EDIT;
			mode |= ENABLE_EXTENDED_FLAGS;

			SetConsoleMode(handle, mode);
		}
	}
}