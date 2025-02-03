class Find_Smallest_Letter_Greater_Than_Target
{
    //challenge from: https://leetcode.com/problems/find-smallest-letter-greater-than-target/description/

    public char findSmallest(char[] arr, char target)
    {
        if(target == 'z')
        {
            return arr[0];
        }

        else
        {
            int minDiff = 10000;
            int tar = (int) target;

            for(int i = 0; i < arr.Length; i++)
            {
                if((int) arr[i] > target && (int) arr[i] - target < minDiff)
                {
                    minDiff = (int) arr[i] - target;
                }
            }

            for(int i = 0; i < arr.Length; i++)
            {
                if((int) arr[i] - target == minDiff)
                {
                    return arr[i];
                }
            }
        }

        return '0'; //this is here to remove an error
    }
}