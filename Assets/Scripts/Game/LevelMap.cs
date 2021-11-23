using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class LevelMap : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        [SerializeField] private Transform _root;

        [SerializeField] private List<Vector3> _points;

        public Transform Root => _root;

        public IReadOnlyList<Vector3> Points => _points;

        [ContextMenu("Instantiate objects")]
        private void InstantiatePoints()
        {
            Clear();
            foreach (var p in _points.Distinct())
            {
                var prefab = PrefabUtility.InstantiatePrefab(_prefab, _root) as GameObject;
                prefab.transform.position = p;
            }
        }


        [ContextMenu("Clear objects")]
        private void Clear()
        {
            var count = _root.childCount;
            for (var i = count - 1; i >= 0; i--)
            {
                DestroyImmediate(_root.GetChild(i).gameObject);
            }
        }

       

        public void ClearAndInitPoints(List<Vector3> pointsList)
        {
            _points = new List<Vector3>();
            for (int i = 0; i < pointsList.Count; i++)
            {
                var p= pointsList[i];
                _points.Add(new Vector3((int)p.x,(int)p.y,(int)p.z));
            }

        }
        
    }
}