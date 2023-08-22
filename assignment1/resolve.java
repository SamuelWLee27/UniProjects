import java.net.*;

//gets a ip address from the net address name
class resolve
{
	static public void main(String[] args) {
		InetAddress ia;
		//if no argument then show usage
		if(args.length == 0) {
			System.out.println("Usage: resolve <name1> <name2> ... <nameN>");
			return;
		}
		//loop through all web address in args
		//printing their ip address
		for(int i = 0; i < args.length; i++) {
			try {
				ia = InetAddress.getByName(args[i]);
				String ip = ia.getHostAddress();
				System.out.println(args[i] + " : " + ip);
			} catch	(UnknownHostException e) {
				System.err.println(args[i] + " : " + "Unknown host");
			}
		}
		
	
	}

}
