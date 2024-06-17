using CityBuilder.Terrains.C01;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace CityBuilder.Unity.Inspector.GUI
{

    [CustomEditor(typeof(Water))]
    public class WaterPropertiesInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            Water property = (Water)target;

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.Space();

            property.Size = EditorGUILayout.Vector2Field("Water Size", property.Size);

            EditorGUILayout.Space();

            SerializedProperty terrainGraphicMode = serializedObject.FindProperty("materials");

            EditorGUILayout.PropertyField(terrainGraphicMode, new GUIContent("Materials"), true);

            serializedObject.ApplyModifiedProperties();
        }

    }
}
