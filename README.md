# Pulsing Noise

This small C# class library simply provides a cycling procedural floating point value result between 0 and 1 that appears noisy.

##public static float PulsingNoise(float progress)##
*This function takes progressive input , like time and returns noisy pulsing results that will cycle, based on a compound of variant intervals.*

##public static void SetSeedVariants(float[] variants)##
*This function sets the variant intervals used in the cycling noisy pulse results. The default will use an array of prime numbers (1,3,5,7,11) with a +1/-1 random deviation upon initialization.*
