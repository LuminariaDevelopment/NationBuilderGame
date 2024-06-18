using CityBuilder.Terrains.C01;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace CityBuilder.Unity.Inspector.GUI
{

    [CustomEditor(typeof(TerrainGenerator))]
    public class TerrainGenPropertiesInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            TerrainGenerator property = (TerrainGenerator)target;

            EditorGUI.BeginChangeCheck();

            property.m_Land = EditorGUILayout.ToggleLeft("Land", property.m_Land);
            property.m_Mountain = EditorGUILayout.ToggleLeft("Mountain", property.m_Mountain);
        }
    }
}