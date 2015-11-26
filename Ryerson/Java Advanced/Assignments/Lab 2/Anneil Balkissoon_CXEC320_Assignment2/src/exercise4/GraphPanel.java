package exercise4;

import java.awt.Graphics;
import javax.swing.JPanel;

public class GraphPanel extends JPanel{

	private String [][] graphVertices; 
		
	public GraphPanel() {		
		//default constructor						
	}
	
	public GraphPanel(String [][] graphVertices) {	
				
		this.graphVertices = graphVertices;	    
	}
	
	@Override
	protected void paintComponent(Graphics g){
		super.paintComponent(g);		
		
		drawOvals(g);	//Draw the ovals
		drawEdges(g);	//Draw the edges
	}	
			
	private void drawOvals(Graphics g)
	{	
		for(int y=0; y < graphVertices.length; y++)
		{
			g.fillOval(Integer.parseInt(graphVertices[y][1]) - 5, 
					   Integer.parseInt(graphVertices[y][2]) - 5, 10, 10);				
		}
	}
	
	private void drawEdges(Graphics g)
	{		
		int vertexIndex;
		
		for(int y=0; y < graphVertices.length; y++)
		{
			for(int x=3; x < graphVertices[y].length; x++)
			{
				if(graphVertices[y][x] != null)
				{
					vertexIndex = Integer.parseInt(graphVertices[y][x]);
					
					g.drawLine(Integer.parseInt(graphVertices[y][1]), 
							   Integer.parseInt(graphVertices[y][2]),
							   Integer.parseInt(graphVertices[vertexIndex][1]),
							   Integer.parseInt(graphVertices[vertexIndex][2]));							    
				}
			}			
		}
	}

}
