using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

namespace CityBuilder.Terrains.C01
{
    [RequireComponent(typeof(Mountain), typeof(Land))]
    public class TerrainGenerator : MonoBehaviour
    {

        public bool m_Land = true;
        public bool m_Mountain = true;
        private Mountain mountain;
        private Land land;

        // public Water water;

        private void Awake()
        {
            if (mountain == null && m_Mountain)
            {
                if (!TryGetComponent<Mountain>(out mountain))
                {
                    mountain = gameObject.AddComponent<Mountain>();
                }
            }

            if (land == null && m_Land)
            {
                if (!TryGetComponent<Land>(out land))
                {
                    land = gameObject.AddComponent<Land>();
                }
            }

            // if (water == null)
            // {
            //     if (!TryGetComponent<Water>(out water))
            //     {
            //         water = gameObject.AddComponent<Water>();
            //     }
            // }
        }

        public void Build()
        {
            if (mountain != null && land != null)
            {
                // water.Generate();
                land.Generate();
                mountain.Generate();
            }
            else
            {
                Debug.LogError("component is missing!");
            }
        }
    }
}
