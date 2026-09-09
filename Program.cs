namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DisplayWord(GenerateWord().ToLower());
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
            string updatedWord = new string('_', generatedWord.Length);  
            Console.WriteLine(updatedWord);

            int numberOfTries = 3;

            char[] letters = updatedWord.ToCharArray(); // convert string to array of individual letters

            // update word and display it after each guess
            // if users guess has a character that matches the character in the generated word in the same location then show that character
            // otherwise continue to show _
            // ie) generatedWord = cat, guess = car, updatedWord should be ca_
            string guess;
            do
            {
                guess = Console.ReadLine();

                // condition in case word is too large (out of bounds array)
                if (guess.Length > generatedWord.Length)
                {
                    Console.WriteLine("Guess exceeds length of word!");
                    Console.WriteLine(updatedWord);
                    continue;
                }

                for (int i = 0; i < guess.Length; i++)
                {
                    // if character in guess matches character in generated word
                    if (guess[i] == generatedWord[i])
                    {
                        // update that specific character from _ in updated word letters array, to a letter from the guess
                        letters[i] = guess[i];
                    }
                    
                }
                if (guess == generatedWord)
                {
                    Console.WriteLine("\nCongratulations you got the word!");
                    break;
                }

                numberOfTries--; 
                updatedWord = new string(letters); // convert back to string
                Console.WriteLine($"{updatedWord}");                
                Draw(numberOfTries);
            } while (numberOfTries > 0);

            if (numberOfTries <= 0) 
                Console.WriteLine($"Game Over! The word was {generatedWord}");
        }

        static void Draw(int stage)
        {
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
