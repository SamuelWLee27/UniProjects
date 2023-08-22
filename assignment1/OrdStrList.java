//class for an ordered string linked list and it's methods
public class OrdStrList
{
	//inner class that stores a string nose
	private class StrNode 
	{
		private String key;
		private StrNode next;
		//constructor that sets string s as the key value
		public StrNode(String s)
		{
			key = s;
		}
	}
	//create head of list
	private StrNode head;
	
	//looks for s string in list returns if it is found 
	//or not as a boolean value
	public boolean has(String s)
	{
		//goes to start of list
		StrNode curr = head;
		//looks through list and returns if found or not
		while(curr != null)
			if(curr.key.compareTo(s) == 0)
				return true;
			else 
				curr = curr.next;
		return false;
	}

	//inserts string s into list so that is stays in alphabetical order 
	//(a-z) returns void
	public void insert(String s)
	{
		//creates new node with s as key value
		StrNode temp = new StrNode(s);
		
		//if head is null or s is less alphabetically then head 
		//add temp node to start of list and set to head then return
		if (head == null || temp.key.compareTo(head.key) <= 0)
		{
			temp.next = head;
			head = temp;
			return;
		}

		//goes to start of the list
		StrNode curr = head;
		
		//goes through list untill the next value in the list is greater then 
		//or equal to s alphabetically
		//or it is the end of list
		while (curr.next != null && temp.key.compareTo(curr.next.key) >= 0)
			curr = curr.next;

		//if end of the list put the new node at the end of the list 
		//else insert it between the current and next value in the list
		if (curr.next == null)
			curr.next = temp;
		else
		{
			temp.next = curr.next;
			curr.next = temp;
		}

		return;
			
	}
	
	//if string s is in the list remove it and return void
	public void remove(String s)
	{
		//go to start of list
		StrNode curr = head;
		
		//if s is the same as the head key make the next value the
		//head of the list
		if (curr.key.compareTo(s) == 0)
		{
			head = curr.next;
			return;
		}

		//loop through list until s is found or reached end or list
		while(curr.next != null && curr.next.key.compareTo(s) != 0)
			curr = curr.next;
		//if s is found remove it
		if(curr.next != null)
			curr.next = curr.next.next;
		return;

	}
	//count length of list and then return the count
	public int length()
	{
		//go to start of list
		StrNode curr = head;
		//set count to zero
		int count = 0;
		//loop until end of list
		while(curr != null)
		{
			count++;
			curr = curr.next;
		}
		//return the count
		return count;
	}
	//returns whether list is empty or not as a boolean value
	public boolean isEmpty()
	{
		//return true if length is zero else false
		if(length() == 0)
			return true;
		else
			return false;
	}

	//dump list into console return void
	public void dump()
	{
		//go to start of the list
		StrNode curr = head;
		//print out each string in the list
		while(curr != null)
		{
			System.out.println(curr.key);
			curr = curr.next;
		}
		return;
	}

}
