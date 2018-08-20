using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	public class MovePoint : MonoBehaviour
	{
		public GameObject Player;
		public Transform Point;
		private Queue<Transform> _points = new Queue<Transform>();
		private Transform _root;
		private LineRenderer _lineRenderer;
		void Start()
		{
			var temp = new GameObject("LineRenderer");
			_lineRenderer = temp.AddComponent<LineRenderer>();
			_lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			_lineRenderer.startColor = _lineRenderer.endColor = Color.green;
			_lineRenderer.startWidth  = _lineRenderer.endWidth = 0.2F;
			_lineRenderer.positionCount = 2;
			_root = new GameObject().transform;
			_lineRenderer.SetPosition(0, Player.transform.position);
		}

		private void Update()
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
			{
				if (Input.GetMouseButtonDown(0))
				{
					DrawPoint(hit.point);
				}
				_lineRenderer.SetPosition(1, hit.point);
			}
		}

		private void DrawPoint(Vector3 pos)
		{
			var tempPoint = Instantiate(Point, pos, Quaternion.identity, _root);
			_points.Enqueue(tempPoint);
			_lineRenderer.SetPosition(0, tempPoint.position);
		}
	}
}