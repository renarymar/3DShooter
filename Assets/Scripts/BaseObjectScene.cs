using UnityEngine;
using Assets.Scripts.Helpers;

namespace Geekbrains
{
	public abstract class BaseObjectScene : MonoBehaviour
	{
		private int _layer;
		private Color _color;
        private bool _isVisible;
        public BulletProjector BulletProjector;
        [HideInInspector] public Rigidbody Rigidbody;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            //Rigidbody = Rigidbody.GetOrAddComponent<Rigidbody>();

        }


        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name
        {
            get { return gameObject.name; }
            set
            {
                gameObject.name = value;
            }
        }

        /// <summary>
        /// Слой объекта.
        /// </summary>
        public int Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
                AskLayer(transform, value);
            }
        }

        /// <summary>
        /// Цвет материала объекта.
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                AskColor(transform, _color);
            }
        }


        /// <summary>
        /// Выключение рендеринга объекта
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                var tempRenderer = GetComponent<Renderer>();
                if (tempRenderer)
                    tempRenderer.enabled = _isVisible;
                if (transform.childCount <= 0) return;
                foreach(Transform d in transform)
                {
                    tempRenderer = d.gameObject.GetComponent<Renderer>();
                    if (tempRenderer)
                        tempRenderer.enabled = _isVisible;
                }
            }
        }

        public void CreateDecal(ContactPoint contact)
        {
            var projectorRotation = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
            if (BulletProjector == null) return;
            var obj = Instantiate(BulletProjector, contact.point + contact.normal * 0.15f, projectorRotation, transform); // контроль за популяцией
            obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, Random.Range(0, 360));
        }

        /// <summary>
        /// Выставляет слой себе и всем вложенным объектам, вне зависимости от уровня вложения
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <param name="layerNumber">Слой.</param>
        private void AskLayer(Transform obj, int layerNumber)
        {
            obj.gameObject.layer = layerNumber;
            if (obj.childCount <= 0) return;
            foreach (Transform d in obj)
                AskLayer(d, layerNumber);
        }

        /// <summary>
        /// Выставляет цвет себе и всем вложенным объектам, вне зависимости от уровня вложения
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <param name="color">Цвет.</param>
        private void AskColor(Transform obj, Color color)
        {
            foreach(var currentMaterial in obj.GetComponent<Renderer>().materials)
            {
                currentMaterial.color = color;
            }

            if (obj.childCount <= 0) return;
            foreach(Transform d in obj)
            {
                AskColor(d, color);
            }
        }


        public bool IsRigidBody()
        {
            return Rigidbody;
        }


        /// <summary>
        /// Выключает физику у объекта и его детей.
        /// </summary>
        public void DisableRigidBody()
        {
            if (!IsRigidBody()) return;

            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach(var rb in rigidbodies)
            {
                rb.isKinematic = true;
            }
        }

        /// <summary>
        /// Включает физику у объекта и его детей.
        /// </summary>
        /// <param name="force">Ускорение.</param>
        public void EnableRigidbody(float force)
        {
            EnableRigidbody();
            Rigidbody.AddForce(transform.forward * force);
        }

        /// <summary>
        /// Включает физику у объекта и его детей.
        /// </summary>
        public void EnableRigidbody()
        {
            if (!IsRigidBody()) return;
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
        }

        /// <summary>
        /// Замораживает или размораживает физическую трансформацию объекта
        /// </summary>
        /// <param name="rigidbodyConstraints">Трансформация, которую нужно заморозить.</param>
        public void ConstraintsRigidBody(RigidbodyConstraints rigidbodyConstraints)
        {
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach(var rb in rigidbodies)
            {
                rb.constraints = rigidbodyConstraints;
            }
        }


        public void SetActive(bool value)
        {
            IsVisible = value;

            var tempColider = GetComponent<Collider>();
            if(tempColider)
            {
                tempColider.enabled = value;
            }
        }
	}
}
