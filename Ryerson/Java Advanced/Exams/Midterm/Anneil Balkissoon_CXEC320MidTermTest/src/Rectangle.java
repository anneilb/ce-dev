
public class Rectangle extends TwoDShape {

	public Rectangle() {
		// TODO Auto-generated constructor stub
	}
	
	public Rectangle(double x, double y, double width, double height) {
		this.setX(x);
		this.setY(y);
		this.setWidth(width);
		this.setHeight(height);
	}

	@Override
	public double area() {
		return getWidth() * getHeight();
	}

	@Override
	public double perimeter() {		
		return 2 * (getWidth() + getHeight());
	}

}
