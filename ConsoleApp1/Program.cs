using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "29535123p48723487597645723645";

        // Resultatet av alla giltiga tal efter man adderat ihop
        long total = 0;

        // Ett tecken i taget när man går igenom texten 
        for (int i = 0; i < input.Length; i++)
        {
            // säkertställ om aktuella tecknet är en siffra 
            if (char.IsDigit(input[i]))
            {
                // Låt oss nu titta framåt för att hitta en annan matchande siffra
                for (int j = i + 2; j < input.Length; j++) // Hoppa över minst ett tecken emellan
                {
                    // Anta att numret mellan siffrorna är giltigt för närvarande
                    bool isValid = true;

                    // Kontrollera varje tecken mellan i och j
                    for (int k = i + 1; k < j; k++)
                    {
                        if (!char.IsDigit(input[k]))
                        {
                            // Om något annat än en siffra hittas är den inte giltig
                            isValid = false;
                            break;
                        }
                    }

                    // Om alla tecken däremellan är siffror och den första/sista siffran matchar
                    if (isValid && input[i] == input[j])
                    {
                        // Hämta hela talsträngen från i till j
                        string foundNumber = input.Substring(i, j - i + 1);

                        // Skriv ut hela strängen med detta nummer markerat
                        // Skriv först ut tecken före numret
                        Console.Write(input.Substring(0, i));

                        // Först byt färg och skriv ut numret som är hittad
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(foundNumber);
                        Console.ResetColor();

                        // Skriv ut tecken efter numret
                        Console.WriteLine(input.Substring(j + 1));

                        // Lägg till det hittade numret till den totala summan av alla giltiga tal
                        total += long.Parse(foundNumber);

                        // Efter utskrift hoppar vi till j så att vi inte överlappar siffror
                        i = j;
                        break; // Gå vidare till nästa startkaraktär
                    }
                }
            }
        }

        // tom rad före summan
        Console.WriteLine();

        // Skriv ut resultatet av alla giltiga tal efter man adderat ihop dem
        Console.WriteLine("Total = " + total);
    }
}