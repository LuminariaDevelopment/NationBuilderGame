using UnityEngine;

namespace CityBuilder.Terrains.C01
{
    [RequireComponent(typeof(Mountain), typeof(Land))]
    public class TerrainGenerator : MonoBehaviour
    {
        public Mountain mountain;
        public Land land;

        // public Water water;

        private void Awake()
        {
            if (mountain == null)
            {
                if (!TryGetComponent<Mountain>(out mountain))
                {
                    mountain = gameObject.AddComponent<Mountain>();
                }
            }

            if (land == null)
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
