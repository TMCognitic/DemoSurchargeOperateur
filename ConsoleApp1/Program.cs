using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Caisse caisse = new Caisse();
            //caisse.Recevoir(new Argent() { UnEuro = 1, CinquanteCents = 1 });
            //caisse.Recevoir(new Argent() { CinqEuros = 1, DixCents = 1 });

            //string s1 = "Hello";
            //string s2 = new string(new char[] { 'H', 'e', 'l', 'l', 'o' });
            //Console.WriteLine(ReferenceEquals(s1, s2));

            //Console.WriteLine(s1 == s2);


            //Argent argent1 = new Argent() { UnEuro = 1, CinquanteCents = 1 };
            //Argent argent2 = new Argent() { UnEuro = 1, CinquanteCents = 1 };

            //Console.WriteLine(argent1 == argent2);
            //Console.WriteLine(ReferenceEquals(argent1, argent2));

            Celsius celsius = new Celsius() { Temperature = 30 };
            Fahrenheit fahrenheit = celsius;

            celsius = (Celsius)fahrenheit;
            Console.WriteLine(celsius.Temperature);

            double d1 = 5.0;
            decimal d2 = (decimal)d1;
        }
    }

    struct Celsius
    {
        public static implicit operator Fahrenheit(Celsius celsius)
        {
            return new Fahrenheit() { Temperature = celsius.Temperature * 1.8 + 32 };
        }

        public double Temperature { get; set; }
    }

    struct Fahrenheit
    {
        public static explicit operator Celsius(Fahrenheit fahrenheit)
        {
            return new Celsius() { Temperature = (fahrenheit.Temperature - 32) / 1.8 };
        }

        public double Temperature { get; set; }
    }

    class Caisse
    {
        public Argent Recette { get; private set; } = new Argent();

        public void Recevoir(Argent argent)
        {
            Recette += argent;
        }
    }

    class Argent
    {
        public static Argent operator +(Argent argent1, Argent argent2)
        {
            if(argent1 == null)
                return argent2;

            if (argent2 == null)
                return argent1;

            return new Argent()
            {
                CinqCents = argent1.CinqCents + argent2.CinqCents,
                DixCents = argent1.DixCents + argent2.DixCents,
                VingtCents = argent1.VingtCents + argent2.VingtCents,
                CinquanteCents = argent1.CinquanteCents + argent2.CinquanteCents,
                UnEuro = argent1.UnEuro + argent2.UnEuro,
                DeuxEuros = argent1.DeuxEuros + argent2.DeuxEuros,
                CinqEuros = argent1.CinqEuros + argent2.CinqEuros,
                DixEuros = argent1.DixEuros + argent2.DixEuros,
                VingtEuros = argent1.VingtEuros + argent2.VingtEuros,
                CinquanteEuros = argent1.CinquanteEuros + argent2.CinquanteEuros
            };
        }

        public static bool operator ==(Argent argent1, Argent argent2)
        {
            if (argent1 is null && argent2 is null)
                return true;

            if (argent1 is null || argent2 is null)
                return false;

            if (ReferenceEquals(argent1, argent2))
                return true;

            return argent1.CinqCents == argent2.CinqCents &&
                argent1.DixCents == argent2.DixCents &&
                argent1.VingtCents == argent2.VingtCents &&
                argent1.CinquanteCents == argent2.CinquanteCents &&
                argent1.UnEuro == argent2.UnEuro &&
                argent1.DeuxEuros == argent2.DeuxEuros &&
                argent1.CinqEuros == argent2.CinqEuros &&
                argent1.DixEuros == argent2.DixEuros &&
                argent1.VingtEuros == argent2.VingtEuros &&
                argent1.CinquanteEuros == argent2.CinquanteEuros;
        }

        public static bool operator !=(Argent argent1, Argent argent2)
        {
            return !(argent1 == argent2);
        }

        //Bonne pratique
        public override bool Equals(object? obj)
        {
            Argent? argent = obj as Argent;

            if (argent is null)
                return false;

            return this == argent;
        }

        public int CinqCents { get; set; }
        public int DixCents { get; set; }
        public int VingtCents { get; set; }
        public int CinquanteCents { get; set; }
        public int UnEuro { get; set; }
        public int DeuxEuros { get; set; }
        public int CinqEuros { get; set; }
        public int DixEuros { get; set; }
        public int VingtEuros { get; set; }
        public int CinquanteEuros { get; set; }

        public double Total
        {
            get { return CinqCents * .05 + 
                    DixCents * .1 +
                    VingtCents * .2 + 
                    CinquanteCents * .5 +
                    UnEuro + 
                    DeuxEuros * 2 + 
                    CinqEuros * 5 +
                    DixEuros * 10 + 
                    VingtEuros * 20 +
                    CinquanteEuros * 50; }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Détail de caisse : ");
            stringBuilder.AppendLine("-------------------");
            stringBuilder.AppendLine($"CinqCents : {CinqCents}");
            stringBuilder.AppendLine($"DixCents : {DixCents}");
            stringBuilder.AppendLine($"VingtCents : {VingtCents}");
            stringBuilder.AppendLine($"CinquanteCents : {CinquanteCents}");
            stringBuilder.AppendLine($"UnEuro : {UnEuro}");
            stringBuilder.AppendLine($"DeuxEuros : {DeuxEuros}");
            stringBuilder.AppendLine($"CinqEuros : {CinqEuros}");
            stringBuilder.AppendLine($"DixEuros : {DixEuros}");
            stringBuilder.AppendLine($"VingtEuros : {VingtEuros}");
            stringBuilder.AppendLine($"CinquanteEuros : {CinquanteEuros}");
            stringBuilder.AppendLine($"Total : {Total}");
            return stringBuilder.ToString();
        }
    }


}