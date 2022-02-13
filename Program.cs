using System;

namespace DetGamleSlot
{
    class Program
    {
        // Dette er starten af din konsol applikation
        static void Main(string[] args)
        {
            Console.Title = "Det Gamle Slots Billet Luge"; // Sæt titlen på din konsol, det er den der bliver vist i toppen af vinduet når programmet kører

            ShowHeader(); // Her kalder jeg den metode som skriver overskriften med gul farve

            ShowMenu(); // Her kalder jeg den metode som jeg har lavet, den bruger jeg til at vise valgmulighederne

            Console.WriteLine("Tryk på en vilkårlig tast for at lukke det her vindue...");
            Console.ReadKey(true); // Her afventer jeg et tastetryk for at undgå applikationen lukker.
        }

        static void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Sæt din tekst farve til gul
            Console.WriteLine("Køb af billetter til Slottet\n"); // Udskriver tekst
            Console.ForegroundColor = ConsoleColor.White; // Sæt din tekst farve til gul
        }

        static void ShowMenu()
        {
            Console.Clear(); // Ryd konsollens tekst.
            ShowHeader(); // Her kalder jeg den metode som skriver overskriften med gul farve

            // De næste 3 linjer er bare udskrift til konsollen. \n er en ny linje og \" er for at skrive " direkte i konsollen.
            Console.WriteLine("Velkommen til Det Gamle Slot, du har nu følgende valgmuligheder:\n");

            Console.WriteLine("Tast \"A\" for at købe billet(ter)");
            Console.WriteLine("Tast \"B\" for at lukke programmet");

            switch (Console.ReadKey(true).KeyChar.ToString().ToUpper()) // Her læser programmet en tast, konverterer den til en tekst streng, og til sidst til stort bogstav (det gør jeg for at det er lige meget om du trykker 'a' eller 'A')
            {
                case "A":
                    ChooseTicketType(); // Her kaldes den næste metode, til at vælge billet type
                    break;
                case "B":
                    Environment.Exit(0); // Det her lukker programmet med status kode "0", som betyder at der IKKE er sket nogle fejl, det er en almindelig nedlukning.
                    break;
                default: // Default, betyder at hvis ikke en af de andre passer, så passer den her. Og her kaldes den samme metode igen, da der kun er 2 muligheder.
                    ShowMenu();
                    break;
            }
        }

        static void ChooseTicketType()
        {
            Console.Clear(); // Ryd konsollens tekst.
            ShowHeader(); // Her kalder jeg den metode som skriver overskriften med gul farve

            Console.WriteLine("Velkommen til Det Gamle Slots Billet Luge, du har nu følgende valgmuligheder:\n");

            Console.WriteLine("Tast \"A\" for at vælge en almindelig billet med adgang til slottet (A), 75,- pr. billet");
            Console.WriteLine("Tast \"B\" for at vælge en udvided billet med adgang til slottet & våbensamlingen (B), 125,- pr. billet");
            Console.WriteLine("Tast \"C\" for at vælge en særlig billet med adgang til både slottet, våbensamlingen og fangekælderen (C), 150,- pr. billet");

            switch (Console.ReadKey(true).KeyChar.ToString().ToUpper()) // Her læser programmet en tast, konverterer den til en tekst streng, og til sidst til stort bogstav (det gør jeg for at det er lige meget om du trykker 'a' eller 'A')
            {
                case "A":
                    BuyTickets("A"); // Kald metoden til at købe billetter af typen A
                    break;
                case "B":
                    BuyTickets("B"); // Kald metoden til at købe billetter af typen B
                    break;
                case "C":
                    BuyTickets("C"); // Kald metoden til at købe billetter af typen C
                    break;
                default: // Default, betyder at hvis ikke en af de andre passer, så passer den her. Og her kaldes den samme metode igen, da der kun er 3 muligheder.
                    ChooseTicketType();
                    break;
            }
        }

        static void BuyTickets(string type)
        {
            int price = 0; // denne variable vil indeholde prisen pr. billet udfra hvilken type den får med som argument.

            Console.Clear(); // Ryd konsollens tekst.
            ShowHeader(); // Her kalder jeg den metode som skriver overskriften med gul farve

            switch (type)
            {
                case "A":
                    price = 75;
                    break;
                case "B":
                    price = 125;
                    break;
                case "C":
                    price = 150;
                    break;
            }

            Console.WriteLine($"Super godt valg!\nHvor mange billetter af typen {type} kunne du tænke dig?");
            
            // Herunder er en Try Catch blok, som vil "Forsøge", og skulle der opstå en fejl vil den "Fange den"
            try
            {
                int quantity = int.Parse(Console.ReadLine()); // Forsøg at læse en tekst streng fra brugeren og konverter den til et tal
                ShowReciept(type, quantity, price); // Kald den metode som til sidst laver en kvitterings udskrift.
            }
            catch (Exception)
            {
                BuyTickets(type);
            }
        }

        static void ShowReciept(string type, int quantity, int price)
        {
            Console.Clear(); // Ryd konsollens tekst.
            ShowHeader(); // Her kalder jeg den metode som skriver overskriften med gul farve

            Console.WriteLine($"Du har købt {quantity} billetter ({type}).");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Pris: {quantity * price},- DKK.\n");
            Console.WriteLine($"Pris: {Math.Round(quantity * price / 7.55, 2, MidpointRounding.AwayFromZero)},- EUR.\n");

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}