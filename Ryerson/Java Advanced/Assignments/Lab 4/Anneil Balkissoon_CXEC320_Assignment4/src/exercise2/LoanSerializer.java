package exercise2;

import java.io.*;
import java.util.*;

public class LoanSerializer {
	
	private String filename = "";
	
	public String getFilename() {
		return filename;
	}

	public void setFilename(String filename) {
		this.filename = filename;
	}
		
	public LoanSerializer(String filename){	
		//Default constructor
		this.filename = filename;
	}

	public void serialize(ArrayList<Loan> loans) throws IOException{
		
		File fileOutput = null;
		
		try{
			fileOutput = new File(filename);		
			
			if(fileOutput != null)
			{
				//Try to create the object output stream. Catch any FileNotFoundException.
				ObjectOutputStream output = new ObjectOutputStream(new FileOutputStream(fileOutput));
				
				//Get the array list's iterator, so we can loop through the array list
				Iterator<Loan> e = loans.iterator();
				
				while(e.hasNext()){
					//Try to write the loan objects to the output file
					Loan loan = e.next();					
					output.writeObject(loan);
				}
				
				output.close();
			}
		}
		catch(FileNotFoundException e){
			//Throw to caller
			throw e;
		}
		
	}
	
	public ArrayList<Loan> deserialize() throws ClassNotFoundException, IOException{
		
		ArrayList<Loan> loans = new ArrayList<Loan>();
		File fileInput = null;		
			
		try{
			fileInput = new File(filename);		
			
			if(fileInput != null)
			{
				//Try to create the object input stream. Catch any FileNotFoundException.
				ObjectInputStream input = new ObjectInputStream(new FileInputStream(fileInput));
				
				try{
					//Try to read the loan objects from the input file
					Loan loan = null;					
					loan = (Loan) input.readObject();
					loans.add(loan);
					
					while(loan != null){
						//Continue reading the file if there are objects						
						loan = (Loan) input.readObject();
						loans.add(loan);
					}								
				}
				catch(EOFException e){
					//Close the input if an EOF exception was thrown. There is no more left to read.
					input.close();
				}
				catch(ClassNotFoundException e){
					throw e;	//Throw to caller
				}
			}
		}
		catch(FileNotFoundException e){
			//Throw to caller
			throw e;
		}		
				
		return loans;		
	}

}
