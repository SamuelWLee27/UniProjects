/**
 * Node Class
 *
 * holds a key and value
 */
public class Node {

	private String key;
	private String value;
	private Node next;
	
	/**
	 * Node(String k, String v) constructor
	 *
	 * initailizes variables
	 * @param k , key position in hashtable
	 * @param v , value of node
	 */
	public Node(String k, String v){
		key = k;
		value = v;
	}

	/**
	 * getKey()
	 *
	 * @return String , returns nodes key
	 */
	public String getKey(){
		
		return this.key;
	}

	/**
	 * getValue()
	 *
	 * @return String , returns nodes value
	 */
	public String getValue(){
		
		return this.value;
	}

	/**
	 * getNext()
	 *
	 * @return Node , returns next node
	 */
	public Node getNext(){
		
		return this.next;
	}

	/**
	 * setNext(Node node)
	 *
	 * @param node , node to set next node in list
	 */
	public void setNext(Node node){
		this.next = node;
	}
}
