using System.Security.Cryptography.X509Certificates;

namespace blackjack
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int penz = 2000;
			int kaszinopont = HuzLapot() + HuzLapot();
			int userpont = HuzLapot() + HuzLapot();
			Blackjack(kaszinopont,userpont);

        }
		static void Blackjack(int kaszinopont,int userpont)
		{


			bool fut = true;
            while (fut==true)
            {
				Console.Clear();
				Console.WriteLine($"Kaszinó pontszám: {kaszinopont}");
				Console.WriteLine($"Felhasználó pontszám: {userpont}");
                if (userpont==21)
                {
                    Console.WriteLine("Gratulálok, nyertél.");
					break;
                }
				else if (kaszinopont>16||userpont>21)
				{
                    Console.WriteLine("Vesztettél.");
					break;
                }
                Console.Write("hit/stand: ");
				string beker = Convert.ToString(Console.ReadLine());
				switch (beker)
                {
					case "hit":
						userpont += HuzLapot();
						break;
					case "stand":
                        while (true)
                        {
							kaszinopont += HuzLapot();
                            if (kaszinopont>21)
                            {
								Console.WriteLine($"Kaszinó pontszám: {kaszinopont}");
								Console.WriteLine($"Felhasználó pontszám: {userpont}");
								Console.WriteLine("Nyertél.");
								fut = false;
								break;
                            }
                            if (kaszinopont>16&&kaszinopont<22)
                            {
                                if (21-kaszinopont<21-userpont)
                                {
									Console.WriteLine($"Kaszinó pontszám: {kaszinopont}");
									Console.WriteLine($"Felhasználó pontszám: {userpont}");
									Console.WriteLine("Vesztettél.");
									fut = false;
									break;
                                }
								else if (21 - kaszinopont > 21 - userpont)
                                {
									Console.WriteLine($"Kaszinó pontszám: {kaszinopont}");
									Console.WriteLine($"Felhasználó pontszám: {userpont}");
									Console.WriteLine("Nyertél, gratulálok.");
									fut=false;
									break;
                                }
                            }
                        }
						break;
					default:
						fut = false;
						break;
                }
            }
        }

		static int HuzLapot()
		{
			Random rand = new Random();
			int randomNumber = rand.Next(2, 15);
			int ertek = 0;
            if (randomNumber==14)
            {
				ertek = 11;
            }
			else if (randomNumber<14&&randomNumber>9)
            {
				ertek = 10;
            }
            else
            {
				ertek = randomNumber;
            }
			return ertek;
        }

	}
}
