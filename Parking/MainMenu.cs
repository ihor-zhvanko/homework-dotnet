using System;
using System.Diagnostics;

namespace Parking
{
	public class MainMenu : BaseMenu
	{
		public MainMenu() {
			AddItem("1", "Add car", AddCar);
			AddItem("2", "Remove car", RemoveCar);
            AddItem("3", "Debit car", AddCar);
            AddItem("4", "Give money for car", AddCar);
            AddItem("5", "Show balance", AddCar);
			AddItem("0", "Close", Close);
		}

		public void AddCar()
		{
			Console.WriteLine("Every thing is okay");

		}

		public void RemoveCar() {
			Router.Instance.Switch("CarListMenu");
		}

		public void Close() {
			Process.GetCurrentProcess().Kill();
		}
	}
}
