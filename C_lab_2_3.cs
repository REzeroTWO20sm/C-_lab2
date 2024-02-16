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
            Console.WriteLine($"�� ������� ����� {summa} � ������ �����. ������� �� �����: {Ostaok}");
        }
        catch (SnyatSoSchetaException e)
        {
            Console.WriteLine("������: " + e.Message);
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
    public SnyatSoSchetaException(decimal summa) : base($"������ ��� ������ {summa} � �����!")
    {
    }
}

class OstatokNaScheteException : Exception
{
    public OstatokNaScheteException(decimal ostaok) : base($"���������� ������� ���� � ������� ������������ �������� ������� �� �����: {ostaok}")
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
            Console.WriteLine("������ ����� ������� ���� � �������� 1000.");

            // �������� ������ �� �����
            schet.SnyatSoScheta(-500); // ������

            Schet lgotnySchet = new LgotnySchet { Number = 654321, PinCode = 4321, Ostaok = 1500 };
            Console.WriteLine("\n������ ����� �������� ���� � �������� 1500.");

            // �������� ������ �� �����
            lgotnySchet.SnyatSoScheta(2000); // ������
            lgotnySchet.SnyatSoScheta(1000); // �������

            Schet obychnySchet = new ObychnySchet { Number = 987654, PinCode = 1234, Ostaok = 2000 };
            Console.WriteLine("\n������ ����� ������� ���� � �������� 2000.");

            // �������� ������ �� �����
            obychnySchet.SnyatSoScheta(2500); // ������
            obychnySchet.SnyatSoScheta(1500); // �������
        }
        catch (Exception e)
        {
            Console.WriteLine("������: " + e.Message);
        }
        Console.ReadLine();
    }
}