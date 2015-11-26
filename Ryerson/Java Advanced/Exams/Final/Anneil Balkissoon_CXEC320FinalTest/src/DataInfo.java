import java.io.*;

public class DataInfo {

	private static final String FILE_NAME = "CXEC320FinalTest.dat";	
	private static File fileOutput = null;		
	private static ObjectOutputStream output;
	
//	public DataInfo() {
//		// TODO Auto-generated constructor stub
//	}
	
	public static void openFile() throws FileNotFoundException, IOException{
		
		try{
			fileOutput = new File(FILE_NAME);		
			
			if(fileOutput != null)
			{
				//Try to create the object output stream. Catch any FileNotFoundException.
				output = new ObjectOutputStream(new FileOutputStream(fileOutput));				
			}
		}
		catch(FileNotFoundException e){
			
			throw e;
		}
		catch(IOException e){
			
			throw e;
		}
	}
	
	public static void addRecords(ConferenceInfo info) throws IOException {
		
		try{			
			if(output != null)
			{
				//Try to write the ConferenceInfo object to the output file
				output.writeObject(info);			
			}
		}
		catch(IOException e){
			
			throw e;
		}
		
	}
	
	public static void closeFile() throws IOException{
		
		try{			
			if(output != null)
			{
				//Try to close the ConferenceInfo output file
				output.close();
			}
		}
		catch(IOException e){
			
			throw e;
		}				
	}

}
