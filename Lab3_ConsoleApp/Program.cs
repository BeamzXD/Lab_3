using System.ComponentModel;
class Vector
{
    public double X;
    public double Y;
    public double Z;

    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Переопределение оператора сложения векторов
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    // Переопределение оператора умножения векторов (скалярное произведение)
    public static double operator *(Vector a, Vector b)
    {
        return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }

    // Умножение вектора на число
    public static Vector operator *(Vector a, double scalar)
    {
        return new Vector(a.X * scalar, a.Y * scalar, a.Z * scalar);
    }

    // Переопределение оператора равенства по длине векторов
    public static bool operator ==(Vector a, Vector b)
    {
        return a.Length == b.Length;
    }

    // Переопределение оператора неравенства по длине векторов
    public static bool operator !=(Vector a, Vector b)
    {
        return a.Length != b.Length;
    }

    // Переопределение оператора "больше" по длине векторов
    public static bool operator >(Vector a, Vector b)
    {
        return a.Length > b.Length;
    }

    // Переопределение оператора "меньше" по длине векторов
    public static bool operator <(Vector a, Vector b)
    {
        return a.Length < b.Length;
    }

    // Вычисление длины вектора
    public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);

    // Переопределим Equals и GetHashCode
    public override bool Equals(object obj)
    {
        if (!(obj is Vector)) return false;
        Vector v = (Vector)obj;
        return X == v.X && Y == v.Y && Z == v.Z;
    }
    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }

    public override string ToString()
    {
        return $"Vector({X}, {Y}, {Z})";
    }
}

public class Car : IEquatable<Car>
{
    public string Name;
    public string Engine;
    public int MaxSpeed;

    // Переопределение метода ToString()
    public override string? ToString()
    {
        return Name;
    }

    // Реализация интерфейса IEquatable<Car> для сравнения объектов
    public bool Equals(Car other)
    {
        if (other == null) return false;
        return this.Name == other.Name && this.Engine == other.Engine && this.MaxSpeed == other.MaxSpeed;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj is Car car)
        {
            return Equals(car);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Engine.GetHashCode() ^ MaxSpeed.GetHashCode();
    }
}

public class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    // Добавление машин в каталог
    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    // Переопределение индексатора
    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Count)
            {
                return $"{cars[index].Name}, Engine: {cars[index].Engine}";
            }
            return "Car not found";
        }
    }
}

public class Currency
{
    public decimal Value;

    public Currency(decimal value)
    {
        Value = value;
    }
}

public class CurrencyUSD : Currency
{
    public static decimal ExchangeRateToEUR;
    public static decimal ExchangeRateToRUB;

    public CurrencyUSD(decimal value) : base(value) { }

    // Преобразование из USD в EUR
    public static explicit operator CurrencyEUR(CurrencyUSD usd)
    {
        return new CurrencyEUR(usd.Value * ExchangeRateToEUR);
    }

    // Преобразование из USD в RUB
    public static explicit operator CurrencyRUB(CurrencyUSD usd)
    {
        return new CurrencyRUB(usd.Value * ExchangeRateToRUB);
    }
}

public class CurrencyEUR : Currency
{
    public static decimal ExchangeRateToUSD;
    public static decimal ExchangeRateToRUB;

    public CurrencyEUR(decimal value) : base(value) { }

    // Преобразование из EUR в USD
    public static explicit operator CurrencyUSD(CurrencyEUR eur)
    {
        return new CurrencyUSD(eur.Value * ExchangeRateToUSD);
    }

    // Преобразование из EUR в RUB
    public static explicit operator CurrencyRUB(CurrencyEUR eur)
    {
        return new CurrencyRUB(eur.Value * ExchangeRateToRUB);
    }
}

public class CurrencyRUB : Currency
{
    public static decimal ExchangeRateToUSD;
    public static decimal ExchangeRateToEUR;

    public CurrencyRUB(decimal value) : base(value) { }

    // Преобразование из RUB в USD
    public static explicit operator CurrencyUSD(CurrencyRUB rub)
    {
        return new CurrencyUSD(rub.Value * ExchangeRateToUSD);
    }

    // Преобразование из RUB в EUR
    public static explicit operator CurrencyEUR(CurrencyRUB rub)
    {
        return new CurrencyEUR(rub.Value * ExchangeRateToEUR);
    }
}


class Program
{
    static void Main(){
        Console.WriteLine("Задание №1");
        // Создаем два вектора
        Vector v1 = new Vector(1, 2, 3);
        Vector v2 = new Vector(4, 5, 6);

        // Операция сложения векторов
        Vector sum = v1 + v2;
        Console.WriteLine($"Сумма векторов: {sum}");

        // Скалярное произведение
        double scalarProduct = v1 * v2;
        Console.WriteLine($"Скалярное произведение: {scalarProduct}");

        // Умножение вектора на скаляр
        Vector multiplied = v1 * 2;
        Console.WriteLine($"Умножение вектора на 2: {multiplied}");

        // Логическое сравнение векторов по длине
        Console.WriteLine($"Вектор 1 == Вектор 2: {v1 == v2}");
        Console.WriteLine($"Вектор 1 > Вектор 2: {v1 > v2}");
        Console.WriteLine($"Вектор 1 < Вектор 2: {v1 < v2}");

        Console.WriteLine("Задание №2");

        // Создаем несколько машин
        Car car1 = new Car { Name = "Toyota", Engine = "V6", MaxSpeed = 200 };
        Car car2 = new Car { Name = "BMW", Engine = "V8", MaxSpeed = 250 };
        Car car3 = new Car { Name = "Audi", Engine = "V6", MaxSpeed = 240 };

        // Создаем каталог машин
        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);

        // Используем переопределенный ToString() для вывода названия машины
        Console.WriteLine(car1.ToString()); // Выводит: Toyota

        // Используем индексатор для получения информации о машине
        Console.WriteLine(catalog[0]); // Выводит: Toyota, Engine: V6
        Console.WriteLine(catalog[1]); // Выводит: BMW, Engine: V8

        // Сравнение машин
        Console.WriteLine(car1.Equals(car2)); // Выводит: False
        Console.WriteLine(car1.Equals(car1)); // Выводит: True

        Console.WriteLine("Задание №3");
        
        // Задание 3. Настройка курсов валют
        CurrencyUSD.ExchangeRateToEUR = 0.85m;
        CurrencyUSD.ExchangeRateToRUB = 75.5m;
        CurrencyEUR.ExchangeRateToUSD = 1.18m;
        CurrencyEUR.ExchangeRateToRUB = 89.0m;
        CurrencyRUB.ExchangeRateToUSD = 0.013m;
        CurrencyRUB.ExchangeRateToEUR = 0.011m;

        // Пример конвертации валют
        CurrencyUSD usd = new CurrencyUSD(100);
        CurrencyEUR eur = (CurrencyEUR)usd;
        CurrencyRUB rub = (CurrencyRUB)usd;

        Console.WriteLine($"USD to EUR: {eur.Value}");
        Console.WriteLine($"USD to RUB: {rub.Value}");
    }
}