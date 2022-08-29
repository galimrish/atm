namespace atm
{
	public class ATM
	{
		private SortedList<int, int?> nominals;
		public ATM(SortedList<int, int?> bills)
		{
			nominals = bills;
		}

		public void WithdrawMoney(decimal amount)
		{
			nominals = new SortedList<int, int?>(nominals);
			Console.WriteLine(HasNominals(amount) ? $"{amount} withdrawn" : $"Can not withdraw {amount}");
		}

		private bool HasNominals(decimal amount)
		{
			var remainAmount = amount;
			while (remainAmount > 0)
			{
				var nominal = nominals.OrderByDescending(n => n.Key).FirstOrDefault(n => n.Key <= remainAmount && n.Value > 0);
				if (nominal.Value == null || nominal.Value == 0)
				{
					return false;
				}
				int i = 0;
				while (i < nominal.Value && nominal.Key <= remainAmount)
				{
					remainAmount -= nominal.Key;
					i++;
				}
				nominals[nominal.Key] = nominal.Value - i;
			}
			return true;
		}
	}
}