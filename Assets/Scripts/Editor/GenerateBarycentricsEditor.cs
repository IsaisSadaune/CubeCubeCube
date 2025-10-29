using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenerateBarycentrics))]
public class GenerateBarycentricsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GenerateBarycentrics gen = (GenerateBarycentrics)target;

        GUILayout.Space(10);
        GUIStyle style = new GUIStyle(GUI.skin.button);
        style.fontSize = 14;
        style.fixedHeight = 35;

        if (GUILayout.Button("🧮 Generate Barycentrics", style))
        {
            gen.ApplyBarycentrics();
        }
    }
}