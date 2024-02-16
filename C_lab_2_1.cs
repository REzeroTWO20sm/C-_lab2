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

    public virtual double ������������������()
    {
        return Oklad;
    }
}

class ShtatnySotrudnik : Sotrudnik
{
    public double Premiya { get; set; }

    public override double ������������������()
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
            Console.WriteLine("������: " + e.Message);
            return 0;
        }
    }
}

class SotrudnikPoKontraktu : Sotrudnik
{
    public override double ������������������()
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
            Console.WriteLine("���������� ������� ���������� � ������ ������������� �����: " + e.Oklad);
            return 0;
        }
    }
}

class PremiyaException : Exception
{
    public PremiyaException() : base("������������� �������� ������!")
    {
    }
}

class OkladException : Exception
{
    public double Oklad { get; }

    public OkladException(double oklad) : base("������������� �������� ������!")
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
        shtatny.Premiya = -5000; // ��������� ������
        Console.WriteLine("�������� �������� ����������: " + shtatny.������������������());

        SotrudnikPoKontraktu kontrakt = new SotrudnikPoKontraktu();
        kontrakt.Oklad = -1000; // ��������� ������
        Console.WriteLine("�������� ���������� �� ���������: " + kontrakt.������������������());
	Console.ReadLine();
    }
}
