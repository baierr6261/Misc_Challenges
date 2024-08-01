using System;

class Typoglycemia
{
    //challenge from: https://old.reddit.com/r/dailyprogrammer/comments/3s4nyq/20151109_challenge_240_easy_typoglycemia/
    public void mispell()
    {
        string file = "..\\C# Projects\\typoglycemia.txt";
        string temp = "";

        foreach(var line in File.ReadAllLines(file))
        {
            string[] strArr = line.Split(' ');
            for(int i = 0; i < strArr.Length; i++)
            {
                //if-else statement to remove the whitespace at the end of the last word in each line
                if(i == strArr.Length - 1)
                {

                    temp = shuffle(strArr[i]);
                    Console.Write("{0}", temp);
                }

                else
                {
                    temp = shuffle(strArr[i]);
                    Console.Write("{0} ", temp);
                }
            }
            
            Console.Write("\n");
        }
    }

    public string shuffle(string str)
    {
        if(str.Length < 4)
        {
            return str;
        }
        else
        {
            string first = str.Substring(0, 1);
            //str.Remove(0, 1);
            str = str.Substring(1);
            string last = str.Substring(str.Length - 1);
            str = str.Remove(str.Length - 1);

            char[] charArr = str.ToCharArray();
            Random rand = new Random();
            int count = charArr.Length;
            int num;
            char c;

            while(count > 1)
            {
                count--;
                num = rand.Next(count + 1);
                c = charArr[num];
                charArr[num] = charArr[count];
                charArr[count] = c;
            }

            string jumble = new string(charArr);
            //jumble.Insert(0, first);
            //jumble.Insert(jumble.Length, last);
            jumble = first + jumble;
            jumble = jumble + last;
            return jumble;
        }
    }
}