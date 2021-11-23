using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelConfig startLevel;
    [SerializeField] private LevelMap levelMap;
    private LevelConfig level;

    private void Start()
    {
        if (startLevel != null)
        {
            InitLevel(startLevel);
        }
    }

    private void InitLevel(LevelConfig levelConfig)
    {
        level = levelConfig;
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < level.Objects.Length; i++)
        {
            var o = level.Objects[i];
            var go=Instantiate(o.Prefab, o.Position, Quaternion.Euler(0, o.Rotation, 0));
            go.transform.SetParent(levelMap.Root);
            points.Add(o.Position);
        }
        
        levelMap.ClearAndInitPoints(points);
        
        
    }
}