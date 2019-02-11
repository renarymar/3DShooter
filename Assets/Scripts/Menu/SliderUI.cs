using UnityEngine;
using UnityEngine.UI;
using Geekbrains;


namespace Assets.Scripts.Menu
{

    public class SliderUI : MonoBehaviour, IControl
    {
        private Text _text;
        private Slider _control;

        private void Awake()
        {
            _control = transform.GetComponentInChildren<Slider>();
            _text = transform.GetComponentInChildren<Text>();
        }

        public Text GetText => _text;
        public Slider GetControl => _control;

        public void Interactable(bool value)
        {
            GetControl.interactable = value;
        }

        public GameObject Instance => gameObject;
        public Selectable Control => GetControl;
    }
}