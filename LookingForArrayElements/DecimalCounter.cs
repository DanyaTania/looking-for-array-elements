using System;

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (ranges.Length == 0)
            {
                return 0;
            }

            int[] arrayResult = new int[arrayToSearch.Length];
            int res = 0;
            for (int k = 0; k < ranges.Length; k++)
            {
                for (int i = 0; i < ranges[k].Length; i++)
                {
                    if (Array.IndexOf(arrayToSearch, ranges[k][i]) >= 0)
                {
                    arrayResult[res] += 1;
                    res++;
                }
            }
            }

            return CountOfFoundElements(arrayResult);
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than arrayToSearch.Length");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentNullException(nameof(count), "startIndex + count > arrayToSearch.Length");
            }

            int lastPosition = startIndex + count;
            if (lastPosition > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > arrayToSearch.Length");
            }

            int[] arrayResult = new int[arrayToSearch.Length];
            int res = 0;
            for (int k = 0; k < ranges.Length; k++)
            {
                for (int i = 0; i < ranges[k].Length; i++)
                {
                    if (Array.IndexOf(arrayToSearch, ranges[k][i], startIndex, count) >= 0)
                    {
                        arrayResult[res] += 1;
                        res++;
                    }
                }
            }

            return CountOfFoundElements(arrayResult, startIndex, count);
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

        public static int CountOfFoundElements(int[] arrayResult, int startIndex, int count)
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
    }
}
