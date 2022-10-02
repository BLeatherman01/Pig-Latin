namespace Pig_Latin
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter a word to translate to Pig Latin");

            bool keepGoing = true;
            while (keepGoing)
            {

                //gets word and converts to lower case
                string userInput = GetWord();

                //returns updated Pig Latin translation
                Console.WriteLine(PigLatinTranslator(userInput));

                //run again
                keepGoing = AskAgain();
            }
        }
        public static string GetWord()
        {
            string inputs = Console.ReadLine().ToLower();
            if (inputs == "")
            {
                Console.WriteLine("Please enter a valid word");
                return GetWord();
            }

            return inputs;
        }
        public static bool AskAgain()
        {
            Console.WriteLine("Would you like to try a different word? Y/N");

            string restart = Console.ReadLine().ToLower();
            if (restart == "y")
            {
                return true;
            }
            else if (restart == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("That is not a valid response");
                return AskAgain();
            }
        }
        public static string PigLatinTranslator(string userInput)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i <= vowels.Length; i++)
            {
                //if first letter starts with vowel add "way" to end of user input
                if (userInput[0] == vowels[i])
                {
                    return userInput += "way";
                }
                else if (userInput.Contains(vowels[i]))
                {
                    //Locates location of first vowel founds
                    int vowelIndex = userInput.IndexOfAny(vowels);

                    //Makes new word starting at vowel.
                    string newWordStartingWithVowel = userInput.Substring(vowelIndex);

                    // Saves letters located before vowel
                    string lettersbeforeVowel = userInput.Substring(0, vowelIndex);

                    //
                    return newWordStartingWithVowel += lettersbeforeVowel + "ay";
                }

            }
            return "no vowels found";
        }
    }
}
