package exercise2;

import java.sql.*;
import java.util.*;

public class DBManager {
	
	private static final String PARAM_DEL = ", ";
	private String connectionURL;
	private String user;
	private String password;
	private Connection dbConnection;
	
	public String getConnectionURL() {
		return connectionURL;
	}

	public void setConnectionURL(String connectionURL) {
		this.connectionURL = connectionURL;
	}
	
	public String getUser() {
		return user;
	}

	public void setUser(String user) {
		this.user = user;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}
	
	public DBManager(String connectionURL, String user, String password){		
		this.connectionURL = connectionURL;	
		this.user = user;
		this.password = password;
	}	
	
//	public static void main(String[] args) {
//		
//		//Test DBManager
//		DBManager db = new DBManager("jdbc:mysql://localhost/assignment6", "root", "");
//		HashMap<String, Object> values = new HashMap<String, Object>();
//		HashMap<String, Object> whereValues = new HashMap<String, Object>();
//		ResultSet records;
//		int result = 0;
//			
//		//Test delete Product
//		System.out.println("Deleting a product");	
//		whereValues.put("productID", new String("SP2"));		
//		
//		result = db.deleteRecord("Product", whereValues);
//		System.out.println("Records deleted: " + result);		
//		whereValues.clear();
//		
//		//Test insert Product
//		System.out.println("Inserting a product");
//		values.put("productID", new String("SP2"));
//		values.put("productDescription", new String("Surface Pro 2"));
//		values.put("productPrice", new Double(1200));
//		
//		result = db.insertRecord("Product", values);
//		System.out.println("Records inserted: " + result);		
//		values.clear();
//		
//		//Test update Product
//		System.out.println("Updating a product");	
//		whereValues.put("productID", new String("SP2"));		
//		values.put("productDescription", new String("Microsoft Surface Pro 2"));
//		values.put("productPrice", new Double(1100));	
//		
//		result = db.updateRecord("Product", values, whereValues);
//		System.out.println("Records updated: " + result);		
//		values.clear();
//		whereValues.clear();
//		
//		System.out.println("Selecting a product");	
//		whereValues.put("productID", new String("SP2"));	
//		records = db.selectRecords("Product", whereValues);
//		System.out.println("Records returned: " + db.getRecordCount(records));
//		whereValues.clear();
//		
//		System.out.println("Selecting all products");	
//		records = db.selectRecords("Product");
//		System.out.println("Records returned: " + db.getRecordCount(records));
//		
//		System.out.println("Selecting a product price");	
//		whereValues.put("productID", new String("SP2"));	
//		Double scalarResult = db.getScalar("Product", "productPrice", Double.class, whereValues);
//		System.out.println("Value returned: " + scalarResult);
//		whereValues.clear();
//		
//		db.closeConnection();
//	}
	
	public boolean createConnection(){
			
		boolean result = false;
		
		try {
			if(dbConnection == null){		
				try {
					Class.forName("com.mysql.jdbc.Driver");
					//Class.forName("oracle.jdbc.driver.OracleDriver");
					System.out.println("Driver loaded");
					
				} catch (ClassNotFoundException e) {			
					// TODO Auto-generated catch block
					e.printStackTrace();
				}		
		
				// Establish a connection			
				dbConnection = DriverManager.getConnection(connectionURL, user, password);
				result = true;
				System.out.println("Database connected");
			}					
			else{				
				if(dbConnection.isClosed()){
					// Reestablish a connection			
					dbConnection = DriverManager.getConnection(connectionURL, user, password);
					result = true;
					System.out.println("Database connected");				
				}
				else if(dbConnection.isValid(0)){
					//connection is already established 
					result = true;
				}
			}
		} catch (SQLException e) {			
			// TODO Auto-generated catch block
			e.printStackTrace();
		}			
	      
		return result;
	}
		
	public boolean closeConnection(){	
		
		boolean result = false;
		
		if(dbConnection != null){
			try{
				if(!dbConnection.isClosed() & dbConnection.isValid(0)){
					dbConnection.close();
					result = true;
					System.out.println("Database connection closed");
				}
								
			} catch (SQLException e){
				// TODO Auto-generated catch block
				e.printStackTrace();				
			}
		}
		
		return result;
	}
	
	public int insertRecord(String table, HashMap<String, Object> insertValues){
		
		int result = 0;		
		
		if(createConnection()){	
			
			//Compose a parameterized insert command			
			String sqlInsert = "INSERT INTO " + table +
							   columnsToString(insertValues) + 
							   " VALUES (" + tokenizeParams(insertValues, false) + ")";	
			
			try {
				PreparedStatement statement = dbConnection.prepareStatement(sqlInsert);
				setStatementParams(statement, insertValues, 1);
				result = statement.executeUpdate();
				
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}			
		}			
		
		return result;
	}
	
	private String columnsToString(HashMap<String, Object> params)
	{
		String result = "";
		
		for(String key : params.keySet())
			result = addToDelimitedString(key, result, PARAM_DEL);
		
		return " (" + result + ")";		
	}
	
