namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayWord("cat");
        }

        static string GenerateWord()
        {
            List<string> words = new List<string>
            {
                "Biblioklept", 
                "Nauseant", 
                "Addend", 
                "Agelast", 
                "Peristeronic",
                "Hibernal",
                "Subnivean",
                "Sitzmark",
                "Primaveral",
                "Solivagant",
                "Filipendulous",
                "Jentacular",
                "Catillate",
                "Bellycheer",
                "Avidulous",
                "Retrogradation",
                "Spinous",
                "Illaudable",
                "Grimoire",
                "Fantod",
                "Dyspathy",
                "Orgulous",
                "Dilapidator",
                "Crimpy",
                "Jubilarian"
            };
            int randomIndex = Random.Shared.Next(0, words.Count);

            return words[randomIndex];
        }

        static void DisplayWord(string generatedWord)
        {
            for (int i = 0; i < generatedWord.Length; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();

            string updatedWord = "";
            int numberOfTries = 3;

            // update word and display it after each guess
            // if users guess has a character that matches the character in the generated word in the same location then show that character
            // otherwise continue to show _
            // ie) generatedWord = cat, guess = car, updatedWord should be ca_
            string guess;
            do
            {
                guess = Console.ReadLine();

                // condition in case word is too large (out of bounds array)
                if (guess.Length > guess.Length)
                {
                    
                }

                for (int i = 0; i < guess.Length; i++)
                {
                    // if character in userinput matches character in generated word
                    if (guess[i] == generatedWord[i])
                    {
                        updatedWord += guess[i];
                    } else
                    {
                        updatedWord += "_";
                    }
                }
                if (guess == generatedWord)
                {
                    Console.WriteLine("\nCongratulations you got the word!");
                    break;
                }
                numberOfTries--;
                Console.WriteLine($"{updatedWord}");
                updatedWord = "";
                
                Draw(numberOfTries);

            } while (numberOfTries > 0);

            Console.WriteLine("Game Over!");
        }

        static void Draw(int stage)
        {
            // Final Sprite should look like this
            if (stage == 2)
            {
                Console.WriteLine("O");
            }
            if (stage == 1)
            {
                Console.WriteLine("O");
                Console.WriteLine("|");
            }
            if (stage == 0)
            {
                Console.WriteLine("O");
                Console.WriteLine("|");
                Console.WriteLine(@"/\");
            }
        }
    }
}
