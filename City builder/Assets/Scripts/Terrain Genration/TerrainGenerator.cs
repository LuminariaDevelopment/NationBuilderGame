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
                if (!TryGetComponent(out mountain))
                {
                    mountain = gameObject.AddComponent<Mountain>();
                }
            }

            // if (land == null && m_Land)
            // {
            //     Debug.Log("Check 0.5");

            //     land = gameObject.GetComponent<Land>();
            //     Debug.Log("Check 1");

            // }

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
            if (mountain != null && m_Mountain) { mountain.Generate(); }

            Terrain _terrain = FindAnyObjectByType<Terrain>();
            _terrain.gameObject.layer = 3;

            // if (land != null && m_Land) { land.Generate(); Debug.Log("Check 2"); }
            // Debug.Log("Check Ended");
        }
    }
}
