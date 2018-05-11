using ParkingSimulator.Entities;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ParkingSimulator.UI
{
	public class MainMenu : BaseMenu
	{
		public MainMenu() : base("Main menu") {
			AddItem("1", "Add car", AddCar);
			AddItem("2", "Remove car", RemoveCar);
            AddItem("3", "Top up car balance", TopUpBalance);
            AddItem("4", "Show transactions for last minute", ShowTransactions);
			AddItem("5", "Show parking current state", ShowParkingState);
			AddItem("0", "Close", Close);
		}

		public void AddCar()
		{
            int id;
            int balance;
            int type;
            Console.WriteLine(">>> New CAR <<<");
			ForceEnterValidInt(" Id: ", out id);

			ForceEnterValidInt(" Balance: ", out balance);

            var enumValues = Enum.GetValues(typeof(CarType));
            for(var i = 0; i < enumValues.Length; ++i)
            {
                Console.WriteLine($"  {i + 1}. {enumValues.GetValue(i)}");
            }

            // I know that 1 and 4 are magic numbers. don't judge me.
            // I had not so much time
			ForceEnterValidInt(" Type:", out type, (x) => x >= 1 && x <= 4);

            _parking.AddCar(new Car
            {
                Id = id,
                Balance = balance,
                Type = (CarType)(type - 1)
            });

            Console.WriteLine("Car added successfully");
        }      

		public void RemoveCar()
        {
			if(_parking.Cars.Count == 0) {
				Console.WriteLine("Sorry, nothing to remove . . .");
				return;
			}

            Router.Instance.Switch("remove-car");
        }

        public void TopUpBalance()
        {
			if (_parking.Cars.Count == 0)
            {
                Console.WriteLine("Sorry, no cars currently . . .");
                return;
            }

            Router.Instance.Switch("topup-balance");
        }

        public void ShowTransactions()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Transactions:");
            var transactions = _parking.LastMinuteTransactions
                .Select(x => $"[{x.Timestamp}] From car with id = {x.CarId} was debited {x.Debited}");

            builder.AppendJoin(Environment.NewLine, transactions)
                .Append(Environment.NewLine);

			Console.WriteLine(builder.ToString());
        }

		public void ShowParkingState() {
			var builder = new StringBuilder();
            for (int i = 0; i < Console.WindowWidth; ++i)
            {
                builder.Append('-');
            }

            builder.AppendLine("Parking State. ")
                .Append($"Balance: {_parking.Balance} | ")
                .Append($"Last minute income: {_parking.LastMinuteIncome} | ")
                .Append($"Capacity: {_parking.MaxCapacity} | ")
                .AppendLine($"Free space: {_parking.FreeSpace}");

            for (int i = 0; i < Console.WindowWidth; ++i)
            {
                builder.Append('-');
            }

			Console.WriteLine(builder);
		}

        public void Close() {
			Process.GetCurrentProcess().Kill();
		}

        public override void OnShow()
        {
            // do nothing. Menu is static
        }
    }
}
