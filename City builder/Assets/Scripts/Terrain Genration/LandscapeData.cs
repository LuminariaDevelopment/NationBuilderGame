using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.Terrains.C01
{
    public abstract class LandscapeData : MonoBehaviour
    {
        #region Variables


        //Datas
        protected Terrain _terrain;
        protected TerrainData _terrainData;

        //Seed Genration
        [SerializeField] protected int _seed = 321564;

        // Resolution
        [SerializeField] protected HeightMapResolutions _heightMapResolution = HeightMapResolutions.Medium;
        [SerializeField] protected ControlTextureResolution _controlTextureResolution = ControlTextureResolution.Medium;
        [SerializeField] protected BaseTextureResolution _baseTextureResolution = BaseTextureResolution.Medium;


        /// Length of the terrain.
        [SerializeField] protected int _landScapeLength = 5000;


        /// Width of the terrain.
        [SerializeField] protected int _landScapeWidth = 5000;


        /// Height of the terrain.
        [SerializeField] protected int _landScapeHeight = 500;


        /// Terrain Layers
        [SerializeField] protected TerrainLayer[] _terrainLayers;
        [SerializeField] protected List<Material> _materials;


        // Local Data Variables..

        [SerializeField] protected float _radius;
        [SerializeField] protected Vector2 _center;
        [SerializeField] protected float _noiseScale;

        [SerializeField] protected float _totalLandArea;
        [SerializeField] protected Vector2 size;


        // Data Status
        public bool DATA_CHANGED = false;
        public bool ON_RUNTIME_UPDATE = false;
        public bool UPDATE_ON_KEY_PRESS = false;
        public bool DEBUGING = false;
        public bool TOPOGRAPHY_MAP = false;
        public bool ENABLE_GIZMOS = true;

        #endregion

        #region Encapsulated Properties

        public int Seed
        {
            get { return _seed; }
            set
            {
                _seed = Mathf.Clamp(value, 10000, 1000000);
            }
        }

        /// <summary>
        /// Terrain Surface
        /// </summary>
        public Terrain Terrain
        {
            get => _terrain;
            set => _terrain = value;
        }


        /// <summary>
        /// Terrain Data
        /// </summary>
        public TerrainData TerrainData
        {
            get => _terrainData;
            set => _terrainData = value;
        }



        public int LandscapeLength
        {
            get => _landScapeLength;
            set
            {
                _landScapeLength = Mathf.Clamp(value, 100, 100000);

                if (value != _landScapeLength) DATA_CHANGED = true;
            }
        }



        public int LandscapeWidth
        {
            get => _landScapeWidth;
            set
            {
                _landScapeWidth = Mathf.Clamp(value, 100, 100000);

                if (value != _landScapeWidth) DATA_CHANGED = true;
            }
        }



        public int LandscapeHeight
        {
            get => _landScapeHeight;
            set
            {
                _landScapeHeight = Mathf.Clamp(value, 0, 10000);

                if (value != _landScapeHeight) DATA_CHANGED = true;
            }
        }



        public Vector2 Center
        {
            get
            {
                _center = new Vector2((float)HeightMapResolution / 2, (float)HeightMapResolution / 2);
                return _center;
            }
        }

        public float Radius
        {
            get => _radius;
            set
            {
                _radius = Mathf.Clamp(value, 0.0f, (float)HeightMapResolution);

                if (value != _radius) DATA_CHANGED = true;
            }

        }


        public float TotalLandArea
        {
            get => _totalLandArea = this.LandscapeLength * this.LandscapeWidth;
        }


        public float NoiseScale
        {
            get => _noiseScale;
            set => _noiseScale = Mathf.Clamp(value, 0.01f, (float)LandscapeLength + (float)LandscapeWidth);
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


        public HeightMapResolutions HeightMapResolution
        {
            get => _heightMapResolution;
            set => _heightMapResolution = value;
        }

        public ControlTextureResolution ControlTextureResolution
        {
            get => _controlTextureResolution;
            set => _controlTextureResolution = value;
        }

        public BaseTextureResolution BaseTextureResolution
        {
            get => _baseTextureResolution;
            set => _baseTextureResolution = value;
        }

        public TerrainLayer[] LandscapeLayers
        {
            get => _terrainLayers;
        }

        // public List<Material> Materials
        // {
        //     get => materials;
        //     set => materials = value;
        // }

    }

    #endregion
}

