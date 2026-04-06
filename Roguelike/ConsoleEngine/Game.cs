using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Roguelike.ConsoleEngine.Core;

namespace Roguelike.ConsoleEngine
{
	internal class Game : Engine
	{
		private string _title = "";
		private byte _width = 100;
		private byte _height = 40;
		private bool _fullscreen = false;

		public override bool IsRunning { get; set; }
		public override void Run()
		{
			const int FPS = 60;
			const int FRAME_DELAY = 1000 / FPS;

			var frameTimer = new Stopwatch();

			Initialize(_width, _height, _title, _fullscreen);

			do
			{
				frameTimer.Restart();

				Update();
				Draw();

				frameTimer.Stop();

				int elapsed = (int)frameTimer.ElapsedMilliseconds;
				if (FRAME_DELAY > elapsed)
					Thread.Sleep(FRAME_DELAY - elapsed);
			}
			while (IsRunning == true);

			Close();
		}

		public override void Initialize(byte w, byte h, string title, bool fullscreen)
		{
			this._title = title;
			this._width = w;
			this._height = h;
			this._fullscreen = fullscreen;

			ConsoleFullscreen.IsFullscreen = fullscreen;
			Console.OutputEncoding = Encoding.UTF8;

			ConsoleHelper.DisableQuickEdit();
			ConsoleWindow.DisableResizeAndMaximize();
			ConsoleFullscreen.SetFullscreen(ConsoleFullscreen.IsFullscreen);

			Console.SetWindowSize(w, h);
			try
			{
#pragma warning disable CA1416
				Console.SetBufferSize(w, h);
#pragma warning restore CA1416
			}
			// ReSharper disable once EmptyGeneralCatchClause
			catch (Exception exception) { return; }

			Console.Title = title;
			Console.CursorVisible = false;
			IsRunning = true;
		}

		public override void Update()
		{
			Console.SetCursorPosition(0, 0);
		}

		public override void Draw()
		{
			Console.ResetColor();
		}

		public override void Close()
		{
			Console.ResetColor();
			Console.Clear();

			Console.WriteLine("Game stop!! >:(");
		}
	}
}