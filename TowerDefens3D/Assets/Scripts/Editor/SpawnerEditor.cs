using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

//[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
////    private Spawner _spawner;

////    public void OnEnable()
////    {
////        _spawner = (Spawner)target;
////    }

////    public override void OnInspectorGUI()
////    {
////        // _spawner.TimeStep = EditorGUILayout.IntField("Spawn Duration", _spawner.TimeStep, "box");

////        if (_spawner.Spawners.Count > 0)
////        {
////            for (int i = 0; i < _spawner.Spawners.Count; i++)
////            {
////                var spawner = _spawner.Spawners[i];

////                EditorGUILayout.BeginHorizontal("box");

////                if (GUILayout.Button("X", GUILayout.Width(15), GUILayout.Height(15))) _spawner.Spawners.Remove(spawner);

////                EditorGUILayout.EndHorizontal();


////                EditorGUILayout.BeginVertical("box");

////                spawner = (SpawnerBase)EditorGUILayout.ObjectField("Spawner", (Object)spawner, typeof(SpawnerBase), false);

////                EditorGUILayout.EndVertical();

////            }
////        }
////        else GUILayout.Label("Null elements");


////        if (GUILayout.Button("Add new spawner")) _spawner.Spawners.Add(new CountedSpawner());
////    }

////    public static void SetObjectDirty(GameObject obj)
////    {
////        EditorUtility.SetDirty(obj);
////        EditorSceneManager.MarkSceneDirty(obj.scene);
////    }
}
