package exercise1;

import java.awt.*;
import javax.swing.*;

public class calculator extends JFrame{

	public calculator() {
		
		//FlowLayout MarginLayout = new FlowLayout(FlowLayout.CENTER,50,50);
		JPanel PanelInterface = new JPanel();
		JPanel PanelButtons = new JPanel();
		JButton TempButton;
		
		//Build the calculator margins and set the margins size
		//setLayout(MarginLayout);
		setLayout(new FlowLayout(FlowLayout.CENTER,40,95));
		
		add(PanelInterface);//, FlowLayout.CENTER);			
						
		PanelInterface.setLayout(new BorderLayout(5,5));
		PanelInterface.add(new JTextField(),BorderLayout.NORTH);		
		PanelInterface.add(PanelButtons, BorderLayout.CENTER);
		
		PanelButtons.setLayout(new GridLayout(4,5,5,5));

		PanelButtons.add(new JButton("7"));
		PanelButtons.add(new JButton("8"));
		PanelButtons.add(new JButton("9"));
		PanelButtons.add(new JButton("/"));
		PanelButtons.add(new JButton("sqrt"));
		
		PanelButtons.add(new JButton("4"));
		PanelButtons.add(new JButton("5"));
		PanelButtons.add(new JButton("6"));
		PanelButtons.add(new JButton("*"));
		PanelButtons.add(new JButton("%"));
		
		PanelButtons.add(new JButton("1"));
		PanelButtons.add(new JButton("2"));
		PanelButtons.add(new JButton("3"));
		PanelButtons.add(new JButton("-"));
		PanelButtons.add(new JButton("1/x"));
		
		PanelButtons.add(new JButton("0"));
		PanelButtons.add(new JButton("+/-"));
		PanelButtons.add(new JButton("."));
		PanelButtons.add(new JButton("+"));
		PanelButtons.add(new JButton("="));
		
	}

	public static void main(String[] args) {
		
		calculator frame = new calculator();
		frame.setTitle("Java Calculator");
	    frame.setSize(380, 380);
	    frame.setLocationRelativeTo(null); // Center the frame
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    frame.setVisible(true);
	}

}
