package exercise1;

import java.awt.*;
import java.util.*;
import javax.swing.*;
import javax.swing.border.Border;

public class CalendarPanel extends JPanel {
	
	private Calendar displayCalendar;
	private JLabel[][] dayLabels;
	
	public CalendarPanel(){
		//Default constructor
	}	
	
	public CalendarPanel(Calendar dateCalendar){	
		
		//Initialize calendar object		
		displayCalendar = dateCalendar;	
		
		//Build grid layout labels and then insert calendar days
		buildLayout();
		buildCalendar();
		
		//Set the panel border
		setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
	}
	
	private void buildLayout(){		
		
		//Determine the upper array bounds for the current calendar month 
		int maximumRows = displayCalendar.getActualMaximum(Calendar.WEEK_OF_MONTH);
		int maximumCols = displayCalendar.getActualMaximum(Calendar.DAY_OF_WEEK);
		
		this.setLayout(new GridLayout(maximumRows, maximumCols));
		dayLabels = new JLabel[maximumRows][maximumCols];
		
		//Initialize the array of grid labels
		for(int x = 0; x < maximumRows; x++)
		{
			for(int y = 0; y < maximumCols; y++)
			{
				dayLabels[x][y] = new JLabel();
				add(dayLabels[x][y]);
			}			
		}		
	}
		
	private void buildCalendar(){	
		
		//Before we start, set the calendar date to the first of the month
		displayCalendar.set(Calendar.DAY_OF_MONTH, 1);
		
		int minimumDayOfMonth = displayCalendar.getActualMinimum(Calendar.DAY_OF_MONTH);
		int maximumDayOfMonth = displayCalendar.getActualMaximum(Calendar.DAY_OF_MONTH);		
		
		for(int dayOfMonth = minimumDayOfMonth; dayOfMonth <= maximumDayOfMonth; dayOfMonth++)
		{			
			int dayOfWeek = displayCalendar.get(Calendar.DAY_OF_WEEK); //get our x coordinate
			int weekOfMonth = displayCalendar.get(Calendar.WEEK_OF_MONTH); //get our y coordinate				
			
			JLabel dayLabel = dayLabels[weekOfMonth - 1][dayOfWeek - 1]; //get our target label
			
			//Set the text of the label to the day of the month
			dayLabel.setText("" + dayOfMonth);
			dayLabel.setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
			dayLabel.setHorizontalAlignment(JLabel.CENTER);
			
			//Finally roll the calendar date up by one day for next iteration
			displayCalendar.roll(Calendar.DAY_OF_MONTH, true);
		}
	}

}
