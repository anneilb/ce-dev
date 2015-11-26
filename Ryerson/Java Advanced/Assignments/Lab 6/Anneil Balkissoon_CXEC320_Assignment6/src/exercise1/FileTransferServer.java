package exercise1;

import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.net.*;
import java.util.*;
import javax.swing.*;

public class FileTransferServer extends JFrame {
	
	private static final int BUFFER_SIZE = 4096; 
	private static final String HEADER_DEL = ";";
	private static final String CAPTION_SELECT_FOLDER = "Select Folder";
	private static final String TOOL_TIP_SELECT_FOLDER = "Select a folder to save transferred files in";
	
	private JTextField textFolder = new JTextField();
	private JTextArea textArea = new JTextArea();
	private JButton buttonSelect = new JButton(CAPTION_SELECT_FOLDER);	
	
    // Number a client
    int clientNo = 1;

	public FileTransferServer(){
		
		buildInterface();
		
		TCPConnectionListener tcpListener = new TCPConnectionListener();
		new Thread(tcpListener).start();
		
		UDPConnectionListener udpListener = new UDPConnectionListener();
		new Thread(udpListener).start();
	}	

	private void buildInterface(){
		
		// Panel p to hold the label and text field
	    JPanel panelInput = new JPanel();
	    panelInput.setLayout(new BorderLayout());
	    panelInput.add(buttonSelect, BorderLayout.EAST);
	    panelInput.add(textFolder, BorderLayout.CENTER);
	    textFolder.setEditable(false);    
	    textFolder.setText(System.getProperty("user.home") + "\\"); //Set default save location
	   
	    setLayout(new BorderLayout());
	    add(panelInput, BorderLayout.NORTH);
	    add(new JScrollPane(textArea), BorderLayout.CENTER);
	    textArea.setEditable(false);

	    buttonSelect.setToolTipText(TOOL_TIP_SELECT_FOLDER);
	    buttonSelect.addActionListener(new ButtonListener()); // Register listener		
	}
	
	private void selectFolder(){
		  
		JFileChooser fileChooser = new JFileChooser();	
		fileChooser.setCurrentDirectory(new File(textFolder.getText()));
		fileChooser.setDialogTitle(CAPTION_SELECT_FOLDER);
		fileChooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
		fileChooser.setApproveButtonText("Select");
		fileChooser.setApproveButtonToolTipText(TOOL_TIP_SELECT_FOLDER);
		 
		if (fileChooser.showOpenDialog(FileTransferServer.this) == JFileChooser.APPROVE_OPTION) 
		{  		
			// Get the selected file
			String path = fileChooser.getSelectedFile().getPath() + "\\";
			textFolder.setText(path); 
		}
	}

	private class ButtonListener implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {
			
			Object source = e.getSource();
								
