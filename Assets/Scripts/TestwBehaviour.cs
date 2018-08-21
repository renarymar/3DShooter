using UnityEngine;

namespace Geekbrains
{
	public class TestwBehaviour : MonoBehaviour
	{
		[SerializeField] private int _count = 1;
		[SerializeField] private int _offset = 1;
		[SerializeField] private GameObject _obj;
		private Transform _root;

		private void Start()
		{
			CreateObj();
		}

		public void CreateObj()
		{
			_root = new GameObject("Root").transform;
			for (var i = 1; i <= _count; i++)
			{
				Instantiate(_obj, new Vector3(0, _offset * i, 0),
					Quaternion.identity, _root);
			}
		}
	}
}