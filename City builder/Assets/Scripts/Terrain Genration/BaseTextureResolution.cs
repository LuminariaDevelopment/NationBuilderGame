namespace CityBuilder.Terrains.C01
{
    /// <summary>
    /// Defines the resolution levels for viewing terrain from a distance.
    /// Lower values mean lower detail and shorter viewing distances.
    /// </summary>
    public enum BaseTextureResolution
    {
        /// <summary>
        /// Lowest resolution, suitable for minimal viewing distance.
        /// Ideal for low-end devices.
        /// </summary>
        Lowest = 32,

        /// <summary>
        /// Low resolution, allows for slightly greater viewing distance.
        /// Also suitable for low-end devices.
        /// </summary>
        Low = 64,

        /// <summary>
        /// Medium resolution, balances viewing distance and performance.
        /// Suitable for mid-range devices.
        /// </summary>
        Medium = 128,

        /// <summary>
        /// High resolution, provides more detail and greater viewing distance.
        /// Best for mid-range devices.
        /// </summary>
        High = 256,

        /// <summary>
        /// Very high resolution, offers intricate details at longer distances.
        /// Recommended for high-end devices.
        /// </summary>
        VeryHigh = 512,

        /// <summary>
        /// Ultra resolution, delivers very detailed graphics at long distances.
        /// Ideal for high-end devices.
        /// </summary>
        Ultra = 1024,

        /// <summary>
        /// Super ultra resolution, for extremely detailed graphics.
        /// Suitable for top-tier devices.
        /// </summary>
        SuperUltra = 2048,

        /// <summary>
        /// Extreme resolution, provides maximum detail and viewing distance.
        /// For the highest-end devices.
        /// </summary>
        Extreme = 4096,
    }
}
