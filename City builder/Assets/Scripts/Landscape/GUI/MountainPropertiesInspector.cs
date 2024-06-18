using CityBuilder.Terrains.C01;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace CityBuilder.Unity.Inspector.GUI
{

    [CustomEditor(typeof(Mountain))]
    public class MountainPropertiesInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            Mountain property = (Mountain)target;

            EditorGUI.BeginChangeCheck();

            SingleMountain(property);


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

        private void SingleMountain(Mountain property)
        {
            EditorGUILayout.LabelField("Terrain Size Properties");

            property.LandscapeShape = (TerrainShape)EditorGUILayout.EnumPopup("Landscape Shape", property.LandscapeShape);

            property.Terrain_Length = EditorGUILayout.IntField("Length", property.Terrain_Length);

            property.Terrain_Width = EditorGUILayout.IntField("Width", property.Terrain_Width);

            property.Terrain_Height = EditorGUILayout.IntField("Height", property.Terrain_Height);


            property.NoiseScale = EditorGUILayout.FloatField(new GUIContent("Noise Scale", "The Lower the value the Grater the Noise effect , Tip: Use range between ( 350 - 550 ) to best effect"), property.NoiseScale);

            if (property.LandscapeShape == TerrainShape.Round)
                property.Radius = EditorGUILayout.FloatField(new GUIContent("Radius", "To set the noise in this radius, Tip: Use range between ( 345 - MAX Value  ) to best effect"), property.Radius);

            EditorGUILayout.Space();

            property.Center = EditorGUILayout.Vector2Field(new GUIContent("Center", "Shows the current center"), property.Center);
            property.offsetX = EditorGUILayout.FloatField(new GUIContent("X", "Shows the current center"), property.offsetX);
            property.offsetY = EditorGUILayout.FloatField(new GUIContent("Y", "Shows the current center"), property.offsetY);

            EditorGUILayout.Space();

            property.centerHeight = EditorGUILayout.FloatField(new GUIContent("Center Height", "Set's the Max height. Tip: use between [ -2 , 0 ]"), property.centerHeight);
            property.surroundingHeight = EditorGUILayout.FloatField(new GUIContent("Surrounding Height", "Set the total percentage height needs to be in surroundings. Tip: use between [ 1 - 2]"), property.surroundingHeight);

            EditorGUILayout.Space();

            property.TotalLandArea = EditorGUILayout.FloatField("Land Total Area", property.TotalLandArea);
            EditorGUILayout.HelpBox("Land area is just for Debugging", MessageType.Info);


        }
    }
}