using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class CreateInterface : MonoBehaviour
    {

        #region Editor
        public void CreateMainMenu()
        {
            CreateComponent();
            gameObject.AddComponent<MainMenu>();
            gameObject.AddComponent<OptionsMenu>();
            Clear();
        }

        public void CreateGameMenu()
        {
            CreateComponent();
            Clear();
        }

        private void Clear()
        {
            DestroyImmediate(this);
        }

        private void CreateComponent()
        {
            gameObject.AddComponent<Interface>();
            gameObject.AddComponent<InterfaceResources>();
        }
        #endregion
    }
}