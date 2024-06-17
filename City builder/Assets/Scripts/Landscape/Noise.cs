using System;
using UnityEngine;

///Note: 
///     Still Under Developing


namespace CityBuilder.Terrains.C01
{

    public static class Noise
    {

        /// <summary>
        ///         Random Noise Genration, using Preline Noise
        ///</summary>
        public static float[,] GenerateNoise(TerrainShape shape, int mapWidth, int mapHeight, float scale, Vector2 center, float radius, float centerHeight, float surroundingHeight)
        {
            switch (shape)
            {
                case TerrainShape.Normal:
                    return GenerateNoiseTypeNormal(mapHeight, mapWidth, mapHeight, scale, center, radius, centerHeight, surroundingHeight);

                case TerrainShape.Round:
                    return GenerateNoiseTypeRound(mapHeight, mapWidth, mapHeight, scale, center, radius, centerHeight, surroundingHeight);

                default:
                    Debug.Log("Under Develope : Applied Normal");
                    return GenerateNoiseTypeNormal(mapHeight, mapWidth, mapHeight, scale, center, radius, centerHeight, surroundingHeight);
            }


        }

        private static float[,] GenerateNoiseTypeNormal(int mapHeight, int mapWidth, int mapHeight2, float scale, Vector2 center, float radius, float centerHeight, float surroundingHeight)
        {
            float[,] noiseData = new float[mapWidth, mapHeight];

            if (scale <= 0) scale = 0.001f;

            float offsetX = UnityEngine.Random.Range(-10000f, 10000f);
            float offsetY = UnityEngine.Random.Range(-10000f, 10000f);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    float sampleX = (x + offsetX) / scale;
                    float sampleY = (y + offsetY) / scale;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);

                    float height = Mathf.Lerp(surroundingHeight, centerHeight, Mathf.Pow(perlinValue, 2)) * .5f;

                    noiseData[y, x] = height;
                }
            }
            return noiseData;
        }


        private static float[,] GenerateNoiseTypeRound(int mapHeight, int mapWidth, int mapHeight2, float scale, Vector2 center, float radius, float centerHeight, float surroundingHeight)
        {
            float[,] noiseData = new float[mapWidth, mapHeight];

            if (scale <= 0) scale = 0.001f;

            float offsetX = UnityEngine.Random.Range(-10000f, 10000f);
            float offsetY = UnityEngine.Random.Range(-10000f, 10000f);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    float sampleX = (x + offsetX) / scale;
                    float sampleY = (y + offsetY) / scale;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);

                    float dx = x - center.x;
                    float dy = y - center.y;
                    float distance = Mathf.Sqrt(dx * dx + dy * dy);

                    float influence = Mathf.Clamp01((radius - distance) / radius * 2);

                    float height = Mathf.Lerp(surroundingHeight, centerHeight, Mathf.Pow(perlinValue, 2)) * influence;

                    noiseData[y, x] = height;
                }
            }


            return noiseData;
        }
    }
}
