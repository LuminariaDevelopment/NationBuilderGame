using System;
using CityBuilder.Terrains.C01;
using UnityEditor;
using UnityEngine;


namespace CityBuilder.Unity.Inspector.GUI
{
    [CustomEditor(typeof(Mountain))]
    public class MountainPropertiesInspector : Editor
    {
        GUIStyle _headerStyle;
        GUIStyle _propertyStyle;
        GUIStyle _containerStyle;
        GUIStyle _debugStyle;

        bool _developerOptionsFoldout = false;
        bool _debugDataFoldout = false;

        private static Texture2D _normalBackground;
        private static Texture2D _hoverBackground;

        [InitializeOnLoadMethod]
        private static void PreloadTextures()
        {
            _normalBackground = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Terrain Genration/GUI/GUI System/Inspector Skins/Normal.png", typeof(Texture2D));
            _hoverBackground = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Terrain Genration/GUI/GUI System/Inspector Skins/Hover.png", typeof(Texture2D));
        }

        private void OnEnable()
        {
            _containerStyle ??= new GUIStyle(EditorStyles.label)
            {
                margin = new RectOffset(5, 5, 5, 5),
                padding = new RectOffset(10, 10, 10, 10),
            };

            _headerStyle ??= new GUIStyle(EditorStyles.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                margin = new RectOffset(5, 5, 5, 5),
                padding = new RectOffset(5, 5, 5, 5),
                normal = { background = _normalBackground },
                fixedHeight = 23,
                hover = { background = _hoverBackground }
            };

            _propertyStyle ??= new GUIStyle(EditorStyles.label)
            {
                margin = new RectOffset(10, 10, 0, 10),
                padding = new RectOffset(10, 10, 0, 0),
            };

            _debugStyle ??= new GUIStyle(EditorStyles.label)
            {
                fontSize = 11,
                fontStyle = FontStyle.Bold,
                hover = { textColor = Color.blue },
                normal = { textColor = Color.green },
            };
        }

        public override void OnInspectorGUI()
        {
            Mountain property = (Mountain)target;

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginVertical(_containerStyle);

            EditorGUILayout.LabelField("Landscape Seed", _headerStyle);
            EditorGUILayout.Space();
            DrawLandscapeSeed(property);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Landscape Detail", _headerStyle);
            EditorGUILayout.Space();
            DrawLandscapeDetail(property);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Landscape Size Properties", _headerStyle);
            EditorGUILayout.Space();
            DrawLandscapeSize(property);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Terrain Generation Properties", _headerStyle);
            EditorGUILayout.Space();
            DrawLandscapeProperties(property);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Graphic Resolution Properties", _headerStyle);
            EditorGUILayout.Space();
            DrawLandscapeGraphicResolutions(property);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Graphic Textures", _headerStyle);
            EditorGUILayout.Space();
            DrawLandscapeTextures(property);
            EditorGUILayout.Space();

            DrawDeveloperOptions(property);

            EditorGUILayout.Space();

            if (property.DEBUGING)
                DrawDebugData(property);

            EditorGUILayout.EndVertical();

            ApplyGUIChanges();
        }

        private void DrawLandscapeDetail(Mountain property)
        {
            EditorGUILayout.BeginVertical(_propertyStyle);

            property.BaseMapDistance = EditorGUILayout.IntField("Render Distance", property.BaseMapDistance);

            EditorGUILayout.EndVertical();
        }


        private void DrawLandscapeSeed(Mountain property)
        {
            EditorGUILayout.BeginVertical(_propertyStyle);

            property.Seed = EditorGUILayout.IntField("Seed", property.Seed);

            EditorGUILayout.EndVertical();
        }


        private void DrawLandscapeSize(Mountain property)
        {
            EditorGUILayout.BeginVertical(_propertyStyle);

            property.LandscapeLength = EditorGUILayout.IntField(new GUIContent("Landscape Length", "The length of the landscape"), property.LandscapeLength);
            property.LandscapeWidth = EditorGUILayout.IntField(new GUIContent("Landscape Width", "The width of the landscape"), property.LandscapeWidth);
            property.LandscapeHeight = EditorGUILayout.IntField(new GUIContent("Landscape Height", "The height of the landscape"), property.LandscapeHeight);

            EditorGUILayout.EndVertical();
        }

        private void DrawLandscapeGraphicResolutions(Mountain property)
        {
            EditorGUILayout.BeginVertical(_propertyStyle);

            property.HeightMapResolution = (HeightMapResolutions)EditorGUILayout.EnumPopup("Height Map Resolution", property.HeightMapResolution);
            property.ControlTextureResolution = (ControlTextureResolution)EditorGUILayout.EnumPopup("Control Texture Resolution", property.ControlTextureResolution);
            property.BaseTextureResolution = (BaseTextureResolution)EditorGUILayout.EnumPopup("Base Texture Resolution", property.BaseTextureResolution);

            EditorGUILayout.EndVertical();
        }

