class System_of_Equations
{
    //challenge from: https://codeforces.com/problemset/problem/214/A

    public void find()
    {
        Console.Write("Please enter two positive non-zero integers from 1-1000. Seperate each integer with a whitespace: ");
        string? str = Console.ReadLine();

        if(str == null || str.Length < 2)
        {
            Console.WriteLine("Invalid input.");
        }

        else
        {
            string[] arr = str.Split(' ');
            int num1 = Convert.ToInt32(arr[0]);
            int num2 = Convert.ToInt32(arr[1]);
            int i = 0;
            int j = 0;

            int count = 0;
            int max = 0;

            if(num1 > num2)
            {
                max = num1;
            }

            else
            {
                max = num2;
            }

            while(i < max + 1)
            {
                while(j < max + 1)
                {
                    if((i * i + j == num1) && (i + j * j == num2))
                    {
                        count++;
                    }

                    j++;
                }

                i++;
            }

            i = 0;
            j = 0;

            while(j < max + 1)
            {
                while(i < max + 1)
                {
                    if((i * i + j == num1) && (i + j * j == num2))
                    {
                        count++;
                    }

                    i++;
                }

                j++;
            }

            Console.WriteLine(count);
        }
    }
}