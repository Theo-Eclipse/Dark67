using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SymbolTable))]
public class SymbolTableEditor : Editor
{
    private SymbolTable _ref;
    private void OnEnable()
    {
        if(!_ref) _ref = (SymbolTable)target;
    }

    public override void OnInspectorGUI()
    {
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Editor Script", MonoScript.FromScriptableObject(this), typeof(SymbolTable), false);
        GUI.enabled = true;
        base.OnInspectorGUI();
        if(GUILayout.Button("Test Button"))
        {
            _ref.LoadSymbolsAndNumbers();
        }
    }
}