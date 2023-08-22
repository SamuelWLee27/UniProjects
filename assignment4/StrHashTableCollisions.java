import java.util.ArrayList; //import for ArrayListClass
import java.lang.Integer;   //for Integer

/**
 * StrHashTable class
 *
 * Holds methods for a String hash table using an array of nodes
 */
public class StrHashTableCollisions {

	Buckets[] hashtable;
	int size;

	int numFullEntries;
	int numCollisions;
	int numRehashes;

	/**
	 * StrHashTable(int s) constructor
	 *
	 * intializes hashtable
	 * @param s , size of hashtable
	 */
	public StrHashTableCollisions(int s){
		size = s;
		//initalize hashtable
		hashtable = new Buckets[size];	
		for(int i = 0; i < size; i++){
			hashtable[i] = new Buckets();
		}

		numFullEntries = 0;
		numCollisions = 0;
		numRehashes = 0;
	}
	
	/**
	 * dump()
	 *
	 * prints the contents of the hashtable
	 */
	public void dump(){
		//loops through list and prints info at each index
		for(int i = 0; i < hashtable.length; i++){
			if(hashtable[i].isEmpty()){
				System.out.println(i + ": null");
			} else {
				System.out.print(i);
				hashtable[i].dump();
				System.out.println("");
			}
		}
	}

	/**
	 * insert(String k, String v)
	 *
	 * adds string key/value pair to the hashtable at appropriate index
	 * @param k , key value for index
	 * @param v , value of node
	 */	
	public void insert(String k, String v){
		
		if((numFullEntries-numCollisions)/(double)size > 0.75){
			rehash();
			numRehashes ++;
		}
		
		//call hash fuction
		int index = hashFunction(k);		
		//add to numFullEntries and collisions and add to hastable
		if(hashtable[index].isEmpty()){
			hashtable[index].add(k, v);
			numFullEntries++;
		} else {
			hashtable[index].add(k, v);
			numFullEntries++;
			numCollisions++;	
		}
		
	}
	
	/**
	 * delete(String k)
	 *
	 * removes a node from the hash table given by k
	 * @param k , key value of removed node
	 */
	public void delete(String k){
		//check if pos in hashtable is empty is so return
		if(!contains(k))
			return;
		//get index for hashtable
		int index = hashFunction(k);
		
		//remove from hashtable and -1 from full entries
		hashtable[index].remove(k);
		numFullEntries--;
		//if bucket is not empty remove 1 from collisions
		if(!hashtable[index].isEmpty())
			numCollisions--;
	}

	/**
	 * hashFunction(String k)
	 *
	 * using folding strings gives a value for the index in hashtable
	 * @param k , key value of node being positioned in array
	 * @return int , index of place in hashtable
	 */
	public int hashFunction(String k){
		//initialize varibles for ascii array
		int groupSize = 3;
		int[] asciiArray = new int[k.length()];
		int concatenatedNum;
		int numGroups = k.length()/groupSize;
		int sum = 0;
		int index = 0;
		//round up instead
		int rem = k.length() % groupSize;
		if(rem != 0)
			numGroups++;

		//convert k to ascii
		for(int i = 0; i < k.length(); i++){
			asciiArray[i] = k.charAt(i);
		}
		//concatenate in groups of 3
		for(int i = 0; i < numGroups; i++){
			//check if last group and rem size so don't go out of array bounds
			if(i == numGroups - 1 && rem == 1)
				concatenatedNum = asciiArray[0 + i * numGroups];
			else if(i == numGroups - 1 && rem == 2)
				concatenatedNum = Integer.parseInt(asciiArray[0 + i * numGroups] + 
						asciiArray[1 + i * numGroups] + "");
			else
				concatenatedNum = Integer.parseInt(asciiArray[0 + i * numGroups] 
						+ asciiArray[1 + i * numGroups] + asciiArray[2 + i * numGroups] + "");
			sum += concatenatedNum;
		}
		index = sum % size;
		return index;
	
	}

	/**
	 * rehash()
	 *
	 * increase size when capcity reaches 75% and rehash values in hashtable
	 */
	public void rehash(){
		
		//get a copy of hashtable
		Buckets[] hashtableCopy = hashtable;
		//double size for new hashtable
		size = size * 2;

		//initalize new hashtable
		hashtable = new Buckets[size];
		for(int i = 0; i < size; i++){
			hashtable[i] = new Buckets();
		}

		//add all the nodes from the copy into hashtable
		for(int i = 0; i < hashtableCopy.length; i++){
			//get bucket
			Buckets bucket = hashtableCopy[i];
			//loop through bucket adding node to new hashtable
			while(!bucket.isEmpty()){
				Node node = bucket.peak();
				int index = hashFunction(node.getKey());
				bucket.remove(node.getKey());
				hashtable[index].add(node.getKey(), node.getValue());
			}
		}

	}

	/**
	 * contains(String k)
	 *
	 * checks if hashtable contains a key value
	 * @param k , key value of node
	 * @return boolean , true if hashtable contains it else false
	 */
	public boolean contains(String k){
		//set intial to false
		boolean contains = false;
		//find index and see if full
		int index = hashFunction(k);
		if(hashtable[index].has(k))
			contains = true;
		return contains;
	}

	/**
	 * get(String k)
	 *
	 * get Node with key value k
	 * @param k , key value of k
	 * @return Node , where node is the node found
	 */
	public Node get(String k){
		//if empty return empty node
		if(!contains(k))
			return new Node("","");
		else{
			//return node at key k
			int index = hashFunction(k);
			return hashtable[index].get(k);
		}
	}
	
	/**
	 * size()
	 *
	 * gets number of items in the hashtable
	 * @return int , number of items in hashtable
	 */
	public int size(){
		//get number of items in the hashtable and return
		return numFullEntries;
	}	


}
