package exercise1; 

import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
import java.util.Enumeration;

public class DisplayStudent extends JFrame {

	private static final String CAPTION_STUDENT_COUNCIL = "Student Council";
	private static final String CAPTION_VOLUNTEER_WORK = "Volunteer Work";
	private static final String DELIMITER = ", ";
	
	private String[] computerScienceCourses = {"Java","C#","Python","Database Analysis"};
	private String[] businessCourses = {"Accounting","Business Analysis","Economics"};
	
	private JPanel panelLeft;
	private JPanel panelRight;
	
	private JTextField textName = new JTextField();
	private JTextField textAddress = new JTextField();
	private JTextField textProvince = new JTextField();
	private JTextField textCity = new JTextField();
	private JTextField textPostalCode = new JTextField();
	private JTextField textPhoneNumber = new JTextField();
	private JTextField textEmail = new JTextField();
	
	private JCheckBox checkStudentCouncil;
	private JCheckBox checkVolunteerWork;	
	private JButton buttonDisplay;
	private JTextArea textAreaDisplay;
	private JRadioButton radioBtnComputerScience;
	private JRadioButton radioBtnBusiness;
	private JComboBox<String> comboCourses; 
	private JList<String> listCourses;
	private ListModel<String> listModel;
	
	public DisplayStudent(){
		
		//Create base layout and panels 
		setLayout(new BorderLayout(5, 5));
		
		JPanel panelNorth = new JPanel(new GridLayout(1, 2, 5, 5));		
		this.add(panelNorth, BorderLayout.NORTH);
		
		panelLeft = new JPanel(new GridLayout(7, 2, 5, 5));
		panelNorth.add(panelLeft);
		
		panelRight = new JPanel(new GridLayout(1, 2, 5, 5));
		panelNorth.add(panelRight);
				
		addDetails();
		addActivities();
		addProgramDetails();							
		addDisplayArea();		
	}	
	
	private void addDetails(){		
		
		panelLeft.add(new JLabel("Name:"));
		panelLeft.add(textName);
		
		panelLeft.add(new JLabel("Address:"));
		panelLeft.add(textAddress);
		
		panelLeft.add(new JLabel("Province:"));
		panelLeft.add(textProvince);
		
		panelLeft.add(new JLabel("City:"));
		panelLeft.add(textCity);

		panelLeft.add(new JLabel("Postal Code:"));
		panelLeft.add(textPostalCode);

		panelLeft.add(new JLabel("Phone Number:"));
		panelLeft.add(textPhoneNumber);

		panelLeft.add(new JLabel("Email:"));
		panelLeft.add(textEmail);	
	}
	
	private void addActivities(){
		
		JPanel panelActivities = new JPanel(new GridLayout(2, 1));
		panelRight.add(panelActivities);
		
		checkStudentCouncil = new JCheckBox(CAPTION_STUDENT_COUNCIL);
		panelActivities.add(checkStudentCouncil);
		
		checkVolunteerWork = new JCheckBox(CAPTION_VOLUNTEER_WORK);		
		panelActivities.add(checkVolunteerWork);		
	}
	
	private void addProgramDetails(){
		
		JPanel panelProgramDetails = new JPanel(new GridLayout(2, 1, 5, 5));
		panelRight.add(panelProgramDetails);
		
		JPanel panelSelectProgram = new JPanel(new BorderLayout(5, 5));
		panelProgramDetails.add(panelSelectProgram);
		
		radioBtnComputerScience = new JRadioButton("Computer Science");
		radioBtnBusiness = new JRadioButton("Business");
		
		//Assign the radio buttons to a button group
		ButtonGroup programGroup = new ButtonGroup();
		programGroup.add(radioBtnComputerScience);
		programGroup.add(radioBtnBusiness);
				
		//Register the radio buttons to the action listener
		RadioButtonListener programGroupListener = new RadioButtonListener(); 
		radioBtnComputerScience.addActionListener(programGroupListener);
		radioBtnBusiness.addActionListener(programGroupListener);
		
		JPanel panelRadioGroup = new JPanel(new FlowLayout(FlowLayout.CENTER));	
		panelRadioGroup.add(radioBtnComputerScience);
		panelRadioGroup.add(radioBtnBusiness);		
		panelSelectProgram.add(panelRadioGroup, BorderLayout.NORTH);
		
		comboCourses = new JComboBox<String>();
		comboCourses.addItemListener(new ComboBoxItemListener());
		panelSelectProgram.add(comboCourses, BorderLayout.CENTER);
		
		listCourses = new JList<String>();
		listCourses.setVisibleRowCount(4);
		listModel = new DefaultListModel<String>();
		listCourses.setModel(listModel);		
		panelProgramDetails.add(new JScrollPane(listCourses));
	}
	
