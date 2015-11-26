package exercise1;

import javax.swing.JFrame;
import javax.swing.JPanel;

public class DrawNumbers extends JFrame{

	public DrawNumbers() {		
		NumberPanel numberPanel = new NumberPanel();
		this.add(numberPanel);				
	}
		
	/** Main method */
	public static void main(String[] args) {
		DrawNumbers frame = new DrawNumbers();
	    frame.setSize(315, 350);
	    frame.setTitle("Exercise 13.5: Display Numbers");
	    frame.setLocationRelativeTo(null); // Center the frame   
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    frame.setVisible(true);
	}
}
