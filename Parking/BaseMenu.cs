using System;
using System.Linq;
using System.Collections.Generic;

namespace Parking
{
	public abstract class BaseMenu : IMenu
    {
		private IList<MenuItem> _items;

        protected BaseMenu()
        {
			_items = new List<MenuItem>();
        }     

		protected void AddItem(string command, string caption, Action action)
		{
			var newItem = new MenuItem(command, caption);
			if(_items.Contains(newItem)) {
				throw new ArgumentException("Failed to add MenuItem. Such command already exists in list");
			}
			newItem.Action = action;

			_items.Add(newItem);
		}
        
		public void Notify(string command)
		{
			var item = _items.FirstOrDefault(x => x.Command == command);
			if(item != null) {

				item.Action();
				Console.WriteLine("Press any key to continue . . .");
				Console.ReadKey(false);
			}
		}

		public void Render(){
			Console.Clear();
            Console.WriteLine(this.GetType().Name);
            foreach (var item in _items)
            {
                item.Render();
            }
		}
	}
}
