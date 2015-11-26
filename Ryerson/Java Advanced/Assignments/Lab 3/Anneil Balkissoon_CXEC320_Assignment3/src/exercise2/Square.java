package exercise2;

public class Square extends GeometricObject implements Colorable {

	private double area;
	private double perimeter;	
	
	public Square(double area, double perimeter)
	{
		this.area = area;
		this.perimeter = perimeter;
	}
	
	@Override
	public String howToColor() {
		return "Color all four sides";		
	}

	@Override
	public double getArea() {
		return area;
	}

	@Override
	public double getPerimeter() {
		return perimeter;
	}

}
