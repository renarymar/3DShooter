﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class Interface : MonoBehaviour
    {
        public InterfaceResources InterfaceResources { get; private set; }

        private SliderUI _progressBar;
        private BaseMenu _currentMenu;

        private Stack<InterfaceObject> _interfaceObject = new Stack<InterfaceObject>();

        #region Object
        private MainMenu _mainMenu;
        private OptionsMenu _optionsMenu;
        //private VideoOptions _videoOptions;
        //private GameOption _gameOptions;
        //private AudioOptions _audioOptions;
        //private MenuPause _menuPause;
        //private OptionsPauseMenu _optionsPauseMenu;
        #endregion


        private void Start()
        {
            InterfaceResources = GetComponent<InterfaceResources>();
            _mainMenu = GetComponent<MainMenu>();
            _optionsMenu = GetComponent<OptionsMenu>();

            //_videoOptions = GetComponent<VideoOptions>();
            //_gameOptions = GetComponent<GameOptions>();
            //_audioOptions = GetComponent<AudioOptions>();
            //_menuPause = GetComponent<MenuPause();
            //_optionsPauseMenu = GetComponent<OptionsPauseMenu>();

            if (_mainMenu)
            {
                Execute(InterfaceObject.MainMenu);
            }
        }


        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
 Application.Quit ();
#endif
        }

        public void Execute(InterfaceObject menuItem) //добавить отмену
        {
            if (_currentMenu != null) _currentMenu.Hide();
            switch (menuItem)
            {
                case InterfaceObject.MainMenu:
                    _currentMenu = _mainMenu;
                    break;
                case InterfaceObject.OptionsMenu:
                    _currentMenu = _optionsMenu;
                    break;
                /*case InterfaceObject.VideoOptions:
                    if (_currentMenu != null) _currentMenu.Hide();
                    _currentMenu = _videoOptions;
                    _currentMenu.Show();
                    break;
                case InterfaceObject.GameOptions:
                    if (_currentMenu != null) _currentMenu.Hide();
                    _currentMenu = _gameOptions;
                    _currentMenu.Show();
                    break;
                case InterfaceObject.AudioOptions:
                    if (_currentMenu != null) _currentMenu.Hide();
                    _currentMenu = _audioOptions;
                    _currentMenu.Show();
                    break;
                case InterfaceObject.MenuPause:
                    if (_currentMenu != null) _currentMenu.Hide();
                    _currentMenu = _menuPause;
                    _currentMenu.Show();
                    break;
                case InterfaceObject.OptionsPauseMenu:
                    if (_currentMenu != null) _currentMenu.Hide();
                    _currentMenu = _optionsPauseMenu;
                    _currentMenu.Show();
                    break;*/
                default:
                    break;

            }

            if (_currentMenu != null)
            {
                _currentMenu.Show();
                _interfaceObject.Push(menuItem);
            }
        }

        #region ProgressBar
        public void ProgressBarSetValue(float value)
        {
            if (_progressBar == null) return;
            _progressBar.GetControl.value = value;
            _progressBar.GetText.text = $"{Math.Truncate(value * 100)}%";
        }

        public void ProgressBarEnabled()
        {
            if (_progressBar) return;
            _progressBar = Instantiate(InterfaceResources.ProgressBarPrefab, InterfaceResources.MainCanvas.transform);
            ProgressBarSetValue(0);
        }

        public void ProgressBarDisaled()
        {
            if (!_progressBar) return;
            Destroy(_progressBar.Instance);
        }
        #endregion

        #region LoadScene
        public void LoadSceneAsync(int lvl)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(lvl);
            StartCoroutine(LoadSceneAsync(async));
        }

        public void LoadSceneAsync(Scene lvl)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(lvl.buildIndex);
            StartCoroutine(LoadSceneAsync(async));
        }

        public void LoadSceneAsync(string lvl)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(lvl);
            StartCoroutine(LoadSceneAsync(async));
        }

        private IEnumerator LoadSceneAsync(AsyncOperation async)
        {
            //ProgressBarEnabled();
            async.allowSceneActivation = false;
            while (!async.isDone)
            {
                //ProgressBarSetValue(async.progress + 0.1f);
                float progress = async.progress * 100f;
                if (async.progress < 0.9f && Mathf.RoundToInt(progress) != 100)
                {
                    async.allowSceneActivation = false;
                }
                else
                {
                    if (async.allowSceneActivation) yield return null;
                    async.allowSceneActivation = true;
                    //ProgressBarDisable();
                }
                yield return null;
            }
        }
        #endregion
    }

}