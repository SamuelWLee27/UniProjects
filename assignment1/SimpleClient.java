import java.net.*;
import java.io.*;

//simple client that gets ip address from server
class SimpleClient
{
	static public void main(String[] args) {
		InetAddress ia;
		//get name address
		try {
			ia = InetAddress.getByName(args[0]);
		} catch(UnknownHostException e) {
			System.err.println("Unknown name for ip");
			return;
		}
		Socket sock;
		try {
			//create new socket from user inputed arguments
			sock = new Socket(ia, Integer.parseInt(args[1]));
			
			BufferedReader read = 
				new BufferedReader(new InputStreamReader(sock.getInputStream()));
			//get host name and ip frim server
			String line = read.readLine();
			System.out.println("server sent: \""+ line + "\"");
			line = read.readLine();
			System.out.println("server sent: \""+ line + "\"");
			
			sock.close();		
		} catch (IOException e) {
			System.err.println("IO Exception" + e);
			return;
		}
	}
}
