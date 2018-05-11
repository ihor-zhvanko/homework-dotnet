using System;
namespace Parking
{
	public class CarListMenu : BaseMenu
    {
        public CarListMenu()
        {
			AddItem("1", "First Car", () => RemoveCar(1));
			AddItem("2", "Second Car", () => RemoveCar(2));
			AddItem("3", "Third Car", () => RemoveCar(3));
			AddItem("4", "Forth Car", () => RemoveCar(4));
			AddItem("5", "Fifth Car", () => RemoveCar(4));
        }

		public void RemoveCar(int id) {
			Console.WriteLine("Remove car: {0}", id);

			Router.Instance.Switch("default");
		} 
    }
}
