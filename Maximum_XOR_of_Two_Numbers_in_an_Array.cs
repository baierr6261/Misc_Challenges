class Maximum_XOR_of_Two_Numbers_in_an_Array
{
    //challenge from: https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array/description/

    public int FindMaximumXOR(int[] nums)
    {
        int max = 0;
        int result = 0;

        for(int i = 0; i < nums.Length; i++)
        {
            for(int j = i + 1; j < nums.Length; j++)
            {
                result = nums[i] ^ nums[j];
                if(result > max)
                {
                    max = result;
                }
            }
        }

        return max;
    }
}