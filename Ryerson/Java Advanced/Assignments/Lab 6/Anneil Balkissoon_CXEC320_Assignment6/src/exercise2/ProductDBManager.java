package exercise2;

import java.awt.*;
import java.util.List;
import java.awt.event.*;
import java.util.*;
import javax.swing.*;
import javax.swing.table.*;

public class ProductDBManager extends JFrame {
	
	private static final String NEW_PRODUCT = "*New";
	private static final int COLUMN_INDEX_ID = 0;
	private static final int COLUMN_INDEX_DESCRIPTION = 1;
	private static final int COLUMN_INDEX_PRICE = 2;
	
	private static final int COLUMN_ID_MAX_INPUT = 10;
	private static final int COLUMN_DESCRIPTION_MAX_INPUT = 100;
	
	private JComboBox<String> comboID;
	private ComboBoxItemListener comboListener;
	private JTextField textID;
	private JTextField textDescription;
	private JTextField textPrice;	
	private JButton buttonInsert;
	private JButton buttonUpdate;
	private JButton buttonDelete;
	private JButton buttonRefresh;
	private JTable table;
	private ProductTableModel tableModel;
	private ProductDB productDB;
	
	private Product selectedProduct;
		
	public ProductDBManager(){
		
		productDB = new ProductDB();
		addWindowListener(new WindowEventListener());
		buildInterface();		
	}
	
	private void close(){
		
		productDB.close();
	}
		
	private void buildInterface(){
		
		setLayout(new BorderLayout(5,5));
		
		ArrayList<Product> products = productDB.selectAll();	
		
		addProductDetails(products);
		addDisplayArea(products);		
	}
	
	private void addProductDetails(ArrayList<Product> products){
		
		JPanel panelNorth = new JPanel();
		panelNorth.setLayout(new GridLayout(2, 4, 5, 0));		
		
		panelNorth.add(new JLabel("Select a product:"));
		panelNorth.add(new JLabel("ID:"));
		panelNorth.add(new JLabel("Description:"));
		panelNorth.add(new JLabel("Price:"));
		
		comboID = new JComboBox<String>();
		comboListener = new ComboBoxItemListener();
		comboID.addItemListener(comboListener);		
		
		//Populate the products combo
		populateComboBox(products);		
				
		textID = new JTextField();
		textDescription = new JTextField();
		textPrice = new JTextField();
		
		panelNorth.add(comboID);
		panelNorth.add(textID);
		panelNorth.add(textDescription);
		panelNorth.add(textPrice);		
				
		this.add(panelNorth, BorderLayout.NORTH);
	}
	
	private void addDisplayArea(ArrayList<Product> products){
		
		JPanel panelCenter;
		JPanel panelCenterNorth;		
		
		panelCenter = new JPanel(new BorderLayout(5, 5)); 
		this.add(panelCenter, BorderLayout.CENTER);
		
		buttonInsert = new JButton("Insert");
		buttonUpdate = new JButton("Update"); 
		buttonDelete = new JButton("Delete");
		buttonRefresh = new JButton("Refresh");
		
		//Create a button listener and attach to buttons
		ButtonListener buttonHandler = new ButtonListener();		
		buttonInsert.addActionListener(buttonHandler);
		buttonUpdate.addActionListener(buttonHandler);
		buttonDelete.addActionListener(buttonHandler);
		buttonRefresh.addActionListener(buttonHandler);
		
		panelCenterNorth = new JPanel(new FlowLayout(FlowLayout.CENTER));
		panelCenter.add(panelCenterNorth, BorderLayout.NORTH);	
		
		panelCenterNorth.add(buttonInsert);
		panelCenterNorth.add(buttonUpdate);
		panelCenterNorth.add(buttonDelete);
		panelCenterNorth.add(buttonRefresh);
		
		tableModel = new ProductTableModel(products);		
		table = new JTable(tableModel);
		
		// Create a scroll pane to hold the text area
		panelCenter.add(new JScrollPane(table), BorderLayout.CENTER);
	}
	
	private void populateComboBox(ArrayList<Product> items){
		
		String selectedProductID = (String)comboID.getSelectedItem();
		boolean selectionExists = false;
		
		//Temporarily remove the item listener to avoid reacting to events
		comboID.removeItemListener(comboListener);
				
		//Remove all combo items before populating
		comboID.removeAllItems();
		
		//Add *NEW item indicator to combo
		comboID.addItem(NEW_PRODUCT);		

		for(Product item : items)
		{
			comboID.addItem(item.getProductID());
			
			//Determine if the selected item is among new items
			if(item.getProductID().equals(selectedProductID))
				selectionExists = true;
		}
		
		//Re-apply the item listener
		comboID.addItemListener(comboListener);
		
		if(selectionExists)
			comboID.setSelectedItem(selectedProductID);		
	}
	
	private void displaySelectedProduct(String productID){
			
		Product product = productDB.select(productID);
		
		textID.setText(product.getProductID());
		textDescription.setText(product.getDescription());
		textPrice.setText(String.valueOf(product.getPrice()));
	}
	
	private void clearFields(){
		
		textID.setText("");
		textDescription.setText("");
		textPrice.setText("");
	}
	
	private void insertProduct(){
		
		if(inputIsValid(true)){
			if(productDB.insert(selectedProduct)){
				refreshDisplay();
				comboID.setSelectedItem(selectedProduct.getProductID());
			}else{
				JOptionPane.showMessageDialog(null, "There was an error inserting the product.");							
			}
		}		
	}
	
