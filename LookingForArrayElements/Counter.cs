using System;

namespace LookingForArrayElements
{
    public static class Counter
    {
        public static int CountOfFoundElements(byte[] arrayResult)
        {
            int result = 0;
            if (arrayResult is null)
            {
                throw new ArgumentNullException(nameof(arrayResult));
            }

            for (int i = 0; i < arrayResult.Length; i++)
            {
                if (arrayResult[i] > 0)
                {
                    result += arrayResult[i];
                }
            }

            return result;
        }

        public static int CountOfFoundElements(byte[] arrayResult, int startIndex, int count)
        {
            int result = 0;
            if (arrayResult is null)
            {
                throw new ArgumentNullException(nameof(arrayResult));
            }

            int lastPosition = startIndex + count;
            for (int i = startIndex; i < lastPosition; i++)
            {
                if (arrayResult[i] > 0)
                {
                    result += arrayResult[i];
                }
            }

            return result;
        }

        public static int CountOfFoundElements(int[] arrayResult)
        {
            int result = 0;
            if (arrayResult is null)
            {
                throw new ArgumentNullException(nameof(arrayResult));
            }

            for (int i = 0; i < arrayResult.Length; i++)
            {
                if (arrayResult[i] > 0)
                {
                    result += arrayResult[i];
                }
            }

            return result;
        }
    }
}
