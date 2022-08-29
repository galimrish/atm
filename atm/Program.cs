
using atm;

var atmMoney = FileReader.ReadValuesFromFile("money.txt");
var atm = new ATM(atmMoney);

Console.Write("Enter amount of money: ");
var amount = Console.ReadLine();
atm.WithdrawMoney(int.Parse(amount));
