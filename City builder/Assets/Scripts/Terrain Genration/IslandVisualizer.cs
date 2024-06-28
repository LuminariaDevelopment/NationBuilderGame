using System;
using UnityEngine;

public class IslandVisualizer : MonoBehaviour
{
    public GizmosOptions _options = new();
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _options.radius);
    }

    public class GizmosOptions
    {
        public float radius = 0;
        public float scale = 0.01f;
        public int resolution = 0;

        public float[,] noiseMap;
    }
}
