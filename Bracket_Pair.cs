using System;
using System.Collections.Generic;

class Bracket_Pair
{
    //challenge from: https://old.reddit.com/r/dailyprogrammer/comments/11par4/10182012_challenge_104_intermediate_bracket_racket/

    public void check(string str)
    {
        Stack<Char> s = new Stack<Char>();
        Console.WriteLine("Checking {0}", str);

        string brackets = "(<[{)>]}";

        for(int i = 0; i < str.Length; i ++)
        {
            //checks if str[i] isn't a bracket
            if(!brackets.Contains(str[i]))
            {
                continue;
            }

            //checks for open brackets
            else if(str[i] == '(' || str[i] == '<' || str[i] == '[' || str[i] == '{')
            {
                s.Push(str[i]);
            }

            //checks if stack is empty and str[i] is a closed bracket
            else if((str[i] == ')' || str[i] == '>' || str[i] == ']' || str[i] == '}') && s.Count == 0)
            {
                Console.WriteLine("false");
                return;
            }

            //checks for mismatched brackets
            else if((s.Peek() == '(' && str[i] != ')') || (s.Peek() == '<' && str[i] != '>') || (s.Peek() == '[' && str[i] != ']') || 
            (s.Peek() == '{' && str[i] != '}'))
            {
                Console.WriteLine("false");
                return;
            }

            //checks for matching brackets
            else if((s.Peek() == '(' && str[i] == ')') || (s.Peek() == '<' && str[i] == '>') || (s.Peek() == '[' && str[i] == ']') || 
            (s.Peek() == '{' && str[i] == '}'))
            {
                s.Pop();
            }
        }

        if(s.Count == 0)
        {
            Console.WriteLine("true");
        }

        else
        {
            Console.WriteLine("false");
        }
    }
}