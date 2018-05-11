using System;
namespace Parking
{
	public interface IMenu
    {
		void Render();
		void Notify(string command);
    }
}
