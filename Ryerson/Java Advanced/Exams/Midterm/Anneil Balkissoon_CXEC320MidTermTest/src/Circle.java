
public class Circle extends TwoDShape {

	public Circle() {
		//default constructor
	}
	
	public Circle(double x, double y, double width, double height) {
		this.setX(x);
		this.setY(y);
		this.setWidth(width);
		this.setHeight(height);
	}
	
	@Override
	public double area() {		
		return this.radius() * this.radius() * Math.PI;
	}

	@Override
	public double perimeter() {
	    return 2 * this.radius() * Math.PI;
	}
	
	private double radius(){		
		return getWidth() / 2;		
	}

}
