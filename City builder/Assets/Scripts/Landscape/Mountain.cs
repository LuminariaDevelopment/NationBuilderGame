using System;
using UnityEditor;
using UnityEngine;

namespace CityBuilder.Terrains.C01
{
    public class Mountain : Landscape
    {
        #region Variables
        [SerializeField] private TerrainShape landscapeShape;
        private Land land;
        public float NoiseScale = 520f;
        private float mountainPercentage = 0;
        private float totalMountainArea = 0;

        public float centerHeight = -1.83f;
        public float surroundingHeight = 1.83f;

        public float offsetX = 0;
        public float offsetY = 0;


        #endregion

        #region Encapsulated 

        public float MountainPercentage
        {
            get
            {
                return mountainPercentage;
            }
            set
            {
                mountainPercentage = Mathf.Clamp(value, 0.0f, 100.0f);
            }
        }

        public float TotalMountainArea
        {
            get
            {
                return totalMountainArea;
            }
            set
            {
                totalMountainArea = (MountainPercentage / 100.0f) * TotalLandArea;
            }
        }

        public Land Land
        {
            get
            {
                if (land == null)
                {
                    Land = GetComponent<Land>();
                }
                return land;
            }
            set { land = value; }
        }

        public float TotalLandArea
        {
            get
            {
                return Land.Terrain_Length * Land.Terrain_Width;
            }
            set
            {
                totalLandArea = Land.Terrain_Length * Land.Terrain_Width;
            }
        }

        public TerrainShape LandscapeShape
        {
            get => landscapeShape;
            set
            {
                landscapeShape = value;
            }
        }

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


                Center = new Vector2(terrainData.heightmapResolution / 2, terrainData.heightmapResolution / 2);

                float[,] heights = Noise.GenerateNoise(LandscapeShape, terrainData.heightmapResolution, terrainData.heightmapResolution, NoiseScale, Center, Radius, centerHeight, surroundingHeight);
                // float[,] heights = GenerateHeights();
                Debug.Log(terrainData.heightmapResolution);
                terrainData.SetHeights(0, 0, heights);

                Terrain terrain = Terrain.CreateTerrainGameObject(terrainData).GetComponent<Terrain>();
                terrain.transform.position = new Vector3(-Terrain_Width / 2, 0, -Terrain_Length / 2);

                TerrainObject = terrain;
                TerrainData = terrainData;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Something went wrong: {this.gameObject.name} " + ex.Message);
            }

            AssetDatabase.CreateAsset(terrainData, "Assets/LandScapeData/Mountain.asset");
            AssetDatabase.SaveAssets();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                Center = new Vector2(terrainData.heightmapResolution / 2, terrainData.heightmapResolution / 2);

                float[,] heights = Noise.GenerateNoise(LandscapeShape, terrainData.heightmapResolution, terrainData.heightmapResolution, NoiseScale, Center, Radius, centerHeight, surroundingHeight);
                // float[,] heights = GenerateHeights();
                Debug.Log(terrainData.heightmapResolution);
                terrainData.SetHeights(0, 0, heights);
            }
        }
    }
}
