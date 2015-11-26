package exercise2;

import java.awt.Graphics;
import java.awt.Polygon;
import javax.swing.JPanel;

public class RegularPolygonPanel extends JPanel{

	private int numberOfSides = 0;
	
	public RegularPolygonPanel() {
		// Default constructor
	}
	
	public RegularPolygonPanel(int numberOfSides) {		
		this.numberOfSides = numberOfSides;
	}

	public void numberOfSides(int numberOfSides) {
		this.numberOfSides = numberOfSides;
	}	

	public int numberOfSides() {
		return numberOfSides;
	}

	@Override
	protected void paintComponent(Graphics g)
	{
		super.paintComponent(g);
		
	    int xPolygonCenter = getWidth() / 2;
	    int yPolygonCenter = getHeight() / 2;
	    int polygonRadius = (int)(Math.min(getWidth(), getHeight()) * 0.4);
	    int factor = 0;

	    // Create a Polygon object
	    Polygon polygon = new Polygon();

	    // Add the points to the polygon
	    for(int x=0; x < numberOfSides; x++) 
	    {	    
	    	factor = x + 1;
	    
	    	if(factor == 1)
	    	{
	    		polygon.addPoint(xPolygonCenter + polygonRadius, yPolygonCenter);
	    		
	    		polygon.addPoint((int)(xPolygonCenter + polygonRadius *
					    Math.cos(2 * Math.PI / numberOfSides)), 
					    		 (int)(yPolygonCenter - polygonRadius *
					    Math.sin(2 * Math.PI / numberOfSides)));
	    	}
	    	else
	    	{
	    		polygon.addPoint((int)(xPolygonCenter + polygonRadius *
				    Math.cos(factor * 2 * Math.PI / numberOfSides)), 
				    		 (int)(yPolygonCenter - polygonRadius *
				    Math.sin(factor * 2 * Math.PI / numberOfSides)));	    		
	    	}
	    }

	    // Draw the polygon
	    g.drawPolygon(polygon);
	}
}
	
