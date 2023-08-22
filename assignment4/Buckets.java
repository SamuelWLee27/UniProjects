/**
 * Buckets class
 *
 * holds linked List of nodes and its methods
 */
public class Buckets{

	//start of list
	private Node head;

	/**
	 * has(String k)
	 *
	 * @param k , key value of node
	 * @return boolean , true if node with string k is in list else false
	 */
	public boolean has(String k){
		
		Node curr = head;

		//look through list to find matching node
		while(curr != null)
			if(curr.getKey().compareTo(k) == 0)
				return true;
			else
				curr = curr.getNext();		
		return false;
	}

	/**
	 * get(String k)
	 *
	 * @param k , key of node that is being looked for
	 * @return Node , returns found node
	 */
	public Node get(String k){
		
		Node curr = head;

		//look through list to find matching node
		while(curr != null)
			if(curr.getKey().compareTo(k) == 0)
				return curr;
			else
				curr = curr.getNext();		
		return new Node("","");
	}

	/**
	 * add(String k, String v)
	 *
	 * adds node to start of list
	 * @param k , key of new node
	 * @param v , value of new node
	 */
	public void add(String k, String v){
		//add new node to start of list
		Node temp = new Node(k, v);
		
		temp.setNext(head);
		head = temp;

		return;
	}

	/**
	 * remove(String k)
	 *
	 * removes node with key k from list
	 * @param k , key of node
	 */
	public void remove(String k){
		
		Node curr = head;

		//check if removing first item in the list
		if(curr.getKey().compareTo(k) == 0){
			head = curr.getNext();
			return;
		}

		//look for item that matches k
		while(curr.getNext() != null && curr.getNext().getKey().compareTo(k) != 0){}
			curr = curr.getNext();
		//remove item if found
		if(curr.getNext() != null)
			curr.setNext(curr.getNext().getNext());
	}
	
	/**
	 * length()
	 *
	 * @return int , returns length of list
	 */
	public int length(){
		
		Node curr = head;

		int count = 0;
		
		//loop through list and add one for each item
		while(curr != null){
			count++;
			curr = curr.getNext();
		}

		return count;
	}

	/**
	 * isEmpty()
	 *
	 * @return boolean, return true if list is empty else false
	 */
	public boolean isEmpty(){
		//check if lists head is null
		if(head == null)
			return true;
		else
			return false;
	}

	/**
	 * dump()
	 *
	 * print content of list in a line
	 */
	public void dump(){
		Node curr = head;
		
		int index = 0;
		//print list
		while(curr != null){
			System.out.print(": key=" + curr.getKey() + ", value=" + curr.getValue());
			curr = curr.getNext();
			index++;
		}
	}

	/**
	 * peak()
	 *
	 * @return Node , returns first Node in list
	 */
	public Node peak(){
		if(head != null)
			return head;
		else
			return new Node("","");
	}
}
