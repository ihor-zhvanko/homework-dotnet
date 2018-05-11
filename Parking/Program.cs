using System;
using System.Collections.Generic;

namespace Parking
{   
	public class Program
    {
		static void Main(string[] args)
		{
			var homework = new Program();
			homework.Start();
		}
        
		public Program()
		{
			Router.Instance.Routes = new Dictionary<string, IMenu>
			{
				["default"] = new MainMenu(),
				["CarListMenu"] = new CarListMenu()
			};
		}

		private IMenu CurrentMenu => Router.Instance.Current;

		public void Start() {
			while(true) {
				CurrentMenu.Render();
				var command = Console.ReadLine();
				CurrentMenu.Notify(command);
			}
		}

    }
}
