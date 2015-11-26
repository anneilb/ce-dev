package exercise4;

import javax.swing.JFrame;
import java.io.*;
import java.util.Scanner;

public class DrawGraphFromFile extends JFrame{
	
	private String [][] graphVertices;
	
	public DrawGraphFromFile(){		
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
		
	    File graphFile = null;
	    
		Scanner input = new Scanner(System.in);
	    System.out.print("Enter a Path: ");
	    String filePath = input.nextLine();
	    input.close();
		
	    if (filePath.length() !=0)
	    {
		    graphFile = new File(filePath);
		    
		    if(!graphFile.exists())
		    {
		    	//Validate file location
		    	System.out.print("File " + filePath + " does not exist.");
		    }
		    else
		    {
		    	Scanner fileInput = null;
				
		    	try 
		    	{
					fileInput = new Scanner(graphFile);
				} 
		    	catch (FileNotFoundException e) 
		    	{
		    		System.out.print("File " + filePath + " does not exist.");
				}	
				
		    	if(fileInput != null)
		    	{		    	
			    	DrawGraphFromFile frame = new DrawGraphFromFile();	
			    	
			    	if (frame.readVertices(fileInput))
			    	{		    		
				    	frame.addGraphPanel();			    
					    frame.setSize(350, 210);
					    frame.setTitle("Exercise 14.21: Display a graph from a File");
					    frame.setLocationRelativeTo(null); // Center the frame   
					    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
					    frame.setVisible(true);
			    	}
		    	}
		    }
	    }
	}

}
