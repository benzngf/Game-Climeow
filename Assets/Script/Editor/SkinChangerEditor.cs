using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SkinChanger))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        SkinChanger myScript = (SkinChanger)target;
        if(GUILayout.Button("Change Skin"))
        {
            myScript.RefreshSkin();
        }
    }
}
