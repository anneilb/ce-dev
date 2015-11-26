package exercise2;

public class Product {
	
	private String productID;
	private String description;
	private Double price;

	public String getProductID() {
		return productID;
	}

	public void setProductID(String productID) {
		this.productID = productID;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public Double getPrice() {
		return price;
	}

	public void setPrice(Double price) {
		this.price = price;
	}
	
	public Product(){
		//Default constructor
	}
	
	public Product(String productID, String description, double price){
		
		this.productID = productID;
		this.description = description;
		this.price = price;				
	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

}