	private void updateProduct(){
		
		if(inputIsValid(false)){
			if(productDB.update(selectedProduct, selectedProduct.getProductID())){
				refreshDisplay();
			}else{
				JOptionPane.showMessageDialog(null, "There was an error updating the product.");							
			}
		}		
	}
	
	private void deleteProduct(){
		
		if(inputIsValid(false)){
			if(productDB.delete(selectedProduct.getProductID())){
				refreshDisplay();
				clearFields();
			}else{
				JOptionPane.showMessageDialog(null, "There was an error deleting the product.");							
			}
		}		
	}
	
	private void refreshDisplay(){
		
		ArrayList<Product> products = productDB.selectAll();	
		populateComboBox(products);
		tableModel.setProducts(products);
		tableModel.fireTableDataChanged();
	}
	
	private boolean inputIsValid(boolean insertAction){			
						
		try{
			selectedProduct = null;
			String productID = "";
			
			if(insertAction){
				productID = textID.getText().trim();		
			}
			else{
				productID = (String)comboID.getSelectedItem();
				
				if(productID.equals(NEW_PRODUCT)){
					JOptionPane.showMessageDialog(null, "A product must be selected.");
					return false;
				}				
			}				
			
			String description = textDescription.getText().trim();
			
			//Throw a null pointer exception if ID and description were empty
			if((productID.length() == 0) || (description.length() == 0)){
				throw new NullPointerException();				
			}//Handle excessive input
			else if(productID.length() > COLUMN_ID_MAX_INPUT){
				JOptionPane.showMessageDialog(null, "ID can be no more than " + COLUMN_ID_MAX_INPUT + " characters.");
				return false;				
			}//Handle excessive input
			else if (description.length() > COLUMN_DESCRIPTION_MAX_INPUT){
				JOptionPane.showMessageDialog(null, "Description can be no more than " + COLUMN_DESCRIPTION_MAX_INPUT + " characters.");
				return false;					
			}
						
			//Try and catch number format exception
			Double price = Double.parseDouble(textPrice.getText().trim());
			
			//Make sure product ID is unique
			if(insertAction){		
				if(productDB.productIDExists(productID)){				
					JOptionPane.showMessageDialog(null, "A unique product ID must be provided.");
					return false;					
				}
			}		
			
			selectedProduct = new Product(productID, description, price);			
			return true;
		}
		catch(NumberFormatException e)
		{
			JOptionPane.showMessageDialog(null, "A numeric price must be provided.");
			return false;		
		}	
		catch(NullPointerException e)
		{
			JOptionPane.showMessageDialog(null, "All fields must be provided.");
			return false;		
		}
	}	
	
	private class WindowEventListener extends WindowAdapter{
		@Override
		public void windowClosing(WindowEvent e) {			
			//Close the database connection
			close();			
		}
	}
	
	private class ComboBoxItemListener implements ItemListener{
		@Override
		public void itemStateChanged(ItemEvent e) {
			
			Object source = e.getSource();
			
			if(source.equals(comboID))
			{
				String productID = (String)comboID.getSelectedItem();
				
				if(productID.equals(NEW_PRODUCT)){				
					//Clear all fields if user selected *NEW
					clearFields();			
				}else{
					displaySelectedProduct(productID);
				}
			}						
		}
	}
	
	private class ButtonListener implements ActionListener{
		@Override
		public void actionPerformed(ActionEvent e) {
		
			Object source = e.getSource();
			
			if(source.equals(buttonInsert))
			{
				insertProduct();			
			}
			else if(source.equals(buttonUpdate))
			{
				updateProduct();			
			}
			else if(source.equals(buttonDelete))
			{
				deleteProduct();			
			}
			else if(source.equals(buttonRefresh))
			{
				refreshDisplay();			
			}
		}
	}

	private class ProductTableModel extends AbstractTableModel {

        private List<Product> products;

        public List<Product> getProducts() {
			return products;
		}

		public void setProducts(List<Product> products) {
			this.products = products;
		}

		public ProductTableModel(ArrayList<Product> products) {
            this.products = new ArrayList<>(products);
        }

        @Override
        public int getRowCount() {
            return products.size();
        }

        @Override
        public int getColumnCount() {
            return 3;
        }

        @Override
        public String getColumnName(int column) {
            String name = "??";
            switch (column) {
                case COLUMN_INDEX_ID:
                    name = ProductDB.COLUMN_NAME_ID;
                    break;
                case COLUMN_INDEX_DESCRIPTION:
                    name = ProductDB.COLUMN_NAME_DESCRIPTION;
                    break;
                case COLUMN_INDEX_PRICE:
                    name = ProductDB.COLUMN_NAME_PRICE;
                    break;                	
            }
            return name;
        }

        @Override
        public Class<?> getColumnClass(int columnIndex) {
            Class type = String.class;
            switch (columnIndex) {                
                case COLUMN_INDEX_PRICE:
                	type = Double.class;
                	break;
                default:
                	break;
            }
            return type;
        }

        @Override
        public Object getValueAt(int rowIndex, int columnIndex) {
            Product product = products.get(rowIndex);
            Object value = null;
            switch (columnIndex) {
                case COLUMN_INDEX_ID:
                    value = product.getProductID();
                    break;
                case COLUMN_INDEX_DESCRIPTION:
                    value = product.getDescription();
                    break;
                case COLUMN_INDEX_PRICE:
                	value = product.getPrice();
                    break;
            }
            return value;
        }            
    }        	
		
	public static void main(String[] args)	
	{
		ProductDBManager frame = new ProductDBManager();			    
		frame.setSize(700, 400);
	    frame.setTitle("Product Database Manager");
	    frame.setLocationRelativeTo(null); // Center the frame   
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);	    
	    frame.setVisible(true);
	}
	
}
