package exercise3;

import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

public class ClockAnimationController extends JPanel {

	private StillClock clock = new StillClock();
	private Thread animationThread;
	private JButton buttonSuspend;
	private JButton buttonResume;
		
	public ClockAnimationController(){		
		
		//Build the interface and start the animation
		buildInterface();	
		resume();
	}

	
	public void resume(){
		
		//Start or resume the animation thread
		animationThread = new Thread(new ClockAnimation());
		animationThread.start();
	}
	
	public void suspend(){
		
		//Suspend the animation thread
		if(! animationThread.isInterrupted())
		{
			animationThread.interrupt();
		}
	}
	

	private class ClockAnimation implements Runnable{
			
	    @Override //Keep animating the clock until it is interrupted
	    public void run() {
	      try {
	    	  while (true) {
	    		  // Set new time and repaint the clock to display current time
	    		  clock.setCurrentTime();	    		 	    		  
	    		  clock.repaint();	          
	    		  Thread.sleep(1000);
	    	  }
	      }
	      catch (InterruptedException ex) {
	    	  //ex.printStackTrace();
	      }
	    }
	}
	
	private class ButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {

			Object source = e.getSource();
					
			if(source.equals(buttonSuspend))
			{					
				suspend();
			}
			else if(source.equals(buttonResume))
			{
				resume();
			}			
		}	
	}
	

	private void buildInterface(){
		
		setLayout(new BorderLayout(5, 5));
		add(clock, BorderLayout.CENTER);
		
		JPanel panelButtons = new JPanel();
		add(panelButtons, BorderLayout.SOUTH);
		
		buttonSuspend = new JButton("Suspend");
		buttonResume = new JButton("Resume");
		
		ButtonListener buttonHandler = new ButtonListener();		
		buttonSuspend.addActionListener(buttonHandler);
		buttonResume.addActionListener(buttonHandler);
		
		panelButtons.add(buttonSuspend);
		panelButtons.add(buttonResume);
	}
}
