using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSimulator.UI
{
    public class TopUpBalanceMenu : BaseMenu
    {
		public TopUpBalanceMenu() : base("Please select car before top up") { }

        public override void OnShow()
        {
            ClearItems();
            foreach (var car in _parking.Cars)
            {
                var id = car.Id;
                AddItem(id.ToString(), $"Car #{id} with balance {car.Balance}", () => TopUpBalance(id));
            }
        }

        public void TopUpBalance(int id)
        {
			int money;

			this.ForceEnterValidInt("How much? ", out money);

            _parking.TopUpBalance(id, money);
            Router.Instance.Switch("default");
        }
    }
}
