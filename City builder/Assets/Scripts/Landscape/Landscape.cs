using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

namespace CityBuilder.Terrains.C01
{
    public abstract class Landscape : MonoBehaviour
    {
        #region Variables

        protected Terrain terrain;
        protected TerrainData terrainData;

        [SerializeField] protected TerrainResolution heightMapResolution = TerrainResolution.Ultra_HD;
        [SerializeField] protected TerrainResolution controlTextureResolution = TerrainResolution.Ultra_HD;
        [SerializeField] protected TerrainResolution baseTextureResolution = TerrainResolution.Ultra_HD;

        /// Layers
        [SerializeField] protected TerrainLayer[] terrainLayers;
        [SerializeField] protected List<Material> materials;

        /// Length of the terrain.
        [SerializeField] protected int terrain_Length = 100000;

        /// Width of the terrain.
        [SerializeField] protected int terrain_Width = 100000;

        /// Height of the terrain.
        [SerializeField] protected int terrain_Height = 2000;

        /// Center of the terrain
        [SerializeField] protected Vector2 center;

        [SerializeField] protected Vector2 size;
        [SerializeField] protected float radius;
        [SerializeField] protected float totalLandArea;

        #endregion

        #region Encapsulated Properties

        public int Terrain_Length
        {
            get => terrain_Length;
            set => terrain_Length = Mathf.Clamp(value, 1, 100000);
        }

        public int Terrain_Width
        {
            get => terrain_Width;
            set => terrain_Width = Mathf.Clamp(value, 1, 100000);
        }

        public int Terrain_Height
        {
            get => terrain_Height;
            set => terrain_Height = Mathf.Clamp(value, 1, 10000);
        }

        public Vector2 Center
        {
            get => center;
            set =>
                center = new Vector2((float)Height_Map_Resolution / 2, (float)Height_Map_Resolution / 2);
        }

        public float Radius
        {
            get => radius;
            set =>
                radius = Mathf.Clamp(value, (float)TerrainResolution.Potato, (float)TerrainResolution.Ultra_HD / 2);

        }


        public Vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }


        public TerrainResolution Height_Map_Resolution
        {
            get => heightMapResolution;
            set => heightMapResolution = value;
        }

        public TerrainResolution Control_Texture_Resolution
        {
            get => controlTextureResolution;
            set => controlTextureResolution = value;
        }

        public TerrainResolution Base_Texture_Resolution
        {
            get => baseTextureResolution;
            set => baseTextureResolution = value;
        }

        public TerrainLayer[] TerrainLayers
        {
            get => terrainLayers;
            set => terrainLayers = value;
        }

        public List<Material> Materials
        {
            get => materials;
            set => materials = value;
        }

        public Terrain TerrainObject
        {
            get => terrain;
            set => terrain = value;
        }

        public TerrainData TerrainData
        {
            get => terrainData;
            set => terrainData = value;
        }

        #endregion

        public abstract void Generate();
    }
}
