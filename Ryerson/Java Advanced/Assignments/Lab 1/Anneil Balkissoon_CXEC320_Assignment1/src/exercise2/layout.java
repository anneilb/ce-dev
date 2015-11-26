package exercise2;

import java.awt.*;

import javax.swing.*;

public class layout extends JFrame{	
	
	private JPanel PanelNorth;
	private JPanel PanelWest;
	private JPanel PanelCenter;
	private JPanel PanelEast;
	private JPanel PanelSouth;
	
	public layout() {
		
		CreatePanels();				
		SetPanelColours();		
		CreatePanelComponents();		
	}
	
	private void CreatePanels()
	{
		PanelNorth = new JPanel(new FlowLayout(FlowLayout.CENTER,5,5));
		PanelWest = new JPanel(new FlowLayout(FlowLayout.LEADING,5,5));
		PanelCenter = new JPanel(new GridLayout(2,2,5,5));
		PanelEast = new JPanel(new FlowLayout(FlowLayout.LEADING,5,5));
		PanelSouth = new JPanel(new FlowLayout(FlowLayout.CENTER,5,5));		
		
		setLayout(new BorderLayout(0,0));
		
		add(PanelNorth, BorderLayout.NORTH);
		add(PanelWest, BorderLayout.WEST);
		add(PanelCenter, BorderLayout.CENTER);
		add(PanelEast, BorderLayout.EAST);		
		add(PanelSouth, BorderLayout.SOUTH);		
	}
	
	private void SetPanelColours()
	{
		PanelNorth.setBackground(Color.RED);
		PanelWest.setBackground(Color.ORANGE);
		PanelCenter.setBackground(Color.GREEN);
		PanelEast.setBackground(Color.GREEN);
		PanelSouth.setBackground(Color.LIGHT_GRAY);						
	}
	
	private void CreatePanelComponents()
	{			
		PanelNorth.add(new JButton("Left"));
		PanelNorth.add(new JButton("Center"));
		PanelNorth.add(new JButton("Right"));
		
		PanelWest.add(new JButton("West"));
		PanelEast.add(new JButton("East"));
		
		PanelSouth.add(new JButton("Java Advanced"));
		PanelSouth.add(new JButton("CXEC320"));		

		PanelCenter.add(new JLabel("Name: "));
		PanelCenter.add(new JTextField());		
		PanelCenter.add(new JLabel("Position: "));	
		PanelCenter.add(new JTextField());		
	}
	
	public static void main(String[] args) {
		layout frame = new layout();
		frame.setTitle("Testing the Layout");
	    frame.setSize(400, 200);
	    frame.setLocationRelativeTo(null); // Center the frame
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    frame.setVisible(true);
	}

}
