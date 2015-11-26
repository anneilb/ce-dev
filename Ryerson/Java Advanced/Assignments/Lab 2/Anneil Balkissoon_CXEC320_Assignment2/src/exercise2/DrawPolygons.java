package exercise2;

import java.awt.GridLayout;

import javax.swing.JFrame;

public class DrawPolygons extends JFrame{
		
	public DrawPolygons() {		
		
		setLayout(new GridLayout(1, 6, 5, 5));
		
		add(new RegularPolygonPanel(5)); //pentagon 
		add(new RegularPolygonPanel(6)); //hexagon
		add(new RegularPolygonPanel(7)); //heptagon
		add(new RegularPolygonPanel(8)); //octogon 
		add(new RegularPolygonPanel(9)); //nonagon 
		add(new RegularPolygonPanel(10)); //decagon
	}

	public static void main(String[] args) {
		DrawPolygons frame = new DrawPolygons();
	    frame.setSize(400, 100);
	    frame.setTitle("Exercise 13.25: Geometry");
	    frame.setLocationRelativeTo(null); // Center the frame   
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    frame.setVisible(true);
	}

}
