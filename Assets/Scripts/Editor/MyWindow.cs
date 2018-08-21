﻿using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;
namespace Geekbrains.Editor
{
	public class MyWindow : EditorWindow
	{
		public static GameObject ObjectInstantiate;
		public string _nameObject = "Object_";
		public bool _groupEnabled;

        [SerializeField] private int _distance;
        [SerializeField] private int _countObject;

        [MenuItem("Geekbrains/Add new object/Mine")]
        [MenuItem("Geekbrains/Add new object/First Aid")]

        public static void ShowWindow()
        {
            // Отобразить существующий экземпляр окна. Если его нет, создаем
            EditorWindow.GetWindow(typeof(MyWindow));
        }

		private void OnGUI()
		{
			GUILayout.Label("Basic Settings", EditorStyles.boldLabel);
			ObjectInstantiate = EditorGUILayout.ObjectField("Object prefab",
		                                                    ObjectInstantiate, 
                                                            typeof(GameObject), 
                                                            true) as GameObject;
            
			_nameObject = EditorGUILayout.TextField("Object_", _nameObject);
            _distance = EditorGUILayout.IntSlider("Distance", _distance, 1, 20);
			_groupEnabled = EditorGUILayout.BeginToggleGroup("Advanced Settings", _groupEnabled);
            _countObject = EditorGUILayout.IntSlider("Amount", _countObject, 1, 20);

			EditorGUILayout.EndToggleGroup();
			if (GUILayout.Button("Add objects"))
			{
				if (ObjectInstantiate)
				{
					GameObject root = new GameObject("New Game Object");
					for (int i = 0; i < _countObject; i++)
					{
                        Vector3 pos = new Vector3(Random.Range(-_distance, _distance), 0, Random.Range(-_distance, _distance));
						GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
						temp.name = _nameObject + "(" + i + ")";
						temp.transform.parent = root.transform;
					}
				}
			}
		}
	}
}