using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Variant_5
{
    public class Task2
    {
        private Embrasure[] embrasures;

        public Embrasure[] Embrasures => embrasures;

        public Task2(Embrasure[] embrasures)
        {
            this.embrasures = embrasures;
        }

        public void Sorting()
        {
            for (int i = 0; i < embrasures.Length - 1; i++)
            {
                for (int j = 0; j < embrasures.Length - 1 - i; j++)
                {
                    if (embrasures[j].Cost() > embrasures[j + 1].Cost())
                    {
                        var temp = embrasures[j];
                        embrasures[j] = embrasures[j + 1];
                        embrasures[j + 1] = temp;
                    }
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var embrasure in embrasures)
            {
                sb.AppendLine(embrasure.ToString());
            }
            return sb.ToString();
        }
    }

    public abstract class Rectangle
    {
        public int A { get; }
        public int B { get; }

        protected Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }

        public int Length() => 2 * (A + B);
        public int Area() => A * B;

        public abstract override string ToString();
    }

    public abstract class Embrasure : Rectangle
    {
        public string Type { get; }
        public int Thick { get; }

        protected Embrasure(string type, int a, int b, int thick) : base(a, b)
        {
            Type = type;
            Thick = thick;
        }

        public virtual double Cost() => Area() * 10;

        public override string ToString()
        {
            return $"Type = {Type}, p = {Length()}, s = {Area()}, price = {Cost()}";
        }
    }

    public class Window : Embrasure
    {
        public int Layers { get; }

        public Window(int a, int b, int thick, int layers) : base("Window", a, b, thick)
        {
            Layers = layers;
        }

        public override double Cost() => base.Cost() + Layers / 0.3;

        public override string ToString()
        {
            return base.ToString() + $", layers = {Layers}";
        }
    }

    public class Door : Embrasure
    {
        public string Material { get; }

        public Door(int a, int b, int thick, string material) : base("Дерево", a, b, thick)
        {
            Material = material;
        }

        public override double Cost()
        {
            double materialMultiplier = Material switch
            {
                "пластик" => 1.25,
                "дерево" => 1.33,
                "стекло" => 1.5,
                _ => 1.0
            };
            return base.Cost() * materialMultiplier;
        }

        public override string ToString()
        {
            return base.ToString() + $", material = {Material}";
        }
    }

}

