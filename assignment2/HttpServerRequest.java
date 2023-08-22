//creates a http server request
class HttpServerRequest
{
    private String file = null;
    private String host = null;
    private boolean done = false;
    private int line = 0;

    public boolean isDone() { return done; }
    public String getFile() { return file; }
    public String getHost() { return host; }

    public void process(String in)
    {
	/*
	 * process the line, setting 'done' when HttpServerSession should
	 * examine the contents of the request using getFile and getHost
	 */
	 //get each part of the string
	 String parts[] = in.split(" ");
	 
	 //check if Get, host or empty string
	 if (parts[0].compareTo("GET") == 0){
	 	//get file name
	 	file = parts[1].substring(1);
	 	if(file.endsWith("/")){
	 		file = file + "index.html";
	 	}else if(file.length() == 0){
	 		file = file + "/" + "index.html";
	 	}
	 }
	 else if (in.startsWith("Host: ")){
	 	//get host name
	 	host = in.substring(6);
	 }
	 else if (in.compareTo("") == 0){
	 	//process is done
	 	done = true;
	 }
	 
	 line++;
    }
}
