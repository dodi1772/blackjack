using System.Security.Cryptography.X509Certificates;

namespace blackjack
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.Write("Mekkora tét: ");
			int penz=Convert.ToInt32(Console.ReadLine());
			int kaszinopont = HuzLapot() + HuzLapot();
			int userpont = HuzLapot() + HuzLapot();
            Console.WriteLine($"Pénzed: {Blackjack(kaszinopont, userpont,penz)}");
            Console.Write($"AKarsz még játszani(i/n): ");
			char jatek=Convert.ToChar(Console.ReadLine());
            if (jatek=='i')
            {
				Console.WriteLine($"Pénzed: {Blackjack(kaszinopont, userpont, penz)}");
			}
        }
		static int Blackjack(int kaszinopont,int userpont,int penz)
		{


			bool fut = true;
			int elso = 0;
            while (fut==true)
            {
				Console.Clear();
				Console.WriteLine($"Kaszinó pontszám: {kaszinopont}");

				Console.WriteLine($"Felhasználó pontszám: {userpont}");
                if (userpont==21)
                {
                    Console.WriteLine("Gratulálok, nyertél.");
					penz = penz * 2;
					break;
                }
				else if (kaszinopont==21)
                {
                    Console.WriteLine("Vesztettél.");
					break;
                }
                if (elso!=0)
                {
					if (kaszinopont > 16 || userpont > 21)
					{
						Console.WriteLine("Vesztettél.");
						break;
					}
				}
				elso += 1;
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
								penz = penz * 2;
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
									penz = penz * 2;
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
			return penz;
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
