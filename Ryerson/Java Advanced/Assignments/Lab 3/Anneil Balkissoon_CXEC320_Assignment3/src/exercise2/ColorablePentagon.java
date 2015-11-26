package exercise2;

public class ColorablePentagon extends GeometricObject implements Colorable {

	private double area;
	private double perimeter;	
	
	public ColorablePentagon(double area, double perimeter)
	{
		this.area = area;
		this.perimeter = perimeter;
	}	
	
	@Override
	public String howToColor() {	
		return "Color all five sides";
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
