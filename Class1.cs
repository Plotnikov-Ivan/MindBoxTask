using System;

namespace MindBoxTask
{
    /// <summary>
    /// Абстрактный базовый класс, представляющий геометрическую фигуру.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Рассчитывает площадь фигуры.
        /// </summary>
        /// <returns>Площадь фигуры в виде числа с плавающей запятой.</returns>
        public abstract double CalculateArea();
    }

    /// <summary>
    /// Представляет фигуру круг.
    /// </summary>
    public class Circle : Shape
    {
        private double radius;

        /// <summary>
        /// Конструктор для создания круга с заданным радиусом.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Рассчитывает площадь круга.
        /// </summary>
        /// <returns>Площадь круга в виде числа с плавающей запятой.</returns>
        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }

    /// <summary>
    /// Представляет фигуру треугольник.
    /// </summary>
    public class Triangle : Shape
    {
        private double sideA;
        private double sideB;
        private double sideC;

        /// <summary>
        /// Конструктор для создания треугольника с заданными длинами сторон.
        /// </summary>
        /// <param name="sideA">Длина стороны A.</param>
        /// <param name="sideB">Длина стороны B.</param>
        /// <param name="sideC">Длина стороны C.</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        /// <summary>
        /// Рассчитывает площадь треугольника с помощью формулы Герона.
        /// </summary>
        /// <returns>Площадь треугольника в виде числа с плавающей запятой.</returns>
        public override double CalculateArea()
        {
            double semiPerimeter = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        }

        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным при помощи теоремы Пифагора.
        /// </summary>
        /// <returns>True, если треугольник прямоугольный, иначе false.</returns>
        public bool IsRightTriangle()
        {
            return sideA * sideA + sideB * sideB == sideC * sideC ||
                   sideA * sideA + sideC * sideC == sideB * sideB ||
                   sideB * sideB + sideC * sideC == sideA * sideA;
        }
    }

    /// <summary>
    /// Фабричный класс для создания экземпляров объектов Shape.
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// Создает новый объект Shape на основе указанного типа и параметров.
        /// </summary>
        /// <param name="type">Тип фигуры ("circle" или "triangle").</param>
        /// <param name="parameters">Параметры, необходимые для создания фигуры.</param>
        /// <returns>Новый экземпляр объекта Shape.</returns>
        public static Shape CreateShape(string type, params double[] parameters)
        {
            switch (type.ToLower())
            {
                case "circle":
                    if (parameters.Length == 1)
                    {
                        Circle circle = new Circle(parameters[0]);
                        double area = circle.CalculateArea(); 
                        Console.WriteLine($"Площадь круга: {area}");
                        return circle;
                    }
                    else
                    {
                        throw new ArgumentException("Некорректное количество параметров для создания круга.");
                    }

                case "triangle":
                    if (parameters.Length == 3)
                    {
                        Triangle triangle = new Triangle(parameters[0], parameters[1], parameters[2]);
                        double area = triangle.CalculateArea(); 
                        Console.WriteLine($"Площадь треугольника: {area}");
                        return triangle;
                    }
                    else
                    {
                        throw new ArgumentException("Некорректное количество параметров для создания треугольника.");
                    }

                default:
                    throw new ArgumentException("Некорректный тип фигуры.");
            }
        }
    }
}