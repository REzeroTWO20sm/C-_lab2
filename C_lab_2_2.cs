using System;

class Bank
{
    public string Name { get; set; }
}

class Filial
{
    public string Name { get; set; }
    public decimal TotalDeposits { get; set; }
}

class Vklad
{
    public string FIOVkladchika { get; set; }
    public decimal SummaVklada { get; set; }

    public virtual void RaschitatSummuVklada(int kolichestvoMesyacev)
    {
        try
        {
            if (kolichestvoMesyacev < 0)
            {
                throw new KolichestvoException();
            }

            decimal summaVklada = SummaVklada * kolichestvoMesyacev;
            Console.WriteLine($"Сумма вашего вклада через {kolichestvoMesyacev} месяцев: {summaVklada}");
        }
        catch (KolichestvoException e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
    }
}

class DolgosrochnyiVklad : Vklad
{
    public override void RaschitatSummuVklada(int kolichestvoMesyacev)
    {
        base.RaschitatSummuVklada(kolichestvoMesyacev);
    }
}

class VkladDoVostrebovaniya : Vklad
{
    public override void RaschitatSummuVklada(int kolichestvoMesyacev)
    {
        base.RaschitatSummuVklada(kolichestvoMesyacev);
    }
}

class KolichestvoException : Exception
{
    public KolichestvoException() : base("Количество месяцев не может быть отрицательным!")
    {
    }
}

class VkladException : Exception
{
    public VkladException(decimal summaVklada) : base($"Невозможно создать вклад – указана отрицательная сумма вклада: {summaVklada}")
    {
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Vklad vklad = new Vklad { FIOVkladchika = "Иванов Иван Иванович", SummaVklada = -1000 };
            Console.WriteLine("Создан новый вклад.");

            // Проверка расчета суммы вклада
            vklad.RaschitatSummuVklada(12); // Генерируется ошибка
        }
        catch (VkladException e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }

        try
        {
            Vklad vklad2 = new Vklad { FIOVkladchika = "Петров Петр Петрович", SummaVklada = 5000 };
            Console.WriteLine("\nСоздан новый вклад.");

            // Проверка расчета суммы вклада
            vklad2.RaschitatSummuVklada(-6); // Генерируется ошибка
            vklad2.RaschitatSummuVklada(6); // Успешно
        }
        catch (KolichestvoException e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
        Console.ReadLine();
    }
}


















