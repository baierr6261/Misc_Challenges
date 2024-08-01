using System;
using System.Collections.Generic;
using System.Linq;
class Concatenated_Integers
{
    //challenge from: https://www.reddit.com/r/dailyprogrammer/comments/69y21t/20170508_challenge_314_easy_concatenated_integers/
    public void concatInt()
    {
        string file = "..\\C# Projects\\concat_ints.txt";
        string temp = File.ReadAllText(file);

        //checks if the file is empty/null
        if(temp is null)
        {
            Console.Write("The provided text file is empty, null, what have you.");
            return;
        }

        else
        {
            List<string> str = temp.Split(" ").ToList();
            List<int> list = new List<int>();

            //checks if each element in str can be converted into an int
            foreach(var s in str)
            {
                int num;
                bool success = int.TryParse(s, out num);
                if(success)
                {
                    list.Add(num);
                }

                else
                {
                    Console.Write("Something went wrong when converting the string list to an int list.");
                    return;
                }
            }

            int min = 100000000;
            int max = 0;
            string str1;
            int perm;
            int temp1;

            //goes through the int list
            for(int i = 0; i < list.Count; i++)
            {
                //goes through the list, checks if permutation is min/max, then swaps
                for(int j = i; j < list.Count; j++)
                {
                    str1 = string.Join("", list);
                    perm = int.Parse(str1);

                    if(perm > max)
                    {
                        max = perm;
                    }

                    if(perm < min)
                    {
                        min = perm;
                    }

                    temp1 = list[i];
                    list[i] = list[j];
                    list[j] = temp1;
                }
            }

            Console.Write("smallest value: {0}, largest value: {1}", min.ToString(), max.ToString());
        }
    }
}