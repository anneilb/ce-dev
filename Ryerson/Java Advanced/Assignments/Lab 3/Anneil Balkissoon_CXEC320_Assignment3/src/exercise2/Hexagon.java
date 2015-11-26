package exercise2;

public class Hexagon extends GeometricObject {

	private double area;
	private double perimeter;	
	
	public Hexagon(double area, double perimeter)
	{
		this.area = area;
		this.perimeter = perimeter;
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
