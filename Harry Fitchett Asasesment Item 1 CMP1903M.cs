using System;
using System.Collections.Generic;
using System.IO;
namespace OOPproject
{
    // -- Output --
    // This class formats the data into the C# console it is in it's own seperate class for the sake of an OOP approach 
    class Output
    {
        // Defines the variables for all the peices of information that the Output class will need
        // counts number of Vowels
        private int vowels;
        // counts number of Consonants
        private int notVowels;
        // counts number of Upper Case letters
        private int upperCase;
        // counts number of Lower Case Letters
        private int lowerCase;
        // counts number of Sentences
        private int Sentences;
        // counts each instance of Letter
        private int[] Letters;

        // instantiate the calss
        public Output(int var1, int var2, int var3, int var4, int var5, int[] var6)
        {
            // sets variables
            vowels = var1;
            notVowels = var2;
            upperCase = var3;
            lowerCase = var4;
            Sentences = var5;
            Letters = var6;
        }

        // Run uses many of the methods in Output and runs them in a specific order to get the desired output
        public void Run()
        {
            ShowVowels(vowels);
            ShowNotVowels(notVowels);
            ShowUpperCase(upperCase);
            ShowLowerCase(lowerCase);
            ShowSentences(Sentences);
            ShowLetterCount(Letters);
        }

        // displays a line telling the user how many Vowels were found
        static void ShowVowels(int number)
        {
            Console.Write("Vowels: ");
            Console.Write(number);
            Console.WriteLine("");
        }

        // displays a line telling the user hou many Consonants were found
        static void ShowNotVowels(int number)
        {
            Console.Write("Consonants: ");
            Console.Write(number);
            Console.WriteLine("");
        }

        // displays a line telling the user hou many Upper Case were found
        static void ShowUpperCase(int number)
        {
            Console.Write("Upper Case Characters: ");
            Console.Write(number);
            Console.WriteLine("");
        }

        // displays a line telling the user hou many Lower Case were found
        static void ShowLowerCase(int number)
        {
            Console.Write("Lower Case Character: ");
            Console.Write(number);
            Console.WriteLine("");
        }

        // displays a line telling the user hou many Sentences were found
        static void ShowSentences(int number)
        {
            Console.Write("Number Of Sentences: ");
            Console.Write(number);
            Console.WriteLine("");
        }

        // displaus the number of times each letter was found
        static void ShowLetterCount(int[] numbers)
        {
            // this is all asthetics
            Console.WriteLine(" A | B | C | D | E | F | G | H | I | J | K | L | M | N | O | P | Q | R | S | T | U | V | W | X | Y | Z |");
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+----");
            Console.Write(" ");
            // the numbers array contains 27 items that record the number of times certain letters were counted the position a letter count fall is in theb array is determine by its alphabetical position
            for (int i = 0; i < 26; i++)
            {

                Console.Write(numbers[i]);
                // this creates the grid
                Console.Write(" | ");
            }
        }

    }
    class Program
    {
        // Main handels everything in this program aside from then output
        static void Main(string[] args)
        {
            // Defines the varibales i will be using for this class
            // text contains the text that will be analysed 
            string text = RegularInput();
            // sentences records the number of Sentences counted
            int sentences = 0;
            // vowels records the number of Vowels recorded
            int vowels = 0;
            // notVowels records the number of Consonants recorded
            int notVowels = 0;
            // upperCase records the number of Upper Case Characters recorded
            int upperCase = 0;
            // lowerCase records the number of Lower Case Characters recorded
            int lowerCase = 0;
            // letters records the number of times each individual letter is recorded
            // the ketters position in this array is determined by its alphabetical location
            int[] letters = new int[27];
            // currentChar stores the current character the progrsam is analysing as it moves through text
            char currentChar;
            // this for loop cycles through the entire text string character by character
            for (int i = 0; i < text.Length; i++)
            {
                // sets the currentChar to the Current Character
                currentChar = text[i];
                bool Check;
                // this checks to see if the Current Character is a Vowel
                if (Check = CheckVowel(currentChar) == true)
                {
                    // if it is it adds one to vowels
                    vowels++;
                }
                // again this checks if the Current Character is a Consonant
                if (Check = CheckNotVowels(currentChar) == true)
                {
                    // and will add one in that eventuality
                    notVowels++;
                }
                // checks for Upper Case Character
                if (Char.IsUpper(currentChar) == true)
                {
                    upperCase++;
                }
                // checks for Lower Case Character
                if (Char.IsLower(currentChar) == true)
                {
                    lowerCase++;
                }
                // updates Letters with the new charcter by increasing that characters count by one
                letters[CountLetter(currentChar)] = letters[CountLetter(currentChar)] + 1;
            }
            // this is all done after the text has been analysed line by line
            // this will recorded all the words bigger than seven characters and add them to a text file
            BigWordCounter(text);
            // this counts the number of sentences
            sentences = CountSentences(text);
            // appropriate information is passed to the ouput class
            Output Current_Output = new Output(vowels, notVowels, upperCase, lowerCase, sentences, letters);
            // the output class is told to run
            Current_Output.Run();
        }

