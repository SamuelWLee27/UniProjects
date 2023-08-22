//creates an account that has a key and balance
//with get set methods
public class Account
{	
	private int key;
	private double balance;

	//constructor to initialize fields
	public Account(int accountKey, double accountBalance)
	{
		this.key = accountKey;
		this.balance = accountBalance;
	}

	//get key value
	public int getKey()
	{
		return key;
	}
	//get balance value
	public double getBalance()
	{
		return balance;
	}

	//set new balance value passed a new account balance
	public void setBalance(double newBalance)
	{
		this.balance = newBalance;
	}
	




}
