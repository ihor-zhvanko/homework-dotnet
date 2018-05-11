using System;
namespace ParkingSimulator.UI
{
  public interface IMenu
  {
    void OnShow();
    void Render();
    void Notify(string command);
  }
}
