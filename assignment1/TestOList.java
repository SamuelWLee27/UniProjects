// TestOList
// Test if all operations on a OrdStrList function correctly with a given test file.
// usage:  java TestOList <filename>
//
// 25 March 2023, Tony C Smith
//
// Reads input file one word/token at a time and if the word is not in the list then it is inserted, otherwise
// the word is removed.  After each token is processed, the list is printed out to the screen, along with
// the length of the list.  The list should be maintained in lexicographical order.
// On completion, the list should be empty, and this is tested.
//

import java.io.File;
import java.util.Scanner;


class TestOList{

    private static OrdStrList msl = new OrdStrList();
    
    public static void main(String [] args){
	if(args.length!=1){
	    System.err.println("Usage:  java TestOList <filename>");
	    return;
	}

	try{
	    Scanner sc = new Scanner(new File(args[0]));
	    String s;
	    while(sc.hasNext()){
		s=sc.next().trim().replaceAll("[,.!;:'`\"]","").toLowerCase(); //cleanup default tokens a bit
		if(! msl.has(s)) {
		    msl.insert(s); // insert into an ordered list of strings
		    System.out.println("Inserted: " + s);
		}else{
		    msl.remove(s);
		    System.out.println("Removed: " + s);
		}
		System.out.println("--- UList ---");
		msl.dump();
		System.out.println("Length = " + msl.length());
		System.out.println("--- ----- ---");
		}
	}catch(Exception e){
	    System.err.println("Exception type: "+e);
	    System.err.println("\t should do more than this to handle an exception!");
	}
	// final test for empty list
	if(msl.isEmpty())System.out.println("successfully emptied!");
	else System.out.println("Oh dear .... not emptied properly?");
    }
}
