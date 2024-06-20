using System;
using System.Text;
public class Task1
{
    private Rectangle[] rectangles;

    public Rectangle[] Rectangles => rectangles;

    public Task1(Rectangle[] rectangles)
    {
        this.rectangles = rectangles;
    }

    public void Sorting()
    {
        for (int i = 0; i < rectangles.Length - 1; i++)
        {
            for (int j = 0; j < rectangles.Length - 1 - i; j++)
            {
                if (rectangles[j].Length() > rectangles[j + 1].Length())
                {
                    var temp = rectangles[j];
                    rectangles[j] = rectangles[j + 1];
                    rectangles[j + 1] = temp;
                }
            }
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var rectangle in rectangles)
        {
            sb.AppendLine(rectangle.ToString());
        }
        return sb.ToString();
    }

    public struct Rectangle
    {
        public int A { get; }
        public int B { get; }

        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }

        public int Length() => 2 * (A + B);
        public int Area() => A * B;

        public int Compare(Rectangle other)
        {
            int area1 = this.Area();
            int area2 = other.Area();

            if (area1 > area2) return 1;
            if (area1 < area2) return -1;
            return 0;
        }

        public override string ToString()
        {
            return $"a = {A}, b = {B}, p = {Length()}, s = {Area()}";
        }
    }
}
