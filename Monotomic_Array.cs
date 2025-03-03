class Monotomic_Array
{
    //challenge from: https://leetcode.com/problems/monotonic-array/

    public bool IsMonotonic(int[] nums) 
    {
        bool inc = false;
        bool dec = false;

        for(int i = 0; i < nums.Length - 1; i++)
        {
            if(nums[i] <= nums[i + 1])
            {
                inc = true;
            }

            else
            {
                inc = false;
                break;
            }
        }

        if(!inc)
        {
            for(int i = 0; i < nums.Length - 1; i++)
            {
                if(nums[i] >= nums[i + 1])
                {
                    dec = true;
                }

                else
                {
                    dec = false;
                    break;
                }
            }
        }

        if(inc || dec)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}