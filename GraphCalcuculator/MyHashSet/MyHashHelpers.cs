using System;

namespace MyHashSet
{
    public static class MyHashHelpers
    {
        public const int HashCollisionThreshold = 100;
        public static readonly int[] capacities = {
            3, 7, 17, 37, 79, 163, 331, 673, 1_361, 2_729, 5_471, 10_949,
            21_911, 43_853, 87_719, 175_447, 350_899, 701_819, 1_403_641,
            2_807_303, 5_614_657, 11_229_331, 22_458_671, 44_917_381,
            89_834_777, 179_669_557, 359_339_171, 718_678_369, 1_437_356_741,
            2_147_483_629};

        public static int GetNextCapacity(int capacity)
        {
            int i = 0;
            while (i < capacities.Length && capacities[i] <= capacity) i++;
            if (i == capacities.Length) throw new ArgumentException("Увеличение ёмкости приведёт к переполнению.");
            else return capacities[i];
        }
    }
}
