import java.io.FileReader;
import java.io.BufferedReader;

//processes and file into a BST
public class XProcess {
	//make BST
	private static BankBST bank = new BankBST();

	//main
	public static void main(String[] args) {

		// check if a file is attached
		if (args.length != 1) {
			System.err.println("Usage: java XProcess <filename>");
			return;
		}

		try {
			// start reading file
			BufferedReader reader = new BufferedReader(new FileReader(args[0]));


			String line = reader.readLine();

			// spit into array of string from spaces
			String[] tokens;

			// loop through file
			while (line != null) {
				tokens = line.split(" ");
				// check if the right amount of fields are passed in 
				if(tokens.length == 3) {
					// call transaction
					bank.transaction(Integer.parseInt(tokens[0]), tokens[1], Double.parseDouble(tokens[2]));
				} else
					System.err.println("should only be three fields passed in");

				line = reader.readLine();
			}

			reader.close();
		} catch (Exception e) {
			System.err.println("Error: " + e);
		}
		// display result
		System.out.println("RESULT");
		bank.transverse();
	}

}
