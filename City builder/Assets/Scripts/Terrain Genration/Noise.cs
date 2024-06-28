using System;
using System.Collections.Generic;
using UnityEngine;

///Note: 
///     Still Under Developing


namespace CityBuilder.Terrains.C01
{

    public static class Noise
    {

        /// <summary>
        /// Generates random noise with an island shape using Perlin Noise.
        /// </summary>
        public static float[,] GenerateNoise(int seed, int resolution, float radius, Vector2 center, float noiseScale, float frequency, int octaves, float amplitude, int mountainPercentage, float mountainRadius, float mountainHeight, float mountainFrequency, float mountainNoiceScale, Mountain.SloapGenrationOption sloapGenration)
        {
            float[,] noise = new float[resolution, resolution];

            System.Random _seed = new System.Random(seed);
            Vector2[] octaveOffsets = new Vector2[octaves];

            for (int i = 0; i < octaves; i++)
            {
                float offsetX = _seed.Next(-100000, 100000);
                float offsetY = _seed.Next(-100000, 100000);

                octaveOffsets[i] = new(offsetX, offsetY);
            }

            for (int y = 0; y < resolution; y++)
            {
                for (int x = 0; x < resolution; x++)
                {
                    float _totalNoise = 0.0f;
                    float _frequency = frequency;
                    float _amplitude = amplitude;

                    for (int i = 0; i < octaves; i++)
                    {

                        float xCoord = ((float)x + octaveOffsets[i].x / resolution) * frequency;
                        float yCoord = ((float)y + octaveOffsets[i].y / resolution) * frequency;

                        _totalNoise = Mathf.PerlinNoise(xCoord / noiseScale, yCoord / noiseScale) * _amplitude;

                        _frequency *= 2.0f;
                    }

                    noise[y, x] = _totalNoise;
                }
            }

            List<Vector3> positions = GetVerticesPositionInRadius(resolution, radius, center);

            for (int i = 0; i <= mountainPercentage; i++)
            {
                GenerateMountainInRadius(positions, _seed, noise, mountainRadius, mountainHeight, mountainFrequency, resolution, mountainNoiceScale);
            }


            // GenerateSloapsInRadius(positions, noise, _seed, resolution, sloapGenration);

            return noise;
        }

        private static void GenerateSloapsInRadius(List<Vector3> positions, float[,] noise, System.Random seed, int resolution, Mountain.SloapGenrationOption sloapGenration)
        {
            Vector3 sloapCenter = positions[seed.Next(positions.Count)];

            int centerX = (int)sloapCenter.x;
            int centerY = (int)sloapCenter.z;

            float sqrSloapRadius = sloapGenration._sloapRadius * sloapGenration._sloapRadius;

            float sloapLength = sloapGenration._curve.customCurve.keys.Length * sloapGenration._sloapSize;

            Debug.Log(sloapLength);

            for (int y = 0; y < sloapLength; y++)
            {
                for (int x = 0; x < sloapLength; x++)
                {
                    float yCoord = (float)y / (sloapLength - 1);
                    float xCoord = (float)x / (sloapLength - 1);

                    float heightValueX = sloapGenration._curve.customCurve.Evaluate(xCoord);
                    float heightValueY = sloapGenration._curve.customCurve.Evaluate(yCoord);

                    noise[centerY + y, centerX + x] += (heightValueY + heightValueX) * sloapGenration._sloapHeight;

                }
            }

            // for (int y = 0; y < resolution; y++)
            // {
            //     for (int x = 0; x < resolution; x++)
            //     {
            //         float sqrDistance = (x - centerX) * (x - centerX) + (y - centerY) * (y - centerY);

            //         if (sqrDistance <= sqrSloapRadius)
            //         {
            // float distance = Mathf.Sqrt(sqrDistance);

            // float normalizedDistance = distance / _sloapRadius; 

            // float heightValue = _curve.customCurve.Evaluate(normalizedDistance) * _sloapHeight;

            //     }
            // }
            // }
        }



