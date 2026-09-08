namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = GenerateWord();
            Console.WriteLine(word);
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

        static void Draw()
        {
            // Final Sprite should look like this
            Console.WriteLine(" O");
            Console.WriteLine("-|-");
            Console.WriteLine(@" /\");
        }
    }
}
