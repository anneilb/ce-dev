package exercise1;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.text.DateFormatSymbols;
import java.util.*;

import javax.swing.*;

public class DisplayCalendar extends JFrame {
	
	private Calendar dateCalendar;
	
	public DisplayCalendar() {		
		
		dateCalendar = new GregorianCalendar();
		//dateCalendar = new GregorianCalendar(2014, 2, 1) ;		
		
		buildCaptions();		
		
		CalendarPanel displayPanel = new CalendarPanel(dateCalendar);		
		this.add(displayPanel, BorderLayout.CENTER);				
	}
	
	private void buildCaptions(){
		
		//Build a collection of month names
//		Map<String, Integer> representations = dateCalendar.getDisplayNames(Calendar.MONTH, Calendar.LONG, Locale.CANADA);		
//		NavigableMap<String, Integer> monthNames = new TreeMap<String, Integer>(representations);
		
		//Set frame layout
		setLayout(new BorderLayout());
		
		//Build label components
		JPanel captionsPanel = new JPanel();
		captionsPanel.setLayout(new GridLayout(2, 1));	
		JLabel monthLabel = new JLabel();		
		captionsPanel.add(monthLabel);
		
		int minimumDaysOfWeek = dateCalendar.getActualMinimum(Calendar.DAY_OF_WEEK);
		int maximumDaysOfWeek = dateCalendar.getActualMaximum(Calendar.DAY_OF_WEEK);		
		
		JLabel daysOfWeekLabel = new JLabel();		
		daysOfWeekLabel.setLayout(new GridLayout(1, maximumDaysOfWeek));
		daysOfWeekLabel.setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
		captionsPanel.add(daysOfWeekLabel);
		
		this.add(captionsPanel, BorderLayout.NORTH);	

		//Populate month label caption
		String monthCaption;
		
		monthCaption = dateCalendar.getDisplayName(Calendar.MONTH, Calendar.LONG, Locale.CANADA);
		monthCaption += " " + dateCalendar.get(Calendar.YEAR);		
		
		monthLabel.setText(monthCaption);
		monthLabel.setHorizontalAlignment(JLabel.CENTER);
		//monthLabel.setMinimumSize(new Dimension(monthLabel.getWidth(), 500));
		
		//Populate weekday label captions. Get names from DateFormatSymbols class.			
		String weekdayNames[] = new DateFormatSymbols(Locale.CANADA).getWeekdays();
		
		for(int dayOfWeek = minimumDaysOfWeek; dayOfWeek <= maximumDaysOfWeek; dayOfWeek++)
		{
			JLabel dayLabel = new JLabel();
			dayLabel.setText(weekdayNames[dayOfWeek]);
			dayLabel.setHorizontalAlignment(JLabel.CENTER);
			daysOfWeekLabel.add(dayLabel);			
		}		
						
	}

	public static void main(String[] args) {
		
		DisplayCalendar frame = new DisplayCalendar();			    
		frame.setSize(500, 300);
	    frame.setTitle("Exercise 15.5: Display a calendar");
	    frame.setLocationRelativeTo(null); // Center the frame   
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    frame.setVisible(true);
	}

}
