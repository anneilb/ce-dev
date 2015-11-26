
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class DisplayTwoDShapes extends JFrame {
	
	JTextField textX = new JTextField();
	JTextField textY = new JTextField();
	JTextField textWidth = new JTextField();
	JTextField textHeight = new JTextField();
	JButton buttonCircle = new JButton("Compute Circle");
	JButton buttonRectangle = new JButton("Compute Rectangle");
	JTextArea textAreaDisplay = new JTextArea();
	
	private double inputX = 0;
	private double inputY = 0;
	private double inputWidth = 0;
	private double inputHeight = 0;
			
	public DisplayTwoDShapes(){	
		
		setLayout(new BorderLayout());
		addUIComponents();
	}
	
	private void addUIComponents(){
		
		JPanel panelNorth = new JPanel();		
		panelNorth.setLayout(new GridLayout(5, 2, 5, 5));
		this.add(panelNorth, BorderLayout.NORTH);
		
		panelNorth.add(new JLabel("X:"));
		panelNorth.add(textX);
		
		panelNorth.add(new JLabel("Y:"));
		panelNorth.add(textY);

		panelNorth.add(new JLabel("Width"));
		panelNorth.add(textWidth);

		panelNorth.add(new JLabel("Height"));
		panelNorth.add(textHeight);	
		
		panelNorth.add(buttonCircle);
		panelNorth.add(buttonRectangle);
		
		ButtonListener buttonHander = new ButtonListener();
		buttonCircle.addActionListener(buttonHander);
		buttonRectangle.addActionListener(buttonHander);
				
		textAreaDisplay.setEditable(false);
		
		// Create a scroll pane to hold the text area
		this.add(new JScrollPane(textAreaDisplay), BorderLayout.CENTER);			
	}
	
	
	public static void main(String[] args) {
		DisplayTwoDShapes frame = new DisplayTwoDShapes();			    
		frame.setSize(400, 300);		
	    frame.setTitle("2D Shape Computations");
	    frame.setLocationRelativeTo(null); // Center the frame   
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    frame.setVisible(true);	    
	}
	
	private class ButtonListener implements ActionListener{
		@Override
		public void actionPerformed(ActionEvent e) {
		
			Object source = e.getSource();
			
			if(source.equals(buttonCircle))
			{
				if(inputIsValid())
				{
					textAreaDisplay.setText(computeCircle());
				}
			}
			else if(source.equals(buttonRectangle))
			{
				if(inputIsValid())
				{
					textAreaDisplay.setText(computeRectangle());
				}
			}
		}
	}
	
	private boolean inputIsValid(){			
		
		try{
			inputX = Double.parseDouble(textX.getText());
			inputY = Double.parseDouble(textY.getText());
			inputWidth = Double.parseDouble(textWidth.getText());
			inputHeight = Double.parseDouble(textHeight.getText());			
			return true;
		}
		catch(NumberFormatException e)
		{
			JOptionPane.showMessageDialog(null, "Numeric values must be provided.");
			return false;
		}	
	}	
	
	private String computeCircle(){
		
		String value;
		
		Circle circle = new Circle(inputX, inputY, inputWidth, inputHeight);		
		value = circle.toString();
		value += "\n\n" + "Circle Area: " + circle.area();	
		value += "\n\n" + "Circle Perimeter: " + circle.perimeter();
		
		return value;
	}
	
	private String computeRectangle(){
		
		String value;
		
		Rectangle  rectangle = new Rectangle(inputX, inputY, inputWidth, inputHeight);
		value = rectangle.toString();
		value += "\n\n" + "Rectangle Area: " + rectangle.area();	
		value += "\n\n" + "Rectangle Perimeter: " + rectangle.perimeter();
		
		return value;				
	}
		
}
