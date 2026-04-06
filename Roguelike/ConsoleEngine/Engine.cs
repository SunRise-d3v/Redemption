using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.ConsoleEngine
{
	internal abstract class Engine
	{
		public abstract bool IsRunning { get; set; }
		public abstract void Run();
		public abstract void Initialize(byte w, byte h, string title, bool fullscreen);
		public abstract void Update();
		public abstract void Draw();
		public abstract void Close();
	}
}