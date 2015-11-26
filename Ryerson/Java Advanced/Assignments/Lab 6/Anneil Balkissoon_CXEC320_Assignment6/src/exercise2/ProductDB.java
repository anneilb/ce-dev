package exercise2;

import java.sql.*;
import java.util.*;

//This class provides an interface for DB communication to client application.
//Also this class is responsible for knowing how to map a product object 
//to a product DB record and back again.
public class ProductDB {

	//Database connection URL and user credentials. Typically these would not be hard coded.
	private static final String CONNECTION_URL = "jdbc:mysql://localhost/assignment6";
	private static final String USERNAME = "root";
	private static final String PASSWORD = "";
	
	public static final String TABLE_NAME = "Product";
	public static final String COLUMN_NAME_ID = "productID";
	public static final String COLUMN_NAME_DESCRIPTION = "productDescription";
	public static final String COLUMN_NAME_PRICE = "productPrice";
	
	private DBManager db;
	
	public ProductDB(){	
		//Initialize the DB
		db = new DBManager(CONNECTION_URL, USERNAME, PASSWORD);		
	}
	
//	public static void main(String[] args) {
//		
//		//Test ProductDB
//		ProductDB products = new ProductDB();
//		Product product;		
//		boolean result;
//		
//		//Test delete Product
//		System.out.println("Deleting a product");
//		result = products.delete("SP2");
//		System.out.println("Records deleted: " + result);		
//		
//		//Test insert Product
//		System.out.println("Inserting a product");
//		product = new Product("SP2", "Surface Pro 2", 1200);		
//		result = products.insert(product);
//		System.out.println("Records inserted: " + result);		
//		
//		//Test update Product
//		System.out.println("Updating a product");	
//		product = new Product("SP2", "Microsoft Surface Pro 2", 1100);
//		result = products.update(product, "SP2");
//		System.out.println("Records updated: " + result);		
//		
//		//Test select a Product
//		System.out.println("Selecting a product");	
//		product = products.select("SP2");
//		System.out.println("Records returned: " + (product != null));
//		
//		//Test select all Products
//		System.out.println("Selecting all products");
//		ArrayList<Product> records = products.selectAll();
//		System.out.println("Records returned: " + records.size());	
//		
//		//Test select a ProductID
//		System.out.println("Selecting a product ID");	
//		result = products.productIDExists("SP2");
//		System.out.println("Records returned: " + result);		
//				
//		products.close();
//	}
	
	public boolean close(){
		
		boolean result = db.closeConnection();
		return result;
	}
	
	public boolean insert(Product product){		

		boolean result = (db.insertRecord(TABLE_NAME, getProductMap(product)) == 1);
		return result;
	}
	
	public boolean update(Product product, String productID){
		
		boolean result = false;
		HashMap<String, Object> where = new HashMap<String, Object>();
		
		where.put(COLUMN_NAME_ID, productID);		
		result = (db.updateRecord(TABLE_NAME, getProductMap(product), where) == 1);
		
		return result;		
	}
	
	public boolean delete(String productID){
		
		boolean result = false;
		HashMap<String, Object> where = new HashMap<String, Object>();
		
		where.put(COLUMN_NAME_ID, productID);		
		result = (db.deleteRecord(TABLE_NAME, where) == 1);
		
		return result;		
	}
	
	public Product select(String productID){
		
		Product product = null;
		HashMap<String, Object> where = new HashMap<String, Object>();
		
		where.put(COLUMN_NAME_ID, productID);
		ResultSet resultSet = db.selectRecords(TABLE_NAME, where);
		
		if(db.getRecordCount(resultSet) == 1){			
			try {
				if(resultSet.next()){
					product = getResultSetProduct(resultSet);
				}
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
				
		return product;
	}
	
	public ArrayList<Product> selectAll(){
		
		ArrayList<Product> products = new ArrayList<Product>();
		int recordCount;

		ResultSet resultSet = db.selectRecords(TABLE_NAME);		
		recordCount = db.getRecordCount(resultSet);
				
		if(recordCount > 0){			
					
			try {
				//Populate the array list with products from the result set
				while(resultSet.next()){
					products.add(getResultSetProduct(resultSet));
				}
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
				
		return products;
	}
	
	public boolean productIDExists(String productID){
		
		HashMap<String, Object> where = new HashMap<String, Object>();		
		where.put(COLUMN_NAME_ID, productID);
		String scalarValue = db.getScalar(TABLE_NAME, COLUMN_NAME_ID, String.class, where);		
		
		if(scalarValue != null){
			return scalarValue.equals(productID);
		}
		else{
			return false;
		}
	}
	
	private Product getResultSetProduct(ResultSet resultSet){
		
		Product product = null;
		
		try {
			product = new Product();
			product.setProductID(resultSet.getString(COLUMN_NAME_ID));
			product.setDescription(resultSet.getString(COLUMN_NAME_DESCRIPTION));
			product.setPrice(resultSet.getDouble(COLUMN_NAME_PRICE));
			
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
				
		return product;				
	}
	
	private HashMap<String, Object> getProductMap(Product product){
		
		HashMap<String, Object> productMap = new HashMap<String, Object>();
		
		//Map product properties to database columns
		productMap.put(COLUMN_NAME_ID, product.getProductID());
		productMap.put(COLUMN_NAME_DESCRIPTION, product.getDescription());
		productMap.put(COLUMN_NAME_PRICE, product.getPrice());
		
		return productMap;
	}	
	
}
