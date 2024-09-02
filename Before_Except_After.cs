class Before_Except_After
{
    public void check(string str)
    {
        if(str.Length < 3)
        {
            Console.Write("false");
        }

        else
        {
            int temp = -1;

            for(int i = 0; i < str.Length - 1; i++)
            {
                if(str[i] == 'c')
                {
                    temp = i;
                }

                //checks if ei is right after c
                else if(str[i] == 'e' && str[i + 1] == 'i' && temp == i - 1)
                {
                    if(i != 0)
                    {
                        Console.Write("true");
                        return;
                    }
                }

                //checks if ie is before c, doesn't matter if c exists
                else if(str[i] == 'i' && str[i + 1] == 'e')
                {
                    if(temp != i + 2)
                    {
                        Console.Write("true");
                        return;
                    }
                }

            }
        }

        
        Console.Write("false");
    }
}