        private static void GenerateMountainInRadius(List<Vector3> positions, System.Random _seed, float[,] noise, float mountainRadius, float mountainHeight, float mountainFrequency, int resolution, float noiseScale)
        {
            Vector3 mountainCenter = positions[_seed.Next(positions.Count)];

            int centerX = (int)mountainCenter.x;
            int centerY = (int)mountainCenter.z;

            float sqrMountainRadius = mountainRadius * mountainRadius;

            for (int y = 0; y < resolution; y++)
            {
                for (int x = 0; x < resolution; x++)
                {
                    float sqrDistance = (x - centerX) * (x - centerX) + (y - centerY) * (y - centerY);

                    if (sqrDistance <= sqrMountainRadius)
                    {
                        float distanceFactor = 1 - (sqrDistance / sqrMountainRadius);
                        float xCoord = (float)x / resolution * mountainFrequency;
                        float yCoord = (float)y / resolution * mountainFrequency;
                        float perlinValue = Mathf.PerlinNoise(xCoord * noiseScale, yCoord * noiseScale);
                        noise[y, x] += perlinValue * mountainHeight * distanceFactor;
                    }
                }
            }

            if (_seed.Next(40) > 20)
                for (int y = 0; y < resolution; y++)
                {
                    for (int x = 0; x < resolution; x++)
                    {
                        float sqrDistance = (x - centerX) * (x - centerX) + (y - centerY) * (y - centerY);

                        if (sqrDistance <= sqrMountainRadius)
                        {
                            float distanceFactor = 1 - (sqrDistance / sqrMountainRadius);
                            float xCoord = (float)x / resolution * mountainFrequency;
                            float yCoord = (float)y / resolution * mountainFrequency;
                            float perlinValue = Mathf.PerlinNoise(xCoord * noiseScale, yCoord * noiseScale / distanceFactor);
                            noise[y, x] += perlinValue * mountainHeight * distanceFactor;
                        }
                    }
                }

            if (_seed.Next(100) > 70 && _seed.Next(40) < 100)
                for (int y = 0; y < resolution; y++)
                {
                    for (int x = 0; x < resolution; x++)
                    {
                        float sqrDistance = (x - centerX) * (x - centerX) + (y - centerY) * (y - centerY);

                        if (sqrDistance <= sqrMountainRadius)
                        {
                            float distanceFactor = 1 - (sqrDistance / sqrMountainRadius);
                            float xCoord = (float)x / resolution * mountainFrequency;
                            float yCoord = (float)y / resolution * mountainFrequency;
                            float perlinValue = Mathf.PerlinNoise(xCoord * noiseScale, yCoord * noiseScale / mountainHeight);
                            noise[y, x] += perlinValue * mountainHeight * distanceFactor;
                        }
                    }
                }
        }



        private static List<Vector3> GetVerticesPositionInRadius(int resolution, float radius, Vector2 center)
        {
            List<Vector3> _verticesPosition = new List<Vector3>();

            float sqrRadius = radius * radius;

            for (int y = 0; y < resolution; y++)
            {
                for (int x = 0; x < resolution; x++)
                {
                    float _distance = (x - center.x) * (x - center.x) + (y - center.y) * (y - center.y);

                    if (_distance <= sqrRadius)
                    {
                        _verticesPosition.Add(new Vector3(x, 0, y));
                    }
                }
            }
            return _verticesPosition;
        }



        /// <summary>
        /// Generates a height texture from noise data.
        /// </summary>
        public static Texture2D GenerateHeightTexture(float[,] noise)
        {
            try
            {
                int resolution = noise.GetLength(0);
                Debug.Log("resolution B : " + resolution);
                Texture2D texture = new Texture2D(resolution, resolution);

                for (int y = 0; y < resolution; y++)
                {
                    for (int x = 0; x < resolution; x++)
                    {
                        float sample = noise[y, x];
                        texture.SetPixel(x, y, new Color(sample, sample, sample));
                    }
                }
                texture.Apply();
                return texture;
            }
            catch (Exception ex)
            {
                Debug.LogError("Not Generated Height Texture " + ex.Message);
                return new Texture2D(0, 0);
            }
        }


        /// <summary>
        /// Applies the generated height texture to a material.
        /// </summary>
        public static void ApplyHeightTexture(Material material, Texture2D heightTexture)
        {
            try
            {
                material.SetTexture("_HeightTex", heightTexture);
            }
            catch (Exception ex)
            {
                Debug.LogError("Not Applied " + ex.Message);
            }
        }


    }
}
