﻿using System;

namespace Apopad.Common.Search
{
    public class LevenshteinAnalyser : IAnalyser
    {
        #region Public Methods and Operators

        public double GetLikenessValue(string needle, string haystack)
        {
            int dist = LevenshteinDistance(needle, haystack);
            return 1 - (double)dist / Math.Max(needle.Length, haystack.Length);
        }

        public int LevenshteinDistance(string s, string t)
        {
            // degenerate cases
            if (s == t) return 0;
            if (s.Length == 0) return t.Length;
            if (t.Length == 0) return s.Length;

            // create two work vectors of integer distances
            int[] v0 = new int[t.Length + 1];
            int[] v1 = new int[t.Length + 1];

            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            for (int i = 0; i < v0.Length; i++)
                v0[i] = i;

            for (int i = 0; i < s.Length; i++)
            {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                //   edit distance is delete (i+1) chars from s to match empty t
                v1[0] = i + 1;

                // use formula to fill in the rest of the row
                for (int j = 0; j < t.Length; j++)
                {
                    var cost = (s[i] == t[j]) ? 0 : 1;
                    v1[j + 1] = minimum(v1[j] + 1, v0[j + 1] + 1, v0[j] + cost);
                }

                // copy v1 (current row) to v0 (previous row) for next iteration
                for (int j = 0; j < v0.Length; j++)
                    v0[j] = v1[j];
            }

            return v1[t.Length];
        }
        #endregion

        #region Methods

        private int minimum(int a, int b, int c)
        {
            int temp = Math.Min(a, b);
            return Math.Min(temp, c);
        }

        #endregion

    }
}