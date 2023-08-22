import java.net.*;

//gets a net address name from the ip address
class reverse
{
	static public void main(String[] args) {
		InetAddress ia;
		
		//if no argument then show usage
		if(args.length == 0) {
			System.out.println("Usage: resolve <name1> <name2> ... <nameN>");
			return;
		}
		//loop through all web address in args
		//printing their net names address
		for(int i = 0; i < args.length; i++) {
			try {
				ia = InetAddress.getByName(args[i]);
				String name = ia.getHostName();
				//compare ip with name to see if it has a web address
				if(args[i].compareTo(name) != 0)
					System.out.println(args[i] + " : " + name);
				else
					System.err.println(args[i] + " : " + "no name");
			} catch	(UnknownHostException e) {
				System.err.println(args[i] + " : " + "no name");
			}
		}
		
	
	}

}
