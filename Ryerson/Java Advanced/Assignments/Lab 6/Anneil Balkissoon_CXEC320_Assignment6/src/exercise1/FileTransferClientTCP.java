package exercise1;

import java.io.*;
import java.net.*;
import java.util.*;
import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

public class FileTransferClientTCP extends JFrame {
  
	private static final String TOOL_TIP_SELECT_FILE = "Select a file to transfer";
	
	private JTextField textFile = new JTextField();
	private JTextArea textArea = new JTextArea();
	private JButton buttonSelect = new JButton("Select File");

	// IO streams
	private DataOutputStream toServer;
	private DataInputStream fromServer;

	public static void main(String[] args) {
		
		FileTransferClientTCP frame =  new FileTransferClientTCP();		
		frame.setTitle("TCP File Transfer Client");
		frame.setSize(500, 300);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true); // It is necessary to show the frame here!
	}

	public FileTransferClientTCP() {
		
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
	      // Create a socket to connect to the server
	      Socket socket = new Socket("localhost", 8000);
	
	      // Create an input stream to receive data from the server
	      fromServer = new DataInputStream(socket.getInputStream());
	
	      // Create an output stream to send data to the server
	      toServer = new DataOutputStream(socket.getOutputStream());
	    }
	    catch (IOException ex) {
	    	System.err.println(ex);
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
		   
		   	byte[] fileBytes = null;
		   	File file = null;
		   	int response;
		   
	        try{
	        	//Allow user to select a file to be sent  	
	        	file = selectFile(); 
	        	
	        	if(file == null)
	        		return;
	        		
	        	fileBytes = new byte[(int)file.length()]; 			
	        	
	        	DataInputStream input = new DataInputStream(new FileInputStream(file));
	        	input.readFully(fileBytes);	 
					
				// Close the file
				input.close();		
			} 
			catch (FileNotFoundException ex) {				
				System.err.println(ex);				
			}  	
	       
	        if (fileBytes != null)
	        {       		
	        	//Send header data containing the length and name of 
	        	//the file to the server before transferring file content
	        	toServer.write((file.length() + ";" + file.getName()).getBytes());	        	
	        	
	        	//Wait for server acknowledgment
	        	response = fromServer.readInt();		  
	        	
	        	textArea.append("Sent file to server. Size was " + fileBytes.length + " bytes.\n");        	
	        	
	        	//Send the file bytes to the server
	        	toServer.write(fileBytes);
	        	toServer.flush();	        	
	        	
	        	//Get the response from the server
	        	response = fromServer.readInt();		        		        	
	        	
	        	if(response == 0)
	        		textArea.append("File was received successfully by server.\n");        	
	        }
	      }
	      catch (IOException ex) {	    	  
	        System.err.println(ex);
	      }
		
	}
}
