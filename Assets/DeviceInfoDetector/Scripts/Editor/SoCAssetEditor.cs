using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Soc_cpuMap))]
public class SoCAssetEditor : Editor
{
    private Soc_cpuMap asset;

    private void OnEnable()
    {
        asset = target as Soc_cpuMap;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("LoadConfig"))
        {
            LoadConfig();
        }
        base.OnInspectorGUI();
    }

    private void LoadConfig()
    {
        var file = EditorUtility.OpenFilePanel("数据导入", Application.dataPath, "txt");
        if (string.IsNullOrEmpty(file))
            return;
        var lines = File.ReadAllLines(file);
        asset.soc_list.Clear();
        foreach (var line in lines)
        {
            asset.soc_list.Add(line);
        }

        EditorUtility.SetDirty(asset);
        AssetDatabase.SaveAssets();
    }
}