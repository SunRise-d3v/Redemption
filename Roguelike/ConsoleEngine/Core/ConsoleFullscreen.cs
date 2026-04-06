using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.ConsoleEngine.Core
{
	using System;
	using System.Runtime.InteropServices;

	public static class ConsoleFullscreen
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool SetConsoleDisplayMode(IntPtr hConsoleOutput, uint dwFlags, out Coordination lpNewScreenBufferDimensions);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetStdHandle(int nStdHandle);

		private const int SW_MAXIMIZE = 3;
		private const int SW_RESTORE = 9;
		private const int STD_OUTPUT_HANDLE = -11;
		private const uint CONSOLE_FULLSCREEN_MODE = 1;
		private const uint CONSOLE_WINDOWED_MODE = 2;

		public static bool IsFullscreen = false;

		public static void SetFullscreen(bool enable)
		{
			IntPtr hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
			IntPtr hwnd = GetConsoleWindow();
			if (hwnd == IntPtr.Zero)
				return;

			if (enable)
			{
				SetConsoleDisplayMode(hConsole, CONSOLE_FULLSCREEN_MODE, out _);
				ShowWindow(hwnd, SW_MAXIMIZE);
			}
			else
			{
				SetConsoleDisplayMode(hConsole, CONSOLE_WINDOWED_MODE, out _);
				ShowWindow(hwnd, SW_RESTORE);
			}

			IsFullscreen = enable;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct Coordination
		{
			private short X;
			private short Y;
		}
	}
}