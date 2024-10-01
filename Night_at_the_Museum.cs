class Night_at_the_Museum
{
    //challenge from: https://codeforces.com/problemset/problem/731/A

    public void start()
    {
        Console.Write("Please enter a word: ");
        string? str = Console.ReadLine();

        if(str == null)
        {
            Console.WriteLine("No input given.");
            return;
        }

        str = str.ToLower();
        char c1;
        char c2;
        int clockwise = 0;
        int counter = 0;
        int num = 0;

        for(int i = 0; i < str.Length - 1; i++)
        {
            c1 = str[i];
            c2 = str[i + 1];

            //checks if starting on the 1st letter
            if(i == 0)
            {
                clockwise = (int) c1 - 97;
                counter = 122 - (int) c1;

                //checks if clockwise takes more rotations than counter-clockwise
                if(clockwise > counter)
                {
                    num += counter;
                }

                else
                {
                    num += clockwise;
                }
            }

            else
            {
                clockwise = (int) c2 - (int) c1;
                counter = (int) c1 - (int) c2;

                if(clockwise > counter)
                {
                    num += counter;
                }
                
                else
                {
                    num += clockwise;
                }
            }
        }

        num = Math.Abs(num);
        Console.WriteLine("{0} rotations needed.", num);
    }
}