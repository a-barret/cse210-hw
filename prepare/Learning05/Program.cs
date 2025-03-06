using System;

class Program
{
    static void Main(string[] args)
    {
        Square s = new Square("Green", 5);
        Console.WriteLine(s.GetColor());
        Console.WriteLine(s.GetArea());

        Circle c = new Circle("Blue", 3);
        Console.WriteLine(c.GetColor());
        Console.WriteLine(c.GetArea());

        Rectangle r = new Rectangle("Yellow", 3, 5);
        Console.WriteLine(r.GetColor());
        Console.WriteLine(r.GetArea());

        List<Shape> shapes = new List<Shape>();
        shapes.Add(s);
        shapes.Add(c);
        shapes.Add(r);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}