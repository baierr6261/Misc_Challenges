using System;
using System.Collections.Generic;
using System.Linq;

class Node_Degrees
{
    //challenge from: https://old.reddit.com/r/dailyprogrammer/comments/4ijtrt/20160509_challenge_266_easy_basic_graph/

    public void findDegrees()
    {
        string file = "..\\C# Projects\\node_degrees.txt";
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int num1;
        int num2;
        int count;

        //reads from the .txt file
        foreach(var line in File.ReadLines(file))
        {
            string[] nums = line.Split(' ');
            num1 = int.Parse(nums[0]);
            nums = nums.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            //checks if there is 1 element in the str array
            if(nums.Length == 1)
            {
                if(!dict.ContainsKey(num1))
                {
                    dict.Add(num1, 0);
                }
            }

            else
            {
                num2 = int.Parse(nums[1]);

                if(!dict.ContainsKey(num1))
                {
                    dict.Add(num1, 0);
                }

                if(!dict.ContainsKey(num2))
                {
                    dict.Add(num2, 0);
                }

                //checks if num2 is in dict
                if(dict.ContainsKey(num2))
                {
                    dict.TryGetValue(num2, out count);
                    dict[num2] = count + 1;
                }

                //checks if num1 is in dictionary
                if(dict.ContainsKey(num1))
                {
                    dict.TryGetValue(num1, out count);
                    dict[num1] = count + 1;
                }
            }
        }

        var ordered = dict.OrderBy(x => x.Key);

        //prints the ordered nodes
        foreach(var node in ordered)
        {
            Console.Write("Node {0} has a degree of {1}.\n", node.Key, node.Value);
        }
    }
}