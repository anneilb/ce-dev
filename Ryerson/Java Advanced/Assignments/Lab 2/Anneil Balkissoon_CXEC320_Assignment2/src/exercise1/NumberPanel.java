package exercise1;

import javax.swing.*;
import java.awt.*;

public class NumberPanel extends JPanel{

	private int heightInterval = 0;
	
	public NumberPanel() {		
		setFont(new Font("Arial", Font.BOLD, 18));		
	}
		
	@Override
	protected void paintComponent(Graphics g)
	{ 
		super.paintComponent(g);
		
		int numberCounter = 0;
		String numberMessage = "";
		int height = getHeight();
		int yCoordinate = 0;		
		
		if (heightInterval == 0)
		{	//Set the height interval using the font height 
			FontMetrics fm = g.getFontMetrics();		
			heightInterval = fm.getHeight();
		}			
		
		for(int y=0; y <= height; y++) 
		{	//Draw our numbers
			numberCounter += 1;	
			numberMessage = numberMessage + " " + numberCounter;
			yCoordinate += heightInterval;
			g.drawString(numberMessage, 0, yCoordinate);
		}		
	}
}
