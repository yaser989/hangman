using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    internal class Words
    {

        public static void callWords()
        {

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine();

            string[] wordList = { "watermelon", "pineapple", "orange", "mango" };

            
            // randomly choose a word from the word list and assign it to a variable called chosenWord

            Random random = new Random();
            int wordListInt = random.Next(0, wordList.Length - 1);

            string chosenWord = wordList[wordListInt].ToLower();
            Console.WriteLine("The word has {0} characters", chosenWord.Length);

            int remainingAttempts = 10;
            List<string> alreadyGuessedLetters = new List<string>();
            List<string> alreadyGuessedWord = new List<string>();
            string displayWord = "";
            bool rightAnswer = false;
            bool chosseWordNotLetters = false;
            bool lettersAlreadyChossen = false;
            string alreadyGuessed = "";


            while (remainingAttempts > 0 && displayWord != chosenWord && !chosenWord.Equals(alreadyGuessedWord) && rightAnswer == false ) 
            {
                Console.WriteLine("Remaining attempts: {0}", remainingAttempts);
              

                // ask the user to guess a letter and assign their answer to a variable called
                // "guess". Make guess lowercase.

                Console.WriteLine("Enter a letter: ");
                char[] input = Console.ReadLine().ToCharArray();

                string guessLetters = "";
                string guessWord = "";
                if (input.Length > 1)
                {
                    chosseWordNotLetters = true;

                    for (int i = 0; i < input.Length; i++)
                    {
                        guessWord += input[i].ToString();
                        guessWord = guessWord.ToLower();
                    }

                  // remainingAttempts -1 if it's not the good word
                    if (!chosenWord.Equals(guessWord))
                    {
                        remainingAttempts--;
                        Console.WriteLine($"the word what you already guess:( {guessWord} ) is not the secret word...");
                       
                    }
                }
                else
                {
                    
                    chosseWordNotLetters = false;
                    guessLetters = new string(input);
                    guessLetters= guessLetters.ToLower();
                }
                alreadyGuessedWord.Add(guessWord);
                alreadyGuessedLetters.Add(guessLetters);


                // check if the letter the user guessed (guessLetters) is one of the letters in the chosenWord
                displayWord = "";
                string containedMessage = "";




                foreach (var letters in alreadyGuessedLetters)
                {
                    if (!alreadyGuessed.Contains(letters))
                    {
                        lettersAlreadyChossen = false;
                    }
                    else
                    {
                        lettersAlreadyChossen = true;
                    }
                 
                }



                    if (chosseWordNotLetters == false)
            {

                if (chosenWord.Contains(guessLetters))
                {
                    containedMessage = "the letters ( {0} ) is contained in the word.";
                       
                    }
             
                else
                {
                    containedMessage = "the letters ( {0} ) is NOT contained in the word.";
                  

                        if (lettersAlreadyChossen == false) {
                            remainingAttempts--;
                        }
                       
                 }
                    Console.WriteLine(containedMessage, guessLetters);
                   

                }

              
              

                foreach (var letter in chosenWord)
                {

                    if (alreadyGuessedLetters.Contains(letter.ToString()))
                    {
                        displayWord += letter;
                    }
                    else
                    {
                        displayWord += "*";
                      
                    }
                }





                // print all the wrong letters what the user choesen
                foreach (var letters in alreadyGuessedLetters)
                {
                    if (!chosenWord.Contains(letters))
                    {

                        if (!alreadyGuessed.Contains(letters))
                        {
                           alreadyGuessed += letters;
                            lettersAlreadyChossen = true;
                        }
                       
                    }

                }


            
              

                Console.WriteLine($"the letters what you already chosse:  {alreadyGuessed}");

               
                // check if the Word the user guessed (guessWord) is one of the Words in the chosenWord
                foreach (var word in alreadyGuessedWord)
                {
                    if (chosenWord.Equals(word))
                    {
                        rightAnswer = true;
                      
                    }
                                       
                }


                Console.WriteLine(displayWord);
                Console.WriteLine();
            } // end while
            if (remainingAttempts == 0 )
            {
                Console.WriteLine("You have ran out of attempts. You lose!");
                Console.WriteLine("The word was: {0}", chosenWord);
                Console.WriteLine("Press E to exit the game...");
            }
            else
            {
                Console.WriteLine("You have won the game!");
                Console.WriteLine("The word is: {0}", chosenWord);
                Console.WriteLine("Press E to exit the game...");
            }


            while (Console.ReadKey().Key != ConsoleKey.E) ; 
        }
        

        }
}
