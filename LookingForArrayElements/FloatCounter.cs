using System;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            if (rangeStart == null || rangeEnd is null || arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart.Length == 0 && rangeEnd.Length == 0)
            {
                return 0;
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("arrays of range starts and range ends contain different number of elements");
            }

            if (rangeStart[0] > rangeEnd[0])
            {
                throw new ArgumentException("range start value is greater than the range end value");
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (arrayToSearch.Length < rangeStart.Length || arrayToSearch.Length < rangeEnd.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayToSearch));
            }

            int[] arrayResult = new int[arrayToSearch.Length];

            float[] elementsToSearchFor = new float[arrayToSearch.Length];

            for (int i = 0; i < arrayToSearch.Length - 1; i++)
            {
                for (int j = 0; j < rangeStart.Length; j++)
                {
                    if (arrayToSearch[i] == rangeStart[j])
                    {
                        elementsToSearchFor[i] = rangeStart[j];
                        arrayResult[i] += 1;
                    }
                    else
                    {
                        arrayResult[i] = 0;
                    }

                    if (arrayToSearch[i + 1] == rangeEnd[j])
                    {
                        elementsToSearchFor[i + 1] = rangeStart[j];
                        arrayResult[i] = 1;
                    }
                    else
                    {
                        arrayResult[i] = 0;
                    }
                }
            }

            for (int j = 0; j < arrayToSearch.Length - 2; j++)
            {
                if (Array.IndexOf(arrayToSearch, elementsToSearchFor[j]) >= 0)
                {
                    arrayResult[j] += 1;
                }
            }

            return Counter.CountOfFoundElements(arrayResult);

        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch is null || rangeStart is null || rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (rangeStart.Length == 0 && rangeEnd.Length == 0)
            {
                return 0;
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("arrays of range starts and range ends contain different number of elements");
            }

            if (rangeStart[0] > rangeEnd[0])
            {
                throw new ArgumentException("range start value is greater than the range end value");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than arrayToSearch.Length");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            int lastPosition = startIndex + count;
            if (lastPosition > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > arrayToSearch.Length");
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (arrayToSearch.Length < rangeStart.Length || arrayToSearch.Length < rangeEnd.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayToSearch));
            }

            int[] arrayResult = new int[arrayToSearch.Length];

            float[] elementsToSearchFor = new float[arrayToSearch.Length];


            int i = 0;
            do
            {
                int k = 0;

                do
                {
                    if (arrayToSearch[i] == rangeStart[k])
                    {
                        elementsToSearchFor[i] = rangeStart[k];
                        arrayResult[i] += 1;
                    }
                    else
                    {
                        arrayResult[i] = 0;
                    }

                    if (arrayToSearch[i + 1] == rangeEnd[k])
                    {
                        elementsToSearchFor[i + 1] = rangeStart[k];
                        arrayResult[i] = 1;
                    }
                    else
                    {
                        arrayResult[i] = 0;
                    }

                    k++;
                }
                while (k < rangeStart.Length);

                i++;
            }
            while (i < arrayToSearch.Length - 1);

            int j = 0;
            do
            {
                if (Array.IndexOf(arrayToSearch, elementsToSearchFor[j]) >= 0)
                {
                    arrayResult[j] += 1;
                }

                j++;
            }
            while (j < arrayToSearch.Length - 2);

            return Counter.CountOfFoundElements(arrayResult, startIndex, count);
        }
    }
}
