package exercise2;

import java.io.*;
import java.util.*;

public class CalculateLoanAmount {			
	
	private static final String DATA_FILENAME = "Exercise19_07.dat";

	public static void main(String[] args){
		
		CalculateLoanAmount calcLoan = new CalculateLoanAmount();		
		calcLoan.writeLoansToFile();
		calcLoan.calculateTotalLoanAmount();		
	}
	
	public void writeLoansToFile(){		
		
		LoanSerializer serializer = new LoanSerializer(DATA_FILENAME);
		ArrayList<Loan> loans = new ArrayList<Loan>();
		
		loans.add(new Loan(1.5, 1, 10000));
		loans.add(new Loan(1.75, 2, 20000));
		loans.add(new Loan(2, 3, 30000));
		
		try{		
			serializer.serialize(loans);
			System.out.println("Loans serialized to file: " + DATA_FILENAME + "\n");						
		}
		catch (IOException e) {			
    		System.out.print(e.getMessage());
		}	
	}	
	
	public void calculateTotalLoanAmount(){
						
		LoanSerializer serializer = new LoanSerializer(DATA_FILENAME);
		ArrayList<Loan> loans;
		
		try{		
			double totalLoanAmount = 0;
			loans = serializer.deserialize();
			System.out.println("Loans deserialized from file: " + DATA_FILENAME + "\n");			
			
			for(Loan loan : loans)
			{
				System.out.println("Annual Interest Rate = " + loan.getAnnualInterestRate() + 
									"\nNumber Of Years = " + loan.getNumberOfYears() +
									"\nLoan Amount = " + loan.getLoanAmount());
				
				//Keep a running total of the total loan amount
				totalLoanAmount += loan.getLoanAmount();
				
				System.out.println();
			}			
			
			System.out.println("Total loan amount =  " + totalLoanAmount);					
		}
		catch (ClassNotFoundException e) {			
    		System.out.print("Class Loan does not exist.");
		}
		catch (IOException e) {			
    		System.out.print(e.getMessage());
		}						
	}
}
