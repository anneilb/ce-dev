
public abstract class TwoDShape {
	
	private double x = 0;
	private double y = 0;
	private double width = 0;
	private double height = 0;	
	
	public double getX() {
		return x;
	}

	public void setX(double x) {
		this.x = x;
	}

	public double getY() {
		return y;
	}

	public void setY(double y) {
		this.y = y;
	}

	public double getWidth() {
		return width;
	}

	public void setWidth(double width) {
		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		this.height = height;
	}
		
	public TwoDShape() {
		// TODO Auto-generated constructor stub
	}
	
	public String toString(){			
		
		String value;
		
		value = "TwoDShape ";
		value += "[x=" + this.getX() + ", y=" + this.getY() + 
				 ", width=" + this.getWidth() + ", height=" + this.getHeight() + "]";
		
		return value;
	}
	
	public abstract double area();
	
	public abstract double perimeter();

}
