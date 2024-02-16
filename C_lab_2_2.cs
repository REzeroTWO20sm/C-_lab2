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
            Console.WriteLine($"����� ������ ������ ����� {kolichestvoMesyacev} �������: {summaVklada}");
        }
        catch (KolichestvoException e)
        {
            Console.WriteLine("������: " + e.Message);
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
    public KolichestvoException() : base("���������� ������� �� ����� ���� �������������!")
    {
    }
}

class VkladException : Exception
{
    public VkladException(decimal summaVklada) : base($"���������� ������� ����� � ������� ������������� ����� ������: {summaVklada}")
    {
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Vklad vklad = new Vklad { FIOVkladchika = "������ ���� ��������", SummaVklada = -1000 };
            Console.WriteLine("������ ����� �����.");

            // �������� ������� ����� ������
            vklad.RaschitatSummuVklada(12); // ������������ ������
        }
        catch (VkladException e)
        {
            Console.WriteLine("������: " + e.Message);
        }

        try
        {
            Vklad vklad2 = new Vklad { FIOVkladchika = "������ ���� ��������", SummaVklada = 5000 };
            Console.WriteLine("\n������ ����� �����.");

            // �������� ������� ����� ������
            vklad2.RaschitatSummuVklada(-6); // ������������ ������
            vklad2.RaschitatSummuVklada(6); // �������
        }
        catch (KolichestvoException e)
        {
            Console.WriteLine("������: " + e.Message);
        }
        Console.ReadLine();
    }
}


