	private void addDisplayArea(){
		
		JPanel panelCenter;
		JPanel panelCenterNorth;		
		
		panelCenter = new JPanel(new BorderLayout(5, 5)); 
		this.add(panelCenter, BorderLayout.CENTER);
		
		panelCenterNorth = new JPanel(new FlowLayout(FlowLayout.CENTER));		
		buttonDisplay = new JButton("Display");
		buttonDisplay.addActionListener(new ButtonListener());
		panelCenterNorth.add(buttonDisplay);				
		panelCenter.add(panelCenterNorth, BorderLayout.NORTH);
		
		textAreaDisplay = new JTextArea();
		textAreaDisplay.setEditable(false);

		// Create a scroll pane to hold the text area
		panelCenter.add(new JScrollPane(textAreaDisplay), BorderLayout.CENTER);		
	}

	public static void main(String[] args) {
		DisplayStudent frame = new DisplayStudent();			    
		frame.setSize(1000, 400);
	    frame.setTitle("Display Student Information");
	    frame.setLocationRelativeTo(null); // Center the frame   
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    frame.setVisible(true);
	}
	
	private class ButtonListener implements ActionListener{
		@Override
		public void actionPerformed(ActionEvent e) {
		
			Object source = e.getSource();
			
			if(source.equals(buttonDisplay))
			{
				textAreaDisplay.setText(getDisplayOutput());
			}			
		}
	}
	
	private class RadioButtonListener implements ActionListener{
		@Override
		public void actionPerformed(ActionEvent e) {
			
			Object source = e.getSource();
			
			//Depending on selection, determine the appropriate array to display
			if(source.equals(radioBtnComputerScience))
			{
				populateComboBox(computerScienceCourses);				
			}						
			else if(source.equals(radioBtnBusiness))
			{
				populateComboBox(businessCourses);
			}
			
			//Clear the course list box
			((DefaultListModel<String>) listModel).clear();
		}				
	}
	
	private class ComboBoxItemListener implements ItemListener{
		@Override
		public void itemStateChanged(ItemEvent e) {
			
			Object source = e.getSource();
			
			if(source.equals(comboCourses))
			{
				addCourseItemToList((String)comboCourses.getSelectedItem());			
			}						
		}
	}	
		
	private void populateComboBox(String[] items){
		
		//Remove all combo items before populating
		comboCourses.removeAllItems();
		
		for(String item : items)
		{
			comboCourses.addItem(item);
		}		
	}
	
	private String getDisplayOutput(){
		
		String studentDetails = ""; 
		String studentCourses = "";
		String studentActivities = "";
		String displayOutput = "";
		
		//Build delimited string of student details
		studentDetails = addToDelimitedString(textName.getText(), studentDetails, DELIMITER);
		studentDetails = addToDelimitedString(textAddress.getText(), studentDetails, DELIMITER);
		studentDetails = addToDelimitedString(textProvince.getText(), studentDetails, DELIMITER);
		studentDetails = addToDelimitedString(textCity.getText(), studentDetails, DELIMITER);
		studentDetails = addToDelimitedString(textPostalCode.getText(), studentDetails, DELIMITER);
		studentDetails = addToDelimitedString(textPhoneNumber.getText(), studentDetails, DELIMITER);
		studentDetails = addToDelimitedString(textEmail.getText(), studentDetails, DELIMITER);
		
		//Get delimited string of student courses
		studentCourses = courseListToString();	
		
		//Build delimited string of student activities
		studentActivities = addToDelimitedString((checkStudentCouncil.isSelected() ? CAPTION_STUDENT_COUNCIL : ""), studentActivities, DELIMITER);
		studentActivities = addToDelimitedString((checkVolunteerWork.isSelected() ? CAPTION_VOLUNTEER_WORK : ""), studentActivities, DELIMITER);
			
		//Build display output. Skip headings for sections that were not entered.
		displayOutput = addToDelimitedString((studentDetails.length() > 0 ? "Student Details:\n" + studentDetails : ""), displayOutput, "\n\n");
		displayOutput = addToDelimitedString((studentCourses.length() > 0 ? "Student Courses:\n" + studentCourses : ""), displayOutput, "\n\n");
		displayOutput = addToDelimitedString((studentActivities.length() > 0 ? "Student Activities:\n" + studentActivities : ""), displayOutput, "\n\n");
		
		return displayOutput;
	}	
	
	private String addToDelimitedString(String value, String delimitedString, String delimiter){
		
		return (value.length() > 0 ? (delimitedString.length() > 0 ? delimitedString + delimiter + value : value) : delimitedString); 
	}
	
	private void addCourseItemToList(String item){
				
		//Make sure the list item does not exist already. 
		if(!((DefaultListModel<String>) listModel).contains(item))
		{		
			((DefaultListModel<String>) listModel).addElement(item);
		}	
	}

	private String courseListToString()	{
		
		String courseList = "";			
		
		//Iteration through enumeration elements and add them to delimited string
		for(Enumeration<String> e = ((DefaultListModel<String>) listModel).elements(); e.hasMoreElements();)
		{
			String course = e.nextElement();
			courseList = addToDelimitedString(course, courseList, "\n");
		}	
		
		return courseList;
	}
	
}
