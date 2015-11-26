package exercise4;

import java.io.IOException;
import java.net.*;
import java.util.Scanner;

import javax.swing.JFrame;

public class DrawGraphFromURL extends JFrame{

	private String [][] graphVertices;
	
	public DrawGraphFromURL(){		
		//Default constructor
	}
		
	public boolean readVertices(Scanner fileInput){		
		
		boolean isArrayLengthRead = false;
		int lineIndex = 0;		
		
		if(fileInput != null)
		{			
			if(!isArrayLengthRead)
	    	{
	    		int arrayLength = fileInput.nextInt();	    		
	    		this.graphVertices = new String [arrayLength][arrayLength + 2];
	    		isArrayLengthRead = true;
	    	}	    			
			
			if(isArrayLengthRead)
			{			
				// Read data from a file
			    while (fileInput.hasNext()) 
			    {     			    	    	
			    	String lineInput = fileInput.nextLine();
			    	
			    	if(lineInput.length() > 0)
			    	{	//Split the string into an array using spaces as the delimiter
			    		String lineArgs[] = lineInput.split(" ");		    	
			    	
				    	for(int x=0; x < lineArgs.length; x++)
				    	{		    	
				    		this.graphVertices[lineIndex][x] = lineArgs[x];
				    	}
				    	
				    	lineIndex += 1;
			    	}  	
			    }			    
			}
			
		    fileInput.close();		    
		    return true;
		}
		else
		{
			return false;			
		}
	}	
	
	public void addGraphPanel()
	{		
		GraphPanel graphPanel = new GraphPanel(graphVertices);
		this.add(graphPanel);
	}

	public static void main(String[] args) {
		
	    URL graphFile = null;
	    
		Scanner input = new Scanner(System.in);
	    System.out.print("Enter a URL: ");
	    String filePath = input.next();
	    input.close();
		
	    if (filePath.length() !=0)
	    {
		    try
		    {
		    	graphFile = new URL(filePath);
		    }
		    catch(MalformedURLException e)
		    {
		    	//Validate URL format
		    	System.out.print("URL " + filePath + " is malformed.");
		    }
		    
		    if(graphFile != null)
		    {
		    	Scanner fileInput = null;
				
		    	try 
		    	{	//Try to open the URL. Catch any IOException.
					fileInput = new Scanner(graphFile.openStream());
				} 
		    	catch (IOException e) 
		    	{
		    		System.out.print("File " + filePath + " does not exist.");
				}	
				
		    	if(fileInput != null)
		    	{		    	
		    		DrawGraphFromURL frame = new DrawGraphFromURL();	
			    	
			    	if (frame.readVertices(fileInput))
			    	{		    		
				    	frame.addGraphPanel();			    
					    frame.setSize(350, 210);
					    frame.setTitle("Exercise 14.21: Display a graph from a URL");
					    frame.setLocationRelativeTo(null); // Center the frame   
					    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
					    frame.setVisible(true);
			    	}
		    	}
		    }
	    }
	}


}
