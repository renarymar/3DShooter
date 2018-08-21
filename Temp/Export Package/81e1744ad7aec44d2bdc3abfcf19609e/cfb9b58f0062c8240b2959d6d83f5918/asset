using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets
{
	public class LineRendererTest : MonoBehaviour
	{
		public Color c1 = Color.yellow;
		public Color c2 = Color.red;
		public int lengthOfLineRenderer = 20;
		private LineRenderer lineRenderer;
		void Start()
		{
			var  temp = new GameObject("LineRenderer");
			lineRenderer = temp.AddComponent<LineRenderer>();
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			lineRenderer.startColor=  c1;
			lineRenderer.endColor = c2;
			lineRenderer.startWidth = 0.2F;
			lineRenderer.endWidth = 0.2F;
			lineRenderer.positionCount = (lengthOfLineRenderer);
		}
		void Update()
		{
			Vector3[] points = new Vector3[lengthOfLineRenderer];
			float t = Time.time;
			int i = 0;
			while (i < lengthOfLineRenderer)
			{
				points[i] = new Vector3(i * 0.5F, Mathf.Sin(i + t), 0);
				i++;
			}
			lineRenderer.SetPositions(points);
		}
	}
}