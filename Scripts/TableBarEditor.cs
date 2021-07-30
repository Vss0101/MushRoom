#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 导航栏组件的面板类。
/// </summary>
[CustomEditor(typeof(TableBar))]
public class TableBarEditor : Editor
{
    #region 成员变量
    private TableBar tableBar;
    private bool showSwitch = true;
    #endregion

    #region 序列化变量
    private SerializedProperty sizeSerialize;
    private SerializedProperty defaultIndexSerialize;
    #endregion

    #region 私有方法
    /// <summary>
    /// 当脚本生效时触发。
    /// </summary>
    private void OnEnable()
    {
        // 获取对象
        tableBar = (TableBar)target;
        // 保存数据
        sizeSerialize = serializedObject.FindProperty("Size");
        defaultIndexSerialize = serializedObject.FindProperty("Default Index");
    }

    /// <summary>
    /// 当面板绘制时触发。
    /// </summary>
    public override void OnInspectorGUI()
    {
        // 垂直布局
        EditorGUILayout.BeginVertical();
        BaseGUI();
        EditorGUILayout.EndVertical();
        // 保存数据
        serializedObject.ApplyModifiedProperties();
        // 当面板修改后触发
        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }

    /// <summary>
    /// 基础属性。
    /// </summary>
    private void BaseGUI()
    {
        tableBar.size = EditorGUILayout.IntField("Size", tableBar.size);
        showSwitch = EditorGUILayout.Foldout(showSwitch, "Switch Elements");
        if (showSwitch)
        {
            for (int i = 0; i < tableBar.size; i++)
            {
                tableBar.buttons[i] = (Button)EditorGUILayout.ObjectField("Button " + i, tableBar.buttons[i], typeof(Button), true);
                tableBar.panels[i] = (GameObject)EditorGUILayout.ObjectField("Panel " + i, tableBar.panels[i], typeof(GameObject), true);
                EditorGUILayout.Space();
            }
        }
        tableBar.defaultIndex = EditorGUILayout.IntField("Default Index", tableBar.defaultIndex);
    }
    #endregion
}
#endif

