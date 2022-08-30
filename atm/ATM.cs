namespace atm
{
	public class ATM
	{
		private SortedDictionary<int, int> banknotes;
		public ATM(SortedDictionary<int, int> banknotes)
		{
			this.banknotes = banknotes;
		}

		public void WithdrawMoney(decimal amount)
		{
			Console.WriteLine(CanWithdraw(amount, banknotes.Keys.ToList()) ? $"{amount} withdrawn" : $"Can not withdraw {amount}");
		}

		private bool CanWithdraw(decimal amount, IEnumerable<int> nominals)
		{
			if (amount == 0)
			{
				return true;
			}
			if (!nominals.Any())
			{
				return false;
			}

			var nominal = nominals.Last();
			var banknotesCount = banknotes[nominal];
			var divider = (int)amount / nominal;
			var count = divider < banknotesCount ? divider : banknotesCount;
			while (count >= 0)
			{
				var remainAmount = amount - count * nominal;
				if (CanWithdraw(remainAmount, nominals.Where(n => n != nominal))) {
					return true;
				}
				count--;
			}

			return false;
		}
	}
}