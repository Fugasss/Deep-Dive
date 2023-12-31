using UnityEngine;
using UnityEditor;

///<summary>
///Usage: [ShowAsVector2] _Vector("Vector",Vector) = (0,0,0,0)
///</summary>
public class ShowAsVector2Drawer : MaterialPropertyDrawer
{
    public override void OnGUI(Rect position, MaterialProperty prop, GUIContent label, MaterialEditor editor)
    {
        if (prop.type != MaterialProperty.PropType.Vector)
        {
            editor.DefaultShaderProperty(prop, label.text);
            return;
        }

        EditorGUIUtility.labelWidth = 0f;
        EditorGUIUtility.fieldWidth = 0f;

        if (!EditorGUIUtility.wideMode)
        {
            EditorGUIUtility.wideMode = true;
            EditorGUIUtility.labelWidth = EditorGUIUtility.currentViewWidth - 212;
        }

        EditorGUI.BeginChangeCheck();
        EditorGUI.showMixedValue = prop.hasMixedValue;
        Vector4 vec = EditorGUI.Vector2Field(position, label, prop.vectorValue);

        if (EditorGUI.EndChangeCheck())
        {
            prop.vectorValue = vec;
        }
    }
}