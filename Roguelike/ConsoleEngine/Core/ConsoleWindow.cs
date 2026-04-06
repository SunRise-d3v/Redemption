using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.ConsoleEngine.Core
{
	public static class ConsoleWindow
	{
		[DllImport("kernel32.dll")]
		private static extern nint GetConsoleWindow();

		[DllImport("user32.dll")]
		private static extern nint GetSystemMenu(nint hWnd, bool bRevert);

		[DllImport("user32.dll")]
		private static extern bool DeleteMenu(nint hMenu, uint uPosition, uint uFlags);

		private const uint SC_SIZE = 0xF000;
		private const uint SC_MAXIMIZE = 0xF030;
		private const uint MF_BYCOMMAND = 0x00000000;

		public static void DisableResizeAndMaximize()
		{
			var handle = GetConsoleWindow();
			var menu = GetSystemMenu(handle, false);

			DeleteMenu(menu, SC_SIZE, MF_BYCOMMAND);
			DeleteMenu(menu, SC_MAXIMIZE, MF_BYCOMMAND);
		}
	}
}