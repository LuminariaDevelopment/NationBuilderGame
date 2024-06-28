using System;
using System.Collections.Generic;
using CityBuilder.Unity.Inspector.GUI;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace CityBuilder.Terrains.C01
{
    public class Mountain : Landscape
    {
        #region Variables

        //Higher frequency means more oscillation, leading to 
        //more spikes in the noise pattern
        public float _frequency = 0.01f;

        //octaves mean more detail and more small-scale
        //variations or spikes.
        public int _octaves = 0;

        //Higher granularity means more detail and spikes
        public float _granularity = 0.0f;

        //more turbulence means more spikes.
        public float _turbulence = 0.0f;

        public float _amplitude = 0.0f;

        //
        // Mountain :
        //          Mountain values.
        //

        public int _mountainPercentage = 3;
        public float _mountainRadius = 0.0f;
        public float _mountainHeight = 0.0f;
        public float _mountainFrequency = 0.01f;
        public float _mountainNoiceScale = 50f;


        //
        // Sloaps :
        //          Sloaps values.
        //

        readonly SloapGenrationOption sloapGenration = new();




        public List<Material> _heightMaterial;
        // public Material _defaultMatirial;


        #endregion

        #region Encapulated


        public float Frequency
        {
            get { return _frequency; }
            set
            {
                _frequency = Mathf.Clamp(value, 0.01f, 500.0f);
            }
        }

        public int Octaves
        {
            get { return _octaves; }
            set
            {
                _octaves = Mathf.Clamp(value, 0, 10);
            }
        }

        public float Amplitude
        {
            get { return _amplitude; }
            set
            {

                _amplitude = Mathf.Clamp(value, 0, 1);
            }
        }

        //
        // Mountain :
        //          Mountain values.
        //

        public float MountainRadius
        {
            get { return _mountainRadius; }
            set
            {
                _mountainRadius = Mathf.Clamp(value, 0, (int)HeightMapResolution);
            }
        }

        public float MountainHeight
        {
            get { return _mountainHeight; }
            set
            {
                _mountainHeight = value;
            }
        }

        public float MountainFrequency
        {
            get { return _mountainFrequency; }
            set
            {
                _mountainFrequency = Mathf.Clamp(value, 0.01f, 500f);
            }
        }
        public float MountainNoiceScale
        {
            get { return _mountainNoiceScale; }
            set
            {
                _mountainNoiceScale = Mathf.Clamp(value, 0.01f, 5000f);
            }
        }

        public int MountainPercentage
        {
            get { return _mountainPercentage; }
            set
            {
                _mountainPercentage = Mathf.Clamp(value, 0, 100);
            }
        }


        //
        // Sloaps :
        //          Sloaps values.
        //

        public float SloapRadius
        {
            get { return sloapGenration._sloapRadius; }
            set
            {
                sloapGenration._sloapRadius = Mathf.Clamp(value, 0, (int)HeightMapResolution);
            }
        }

        public float SloapHeight
        {
            get { return sloapGenration._sloapHeight; }
            set
            {
                sloapGenration._sloapHeight = value;
            }
        }

        public int SloapWidth
        {
            get { return sloapGenration._sloapWidth; }
            set
            {
                sloapGenration._sloapWidth = value;
            }
        }

        public int SloapLength
        {
            get { return sloapGenration._sloapLength; }
            set
            {
                sloapGenration._sloapLength = value;
            }
        }

        public float SloapSize
        {
            get { return sloapGenration._sloapSize; }
            set
            {
                sloapGenration._sloapSize = value;
            }
        }

        // public float SloapFrequency
        // {
        //     get { return _SloapFrequency; }
        //     set
        //     {
        //         _SloapFrequency = Mathf.Clamp(value, 0.01f, 500f);
        //     }
        // }
        // public float SloapNoiceScale
        // {
        //     get { return _sloapNoiceScale; }
        //     set
        //     {
        //         _sloapNoiceScale = Mathf.Clamp(value, 0.01f, 5000f);
        //     }
        // }


        public class SloapGenrationOption
        {
            public Test _curve;
            public float _sloapHeight = 0.0f;
            public float _sloapSize = 0.01f;
            public float _sloapRadius = 0.0f;
            public int _sloapWidth = 0;
            public int _sloapLength = 0;
        }


        #endregion

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            if (TryGetComponent<Test>(out sloapGenration._curve))
            {
                Debug.Log("Got It");
            }
        }

        public override void Generate()
        {
            try
            {
                CreateLandscapeMesh();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        private void CreateLandscapeMesh()
        {
            TerrainData = new()
            {
                heightmapResolution = (int)HeightMapResolution,
                alphamapResolution = (int)ControlTextureResolution,
                baseMapResolution = (int)BaseTextureResolution,
                size = new Vector3(LandscapeWidth, LandscapeHeight, LandscapeLength),
                terrainLayers = LandscapeLayers,
            };

            // _defaultMatirial = Terrain.materialTemplate;

            float[,] noise = Noise.GenerateNoise(Seed, (int)HeightMapResolution, Radius, Center, NoiseScale, Frequency, Octaves, Amplitude, MountainPercentage, MountainRadius, MountainHeight, MountainFrequency, MountainNoiceScale, sloapGenration);



            TerrainData.SetHeights(0, 0, noise);

            Terrain = Terrain.CreateTerrainGameObject(_terrainData).GetComponent<Terrain>();

            if (TOPOGRAPHY_MAP)
            {
                Texture2D heightTexture = Noise.GenerateHeightTexture(noise);
                Noise.ApplyHeightTexture(_heightMaterial[0], heightTexture);
                Terrain.materialTemplate = _heightMaterial[0];
            }
            else
            {
                Terrain.materialTemplate = _heightMaterial[1];
                TerrainData.terrainLayers = LandscapeLayers;
            }

            Terrain.transform.position = new Vector3(-LandscapeWidth / 2, 0, -LandscapeLength / 2);

            AssetDatabase.CreateAsset(TerrainData, "Assets/LandscapeData/Mountain.asset");
            AssetDatabase.SaveAssets();
        }

        private void UpdateLandscapeMesh()
        {
#if UNITY_EDITOR
            if (TerrainData == null)
                return;

            TerrainData.heightmapResolution = (int)HeightMapResolution;
            TerrainData.alphamapResolution = (int)ControlTextureResolution;
            TerrainData.baseMapResolution = (int)BaseTextureResolution;
            TerrainData.size = new Vector3(LandscapeWidth, LandscapeHeight, LandscapeLength);
            TerrainData.terrainLayers = LandscapeLayers;

            float[,] noise = Noise.GenerateNoise(Seed, (int)HeightMapResolution, Radius, Center, NoiseScale, Frequency, Octaves, Amplitude, MountainPercentage, MountainRadius, MountainHeight, MountainFrequency, MountainNoiceScale, sloapGenration);



            TerrainData.SetHeights(0, 0, noise);

            if (TOPOGRAPHY_MAP)
            {
                Texture2D heightTexture = Noise.GenerateHeightTexture(noise);
                Noise.ApplyHeightTexture(_heightMaterial[0], heightTexture);
                Terrain.materialTemplate = _heightMaterial[0];
            }
            else
            {
                Terrain.materialTemplate = _heightMaterial[1];

                TerrainData.terrainLayers = LandscapeLayers;
            }

            Terrain.transform.position = new Vector3(-LandscapeWidth / 2, 0, -LandscapeLength / 2);
#endif
        }


        private void Update()
        {
            if (ON_RUNTIME_UPDATE)
            {
                if (UPDATE_ON_KEY_PRESS)
                {
                    if (Input.GetKey(KeyCode.U))
                    {
                        UpdateLandscapeMesh();
                    }
                }
                else
                {
                    UpdateLandscapeMesh();
                }
            }

        }


        // #if ENABLE_GIZMOS
        private void OnDrawGizmos()
        {
            if (ENABLE_GIZMOS)
            {
                Gizmos.color = Color.red;
                // Gizmos.DrawSphere(new Vector3(0, 0, 0), Radius);
                Vector3 bottomLeft = transform.position - new Vector3((LandscapeWidth) / 2, 0, (LandscapeLength) / 2) * (Radius / (int)HeightMapResolution);
                Vector3 bottomRight = bottomLeft + new Vector3(LandscapeWidth, 0, 0) * (Radius / (int)HeightMapResolution);
                Vector3 topLeft = bottomLeft + new Vector3(0, 0, LandscapeLength) * (Radius / (int)HeightMapResolution);
                Vector3 topRight = bottomLeft + new Vector3(LandscapeWidth, 0, LandscapeLength) * (Radius / (int)HeightMapResolution);

                Gizmos.color = Color.blue;
                Gizmos.DrawLine(bottomLeft, bottomRight);
                Gizmos.DrawLine(bottomRight, topRight);
                Gizmos.DrawLine(topRight, topLeft);
                Gizmos.DrawLine(topLeft, bottomLeft);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(bottomLeft, topRight);
            }
        }
        // #endif
    }


}



