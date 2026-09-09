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
            string word;
            char[] letterBank = generatedWord.ToCharArray();

            string blanks = new string('_', generatedWord.Length);  
            Console.WriteLine(blanks);

            char[] guessWord = blanks.ToCharArray();
            int tries = 5;

            do
            {
                // get char from user
                char guess = Convert.ToChar(Console.ReadLine());

                for (int i = 0; i < letterBank.Length; i++)
                {
                    // if guess matches a letter 
                    if (letterBank[i] == guess)
                    {
                        // update the blank spot _ in guess word to the guess letter in that location of the word
                        guessWord[i] = guess;
                    }
                }

                // remove a try ONLY if letter does not exist ANYWHERE in the array
                if (!guessWord.Contains(guess))
                {
                    tries--;
                }

                word = new string(guessWord);

                if (word == generatedWord)
                {
                    Console.WriteLine("You Win!");
                    break;
                }

                Console.WriteLine(word);
            } while (tries > 0);

            if (word != generatedWord)
                Console.WriteLine("You Lose!");

            Console.WriteLine($"The word was {generatedWord}");
        }

        static void Draw(int stage)
        {
            string[] hangmanStages = new string[]
            {
                " ___\n |   O\n |\n |\n_|_",              // 1 wrong guess
                " ___\n |   O\n |   |\n |\n_|_",          // 2 wrong guesses
                " ___\n |   O\n |  /|\n |\n_|_",          // 3 wrong guesses
                " ___\n |   O\n |  /|\\\n |\n_|_",        // 4 wrong guesses
                " ___\n |   O\n |  /|\\\n |  / \\\n_|_"   // 5 wrong guesses
            };

            // a number is passed to this method as an argument
            // everytime that number decreases from its initial value, we should increase the value of the index
            // and then we should print out the index position of the array of strings we have, representing each stage

            //if (stage == 4)
            //{
            //    Console.WriteLine(hangmanStages[0]);
            //}
            //if (stage == 1)
            //{
            //    Console.WriteLine("O");
            //    Console.WriteLine("|");
            //}
            //if (stage == 0)
            //{
            //    Console.WriteLine("O");
            //    Console.WriteLine("|");
            //    Console.WriteLine(@"/\");
            //}
        }
    }
}
