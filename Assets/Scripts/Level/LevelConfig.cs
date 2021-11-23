using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelConfig : ScriptableObject
{
    [Serializable]
    public struct PrefabData
    {
        public GameObject Prefab;
        public Vector3 Position;
        public float Rotation;

    }
    
    public PrefabData[] Objects;


}
