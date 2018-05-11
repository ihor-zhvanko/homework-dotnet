using System;
namespace Parking
{
    public class MenuItem
    {
        public MenuItem(string command, string caption = "Unknown command")
        {
			Command = command;
			Caption = caption;
        }

		public string Command { get; }
		public string Caption { get; }
		public Action Action { get; set; }

		public override bool Equals(object obj)
		{
			var tObj = obj as MenuItem;
			return tObj?.Command == this.Command;
		}

		public override int GetHashCode()
		{
			return Command.GetHashCode();
		}

		public void Render()
		{
			Console.WriteLine($"[ {Command} ] {Caption}");
		}
	}
}
