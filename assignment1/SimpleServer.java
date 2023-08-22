import java.net.*;
import java.io.*;


//creates a simple server
class SimpleServer 
{
	static public void main(String[] args) {
		try{
			//listening on an avalible port
			ServerSocket ss = new ServerSocket(0);
			
			System.out.println("Listening on port " + ss.getLocalPort());
			
			//loop around, accepting new connections as they arrive
			while (true) {
				Socket s = ss.accept();
				PrintWriter write = 
					new PrintWriter(s.getOutputStream(), true);

				// Get ip address and host name, and then send it to the client
				InetAddress ia = s.getInetAddress();
				String name = ia.getHostName();
				String ip = ia.getHostAddress();
				write.println("Hello, " + name);
				write.println("Your IP address is " + ip);
				
 				s.close(); // close the socket
			}
		} catch(Exception e) {
			System.err.println(e);
		}
	}
}
