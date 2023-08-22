import java.net.*;
import java.io.*;
import java.util.*;

//holds http server
class HttpServer
{
    	
    	private ArrayList<HttpServerSession> sessions;
    	public void startServer(){
    		try{
			//listening on an port 59987 for incoming connections
			ServerSocket ss = new ServerSocket(59987);
			sessions = new ArrayList<HttpServerSession>();
        		//write something to the console here
        		System.out.println("\"web server starting\"");
        		//loop arouns accepting new connections as they arrive
        		while(true) {
				Socket s = ss.accept();
				HttpServerSession session = new HttpServerSession(s);
				sessions.add(session);
				
				/* the start method causes the thread to run */
				session.start();
			}
        	} catch (Exception e) {
        		System.err.println("Exception: " + e);
        	}
        }
        public static void main(String[] args) {
		HttpServer server = new HttpServer();
		server.startServer();
	}
    
 }

 //prints request and responds
class HttpServerSession extends Thread {
	private HttpServer cs;
	private Socket s;
	private BufferedReader read;
	private BufferedOutputStream write;
	private HttpServerRequest request;
	private String file;
	private String host;
	private FileInputStream openFile;
	private byte[] byteArray;
	private int byteRead;
	
	//Constructor for HttpServerSession
	public HttpServerSession(Socket s){
		this.s = s;
	}
	
	public void run() { /* entry point into the HttpServerSession */
		try {
			read = new BufferedReader(
					new InputStreamReader(s.getInputStream()));
			write = new BufferedOutputStream(s.getOutputStream());
			
			//new request
			request = new HttpServerRequest();
			
			//process first line
			String line = read.readLine();
			request.process(line);
			
			while (!request.isDone()) {
				/* read a line of text, and then echo it back */
				line = read.readLine();
				request.process(line);
			}
			//get file and host
			if(request.getFile() != null)
				file = request.getFile();
			if(request.getHost() != null)
				host = request.getHost();
			try{
				file = host + "/" + file;
				//open the file and set byte array size
				openFile = new FileInputStream(file);
				byteArray = new byte[120];
				//write ok message
				println(write, "HTTP/1.1 200 OK");
				println(write, "");
				//read file
				while((byteRead = openFile.read(byteArray)) != -1){
					write.write(byteArray, 0, byteRead);
					//Thread.sleep(100);
				}
				write.flush();
				openFile.close();
			
			} catch(Exception ex) {
				println(write, "HTTP/1.1 404 File not found");
				println(write, "");
				println(write, "file not found");
				write.flush();
			}
			
			
			/* close the socket */
			s.close();
		
		} catch (Exception e) {
			System.err.println("Exception: " + e);
		}
	}
	
	private boolean println(BufferedOutputStream bos, String s)
	{
  		String news = s + "\r\n";
	  	byte[] array = news.getBytes();
	  	try {
	  	    	bos.write(array, 0, array.length);
	  	} catch(IOException e) {
	  		return false;
  		}
 			return true;
	}
}
