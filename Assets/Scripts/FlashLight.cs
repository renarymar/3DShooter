using UnityEngine;

namespace Geekbrains
{
	public class FlashLight : MonoBehaviour
	{
		private Light _light;
        private Transform _goFollow;
        private Vector3 _vectorOffset;
        private float _speed = 5;

		private void Awake()
		{
			_light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vectorOffset = transform.position - _goFollow.position;
		}

      
        public Light Light
		{
			get { return _light; }
		}

		public void Switch(bool value)
		{
			_light.enabled = value;
            transform.position = _goFollow.position + _vectorOffset;
            transform.rotation = _goFollow.rotation;
		}

		public void Rotation()
        {
            transform.position = _goFollow.position + _vectorOffset;
            transform.rotation = Quaternion.Slerp(transform.rotation, _goFollow.rotation, _speed * Time.deltaTime);
		}
	}
}