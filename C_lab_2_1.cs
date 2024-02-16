using System;

class Firma
{
    public string Name { get; set; }
}

class Otdel
{
    public string Name { get; set; }
    public int NumEmployees { get; set; }
}

class Sotrudnik
{
    public string FIO { get; set; }
    public string Position { get; set; }
    public double Oklad { get; set; }

    public virtual double РассчитатьЗарплату()
    {
        return Oklad;
    }
}

class ShtatnySotrudnik : Sotrudnik
{
    public double Premiya { get; set; }

    public override double РассчитатьЗарплату()
    {
        try
        {
            if (Premiya < 0)
            {
                throw new PremiyaException();
            }

            return Oklad + Premiya;
        }
        catch (PremiyaException e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
            return 0;
        }
    }
}

class SotrudnikPoKontraktu : Sotrudnik
{
    public override double РассчитатьЗарплату()
    {
        try
        {
            if (Oklad < 0)
            {
                throw new OkladException(Oklad);
            }

            return Oklad;
        }
        catch (OkladException e)
        {
            Console.WriteLine("Невозможно создать сотрудника – указан отрицательный оклад: " + e.Oklad);
            return 0;
        }
    }
}

class PremiyaException : Exception
{
    public PremiyaException() : base("Отрицательное значение премии!")
    {
    }
}

class OkladException : Exception
{
    public double Oklad { get; }

    public OkladException(double oklad) : base("Отрицательное значение оклада!")
    {
        Oklad = oklad;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ShtatnySotrudnik shtatny = new ShtatnySotrudnik();
        shtatny.Oklad = 50000;
        shtatny.Premiya = -5000; // Генерация ошибки
        Console.WriteLine("Зарплата штатного сотрудника: " + shtatny.РассчитатьЗарплату());

        SotrudnikPoKontraktu kontrakt = new SotrudnikPoKontraktu();
        kontrakt.Oklad = -1000; // Генерация ошибки
        Console.WriteLine("Зарплата сотрудника по контракту: " + kontrakt.РассчитатьЗарплату());
	Console.ReadLine();
    }
}
