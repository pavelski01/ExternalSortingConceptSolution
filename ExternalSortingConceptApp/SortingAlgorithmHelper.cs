using System.Threading.Tasks;

namespace ExternalSortingConceptApp
{
    public static class SortingAlgorithmHelper
    {
        public static void QuicksortPara(int[] arr, int left, int right)
        {
            if (right > left)
            {
                var pivot = Partition(arr, left, right);
                Parallel.Invoke(
                    () => QuicksortPara(arr, left, pivot - 1),
                    () => QuicksortPara(arr, pivot + 1, right)
                );
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivotPos = (high + low) / 2;
            var pivot = arr[pivotPos];
            Swap(arr, low, pivotPos);
            int left = low;
            for (int i = low + 1; i <= high; i++)
            {
                if (arr[i].CompareTo(pivot) < 0)
                {
                    left++;
                    Swap(arr, i, left);
                }
            }
            Swap(arr, low, left);
            return left;
        }

    }
}