        private void DrawLandscapeProperties(Mountain property)
        {
            EditorGUILayout.BeginVertical(_propertyStyle);

            EditorGUILayout.LabelField("Land Properties", _headerStyle);
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(_propertyStyle);

            property.Frequency = EditorGUILayout.FloatField("Frequency", property.Frequency);
            property.NoiseScale = EditorGUILayout.FloatField("Noise Scale", property.NoiseScale);
            property.Octaves = EditorGUILayout.IntField("Octaves", property.Octaves);
            property.Amplitude = EditorGUILayout.FloatField("Amplitude", property.Amplitude);
            property.Radius = EditorGUILayout.FloatField("Radius", property.Radius);

            EditorGUILayout.EndVertical();



            EditorGUILayout.LabelField("Mountain Properties", _headerStyle);
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(_propertyStyle);

            property.MountainPercentage = EditorGUILayout.IntField("Mountain Percentage", property.MountainPercentage);
            property.MountainRadius = EditorGUILayout.FloatField("Mountain Radius", property.MountainRadius);
            property.MountainHeight = EditorGUILayout.FloatField("Mountain Height", property.MountainHeight);
            property.MountainFrequency = EditorGUILayout.FloatField("Mountain Frequency", property.MountainFrequency);
            property.MountainNoiceScale = EditorGUILayout.FloatField("Mountain NoisceScale", property.MountainNoiceScale);

            EditorGUILayout.EndVertical();



            EditorGUILayout.LabelField("Sloaps Properties", _headerStyle);
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(_propertyStyle);

            property.SloapRadius = EditorGUILayout.FloatField("Sloap Radius", property.SloapRadius);
            property.SloapSize = EditorGUILayout.FloatField("Sloap Size", property.SloapSize);
            property.SloapHeight = EditorGUILayout.FloatField("Sloap Height", property.SloapHeight);

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndVertical();
        }

        private void DrawLandscapeTextures(Mountain property)
        {
            EditorGUILayout.BeginVertical(_propertyStyle);

            SerializedProperty terrainGraphicMode = serializedObject.FindProperty("_terrainLayers");
            EditorGUILayout.PropertyField(terrainGraphicMode, new GUIContent("Landscape Textures"), true);
            serializedObject.ApplyModifiedProperties();

            SerializedProperty terrainMatirialMode = serializedObject.FindProperty("_heightMaterial");
            EditorGUILayout.PropertyField(terrainMatirialMode, new GUIContent("Height Matirial"), true);
            serializedObject.ApplyModifiedProperties();



            EditorGUILayout.EndVertical();
        }

        private void DrawDeveloperOptions(Mountain property)
        {
            EditorGUILayout.BeginVertical(_propertyStyle);

            _developerOptionsFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(_developerOptionsFoldout, "Developer Options");

            if (_developerOptionsFoldout)
            {
                property.ON_RUNTIME_UPDATE = EditorGUILayout.Toggle(new GUIContent("On Runtime Update", "This will update the landscape at runtime"), property.ON_RUNTIME_UPDATE);
                EditorGUILayout.BeginVertical(_propertyStyle);

                if (property.ON_RUNTIME_UPDATE)
                    property.UPDATE_ON_KEY_PRESS = EditorGUILayout.Toggle(new GUIContent("Update On Key Press", "Press [ U ] Key on Key board to Update."), property.UPDATE_ON_KEY_PRESS);

                EditorGUILayout.EndVertical();
                EditorGUILayout.HelpBox("This might put a lot of stress on the PC. Enable it only if the PC has high performance.", MessageType.Warning);



                EditorGUILayout.Space();

                property.DEBUGING = EditorGUILayout.Toggle(new GUIContent("Debugging", ""), property.DEBUGING);
                EditorGUILayout.Space();
                property.ENABLE_GIZMOS = EditorGUILayout.Toggle(new GUIContent("Draw Gizmose", ""), property.ENABLE_GIZMOS);
                EditorGUILayout.Space();
                property.TOPOGRAPHY_MAP = EditorGUILayout.Toggle(new GUIContent("Topography Map", "In a map where the color varies based on height."), property.TOPOGRAPHY_MAP);
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.EndVertical();
        }

        private void DrawDebugData(Mountain property)
        {
            EditorGUILayout.BeginVertical(_propertyStyle, GUILayout.Width(440));

            _debugDataFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(_debugDataFoldout, "Debugging Data");

            if (_debugDataFoldout)
            {
                EditorGUILayout.Space();

                DisplayData("Terrain Center", property.Center);
                DisplayData("Terrain Radius", property.Radius);
                DisplayData("Land Area", property.TotalLandArea);
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.EndVertical();
        }

        private void ApplyGUIChanges()
        {
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(target);
                Repaint();
            }
        }

        private void DisplayData(string name, string value)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(name, _debugStyle);
            EditorGUILayout.LabelField(value, _debugStyle);

            EditorGUILayout.EndHorizontal();
        }

        private void DisplayData(string name, int value)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(name, _debugStyle);
            EditorGUILayout.LabelField(value.ToString(), _debugStyle);

            EditorGUILayout.EndHorizontal();
        }

        private void DisplayData(string name, float value)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(name, _debugStyle);
            EditorGUILayout.LabelField(value.ToString(), _debugStyle);

            EditorGUILayout.EndHorizontal();
        }

        private void DisplayData(string name, Vector2 value)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(name, _debugStyle);
            EditorGUILayout.LabelField(value.ToString(), _debugStyle);

            EditorGUILayout.EndHorizontal();
        }
    }
}
