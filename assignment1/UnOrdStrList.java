//this is a class for an unordered string linked list and it's methods
public class UnOrdStrList
{
	//inner class that creates a string node 
	private class StrNode 
	{
		private String key;
		private StrNode next;
		//constructer for string node that intializes the key
		public StrNode(String s)
		{
			key = s;
		}
	}
	//create head string node of list
	private StrNode head;
	
	//method the looks for the string parsed into list through parameter 
	//String s and return if its found as a boolean
	public boolean has(String s)
	{
		//goes to start of list
		StrNode curr = head;
		
		//looks through list until either s is found or it reaches the end of the list
		while(curr != null)
			if(curr.key.compareTo(s) == 0)
				return true;
			else 
				curr = curr.next;
		return false;
	}
	
	//adds new node with key value s to front of the list and returns void
	public void add(String s)
	{
		 //creates new node with s as key value and adds to start of list
		 StrNode temp = new StrNode(s);
		 temp.next = head;
		 head = temp;
		 return;
	}
	
	//removes node with key value s from list then returns void
	public void remove(String s)
	{
		//goes to start of list
		StrNode curr = head;

		//if s is the same as the head key make next string the head of the list
		if (curr.key.compareTo(s) == 0)
		{
			head = curr.next;
			return;
		}
		//looks though list for s string value if found it removes it from the list
		while(curr.next != null && curr.next.key.compareTo(s) != 0)
			curr = curr.next;
		if(curr.next != null)
			curr.next = curr.next.next;
		
		return;
	}

	//returns the length of the list as an int
	public int length()
	{	
		//goes to start of list
		StrNode curr = head;

		//sets count to zersh cpilbrow@lab-rg06-22.cms.waikato.ac.nz -J cpilbrow@linux-labs.cms.waikato.ac.nz
		int count = 0;
		
		//goes through list counting the length then returns the count
		while(curr != null)
		{
			count++;
			curr = curr.next;
		}
		return count;
	}
	//returns whether the list is empty or not as a boolean value
	public boolean isEmpty()
	{
		//checks if length is zero and returns true or false
		if(length() == 0)
			return true;
		else
			return false;
	}
	//dumps list into console then returns void
	public void dump()
	{
		//goes to start of list
		StrNode curr = head;
		//goes through list and prints each string value
		while(curr != null)
		{
			System.out.println(curr.key);
			curr = curr.next;
		}
		return;
	}

}
