
using atm;

var atmMoney = FileReader.ReadValuesFromFile("money.txt");
var atm = new ATM(atmMoney);

while (true)
{
	Console.Write("Enter amount of money: ");
	var amount = Console.ReadLine();
	atm.WithdrawMoney(int.Parse(amount));
	Console.Write("Press 'Enter' to repeat or any other key to exit");
	var key = Console.ReadKey().Key;
	if (key != ConsoleKey.Enter) break;
	Console.Clear();
}
