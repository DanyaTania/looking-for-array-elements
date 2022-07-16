using System;

namespace LookingForArrayElements
{
    public static class IntegersCounter
    {
        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (elementsToSearchFor == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (arrayToSearch.Length < elementsToSearchFor.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(elementsToSearchFor));
            }

            if (elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            byte[] arrayResult = new byte[arrayToSearch.Length];
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                for (int j = 0; j < elementsToSearchFor.Length; j++)
                {
                    if (arrayToSearch[i] == elementsToSearchFor[j])
                    {
                        arrayResult[i]++;
                    }
                }
            }

            return CountOfFoundElements(arrayResult);
        }

        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements withing the range of elements in the <see cref="Array"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "array to search is null.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than arrayToSearch.Length");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentNullException(nameof(count));
            }

            if (elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            int lastPosition = startIndex + count;
            if (lastPosition > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > arrayToSearch.Length");
            }

            byte[] arrayResult = new byte[arrayToSearch.Length];

            int i = 0;
            while (i < arrayToSearch.Length - 1)
            {
                int j = 0;
                while (j < elementsToSearchFor.Length)
                {
                    if (arrayToSearch[i] == elementsToSearchFor[j])
                    {
                        arrayResult[i]++;
                    }

                    j++;
                }

                i++;
            }

            return CountOfFoundElements(arrayResult, startIndex, count);
        }

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
    }
}
