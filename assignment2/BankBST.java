//holds a binary search tree of accounts 
//with methods to alter and tranverse the tree
//as well as print
public class BankBST {
	// intializes tree nodes for BST
	
	Account bankAccount;
	BankBST left;
	BankBST right;

	// intializes the account for TNode by passin accountNum and balance into the
	// constructor
	public BankBST(int accountNum, double accountBalance) {
		bankAccount = new Account(accountNum, accountBalance);
	}
	//default constructor
	public BankBST(){
		bankAccount = null;
		left = null;
		right = null;
	}

	// recursion method for insert passes in the current root, account num (key) and
	// the balance while
	// returns the BST with inserted num
	private BankBST insertR(BankBST currRoot, int key, double balance) {
		// no root for tree
		if (currRoot == null) {
			// add Node to tree
			currRoot = new BankBST(key, balance);
		} // if key is less then currRoot key then move to the left tree node
		else if (key < currRoot.bankAccount.getKey())
			currRoot.left = insertR(currRoot.left, key, balance);
		// if key is more then currRoot key then move to the right sub tree node
		else if (key > currRoot.bankAccount.getKey())
			currRoot.right = insertR(currRoot.right, key, balance);

		return currRoot;
		}

	// recurssion method to find a bank account passed the current root and account
	// number
	// returns the account number if found
	private BankBST findR(BankBST currRoot, int accountNum) {
		// start as false untill sothing is found
		BankBST found = null;

		// if null return false
		if (currRoot == null)
			return null;
		// print current root bank num to console
		System.out.print(currRoot.bankAccount.getKey() + " ");

		// if account num is equal to current roots account num then set found to true
		if (currRoot.bankAccount.getKey() == accountNum) {
			found = currRoot;
			return found;
		}
		// else smaller then currRoot accountnum go to left sub tree
		else if (accountNum < currRoot.bankAccount.getKey())
		{
			found = findR(currRoot.left, accountNum);
		}
		// else if greater then go to right sub tree
		else
		{
			found = findR(currRoot.right, accountNum);
		}
		return found;
		
	}

	// recursion for removing a node from BST passed currRoot accountNum and parent
	// node
	// returns BST with node sharing accountNum removed
	private BankBST removeR(BankBST currRoot, int accountNum)
	{
		//if root is empty return
		if(currRoot == null)
			return currRoot;

		//if account number is smaller then the roots account num go to left subtree
		if(accountNum < currRoot.bankAccount.getKey())
		       currRoot.left = removeR(currRoot.left, accountNum);
		//else if bigger go right subtree
		else if (accountNum > currRoot.bankAccount.getKey())
		       currRoot.right = removeR(currRoot.right, accountNum);
		//else value found for removal
		else
		{
			//if it has no children just remove it
			if(currRoot.left == null && currRoot.right == null)
				return null;
			//if has one child
			else if(currRoot.left == null)
				return currRoot.right;
			else if(currRoot.right == null)
				return currRoot.left;
			else//if has both children
			{
				//find right leftmost root
				BankBST temp = leftmostRoot(currRoot.right);	

				//replace currRoot
				currRoot.right = removeR(currRoot.right, temp.bankAccount.getKey());
				//give temp same decendants as currRoot	
				temp.left = currRoot.left;
				temp.right = currRoot.right;
				return temp;

			}

		}
		return currRoot; 
	}

	//find min root
	private BankBST leftmostRoot(BankBST currRoot)
	{
		//find and return left most root
		while (currRoot.left != null)
			currRoot = currRoot.left;
		return currRoot;
	}

	/// recursion for traversing and printing bst in order
	private void transverseR(BankBST currRoot) {
		// check if tree is null
		if (currRoot == null)
			return;

		// traverse left subtree
		if (currRoot.left != null)
			transverseR(currRoot.left);

		// print current roots account num and balance
		System.out.println(currRoot.bankAccount.getKey() + " " + currRoot.bankAccount.getBalance());

		// traverse right subtree
		if (currRoot.right != null)
			transverseR(currRoot.right);

		return;

	}

	

	// root of BST
	BankBST root;

	// inserts new account into the tree passed the account num and balance
	public void insert(int accountNum, double accountBalance) {
		// insert into tree using recursion
		root = insertR(root, accountNum, accountBalance);

		return;
	}

	// find bank account passed account num and returns whether it is found or not
	public BankBST find(int accountNum) {
		// find bank account using recursion method
		BankBST found = findR(root, accountNum);
		System.out.println("");
		return found;
	}

	// removes node from binary search tree passed accountNum
	public void remove(int accountNum) {
		// call remove recurrsion;
		root = removeR(root, accountNum);

		return;
	}

	// traverses the bst printing the list as it goes using recursion
	public void transverse() {
		if (root != null)
			transverseR(root);

		return;
	}

	// runs a transaction passed in account num a type of transaction and and amount
	public void transaction(int accNum, String type, double amount) {
		BankBST account = null;
		double balance;
		// if deposit deposit amount into account
		if (type.compareTo("d") == 0) {
			
			//find bank account		
			account = find(accNum);
			// if account doesn't exist insert it into bank
			if(account == null)
				insert(accNum, amount);
			else //deposit money
			{
				balance = account.bankAccount.getBalance();
				balance = balance + amount;
				account.bankAccount.setBalance(balance);
			}
			
			return;
	
		} // if withdrawl withdrawl from bank account
		else if (type.compareTo("w") == 0) {
			
			//find bank account			
			account = find(accNum);
			// if account is null return
			if (account == null)
				return;
			// get account balance
			balance = account.bankAccount.getBalance();
			// check if you have money to withdraw
			if ((balance - amount) < 0) {
				System.err.println("can't have negative balance");
			} else {
				// set new balance after withdrawl
				balance = balance - amount;
				account.bankAccount.setBalance(balance);
			}
			return;
		} // if closure remove bank account
		else if(type.compareTo("c") == 0){
			
			//find account path			
			account = find(accNum);
			// remove bank account
			remove(accNum);
		} 
		else { // error
			System.err.println("transation type must be lower case d, w, or c");
		}
	}

}
