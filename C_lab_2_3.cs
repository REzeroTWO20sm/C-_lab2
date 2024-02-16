using System;

class Bank
{
    public string Name { get; set; }
}

class Schet
{
    public int Number { get; set; }
    public int PinCode { get; set; }
    private decimal ostaok;

    public decimal Ostaok
    {
        get { return ostaok; }
        set
        {
            if (value < 0)
            {
                throw new OstatokNaScheteException(value);
            }
            ostaok = value;
        }
    }

    public virtual void SnyatSoScheta(decimal summa)
    {
        try
        {
            if (summa < 0 || summa > Ostaok)
            {
                throw new SnyatSoSchetaException(summa);
            }

            Ostaok -= summa;
            Console.WriteLine($"Вы успешно сняли {summa} с вашего счета. Остаток на счете: {Ostaok}");
        }
        catch (SnyatSoSchetaException e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
    }
}

class ObychnySchet : Schet
{
    public override void SnyatSoScheta(decimal summa)
    {
        base.SnyatSoScheta(summa);
    }
}

class LgotnySchet : Schet
{
    public override void SnyatSoScheta(decimal summa)
    {
        base.SnyatSoScheta(summa);
    }
}

class Bankomat
{
    public int Id { get; set; }
    public string Address { get; set; }
}

class SnyatSoSchetaException : Exception
{
    public SnyatSoSchetaException(decimal summa) : base($"Ошибка при снятии {summa} с счета!")
    {
    }
}

class OstatokNaScheteException : Exception
{
    public OstatokNaScheteException(decimal ostaok) : base($"Невозможно создать счет – указано некорректное значение остатка на счете: {ostaok}")
    {
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Schet schet = new Schet { Number = 123456, PinCode = 7890, Ostaok = 1000 };
            Console.WriteLine("Создан новый обычный счет с остатком 1000.");

            // Проверка снятия со счета
            schet.SnyatSoScheta(-500); // Ошибка

            Schet lgotnySchet = new LgotnySchet { Number = 654321, PinCode = 4321, Ostaok = 1500 };
            Console.WriteLine("\nСоздан новый льготный счет с остатком 1500.");

            // Проверка снятия со счета
            lgotnySchet.SnyatSoScheta(2000); // Ошибка
            lgotnySchet.SnyatSoScheta(1000); // Успешно

            Schet obychnySchet = new ObychnySchet { Number = 987654, PinCode = 1234, Ostaok = 2000 };
            Console.WriteLine("\nСоздан новый обычный счет с остатком 2000.");

            // Проверка снятия со счета
            obychnySchet.SnyatSoScheta(2500); // Ошибка
            obychnySchet.SnyatSoScheta(1500); // Успешно
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
        Console.ReadLine();
    }
}