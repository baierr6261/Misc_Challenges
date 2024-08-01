class Easy_Anagram_Detector
{
    //challenge from: https://old.reddit.com/r/dailyprogrammer/comments/52enht/20160912_challenge_283_easy_anagram_detector/

    public void detect()
    {
        string file = "..\\C# Projects\\anagram_detection_tests.txt";
        string[] arr = new string[]{};
        bool anagram;

        foreach(var line in File.ReadLines(file))
        {
            arr = line.Split('?');
            anagram = test(arr[0], arr[1]);

            if(anagram)
            {
                Console.Write("{0}is an anagram of{1}\n", arr[0], arr[1]);
            }

            else
            {
                Console.WriteLine("{0}isn't an anagram of{1}\n", arr[0], arr[1]);
            }

        }
    }

    public bool test(string str1, string str2)
    {
        str1 = str1.ToLower().Replace(" ", "").Replace("'","");
        str2 = str2.ToLower().Replace(" ", "").Replace("'","");
        List<char> list = new List<char>();
        char c;

        if(str1.Length != str2.Length)
        {
            return false;
        }

        else
        {
            for(int i = 0; i < str2.Length; i++)
            {
                c = str2[i];
                list.Add(c);
            }

            for(int i = 0; i < str1.Length; i++)
            {
                if(list.Contains(str1[i]))
                {
                    list.Remove(str1[i]);
                }
            }

            if(list.Count == 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}