			if(source.equals(buttonSelect))
			{
				selectFolder();
			}
    	}
	}
	
	//Class that listens for incoming UDP connections
	private class UDPConnectionListener implements Runnable {		
		
		@Override
		public void run() {
			
			try {
		        // Create a server socket
				//DatagramSocket socket = new DatagramSocket(8000);
		        textArea.append("UDP connnection listener started at " + new Date() + '\n');		        


		        //while (true) {        	  
			        		        	
		    		// The byte array for sending and receiving datagram packets
		    		byte[] buffer = new byte[BUFFER_SIZE];
		        	
		        	// Initialize buffer for each iteration
		        	Arrays.fill(buffer, (byte)0);
		        	
		        	// Create a packet for receiving data
		        	//DatagramPacket receivePacket = new DatagramPacket(buffer.clone(), buffer.length);        	
		        			        			        	
		        	// Receive radius from the client in a packet
		        	//socket.receive(receivePacket);
		        			        	
					// Create a new thread for the UDP connection
		        	HandleUDPClient task = new HandleUDPClient(new DatagramSocket(8000), new DatagramPacket(buffer.clone(), buffer.length));
					
					// Start the new thread
					//new Thread(task).start();
		        	task.run();
					
					// Increment clientNo
					clientNo++;
					
//					break;
//	        	}
			}
			catch(BindException ex){
				//Not supporting multiple UDP clients for now
				textArea.append("Multiple UDP client connections are currently not supported.\n");				
			}
			catch(IOException ex) {
		        ex.printStackTrace();
			}		
		}		
		
	}
	
	private class HandleUDPClient implements Runnable{
		
		// The byte array for sending and receiving datagram packets
		private byte[] buffer = new byte[BUFFER_SIZE];
		private DatagramSocket socket;
		
		// Create a packet for receiving data
        private DatagramPacket receivePacket; //= new DatagramPacket(buf, buf.length);
		
		public HandleUDPClient(DatagramSocket socket, DatagramPacket receivePacket){		
			
			this.socket = socket;
			this.receivePacket = receivePacket;			
		}

		@Override
		public void run() {
			
			try {					
				// Create a packet for sending data
		        DatagramPacket sendPacket = new DatagramPacket(buffer, buffer.length);
		        
		        OutputStream outputStream = null;
    			String fileName = "";
    			boolean createFile = true;   			
    			int bytesReceived = 0;     			
    			long totalBytesReceived = 0;
    			long fileSize = 0;				
    			
    			socket.receive(receivePacket);
				
				// Display the client number
				textArea.append("Starting thread for UDP client " + clientNo + " at " + new Date() + '\n');

	        	textArea.append("The client host name is " + receivePacket.getAddress().getHostName() +
	        			   		" and port number is " + receivePacket.getPort() + '\n');  			
	
		        // Continuously serve the client
		        while (true) 
		        {				        	
		        	bytesReceived = receivePacket.getLength();
		        	
		        	if(bytesReceived > 0)
		        	{	//Get the file transmission header from the initial client packet	        		
		        		String transmitHeader = new String(receivePacket.getData(),0, bytesReceived);
		        		//transmitHeader = transmitHeader.substring(0, bytesReceived).trim().;
		        		String[] header = transmitHeader.split(HEADER_DEL);
		        		fileSize = Long.parseLong(header[0]);
		        		fileName = header[1];
		        	    
		        		//Send receipt acknowledgment back to the client. Just send back the number of bytes received.
		        		setSendPacketAddress(sendPacket, receivePacket);
		        		sendPacket.setData(String.valueOf(bytesReceived).getBytes());
		        		socket.send(sendPacket);
		        	}
		        	
	        		while(totalBytesReceived < fileSize)
  					{	        			
	            		//Wait for client to send bytes 
	        			//socket.setSendBufferSize(BUFFER_SIZE);
			        	socket.receive(receivePacket);
			        	bytesReceived = receivePacket.getLength();			        	
			        	
						if(totalBytesReceived == 0)
						{
						   	if(createFile)
						   	{ 	//Get a unique name for the file to be received 
						   		//fileName = getUniqueFileName();
						   		fileName = textFolder.getText() + fileName;						   		
						   		outputStream = createFile(fileName);
						   		createFile = false;
						   		textArea.append("Receiving file from client.\n");
						   	}	        			
						   	
						   	//Write bytes to file 
							outputStream.write(receivePacket.getData(), 0, bytesReceived);												
						}
						else
						{							
			        		if(outputStream != null)
			        		{   //Write bytes to file, if any 
	    						outputStream.write(receivePacket.getData(), 0, bytesReceived);	    	        	
		        			}
						}       
			        		
		        		//Increment total bytes received	        	
		        		totalBytesReceived += bytesReceived;
			        			        				        		
		        		//Tell the client to send more data. Just send back the number of bytes received.
		                sendPacket.setData(String.valueOf(bytesReceived).getBytes());
		        		socket.send(sendPacket);
		        		
			        	//buffer = new byte[BUFFER_SIZE]; 
			        	Arrays.fill(buffer, (byte)0);		        	
		        		
			        	receivePacket = new DatagramPacket(buffer, buffer.length);
					}
	        		
    				outputStream.flush();
        			outputStream.close();
        			 
        			textArea.append("Received file successfully. Saved as " + fileName + "\n" );        			
 	        		
	        		//Tell the client transmission is complete. Just send back the total number of bytes received.
	                sendPacket.setData(String.valueOf(totalBytesReceived).getBytes());
	        		socket.send(sendPacket);
        			
	        		//Reset creation flag
        			createFile = true;					        		
	        		totalBytesReceived = 0;
	        		
            		//Wait for client to send another file 
		        	socket.receive(receivePacket);
		        }
			}	
	       	catch(IOException e) {
	       		System.err.println(e);
	       	}	
		}		
	}
	
	private void setSendPacketAddress(DatagramPacket sendPacket, DatagramPacket receivePacket){
		
		//Tell the client to send more data		        	    
        sendPacket.setAddress(receivePacket.getAddress());
        sendPacket.setPort(receivePacket.getPort());
	}
	
	//Class that listens for incoming TCP connections
	private class TCPConnectionListener implements Runnable {

		@Override
		public void run() {
		    
			try {
		        // Create a server socket
		        ServerSocket serverSocket = new ServerSocket(8000);
		        textArea.append("TCP connection listener started at " + new Date() + '\n');

		        while (true) {
		        	
					// Listen for a new connection request
					Socket socket = serverSocket.accept();
					
					// Display the client number
					textArea.append("Starting thread for TCP client " + clientNo + " at " + new Date() + '\n');
					
					// Find the client's host name, and IP address
					InetAddress inetAddress = socket.getInetAddress();
					textArea.append("Client " + clientNo + "'s host name is " + inetAddress.getHostName() + "\n");
					textArea.append("Client " + clientNo + "'s IP Address is " + inetAddress.getHostAddress() + "\n");
					
					// Create a new thread for the TCP connection
					HandleTCPClient task = new HandleTCPClient(socket);
					
					// Start the new thread
					new Thread(task).start();
					
					// Increment clientNo
					clientNo++;
	        	}	        

			}
			catch(IOException ex) {
				System.err.println(ex);
			}			
		}		
	}
	
	private class HandleTCPClient implements Runnable{
		
		private Socket socket;
		
		public HandleTCPClient(Socket socket){		
			
			this.socket = socket;
		}

		@Override
		public void run() {
			
			try {
		        // Create data input and output streams
		        DataInputStream inputFromClient = new DataInputStream(socket.getInputStream());
		        DataOutputStream outputToClient = new DataOutputStream(socket.getOutputStream());
		        
    			//Set up a byte buffer to capture the file from the client	        	
		        byte[] buffer = new byte[BUFFER_SIZE]; 		        
		        OutputStream outputStream = null;
    			String fileName = "";
    			boolean createFile = true;  
    			int bytesReceived = 0;     			
    			long totalBytesReceived = 0;
    			long fileSize = 0;			
	
		        // Continuously serve the client
		        while (true) 
		        {			
		        	bytesReceived = inputFromClient.read(buffer);
		        	
		        	if(bytesReceived > 0)
		        	{	//Get the file transmission header from the initial client packet	        		
		        		String transmitHeader = new String(buffer,0, bytesReceived);
		        		//transmitHeader = transmitHeader.substring(0, bytesReceived).trim().;
		        		String[] header = transmitHeader.split(HEADER_DEL);
		        		fileSize = Long.parseLong(header[0]);
		        		fileName = header[1];
		        	    
		        		//Send receipt acknowledgment back to the client. Just send back the number of bytes received.
		        		outputToClient.writeInt(bytesReceived);
		        		
						//Reinitialize buffer values	        	
			        	buffer = new byte[BUFFER_SIZE]; 
		        		bytesReceived = 0;
		        	}
		        	
	        		//Wait for client to send bytes 
	        		while((bytesReceived = inputFromClient.read(buffer)) != -1)
  					{		        			
						if(inputFromClient.available() > 0)
						{
						   	if(createFile)
						   	{ 	//Get a unique name for the file to be received 
						   		fileName = textFolder.getText() + fileName; //getUniqueFileName();
						   		outputStream = createFile(fileName);
						   		createFile = false;
						   		textArea.append("Receiving file from client.\n");
						   	}	        			
						   	
						   	//Write bytes to file 
							outputStream.write(buffer, 0, bytesReceived);												
						}
						else
						{	//We get here if no more data is available, but some bytes were already received
							
							//If bytes were received and the file wasn't already created, 
							//it means that the file was smaller than our buffer size. 
							//Create the file...
						   	if(bytesReceived > 0 && createFile)
						   	{ 	//Get a unique name for the file to be received 
						   		fileName = textFolder.getText() + fileName; //getUniqueFileName();
						   		outputStream = createFile(fileName);
						   		createFile = false;
						   		textArea.append("Receiving file from client.\n");
						   	}	        										
							
			        		if(outputStream != null)
			        		{
			               		if(bytesReceived > 0)
		    	        		{	//Write remaining bytes to file, if any 
		    						outputStream.write(buffer, 0, bytesReceived);
		    	        		}
			        			
			        			outputStream.flush();
			        			outputStream.close();			        		
			        			textArea.append("Received file successfully. Saved as " + fileName + "\n" );
			        			
			        			//Return success to client.
			        			outputToClient.writeInt(0);
			        		}
				        	
							//Reset creation flag
			        		createFile = true;
			        		break;
						}       

						//Reinitialize buffer values	        	
			        	buffer = new byte[BUFFER_SIZE]; 
		        		bytesReceived = 0;
					}					
		        }
			}	
	       	catch(IOException e) {
	       		System.err.println(e);
	       	}			
		}		
	}	
	
	private OutputStream createFile(String fileName){
		
		OutputStream outputStream = null;		
     	    	
    	File outputFile = new File(fileName);
    	
    	try {
			outputStream = new FileOutputStream(outputFile);
		}catch (FileNotFoundException e) {
			e.printStackTrace();
		}
    	
    	return outputStream;
	}
	
	//Generates a unique filename based on the current date and time.
	private String getUniqueFileName(){
		
    	GregorianCalendar now =  new GregorianCalendar();
    	String fileName = "" + now.get(Calendar.YEAR) + now.get(Calendar.MONTH) + 
    					  now.get(Calendar.DATE) + now.get(Calendar.HOUR_OF_DAY) + 
    					  now.get(Calendar.MINUTE) + now.get(Calendar.SECOND) +
    					  now.get(Calendar.MILLISECOND);
    	
    	return fileName + ".jpg";
	}	
	
	public static void main(String[] args) {
		
		FileTransferServer frame = new FileTransferServer();
		frame.setTitle("File Transfer Server");
		frame.setSize(500, 300);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true); // It is necessary to show the frame here!			
	}
		
}
