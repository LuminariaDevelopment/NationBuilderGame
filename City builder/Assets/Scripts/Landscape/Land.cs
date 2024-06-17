using System;
using UnityEditor;
using UnityEngine;

namespace CityBuilder.Terrains.C01
{
    public class Land : Landscape
    {

        #region Variables

        public float NoiseScale = 5f;

        #endregion

        public override void Generate()
        {
            try
            {
                terrainData = new()
                {
                    heightmapResolution = (int)Height_Map_Resolution,
                    alphamapResolution = (int)Control_Texture_Resolution,
                    baseMapResolution = (int)Base_Texture_Resolution,
                    size = new Vector3(Terrain_Width, Terrain_Height, Terrain_Length),
                    terrainLayers = TerrainLayers
                };

                float[,] heights = GenerateVolumeFlate(terrainData.heightmapResolution);

                terrainData.SetHeights(0, 0, heights);

                Terrain terrain = Terrain.CreateTerrainGameObject(terrainData).GetComponent<Terrain>();
                terrain.transform.position = new Vector3(-Terrain_Width / 2, 0, -Terrain_Length / 2);
            }
            catch (Exception ex)
            {
                Debug.LogError("Something went wrong: " + ex.Message);
            }

            AssetDatabase.CreateAsset(terrainData, "Assets/LandScapeData/Land.asset");
            AssetDatabase.SaveAssets();
        }

        private float[,] GenerateVolumeFlate(int Resolution)
        {
            float[,] heights = new float[Resolution, Resolution];

            for (int x = 0; x < Resolution; x++)
            {
                for (int y = 0; y < Resolution; y++)
                {
                    heights[x, y] = 0;
                }
            }
            return heights;
        }
    }
}