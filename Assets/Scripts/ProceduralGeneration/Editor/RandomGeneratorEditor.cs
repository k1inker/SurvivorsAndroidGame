using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WorldGenerator),true)]
public class RandomGeneratorEditor : Editor
{
    private WorldGenerator _generator;
    private void Awake()
    {
        _generator = (WorldGenerator)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Map"))
        {
            _generator.GenerateMap();
        }
    }
}
