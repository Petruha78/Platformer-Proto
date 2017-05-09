using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Knight))]
[CanEditMultipleObjects]
public class KnightEditor : Editor
{

    SerializedProperty currentHealth;
    SerializedProperty pos;

    void OnEnable()
    {
        currentHealth = serializedObject.FindProperty("currentHealth");
        pos = serializedObject.FindProperty("pos");
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(currentHealth);
        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.IntSlider(currentHealth, 0, 100, new GUIContent("Health"));
        if (!currentHealth.hasMultipleDifferentValues)
            ProgressBar(currentHealth.intValue / 100.0f, "Health");
    }

    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18,18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }

    public void OnSceneGUI()
    {
        
        var knight = ((Knight)target);
        EditorGUI.BeginChangeCheck();
        Vector3 pos = Handles.PositionHandle(knight.Pos, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            
            Undo.RecordObject(target, "Hits");
            knight.Pos = pos;
            knight.Update();
            Debug.Log(pos);
            
        }
        
    }

}
