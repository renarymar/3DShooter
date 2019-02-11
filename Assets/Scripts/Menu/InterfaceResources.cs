using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class InterfaceResources : MonoBehaviour
    {

        public ButtonUi ButtonPrefab { get; private set; }
        public Canvas MainCanvas { get; private set; }
        public LayoutGroup MainPanel { get; private set; }
        public SliderUI ProgressBarPrefab { get; private set; }

        private void Awake()
        {
            ButtonPrefab = Resources.Load<ButtonUi>("Button");
            MainCanvas = FindObjectOfType<Canvas>();
            ProgressBarPrefab = Resources.Load<SliderUI>("ProgressBar");
            MainPanel = MainCanvas.GetComponentInChildren<LayoutGroup>();
        }
    }
}
