using System;

class Shape
{
    protected int width, height;

    public void setWidth(int w) { width = w; }
    public void setHeight(int h) { height = h; }

}

class Rectangle : Shape
{
    long area;
    public int getArea()
    {
        return width * height;
    }

    public long getCost(long lCostPerUnit)
    {
        area = getArea();
        return area * lCostPerUnit;
    }
}

class Cuboid :Rectangle
{
    int length;

    public void setLength(int l) { length = l; }

    public int getVolume()
    {
        return length * width * height;
    }

    public int getSurfaceArea()
    {
        return 2 * (length * width + length * height + width * height);
    }
}

class ShapeTester
{
    public void TestShapes()
    {
        long area;
        Rectangle rect = new Rectangle();
        Cuboid cube = new Cuboid();
        long lcost = 75;

        rect.setWidth(5);
        rect.setHeight(7);
        area = rect.getArea();

        cube.setHeight(6);
        cube.setWidth(5);
        cube.setLength(8);

        Console.WriteLine("Total Area:{0}", rect.getArea());
        Console.WriteLine("Total paint cost:${0}", rect.getCost(lcost));

        Console.WriteLine("Cuboid Surface Area: {0}", cube.getSurfaceArea());
        Console.WriteLine("Cuboid Volume: {0}", cube.getVolume());

        Console.ReadKey();
    }
}
