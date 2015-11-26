package exercise1;

public class BubbleSortGeometricObjects {	
	
	/** Bubble sort method */
	public static void bubbleSort(GeometricObject[] list) {
		  
		GeometricObjectComparator comparator = new GeometricObjectComparator();
		boolean needNextPass = true;
		    
		for (int k = 1; k < list.length && needNextPass; k++) 
		{  
			// Array may be sorted and next pass not needed
			needNextPass = false;
	
			for (int i = 0; i < list.length - k; i++) 
			{		    
				if (comparator.compare(list[i], list[i + 1]) > 0)  
				//(list[i] > list[i + 1]) 
				{
					// Swap list[i] with list[i + 1]
					GeometricObject temp = list[i];
					list[i] = list[i + 1];
					list[i + 1] = temp;
	  
					needNextPass = true; // Next pass still needed
				}
			}
		}
	}

	/** A test method */
	public static void main(String[] args) {
	 
		GeometricObject[] list = {new Circle(5), new Rectangle(4, 5),
			new Circle(5.5), new Rectangle(2.4, 5), new Circle(0.5),
			new Rectangle(4, 65), new Circle(4.5), new Rectangle(4.4, 1),
			new Circle(6.5), new Rectangle(4, 5)};
	    
		bubbleSort(list);
		
		for (int i = 0; i < list.length; i++)
		{
			String output = "[" + i + "] " + list[i].getClass().getSimpleName() + ":\t" + 
							list[i].getArea() + "\n";
			
			System.out.print(output );
		}
	}
}