	private String tokenizeParams(HashMap<String, Object> params, boolean applyColumnNames){
		
		String result = "";
		
		for(String key : params.keySet())
		{
			if(applyColumnNames){
				result = addToDelimitedString(key + "=?", result, PARAM_DEL);
			}
			else{
				result = addToDelimitedString("?", result, PARAM_DEL);
			}
		}
			
		return result;
	}
	
	private void setStatementParams(PreparedStatement statement, 
									HashMap<String, Object> params,
									int startParameterIndex){
		
		try {
			int parameterIndex;
			
			//Make sure parameter index is handled correctly
			if(startParameterIndex == 0){
				parameterIndex = 1;
			}
			else{
				parameterIndex = startParameterIndex;
			}
			
			//Iterate through values and set their statement values 
			for(String key : params.keySet())
			{
				if(params.get(key) instanceof String){					
					statement.setString(parameterIndex, (String)params.get(key));				
				}
				else if(params.get(key) instanceof Double){
					statement.setDouble(parameterIndex, (double)params.get(key));
				}	
				
				//Increment the index for the next parameter
				parameterIndex++;
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
		
	private String addToDelimitedString(String value, String delimitedString, String delimiter){
		
		return (value.length() > 0 ? (delimitedString.length() > 0 ? delimitedString + delimiter + value : value) : delimitedString); 
	}

	public int updateRecord(String table, 
					  		HashMap<String, Object> updateValues, 
					  		HashMap<String, Object> whereValues){
		int result = 0;		
		
		if(createConnection()){	
			
			//Compose a parameterized update command
			String sqlUpdate = "UPDATE " + table +
							   " SET " + tokenizeParams(updateValues, true) +	
							   " WHERE " + tokenizeParams(whereValues, true);					
							   							   			 
			try {
				//Obtain the record to update
				PreparedStatement statement = dbConnection.prepareStatement(sqlUpdate);
				setStatementParams(statement, updateValues, 1);
				setStatementParams(statement, whereValues, updateValues.size() + 1);
				result = statement.executeUpdate();
				
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}			
		}			
		
		return result;
	}

	public int deleteRecord(String table, HashMap<String, Object> whereValues) {
		
		int result = 0;

		if (createConnection()) {

			// Compose a parameterized update command
			String sqlDelete = "DELETE FROM " + table + 
							   " WHERE " + tokenizeParams(whereValues, true);

			try {
				// Obtain the record to update
				PreparedStatement statement = dbConnection.prepareStatement(sqlDelete);
				setStatementParams(statement, whereValues, 1);
				result = statement.executeUpdate();

			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}

		return result;
	}	
	
	public ResultSet selectRecords(String table, HashMap<String, Object> whereValues) {
		
		ResultSet result = executeSelectQuery(table, whereValues, null);
		return result;
	}	
	
	//Overloaded method to return all records
	public ResultSet selectRecords(String table) {
		
		ResultSet result = executeSelectQuery(table, null, null);
		return result;
	}
	
	//Generic method to return different column types
	public <T> T getScalar(String table,
					       String selectColumn,
					       Class<T> columnType, 
					       HashMap<String, Object> whereValues){
		
		ResultSet result = executeSelectQuery(table, whereValues, new String[]{selectColumn});				
		T returnValue = null;
		
		try {
			if(getRecordCount(result) > 0){				
				result.next();
				if(columnType.isInstance(new String())){					
					returnValue = columnType.cast(result.getString(selectColumn));				
				}
				if(columnType.isInstance(new Double(0))){
					returnValue = columnType.cast(result.getDouble(selectColumn));
				}	
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}						
		return returnValue;
	}
	
	private ResultSet executeSelectQuery(String table, 
										 HashMap<String, Object> whereValues, 
										 String[] selectColumns){	
		ResultSet result = null;
		String sqlSelect = "";

		if (createConnection()) {

			//Compose select query with specified options
			if(selectColumns != null){			
								
				for(String column : selectColumns)
					sqlSelect = addToDelimitedString(column, sqlSelect, PARAM_DEL);
					
				sqlSelect = "SELECT " + sqlSelect + " FROM " + table;
			}
			else{
				sqlSelect = "SELECT * FROM " + table;
			}
			
			//Add where clause if needed
			if(whereValues != null) 
				sqlSelect +=  " WHERE " + tokenizeParams(whereValues, true);

			try {
				// Obtain the record to update
				PreparedStatement statement = dbConnection.prepareStatement(sqlSelect);
				
				//Add where criteria if needed				
				if(whereValues != null)					
					setStatementParams(statement, whereValues, 1);
				
				result = statement.executeQuery();

			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}

		return result;		
	}
	
	//Returns the actual record count for a result set
	public int getRecordCount(ResultSet resultSet){
		
		int result = 0;
		
		//Get the size of the data returned
		try {
			resultSet.last();
			result = resultSet.getRow();      
			resultSet.beforeFirst();		
			
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}  
		
		return result;
	}
}
