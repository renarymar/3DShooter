using UnityEditor;
using UnityEngine;

namespace Geekbrains.Editor
{
    [CustomEditor(typeof(TestwBehaviour))]
	public class TestwBehaviourEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

            var temp = (TestwBehaviour) target;

			var isPressButton = GUILayout.Button("Create Obj", EditorStyles.miniButtonMid);

			if (isPressButton)
			{
				temp.CreateObj();
				//DestroyImmediate(this);
			}

			EditorGUILayout.HelpBox("Hi!", MessageType.Info);
		}
	}
}