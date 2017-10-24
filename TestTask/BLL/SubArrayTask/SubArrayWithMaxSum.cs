using System;
using System.Linq;

namespace BLL.SubArrayTask
{
    public static class SubArrayWithMaxSum
    {
        public static Tuple<int[], int> GetSubArrayWithMaxSum(int[] array)
        {          
            int max_so_far = 0;
            int max_ending_here = 0;
            int max_start_index = 0;
            int startIndex = 0;
            int max_end_index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (max_ending_here + array[i] < 0)
                {
                    startIndex = i + 1;
                    max_ending_here = 0;
                }
                else
                {
                    max_ending_here += array[i];
                }

                if (max_ending_here > max_so_far)
                {
                    max_so_far = max_ending_here;
                    max_start_index = startIndex;
                    max_end_index = i;
                }
            }

            int[] subArray = new int[max_end_index - max_start_index + 1];
            int h = 0;

            for (int i = max_start_index; i <= max_end_index; i++)
            {
                subArray[h] = array[i];
                h++;
            }
 
            return Tuple.Create(subArray, subArray.Sum());
        }
    }
}
