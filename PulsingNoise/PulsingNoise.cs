using System;

/// <summary>
/// Support system to produce gently pulsing noise results
/// </summary>
public class ProceduralPulse
{
    static float[] noiseVariants = ScrambleVariants();

    /// <summary>
    /// Explicitly sets an array of intervals to use as variants for noisy pulse results
    /// </summary>
    /// <param name="seedVariants">An array of progressive intervals that overlap to develop noisy pulsing results</param>
    public static void SetSeedVariants(float[] seedVariants)
    {
        noiseVariants = seedVariants;
    }

    static float[] ScrambleVariants()
    {
        float[] retFloats = { 1, 3, 5, 7, 11 };
        Random rnd = new Random();

        for (int i = 0; i < retFloats.Length; i++)
        {
            retFloats[i] += (float)(rnd.NextDouble() * 2.0 - 1.0);
        }

        return retFloats;
    }

    static float NormalizeToUnsigned01(float value)
    {
        return (value + 1f) / 2f;
    }

    static float UnsignedSine(float time, float divisor)
    {
        return NormalizeToUnsigned01(MathF.Sin((time * 2f * MathF.PI) / divisor));
    }

    /// <summary>
    /// Produces a noisy pulsing result value from progressive input, using randomly seeded source variants
    /// </summary>
    /// <param name="time">Input value</param>
    /// <returns>Noisy pulsing results between 0 and 1</returns>
    public static float PulseNoise(float time)
    {
        float retFloat = 0f;

        for (int i = 0; i < noiseVariants.Length; i++)
        {
            retFloat += UnsignedSine(time, noiseVariants[i]);
        }
        retFloat /= noiseVariants.Length;

        return retFloat;
    }
}