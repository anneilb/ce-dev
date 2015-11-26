package exercise3;

import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

public class MultithreadClocks extends JFrame {
	
	private JButton buttonSuspendAll;
	private JButton buttonResumeAll;		
	private ClockAnimationController clock1;
	private ClockAnimationController clock2;
	private ClockAnimationController clock3;


	public MultithreadClocks(){
		addPanels();		
	}
	
	private class ButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {

			Object source = e.getSource();
					
			if(source.equals(buttonSuspendAll))
			{					
				suspendAll();
			}
			else if(source.equals(buttonResumeAll))
			{
				resumeAll();
			}			
		}	
	}
	
	private void addPanels(){
		
		setLayout(new BorderLayout());		
				
		JPanel panelCenter = new JPanel(new GridLayout(1, 3, 5, 5));
		add(panelCenter, BorderLayout.CENTER);
		
		JPanel panelSouth = new JPanel();		
		add(panelSouth, BorderLayout.SOUTH);
		
		buttonResumeAll = new JButton("Resume All");
		buttonSuspendAll = new JButton("Suspend All");
		
		ButtonListener buttonHandler = new ButtonListener();
		buttonResumeAll.addActionListener(buttonHandler);		
		buttonSuspendAll.addActionListener(buttonHandler);
		
		clock1 = new ClockAnimationController();
		clock2 = new ClockAnimationController();
		clock3 = new ClockAnimationController();
		
		panelCenter.add(clock1);
		panelCenter.add(clock2);
		panelCenter.add(clock3);
		
		panelSouth.add(buttonResumeAll);
		panelSouth.add(buttonSuspendAll);
	}
	
	private void resumeAll(){
			
		clock1.resume();
		clock2.resume();
		clock3.resume();
	}
	
	private void suspendAll(){
		
		clock1.suspend();
		clock2.suspend();
		clock3.suspend();
	}
	
	public static void main(String[] args) {			
	
	    JFrame frame = new MultithreadClocks();
	    frame.setTitle("Multithread Clocks");
	    frame.setSize(560, 250);
	    frame.setLocationRelativeTo(null); // Center the frame
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    frame.setVisible(true);
	}

}
