import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;
import javax.swing.*;


public class ConferenceGUI extends JFrame{

	private static String[] citiesList = new String[]{"New York", "San Francisco", "Toronto"};
	private static String SPACER = "            ";
	
	private JTextField textSponsors = new JTextField();
	private JTextField textDate = new JTextField();
	private JTextField textParticipants = new JTextField();
	private JComboBox<String> comboCity = new JComboBox<String>();
	private JButton buttonEnter = new JButton("Enter");	
	private JTextArea textArea = new JTextArea();
	private ArrayList<ConferenceInfo> list = null;
	
	private String inputSponsor = "";
	private String inputDate = "";
	private int inputParticipants = 0;
	private String inputCity = "";
	
	public ConferenceGUI() {		
		
		buildInterface();
		list = new ArrayList<ConferenceInfo>();
	}
	
	private void buildInterface(){
		
		// build interface	
		//Build the calculator margins and set the margins size
		//setLayout(MarginLayout);
		setLayout(new FlowLayout(FlowLayout.CENTER,40,95));
		
		JPanel panelCenter = new JPanel(new GridLayout(2,1)); ;	
		
		JPanel panelCenterNorth = new JPanel(new GridLayout(4, 3)) ;
		panelCenterNorth.add(new JLabel("Main sponsors:"));
		panelCenterNorth.add(textSponsors);
		panelCenterNorth.add(new JLabel(""));
		
		panelCenterNorth.add(new JLabel("Date:"));
		panelCenterNorth.add(textDate);
		panelCenterNorth.add(new JLabel(""));
		
		panelCenterNorth.add(new JLabel("Participants:"));
		panelCenterNorth.add(textParticipants);
		panelCenterNorth.add(new JLabel(""));
		
		panelCenterNorth.add(new JLabel("City:"));	
		panelCenterNorth.add(comboCity);
		panelCenterNorth.add(buttonEnter);
		buttonEnter.addActionListener(new ButtonListener());
		populateComboBox(citiesList);	
					
		JPanel panelCenterSouth = new JPanel(new GridLayout(2,1));
		panelCenterSouth.add(new JLabel("Date" + SPACER  +  "Participants" + SPACER + "Sponsor"  + SPACER + "City"));		
		panelCenterSouth.add(new JScrollPane(textArea));
		
		panelCenter.add(panelCenterNorth);	
		panelCenter.add(panelCenterSouth);
		this.add(panelCenter);		
	}
	
	private void populateComboBox(String[] items){
		
		//Remove all combo items before populating
		comboCity.removeAllItems();
		
		for(String item : items)
		{
			comboCity.addItem(item);
		}		
	}
	
	private class ButtonListener implements ActionListener{
		@Override
		public void actionPerformed(ActionEvent e) {
		
			Object source = e.getSource();
			
			if(source.equals(buttonEnter))
			{
				if(inputIsValid()){
					writeData();
					displayData();
				}							
			}
		}
	}
	
	private void writeData(){		
			
		ConferenceInfo input = new ConferenceInfo(inputDate, inputParticipants, inputSponsor, inputCity);
		list.add(input);
		
		for(ConferenceInfo item : list){
			
			textArea.append(inputDate + SPACER + inputParticipants + SPACER + inputSponsor + SPACER + inputCity + "\n");	
			
			try {
				DataInfo.openFile();
				DataInfo.addRecords(item);
				DataInfo.closeFile();
				
			} catch (FileNotFoundException e) {
				JOptionPane.showMessageDialog(null, "The data file was not found.");
				
			} catch (IOException e) {
				
				JOptionPane.showMessageDialog(null, "There was problem writing to data file.");
			}					
		}					
	}
	
	private void displayData(){
		
		textArea.setText("");
		
		for(ConferenceInfo item : list){
			
			textArea.append(item.getDate() + SPACER + item.getNrOfParticipants() + SPACER + item.getSponsor() + SPACER + item.getCity() + "\n");
		}					
	}
	
	private boolean inputIsValid(){			
		
		try{					
			
			inputDate = textDate.getText().trim();
			inputParticipants = Integer.parseInt(textParticipants.getText().trim());
			inputSponsor = textSponsors.getText().trim();
			inputCity = (String)comboCity.getSelectedItem();			
			
			//Throw a null pointer exception if ID and description were empty
			if((inputDate.length() == 0) || (inputSponsor.length() == 0) || (inputCity.length() == 0)){
				throw new NullPointerException();
			}
	
			return true;
		}
		catch(NumberFormatException e)
		{
			JOptionPane.showMessageDialog(null, "A numeric participant number must be provided.");
			return false;		
		}	
		catch(NullPointerException e)
		{
			JOptionPane.showMessageDialog(null, "All fields must be provided.");
			return false;		
		}
	}	

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		ConferenceGUI frame = new ConferenceGUI();			    
		frame.setSize(700, 400);
	    frame.setTitle("Product Database Manager");
	    frame.setLocationRelativeTo(null); // Center the frame   
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);	    
	    frame.setVisible(true);
	}

}
