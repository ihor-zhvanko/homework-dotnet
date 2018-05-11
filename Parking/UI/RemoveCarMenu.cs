using System;
namespace ParkingSimulator.UI
{
  public class RemoveCarMenu : BaseMenu
  {
    public RemoveCarMenu() : base("Please select what car to remove")
    {

    }

    public override void OnShow()
    {
      ClearItems();
      foreach (var car in _parking.Cars)
      {
        var id = car.Id;
        AddItem(id.ToString(), $"Car #{id} with balance {car.Balance}", () => RemoveCar(id));
      }
    }

    public void RemoveCar(int id)
    {
      var isRemoved = _parking.RemoveCar(id);

      if (isRemoved)
      {
        Console.WriteLine("Removed car: {0}", id);
      }
      else
      {
        Console.WriteLine("Sorry, but this car has fine. First top up a balance and then try again");
      }

      Router.Instance.Switch("default");
    }
  }
}
