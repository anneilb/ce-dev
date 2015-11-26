package exercise2;

public class TestGeometricObjects {
  
	public static void main(String[] args) {
    
		// Declare and initialize and array of five geometric objects
		GeometricObject shapes[] = new GeometricObject[5]; 
		
		shapes[0] = new Triangle(5, 15);
		shapes[1] = new Square(10, 30);
		shapes[2] = new ColorablePentagon(20, 60);
		shapes[3] = new Hexagon(30, 90);
		shapes[4] = new ColorableOctagon(40, 120);    
		
		for(int x = 0; x <= 4; x++)
		{
		    // Display the shape
		    displayGeometricObject(shapes[x]);
		}
	}
 
	/** A method for displaying a geometric object */
	public static void displayGeometricObject(GeometricObject object) {
    
	  	System.out.println();
	  	System.out.println("The object is a " + object.getClass().getSimpleName());
	  	System.out.println("The area is " + object.getArea());
	  	System.out.println("The perimeter is " + object.getPerimeter());
	
		//Indicate if the object implements Colorable 
		if(object instanceof Colorable)
		{
			System.out.println("How to color: " + ((Colorable)object).howToColor());
		}
	}
}
