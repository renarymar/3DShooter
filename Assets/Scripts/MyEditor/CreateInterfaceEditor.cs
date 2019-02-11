﻿using UnityEditor;
using UnityEngine;
using Assets.Scripts.Menu;

namespace Assets.Scripts.MyEditor
{
    [CustomEditor(typeof(CreateInterface))]
    public class CreateInterfaceEditor : Editor
    {
        private static CreateInterface _interface;
        private static bool _isPressButtonMainMenu;
        private static bool _isPressButtonMenuPause;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var interfaceTarget = (CreateInterface)target;
            if (EditorApplication.isPlaying) return;
            _isPressButtonMainMenu = GUILayout.Button("Создать Главное Меню",
            EditorStyles.miniButton);
            _isPressButtonMenuPause = GUILayout.Button("Создать Меню Паузы",
            EditorStyles.miniButton);
            if (_isPressButtonMainMenu)
            {
                interfaceTarget.CreateMainMenu();
            }
            if (_isPressButtonMenuPause)
            {
                interfaceTarget.CreateGameMenu();
            }
        }
    }
}