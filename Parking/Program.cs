using System;using System.Collections.Generic;
using ParkingSimulator.UI;using ParkingSimulator.Workers;

namespace ParkingSimulator{   	public class Program    {		static void Main(string[] args)		{			var homework = new Program();            
            try
            {
                homework.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }		}        		public Program()		{			Router.Instance.Routes = new Dictionary<string, IMenu>			{				["default"] = new MainMenu(),                ["remove-car"] = new RemoveCarMenu(),                ["topup-balance"] = new TopUpBalanceMenu()			};		}		private IMenu CurrentMenu => Router.Instance.Current;		public void Start() {            var parkingWorker = new ParkingWorker();            var transactionWorker = new TransactionWorker();

            parkingWorker.Start();
            transactionWorker.Start();			Router.Instance.Switch("default");

            while (true) {				CurrentMenu.Render();				var command = Console.ReadLine();				CurrentMenu.Notify(command);			}		}    }}