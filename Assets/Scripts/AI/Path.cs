using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.AI
{
	public class Path : MonoBehaviour
	{
        [SerializeField]
        [ColorUsage(false)] 
        private Color _lineColor;
		
        private List<Transform> _nodes = new List<Transform>();

        int counter = 0;
		void OnDrawGizmos()
		{
            Gizmos.color = _lineColor;
			var pathTransforms = GetComponentsInChildren<Transform>();
			_nodes = new List<Transform>();
			foreach (var t in pathTransforms)
			{
                if (t != this.transform)
				{
					_nodes.Add(t);
                    counter++;
				}
			}
			for (int i = 0; i < _nodes.Count; i++)
			{
				var currentNode = _nodes[i].position;
				var previousNode = Vector3.zero;
				if (i > 0)
				{
					previousNode = _nodes[i - 1].position;
				}
				else if (i == 0 && _nodes.Count > 1)
				{
					previousNode = _nodes[_nodes.Count - 1].position;
				}
				Gizmos.DrawLine(previousNode, currentNode);
				Gizmos.DrawWireSphere(currentNode, 0.3f);
			}
		}
	}
}