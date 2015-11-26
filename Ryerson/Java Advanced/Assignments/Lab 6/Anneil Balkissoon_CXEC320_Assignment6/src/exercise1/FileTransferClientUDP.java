package exercise1;

import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.net.*;
import java.util.Arrays;

import javax.swing.*;

public class FileTransferClientUDP extends JFrame {

	private static final String TOOL_TIP_SELECT_FILE = "Select a file to transfer";
	private static final int BUFFER_SIZE = 4096;
	
	//private int sendBufferSize;
	
	private JTextField textFile = new JTextField();
	private JTextArea textArea = new JTextArea();
	private JButton buttonSelect = new JButton("Select File");

	// Datagram socket
	private DatagramSocket socket;
	
//	// The byte array for sending and receiving datagram packets
	private byte[] buffer = new byte[BUFFER_SIZE];
	
	// Server InetAddress
	private InetAddress address;
	
	// The send and receive server packets
	private DatagramPacket sendPacket;
	private DatagramPacket receivePacket;	

	public static void main(String[] args) {
		
		FileTransferClientUDP frame =  new FileTransferClientUDP();		
		frame.setTitle("UDP File Transfer Client");
		frame.setSize(500, 300);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true); // It is necessary to show the frame here!
	}

	public FileTransferClientUDP() {
		
		buildInterface();  
		createServerConnection();
	}
			
	private void buildInterface(){
		
		// Panel p to hold the label and text field
	    JPanel panelInput = new JPanel();
	    panelInput.setLayout(new BorderLayout());
	    panelInput.add(buttonSelect, BorderLayout.EAST);
	    panelInput.add(textFile, BorderLayout.CENTER);
	    textFile.setEditable(false); 
	   
	    setLayout(new BorderLayout());
	    add(panelInput, BorderLayout.NORTH);
	    add(new JScrollPane(textArea), BorderLayout.CENTER);
	    textArea.setEditable(false);

	    buttonSelect.setToolTipText(TOOL_TIP_SELECT_FILE);
	    buttonSelect.addActionListener(new ButtonListener()); // Register listener		
	}
	
	private void createServerConnection(){		
						
	    try {
	        // get a datagram socket
	        socket = new DatagramSocket();
	        address = InetAddress.getByName("localhost");
	        sendPacket = new DatagramPacket(buffer, buffer.length, address, 8000);
	        receivePacket = new DatagramPacket(buffer, buffer.length);
	      }
	      catch (IOException ex) {
	        ex.printStackTrace();
	      }
	}
  
	private File selectFile(){
	  
		JFileChooser fileChooser = new JFileChooser();
		fileChooser.setApproveButtonToolTipText(TOOL_TIP_SELECT_FILE);
		File file = null;
		 
		if (fileChooser.showOpenDialog(null) == JFileChooser.APPROVE_OPTION) 
		{  		
			// Get the selected file
			file = fileChooser.getSelectedFile();
			textFile.setText(file.getAbsolutePath()); 
		}
	
		return file;
	}

	private class ButtonListener implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {
			
			Object source = e.getSource();
								
			if(source.equals(buttonSelect))
			{
				sendSelectedFileToServer();
			}
    	}
	}
	
	private void sendSelectedFileToServer(){
		
	   try {
		   	
		   	File file = null;
		   	DataInputStream input = null;		   
		   	byte[] buffer = new byte[BUFFER_SIZE];
		   	int bytesRead = 0;
		   	long bytesSent = 0;
		   	long totalBytesSent = 0;
		   	
	        try{
	        	//Allow user to select a file to be sent  	
	        	file = selectFile();  
	        	
	        	if(file == null)
	        		return;
	        	
	        	input = new DataInputStream(new FileInputStream(file));	
			} 
			catch (FileNotFoundException ex) {				
				System.err.println(ex);				
			}  	
	        
	        if(input != null && file != null)
	        {	        	
	        	//Send header data containing the length and name of 
	        	//the file to the server before transferring file content
	        	sendPacket.setData((file.length() + ";" + file.getName()).getBytes());
	        	socket.send(sendPacket);
	        	
	        	//Wait for server acknowledgment
	            socket.receive(receivePacket);           	            
	        	
	    		//Begin file transmission
	    		while((bytesRead = input.read(buffer)) != -1)
	    		{		        	
		            // send file bytes the server in a packet
		            sendPacket.setData(buffer);
		            socket.send(sendPacket);            
		        	
		            //Await server acknowledgment
		            socket.receive(receivePacket);
		            bytesSent = getByteLengthSent(receivePacket);
		            totalBytesSent += bytesSent; //keep a total of bytes sent

		            // Initialize buffer for each iteration
		            Arrays.fill(buffer, (byte)0);
		        }
	            	
		        textArea.append("Sent file to server. Size was " + file.length() + " bytes.\n");	
		        
	            //Await server acknowledgment
	            socket.receive(receivePacket);
	            bytesSent = getByteLengthSent(receivePacket);
	            
	            if(bytesSent == totalBytesSent)
	            //if(totalBytesSent == file.length() && bytesSent == totalBytesSent)	            	
	            {
            		textArea.append("File was received successfully by server.\n");
	            }
	      	    
	            input.close();  
      	  	}
        	
	      }
	      catch (IOException ex) {	    	  
	        System.err.println(ex);
	      }
	   	   
	}
	
	private long getByteLengthSent(DatagramPacket receivePacket){
	
		String data;
		
		data = new String(receivePacket.getData());
		data = data.substring(0, receivePacket.getLength());
		
		return Long.parseLong(data.trim());
		   
	}
}
