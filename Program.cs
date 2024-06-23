using System;

public class Rectangle
{
    // Член-данные класса
    public double X { get; set; } // координата X точки A
    public double Y { get; set; } // координата Y точки A
    public double A { get; set; } // длина горизонтальной стороны
    public double B { get; set; } // длина вертикальной стороны

    // Конструкторы
    public Rectangle()
    {
        X = 0;
        Y = 0;
        A = 1;
        B = 1;
    }

    public Rectangle(double x, double y, double a, double b)
    {
        if (a <= 0 || b <= 0)
        {
            throw new ArgumentException("Стороны прямоугольника должны быть положительными числами.");
        }
        X = x;
        Y = y;
        A = a;
        B = b;
    }

    // Ввод/вывод прямоугольника
    public void Input()
    {
        Console.WriteLine("Введите координаты точки A (X Y):");
        X = double.Parse(Console.ReadLine());
        Y = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите длину стороны a:");
        A = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите длину стороны b:");
        B = double.Parse(Console.ReadLine());

        if (A <= 0 || B <= 0)
        {
            throw new ArgumentException("Стороны прямоугольника должны быть положительными числами.");
        }
    }

    public void Output()
    {
        Console.WriteLine($"Прямоугольник: A({X}, {Y}), a = {A}, b = {B}");
    }

    // Нахождение периметра
    public double Perimeter()
    {
        return 2 * (A + B);
    }

    // Нахождение центра описанной окружности
    public (double, double) Circumcenter()
    {
        return (X + A / 2, Y + B / 2);
    }

    // Проверка, является ли прямоугольник квадратом
    public bool IsSquare()
    {
        return A == B;
    }

    // Нахождение прямоугольника, симметричного заданному относительно начала координат
    public Rectangle Symmetric()
    {
        return new Rectangle(-X - A, -Y - B, A, B);
    }

    // Проверка двух прямоугольников на подобие
    public bool IsSimilar(Rectangle other)
    {
        return (A / other.A == B / other.B) || (A / other.B == B / other.A);
    }

    // Проверка, имеет ли прямоугольник пересечение со всеми четвертями
    public bool IntersectsAllQuadrants()
    {
        return (X < 0 && X + A > 0) && (Y < 0 && Y + B > 0);
    }

    // Проверка пересечения прямоугольников
    public bool Intersects(Rectangle other)
    {
        return !(X + A <= other.X || X >= other.X + other.A || Y + B <= other.Y || Y >= other.Y + other.B);
    }

    // Проверка, пересекает ли заданная прямая прямоугольник
    public bool IntersectsLine(double a, double b, double c)
    {
        double[] xCorners = { X, X + A };
        double[] yCorners = { Y, Y + B };

        bool CheckLineIntersection(double x1, double y1, double x2, double y2)
        {
            double z1 = a * x1 + b * y1 + c;
            double z2 = a * x2 + b * y2 + c;
            return z1 * z2 <= 0;
        }

        return CheckLineIntersection(xCorners[0], yCorners[0], xCorners[1], yCorners[0]) ||
               CheckLineIntersection(xCorners[1], yCorners[0], xCorners[1], yCorners[1]) ||
               CheckLineIntersection(xCorners[1], yCorners[1], xCorners[0], yCorners[1]) ||
               CheckLineIntersection(xCorners[0], yCorners[1], xCorners[0], yCorners[0]);
    }

    // Главный метод для запуска программы
    public static void Main()
    {
        Rectangle rect1 = new Rectangle();
        rect1.Input();
        rect1.Output();

        Console.WriteLine($"Периметр: {rect1.Perimeter()}");
        var center = rect1.Circumcenter();
        Console.WriteLine($"Центр описанной окружности: ({center.Item1}, {center.Item2})");
        Console.WriteLine($"Является квадратом: {rect1.IsSquare()}");

        Rectangle symmetricRect = rect1.Symmetric();
        Console.WriteLine("Симметричный прямоугольник:");
        symmetricRect.Output();

        Rectangle rect2 = new Rectangle(1, 1, 2, 2);
        Console.WriteLine("Второй прямоугольник:");
        rect2.Output();
        Console.WriteLine($"Подобие прямоугольников: {rect1.IsSimilar(rect2)}");

        Console.WriteLine($"Пересекает все четверти: {rect1.IntersectsAllQuadrants()}");
        Console.WriteLine($"Пересечение с другим прямоугольником: {rect1.Intersects(rect2)}");
        Console.WriteLine($"Пересекает ли прямая: {rect1.IntersectsLine(1, -1, 0)}"); // Пример прямой y = x
    }
}
