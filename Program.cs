namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame(GenerateWord().ToLower());
            //StartGame("cat");
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

        static void StartGame(string generatedWord)
        {
            string word = "";
            char[] letterBank = generatedWord.ToCharArray();

            string blanks = new string('_', generatedWord.Length);  
            Console.WriteLine(blanks);

            char[] guessWord = blanks.ToCharArray();
            int tries = 6;

            do
            {
                string userInput = Console.ReadLine();

                if (userInput.Length != 1)
                {
                    Console.WriteLine("Guess is too large! Only provide 1 letter at a time.");
                    continue;
                }

                char guessLetter = userInput[0];

                for (int i = 0; i < letterBank.Length; i++)
                {
                    // if guess matches a letter 
                    if (letterBank[i] == guessLetter)
                    {
                        // update the blank spot _ in guess word to the guess letter in that location of the word
                        guessWord[i] = guessLetter;
                    }
                }

                // remove a try ONLY if letter does not exist ANYWHERE in the array
                if (!guessWord.Contains(guessLetter))
                {
                    DrawHangman(tries);
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

        static void DrawHangman(int stage)
        {
            string[] hangmanStages = new string[]
            {
                " ___\n |   O\n |  /|\\\n |  / \\\n_|_",
                " ___\n |   O\n |  /|\\\n |  /\n_|_",
                " ___\n |   O\n |  /|\\\n |\n_|_",
                " ___\n |   O\n |  /|\n |\n_|_",
                " ___\n |   O\n |   |\n |\n_|_",
                " ___\n |   O\n |\n |\n_|_"
            };

            Console.WriteLine(hangmanStages[stage-1]);
        }
    }
}
