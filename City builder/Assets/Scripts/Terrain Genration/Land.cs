using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace CityBuilder.Terrains.C01
{
    public class Land : Landscape
    {
        // #region Variables

        // public float NoiseScale = 800f;
        // public bool READY_TO_UPDATE = false;

        // public Test _curve;

        // public int _sloapHeight = 0;

        // public float _sloapSixe = 0.0f;

        // [SerializeField] private float[,] m_Heights = new float[2049, 2049];

        // #endregion

        // public float[,] Heights
        // {
        //     get { return m_Heights; }
        //     set
        //     {
        //         if (value != m_Heights)
        //         {
        //             m_Heights = value;
        //             UpdateData();
        //         }
        //     }
        // }

        // public void Awake()
        // {
        //     _ = TryGetComponent<Test>(out _curve);

        //     if (_curve)
        //     {
        //         Debug.Log("Succesess");
        //     }
        // }

        // private void Update()
        // {
        //     if (READY_TO_UPDATE)
        //     {
        //         Debug.Log("Updating terrain data...");
        //         UpdateData();
        //     }
        // }

        // private void UpdateData()
        // {
        //     if (terrainData == null)
        //     {
        //         Debug.LogError("TerrainData is null!");
        //         return;
        //     }

        //     Debug.Log("Check 4");

        //     // Update the terrain data properties if needed
        //     // terrainData.heightmapResolution = (int)Height_Map_Resolution;
        //     // terrainData.alphamapResolution = (int)Control_Texture_Resolution;
        //     // terrainData.baseMapResolution = (int)Base_Texture_Resolution;
        //     terrainData.size = new Vector3(Terrain_Width, Terrain_Height, Terrain_Length);
        //     terrainData.terrainLayers = TerrainLayers;

        //     float[,] heights = GenerateVolumeFlat();

        //     terrainData.SetHeights(0, 0, heights);

        //     Debug.Log("Check 6");
        // }

        // private void CreateData()
        // {
        //     Debug.Log("Check 4");

        //     terrainData = new TerrainData
        //     {
        //         heightmapResolution = (int)Height_Map_Resolution,
        //         alphamapResolution = (int)Control_Texture_Resolution,
        //         baseMapResolution = (int)Base_Texture_Resolution,
        //         size = new Vector3(Terrain_Width, Terrain_Height, Terrain_Length),
        //         terrainLayers = TerrainLayers,
        //     };

        //     float[,] heights = GenerateVolumeFlat();

        //     terrainData.SetHeights(0, 0, heights);

        //     Debug.Log("Check 6");

        //     SaveTerrainData(terrainData);
        // }

        // private void SaveTerrainData(TerrainData terrainData)
        // {
        //     Debug.Log("Check 6.5");
        //     AssetDatabase.CreateAsset(terrainData, "Assets/LandScape/Land.asset");
        //     AssetDatabase.SaveAssets();

        //     DATA_CHANGED = false;
        //     Debug.Log("Check 6.7");
        // }

        public override void Generate()
        {
            // Debug.Log("Check 3");
            // try
            // {
            //     CreateData();

            //     Debug.Log("Check 7");

            //     if (terrain == null)
            //     {
            //         terrain = Terrain.CreateTerrainGameObject(terrainData).GetComponent<Terrain>();
            //         terrain.transform.position = new Vector3(-Terrain_Width / 2, 0, -Terrain_Length / 2);
            //     }

            //     Debug.Log("Check 8");
            // }
            // catch (Exception ex)
            // {
            //     Debug.LogError("Something went wrong: " + ex.Message);
            // }

            // READY_TO_UPDATE = true;
            // Debug.Log("Check 9 Complete");
        }

        // private float[,] GenerateVolumeFlat()
        // {
        //     // // Ensure the heights array has the correct dimensions
        //     // if (Heights == null || Heights.GetLength(0) != 2049 || Heights.GetLength(1) != 2049)
        //     // {
        //     //     Heights = new float[2049, 2049];
        //     // }

        //     int width = terrainData.heightmapResolution;

        //     for (int x = 0; x < 2049; x++)
        //     {
        //         for (int y = 0; y < 2049; y++)
        //         {
        //             float xCoord = (float)x / (width - 1) / _sloapSixe;
        //             float yCoord = (float)y / (width - 1) / _sloapSixe;

        //             float heightValueX = _curve.customCurve.Evaluate(xCoord) * _sloapHeight;
        //             float heightValueY = _curve.customCurve.Evaluate(yCoord) * _sloapHeight;

        //             Heights[x, y] = (heightValueY + heightValueX) / _sloapSixe;
        //         }
        //     }
        //     Debug.Log("Check 5");
        //     return Heights;
        // }
    }
}
