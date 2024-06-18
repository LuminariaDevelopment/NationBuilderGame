using CityBuilder.Terrains.C01;
using TMPro;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

namespace CityBuilder.Unity.Inspector.GUI
{
    [CustomEditor(typeof(Land))]
    public class LandPropertiesInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            Land property = (Land)target;

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("Terrain Size Properties");

            property.Terrain_Length = EditorGUILayout.IntField("Length", property.Terrain_Length);

            property.Terrain_Width = EditorGUILayout.IntField("Width", property.Terrain_Width);

            property.Terrain_Height = EditorGUILayout.IntField("Height", property.Terrain_Height);

            // property.NoiseScale = EditorGUILayout.FloatField("Noise Scale", property.NoiseScale);

            // property.Radius = EditorGUILayout.FloatField(new GUIContent("Radius", $"To set the noise in this radius, Tip: Use range between ( 1300 - 2000 ) to best effect"), property.Radius);
            property.Center = EditorGUILayout.Vector2Field("Center", property.Center);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Graphic Properties");

            property.Height_Map_Resolution = (TerrainResolution)EditorGUILayout.EnumPopup("Height Map Resolution", property.Height_Map_Resolution);
            property.Control_Texture_Resolution = (TerrainResolution)EditorGUILayout.EnumPopup("Control Map Resolution", property.Control_Texture_Resolution);
            property.Base_Texture_Resolution = (TerrainResolution)EditorGUILayout.EnumPopup("Base Map Resolution", property.Base_Texture_Resolution);

            EditorGUILayout.Space();

            SerializedProperty terrainGraphicMode = serializedObject.FindProperty("terrainLayers");

            EditorGUILayout.PropertyField(terrainGraphicMode, new GUIContent("Terrain Texture Layers"), true);

            serializedObject.ApplyModifiedProperties();

            // property.NoiseScale = EditorGUILayout.FloatField("Noise Scale", property.NoiseScale);
        }
    }
}