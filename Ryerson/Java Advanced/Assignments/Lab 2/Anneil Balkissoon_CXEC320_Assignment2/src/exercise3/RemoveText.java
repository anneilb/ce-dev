package exercise3;

import java.util.Scanner;
import java.io.*;
import java.io.PrintWriter;


public class RemoveText {

	public static void main(String[] args) throws Exception {
		  
	    // Check command line parameter usage
	    if (args.length != 2) {
	      System.out.println(
	        "Usage: java RemoveText targetFile str");
	      System.exit(1);
	    }

	    // Check if source file exists
	    File targetFile = new File(args[0]);
	    if (!targetFile.exists()) {
	      System.out.println("Source file " + args[0] + " does not exist.");
	      System.exit(2);
	    }

	    // Create input and output files
	    Scanner input = new Scanner(targetFile);
	    PrintWriter output = new PrintWriter("newtext.txt");

	    while (input.hasNext()) {
	      String s1 = input.nextLine();
	      String s2 = s1.replaceAll(args[1], "");
	      output.println(s2);
	    }

	    input.close();
	    output.close();
	}
}
