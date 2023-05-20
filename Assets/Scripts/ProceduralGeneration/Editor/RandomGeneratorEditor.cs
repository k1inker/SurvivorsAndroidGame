using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbstractGenerator),true)]
public class RandomGeneratorEditor : Editor
{
    private AbstractGenerator _generator;
    private void Awake()
    {
        _generator = (AbstractGenerator)target;
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
