using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SymbolLoader))]
public class SymbolLoaderEditor : Editor
{
    private SymbolLoader _ref;
    private void OnEnable()
    {
        if(!_ref) _ref = (SymbolLoader)target;
    }

    public override void OnInspectorGUI()
    {
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Editor Script", MonoScript.FromScriptableObject(this), typeof(SymbolLoader), false);
        GUI.enabled = true;
        base.OnInspectorGUI();
        if(GUILayout.Button("Test Button"))
        {
            _ref.LoadSymbolsAndNumbers();
        }
    }
}