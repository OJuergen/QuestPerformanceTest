using UnityEditor;
using UnityEngine;

namespace PerformanceTest
{
    [CustomEditor(typeof(ArrayObjectSpawner))]
    public class ArrayObjectSpawnerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Recreate"))
            {
                ((ArrayObjectSpawner)target).Recreate();
            }
        }
    }
}