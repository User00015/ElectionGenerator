using System;

namespace ElectionGenerator
{
    public static class Random
    {
        public static int Integers(int min, int max)
        {
            var scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                var fourBytes = new byte[4];
                Program._rng.GetBytes(fourBytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(fourBytes, 0);
            }

            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) *
                         (scale / (double)uint.MaxValue));
        }
    }
}