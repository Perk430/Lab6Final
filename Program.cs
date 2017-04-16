using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!");

            bool play = true, inputIsValid = false;
            string sentence, pigLatinSentence = "";
            string[] words;

            while (play)
            {
                pigLatinSentence = "";
                sentence = "";
                do
                {
                    Console.Write("Enter your sentence here:  ");
                    sentence = Console.ReadLine();

                    inputIsValid = sentence.Length > 0;
                } while (!inputIsValid);
                // First, we'll split the sentence into seperate words
                // Trimming and making lowercase at the same time as well
                words = sentence.Trim().ToLower().Split(' ');

                int len = words.Length, i;
                for (i = 0; i < len; i++)
                {
                    // going to put vowels in array to check how to handle the word
                    // if it's not a vowel, it's a consonant, so it's less typing and faster to check for the smaller subset
                    string word = words[i];
                    char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
                    char firstLetter = word[0];
                    bool firstLetterIsVowel = vowels.Contains(firstLetter);

                    if (firstLetterIsVowel)
                    {
                        // just add way at the end
                        word += "way";
                    }
                    else
                    {
                        // figure ut where the first vowel is
                        int firstVowel = word.IndexOfAny(vowels) > -1 ? word.IndexOfAny(vowels) : word.Length - 1;

                        // move the beginning to the first string to the back and add "ay"
                        word = word + word.Substring(0, firstVowel) + "ay";
                        // slice the beginning of the string now
                        word = word.Substring(firstVowel);
                    }

                    pigLatinSentence = pigLatinSentence + word + " ";
                }
                Console.WriteLine("Your sentence is:  {0}", pigLatinSentence);

                Console.Write("Play again? y/n\t");
                play = Console.ReadLine()[0] == 'y';
            }

            Console.Write("\nBye...(Press Enter to exit)");
            Console.ReadLine();
        }
    }
}

       