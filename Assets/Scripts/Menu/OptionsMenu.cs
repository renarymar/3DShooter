﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Menu
{

    public class OptionsMenu : BaseMenu
    {
        enum OptionsMenuItems
        {
            Video,
            Sound,
            Game,
            Back
        }
        private void CreateMenu(string[] menuItems)
        {
            _elementsOfInterface = new IControl[menuItems.Length];
            for (var index = 0; index < menuItems.Length; index++)
            {
                switch (index)
                {
                    case (int)OptionsMenuItems.Video:
                        {
                            var tempControl =
                            CreateControl(Interface.InterfaceResources.ButtonPrefab,
                                LangManager.Instance.Text("OptionsMenuItems", "Video"));
                            tempControl.GetControl.onClick.AddListener(LoadVideoOptions);
                            _elementsOfInterface[index] = tempControl;
                            break;
                        }
                    case (int)OptionsMenuItems.Sound:
                        {
                            var tempControl =
                            CreateControl(Interface.InterfaceResources.ButtonPrefab,
                                LangManager.Instance.Text("OptionsMenuItems", "Sound"));
                            tempControl.GetControl.onClick.AddListener(LoadSoundOptions);
                            _elementsOfInterface[index] = tempControl;
                            break;
                        }
                    case (int)OptionsMenuItems.Game:
                        {
                            var tempControl =
                            CreateControl(Interface.InterfaceResources.ButtonPrefab,
                                LangManager.Instance.Text("OptionsMenuItems", "Game"));
                            tempControl.GetControl.onClick.AddListener(LoadGameOptions);
                            _elementsOfInterface[index] = tempControl;
                            break;
                        }
                    case (int)OptionsMenuItems.Back:
                        {
                            var tempControl =
                            CreateControl(Interface.InterfaceResources.ButtonPrefab,
                                LangManager.Instance.Text("OptionsMenuItems", "Back"));
                            tempControl.GetControl.onClick.AddListener(Back);
                            _elementsOfInterface[index] = tempControl;
                            break;
                        }
                }
            }
            if (_elementsOfInterface.Length < 0) return;
            _elementsOfInterface[0].Control.Select();
            _elementsOfInterface[0].Control.OnSelect(new
            BaseEventData(EventSystem.current));
        }
        private void LoadVideoOptions()
        {
            Interface.Execute(InterfaceObject.VideoOptions);

        }
        private void LoadSoundOptions()
        {
            Interface.Execute(InterfaceObject.AudioOptions);
        }
        private void LoadGameOptions()
        {
            Interface.Execute(InterfaceObject.GameOptions);
        }
        private void Back()
        {
            Interface.Execute(InterfaceObject.MainMenu);
        }
        public override void Hide()
        {
            if (!IsShow) return;
            Clear(_elementsOfInterface);
            IsShow = false;
        }
        public override void Show()
        {
            if (IsShow) return;
            var tempMenuItems = System.Enum.GetNames(typeof(OptionsMenuItems));
            CreateMenu(tempMenuItems);
            IsShow = true;
        }
    }
}