        // this function counts the seven character or bigger words and ouputs them to a text file
        static void BigWordCounter(string text)
        {
            // these lines ask the user to input the location on the C drive and the name the file should be saved as
            Console.WriteLine("What extension would you like the big word file to be saved at");
            Console.WriteLine(">>>   ");
            string filename = Console.ReadLine();
            // allWords stores all the words in the text by splitting text by " "
            string[] allWords = text.Split(" ");
            // big words will store words bigger than seven characters
            List<string> BigWords = new List<string>();
            // this deletes any exsiting files of that name and location to avoid errors
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            // this creates creates the file in the specified location and name
            using (FileStream fs = File.Create(filename))
            // this for loop searches through all words 
            for (int i = 0; i < allWords.Length; i++)
            {
                // the if statement will retreive any words bigger than seven characters
                if (allWords[i].Length >= 7)
                {
                    // this adds the words to BigWords
                    BigWords.Add(allWords[i]);
                }
            }
            // This writes to the recently created text file
            using (StreamWriter writetext = new StreamWriter(filename))
            {
                // this for loop goes through all the items in BigWord
                foreach (string BigWord in BigWords)
                {
                    // and adds them to the text file
                    writetext.WriteLine(BigWord);
                }
            }
        }

        // This function is ran to receive input 
        static string RegularInput()
        {
            // these variables are used for input validation
            string answer;
            char checkedAnswer;
            // this while loop is used to ensure a usable intput is gievnm from the user
            while (true)
            {
                // asks the user if they would to input via console or text file
                Console.WriteLine("Would you like to input with console or with file C for console F for file");
                Console.WriteLine(">>>   ");
                answer = Console.ReadLine();
                // validates the answer
                if (answer.Length == 1)
                {
                    // validates the answer
                    checkedAnswer = answer[0];
                    if (checkedAnswer == 'C')
                    {
                        // performs a console input
                        return ConsoleInput();
                    }
                    // validates answer
                    else if (checkedAnswer == 'F')
                    {
                        // performs a file input
                        return FileInput();
                    }
                }


            }

        }
        // This function receives inputs via console
        static string ConsoleInput()
        {
            string text = "";
            char answer;
            string lineQuestion;
            // this loop is to ensure the user can input lines until the all the text they want is submitted
            while (true)
            {
                // asking the user to input a line of text
                Console.WriteLine("Enter your next line of text");
                Console.WriteLine(">>>   ");
                text = text + Console.ReadLine();
                // this is used for error handling purposes should the user not input one of the conditions
                while (true)
                {
                    // asks the user if they would like to add anymore lines
                    Console.WriteLine("Would you like to input another line? Y for yes N for no.");
                    lineQuestion = Console.ReadLine();
                    // checks to see if the input is valid to the prior question and breaks if it is valid
                    if (lineQuestion.Length == 1)
                    {
                        answer = char.ToUpper(lineQuestion[0]);
                        if (answer == 'Y' || answer == 'N')
                        {
                            break;
                        }

                    }
                // once the user types N or n into would they like to type new lines the initial while loop breaks
                }
                if (answer == 'N')
                {
                    break;
                }
            }
            // the console input text is returned
            return text;
        }
        // this function is for inputting text via external text file
        static string FileInput()
        {
            string text;
            string extension;
            // while loop used for error handeling purposes
            while (true)
            {
                // asks the user the location and name of the file they want to input
                Console.WriteLine("What is the file extension you would like to open from");
                Console.WriteLine(">>>   ");
                extension = Console.ReadLine();
                // checks to see if the file exsists if it does'nt the program will ask again 
                if (File.Exists(@extension) == true)
                {
                    // if the file exsists the contents is read and the text is returned to the main function
                    text = File.ReadAllText(@extension);
                    return text;
                }

            }

        }
        // this function checks to see if a character is a vowel
        static bool CheckVowel(char current)
        {
            char letter = char.ToUpper(current);
            // if the character is vowel it returns true
            if (letter == 'A' || letter == 'E' || letter == 'I' || letter == 'O' || letter == 'U')
            {
                // returning true
                return true;
            }
            // otherwise the character is not a vowel and returns false
            else
            {
                // returning false
                return false;
            }
        }
        // this function checks if it is a consonants
        static bool CheckNotVowels(char current)
        {
            bool Check;
            // if the character is not a vowel and is a letter it returns true
            if (Check = CheckVowel(current) == false && Char.IsLetter(current) == true)
            {
                // returning true
                return true;
            }
            // otherwise it returns false
            else
            {
                // returning false
                return false;
            }
        }
        // this function is used to count the number of sentences
        static int CountSentences(string text)
        {
            // the text file is split by "." and the parts are put into and array called SentenceList
            string[] SentenceList = text.Split(".");
            int SentenceListLength = SentenceList.Length;
            // searches through all the sentences
            for (int i = 0; i < SentenceList.Length; i++)
            {
                // removes any empty sentences
                if (SentenceList[i] == "")
                {
                    SentenceListLength = SentenceListLength - 1;
                }
            }
            return SentenceListLength;
        }
        // this is used to count the number of times each letter appears
        // it does this by simply converting the letter to its array location
        // not a very pretty or efficient function but it works
        static int CountLetter(char current)
        {
            // the characters are converted to Uppercase to cut down on the number of comparisons required to be made later
            current = char.ToUpper(current);
            if (current == 'A')
            {
                // returns the apprpriate array location equivilent to the letter
                return 0;
            }
            // the loogic for each of these loops is the same as the first no need for additional comments
            else if (current == 'B')
            {
                return 1;
            }
            else if (current == 'C')
            {
                return 2;
            }
            else if (current == 'D')
            {
                return 3;
            }
            else if (current == 'E')
            {
                return 4;
            }
            else if (current == 'F')
            {
                return 5;
            }
            else if (current == 'G')
            {
                return 6;
            }
            else if (current == 'H')
            {
                return 7;
            }
            else if (current == 'I')
            {
                return 8;
            }
            else if (current == 'J')
            {
                return 9;
            }
            else if (current == 'K')
            {
                return 10;
            }
            else if (current == 'L')
            {
                return 11;
            }
            else if (current == 'M')
            {
                return 12;
            }
            else if (current == 'N')
            {
                return 13;
            }
            else if (current == 'O')
            {
                return 14;
            }
            else if (current == 'P')
            {
                return 15;
            }
            else if (current == 'Q')
            {
                return 16;
            }
            else if (current == 'R')
            {
                return 17;
            }
            else if (current == 'S')
            {
                return 18;
            }
            else if (current == 'T')
            {
                return 19;
            }
            else if (current == 'U')
            {
                return 20;
            }
            else if (current == 'V')
            {
                return 21;
            }
            else if (current == 'W')
            {
                return 22;
            }
            else if (current == 'X')
            {
                return 23;
            }
            else if (current == 'Y')
            {
                return 24;
            }
            else if (current == 'Z')
            {
                return 25;
            }
            // if the character is not a letter it returns 26 this value is never used again however could be employed should it be required in later builds
            else
            {
                return 26;
            }

        }
    }


}