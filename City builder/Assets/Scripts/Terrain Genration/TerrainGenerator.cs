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
            Debug.Log("Check 0");

            if (mountain == null && m_Mountain)
            {
                if (!TryGetComponent(out mountain))
                {
                    mountain = gameObject.AddComponent<Mountain>();
                    Debug.Log("Check 1");
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
            Debug.Log("Check 1.5");
            if (mountain != null && m_Mountain) { mountain.Generate(); }


            // if (land != null && m_Land) { land.Generate(); Debug.Log("Check 2"); }
            // Debug.Log("Check Ended");
        }
    }
}
