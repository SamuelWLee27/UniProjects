/**
* Queue class
*
* holds a linked list in the form of a queue with its methods
*/
public class Queue{

	/**
	* Node class
	*
	* inner class that holds a node and its varibles
	*/
	private class Node{
		
		String value;
		Node next;
		
		/**
		* Node(String s) constructor
		* 
		* intializes the nodes value 
		* @param s, sting used to intialize the node value
		*/
		private Node(String s){
			this.value = s;
		}
	
	}

	//create nodes for start and end of the queue
	private Node head;
	private Node last;

	/**
	* enqueue(String s) 
	* adds a new node and attaches it to the end of the queue
	* @param s, the string key value for the new node  
	*/
	public void enqueue(String s){
		//check if string is not empty
		if(s != ""){
			//create new node
			Node temp = new Node(s);
			//check if queue is empty if empty 
			//make head and last point to the new node
			if(head == null){
		
				head = temp;
				last = temp;
			}
			else{
				//add to end of queue
				last.next = temp;
				last = last.next;
			}
		}

	}
	
	/**
	* dequeue()
	* removes node from the start of the queue
	*/
	public void dequeue(){
		
		//if queue is empty do nothing
		if(head != null){
			//if head is equal to last make queue null/empty
			if(head == last){
		
				head = null;
				last = null;
				
			}
			else{
				//remove first item from queue
				head = head.next;
			}
		}
	}

	/**
	* peek()
	* looks at first item in queue
	* @return the first items value
	*/
	public String peek(){
	
		//return value of item at start of the queue
		if(head != null)
			return head.value;
		else
			return "";
	}

	/**
	* isEmpty()
	* checks head to see if queue is empty
	* @return true if queue is empty and false if not
	*/
	public boolean isEmpty(){
	
		//if head is null return true else return false
		if(head == null)
			return true;
		else
			return false;
	}
	
	/**
	* length()
	* finds number of items in the queue as an int value
	* @return length of queue
	*/
	public int length(){
	
		int count = 0;
		//if queue is not empty count how many items are in the queue
		if(head != null){
	
			Node curr = head;
			count++;
			while(curr.next != null){
	
				curr = curr.next;
				count++;
			}
		}
		//return count for length of list
		return count;
	}

	/**
	* dump()
	* dumps content of queue into the standard output
	*/
	public void dump(){
	
		//If there is something in the queue go through and print the items
		if(head != null){
			
			Node curr = head;
			System.out.println(curr.value);
	
			while(curr.next != null){
	
				curr = curr.next;
				System.out.println(curr.value);
			}
		}
	}
}
