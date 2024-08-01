class Fallout_Hacking_Game
{
    //challenge from: https://old.reddit.com/r/dailyprogrammer/comments/3qjnil/20151028_challenge_238_intermediate_fallout/

    public void start()
    {
        string file = "..\\C# Projects\\fallout_hacking_words.txt";
        List <string> list1 = new List<string>();

        //reads each line in the file and adds the word to a list if the word's length > 4
        foreach(var line in File.ReadLines(file))
        {
            string[] words = line.Split(' ');
            for(int i = 0; i < words.Length; i++)
            {
                if(words[i].Length > 4)
                {
                    list1.Add(words[i]);
                }
            }
        }
        
        //very easy = 4-5 letters, easy = 6-8 letters, avg. = 9-10 letters, hard = 11-12 letters, very hard = 13-15 letters
        Console.WriteLine("1 - Very Easy | 2 - Easy | 3 - Average | 4 - Hard | 5 - Very Hard\n");
        Console.Write("Choose a difficulty in the form of the corresponding number: ");
        int diff = Convert.ToInt32(Console.ReadLine());
        List<string> list2 = new List<string>(); //2nd list that has words removed based on the difficulty
        list2 = removeWords(list1, diff);

        Console.Write("\nStarting the game...\n");
        play(list2);
    }

    public List<string> removeWords(List<string> list, int diff)
    {
        int min;
        int max;
        
        //sets the min. and max word lengths
        switch(diff)
        {
            case 1:
                min = 4;
                max = 5;
                break;

            case 2:
                min = 6;
                max = 8;
                break;
            case 3:
                min = 9;
                max = 10;
                break;
            case 4:
                min = 11;
                max = 12;
                break;
            default:
                min = 13;
                max = 15;
                break;
        }

        //removes words if the word's length doesn't fit the difficulty's criteria
        for(int i = 0; i < list.Count; i++)
        {
            if(list[i].Length < min && list[i].Length > max)
            {
                list.Remove(list[i]);
            }
        }

        return list;
    }

    //where the player plays the hacking game
    public void play(List<string> list2)
    {
        int correct;
        int len = 0;
        int num;
        int tries = 4;
        string? guess = "";
        string password = "";
        List<string> list3 = new List<string>();
        Random rand = new Random();

        //puts random words into another list and removes the word from the 2nd list
        while(list3.Count < 16)
        {
            num = rand.Next(0, list2.Count - 1);

            //checks if the first word added to the 3rd list
            if(list3.Count == 0)
            {
                len = list2[num].Length;
                list3.Add(list2[num]);
                list2.Remove(list2[num]);
            }

            else
            {
                //checks if the random word is the same length as the other words in the 3rd list
                if(list2[num].Length == len)
                {
                    list3.Add(list2[num]);
                    list2.Remove(list2[num]);
                }

                //removes the chosen random word from the 2nd list if its length != the password's length
                else
                {
                    list2.Remove(list2[num]);
                }
            }
        }

        //chooses a random word from the 3rd list to be the password
        num = rand.Next(0, list3.Count - 1);
        password = list3[num];

        //the actual game itself
        while(tries > 0)
        {
            correct = 0;

            //displays the remaining words
            for(int i = 0; i < list3.Count; i++)
            {
                if(i % 3 == 0)
                {
                    Console.Write("\n");
                }
                Console.Write(list3[i] + "|");
            }

            Console.WriteLine("\nGuesses? {0} tries remain. ", tries);
            guess = Console.ReadLine();

            //checks if the guess isn't valid
            if(guess == null || guess.Length != password.Length)
            {
                tries--;
            }

            else
            {
                guess = guess.ToUpper();

                //checks if the guess is the same as the password, if so then end the game
                if(guess.Equals(password))
                {
                    Console.WriteLine("{0}/{0} correct", password.Length);
                    Console.WriteLine("Access granted...");
                    return;
                }

                //otherwise decrement # of tries and remove the guess from the 3rd list
                else
                {
                    //removes the guessed word from the 3rd list if it exists
                    guess = guess.ToUpper();
                    //Console.WriteLine("guess is here");
                    list3.Remove(guess);

                    for(int i = 0; i < guess.Length; i++)
                    {
                        if(guess[i] == password[i])
                        {
                            correct++;
                        }
                    }

                    Console.WriteLine("{0}/{1} correct", correct, password.Length);
                    tries--;
                }
                
            }
        }

    }
}