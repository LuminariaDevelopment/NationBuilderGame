namespace CityBuilder.Terrains.C01
{

    /// <summary>
    /// The terain pixel resolution of the height map.
    /// </summary>

    public enum HeightMapResolutions
    {

        /// <summary>
        /// Lowest resolution suitable for minimal details,
        /// Good for Low - end Device.
        /// </summary>
        Lowest = 33,

        /// <summary>
        /// Low resolution for slightly more details,
        /// Good for Low - end Device.
        /// </summary>
        Low = 64,

        /// <summary>
        /// Medium resolution offers a balance between details and performence.
        /// </summary>
        Medium = 129,

        /// <summary>
        /// High resolution for more detailed,
        /// Good for Mid - end Device.
        /// </summary>
        High = 257,

        /// <summary>
        /// Very High resolution for intricate details.
        /// Good for High - end Device.
        /// </summary>
        VeryHigh = 513,

        /// <summary>
        /// Ultra resolution for very detailed Graphics.
        /// Good for High - end Device. 
        /// </summary>
        Ultra = 1025,

        /// <summary>
        /// Super Ultra resolution provides extremely detailed.
        /// </summary>
        SuperUltra = 2049,

        /// <summary>
        /// Extreme resolution provides max detailed.
        /// </summary>
        Extreme = 4097,
    }
}
