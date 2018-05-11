using System;
using System.Linq;
using System.Collections.Generic;
using ParkingSimulator.Entities;
using System.Text;

namespace ParkingSimulator.UI
{
  public abstract class BaseMenu : IMenu
  {
    private IList<MenuItem> _items;
    protected Parking _parking;
    private string _caption;

    protected BaseMenu(string caption = "")
    {
      _items = new List<MenuItem>();
      _parking = Parking.Instance;
      _caption = caption;
    }

    protected void AddItem(string command, string caption, Action action)
    {
      var newItem = new MenuItem(command, caption);
      if (_items.Contains(newItem))
      {
        throw new ArgumentException("Failed to add MenuItem. Such command already exists in list");
      }
      newItem.Action = action;

      _items.Add(newItem);
    }

    protected void ClearItems()
    {
      _items.Clear();
    }

    public abstract void OnShow();

    public void Notify(string command)
    {
      var item = _items.FirstOrDefault(x => x.Command == command);
      if (item != null)
      {

        item.Action();
        Console.WriteLine("Press any key to continue . . .");
        Console.ReadKey(false);
      }
    }

    private static object consoleblocker = new object();
    public void Render()
    {
      var builder = new StringBuilder();

      builder.AppendLine($"----------- {_caption} ------------");

      foreach (var item in _items)
      {
        item.Render(builder);
      }
      builder.Append("> ");

      Console.Clear();
      Console.Write(builder);
    }

    protected void ForceEnterValidInt(string text, out int value, Func<int, bool> otherPredicate = null)
    {
      otherPredicate = otherPredicate ?? ((x) => true);
      do
      {
        Console.Write(text);

        if (!int.TryParse(Console.ReadLine(), out value) || !otherPredicate(value))
        {
          Console.WriteLine("Failed to parse or is not valid. Please try again . . .");
        }
        else
        {
          break;
        }
      } while (true);
    }
  }
}
