using UnityEngine;

namespace PerformanceTest
{
    public class ArrayObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _countX;
        [SerializeField] private int _countY;
        [SerializeField] private int _countZ;
        [SerializeField] private float _spacing;
        [SerializeField] private bool _centered;

        public void Recreate()
        {
            Transform[] children = transform.GetComponentsInChildren<Transform>();
            foreach (Transform child in children)
            {
                if (child != transform) DestroyImmediate(child.gameObject);
            }

            for (var x = 0; x < _countX; x++)
            {
                for (var y = 0; y < _countY; y++)
                {
                    for (var z = 0; z < _countZ; z++)
                    {
                        var position = new Vector3(x * _spacing, y * _spacing, z * _spacing);
                        if (_centered) position -= new Vector3(_countX - 1, _countY - 1, _countZ - 1) * _spacing / 2f;
#if UNITY_EDITOR
                        var instance = (GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(_prefab, transform);
                        instance.transform.position = position;
                        instance.name = $"{_prefab.name}_({x}|{y}|{z})";
#endif
                    }
                }
            }
        }
    }
}