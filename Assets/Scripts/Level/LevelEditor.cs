using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class LevelEditor : MonoBehaviour
{
    [SerializeField] private LevelConfig levelConfig;

    [ContextMenu("Save")]
    public void Save()
    {
        
        if (levelConfig == null)
        {
            levelConfig = ScriptableObject.CreateInstance<LevelConfig>();
            AssetDatabase.CreateAsset(levelConfig,
                $"Assets/Resources/Levels/{SceneManager.GetActiveScene().name}.asset");
        }

        levelConfig.Objects = new LevelConfig.PrefabData[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            var obj = transform.GetChild(i);
            levelConfig.Objects[i] = new LevelConfig.PrefabData()
            {
                Prefab = PrefabUtility.GetCorrespondingObjectFromSource(obj.gameObject),
                Position = new Vector3(obj.position.x, obj.position.y, obj.position.z),
                Rotation = obj.rotation.eulerAngles.y
                
            };
        }

        EditorUtility.SetDirty(levelConfig);
        AssetDatabase.SaveAssets();
    }
}