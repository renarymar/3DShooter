using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Geekbrains.AI
{
	public class Patrol
	{
		private Vector3[] _listPoint;
		private int _indexCurPoint;
        private bool assignFirstPoint = true;

		public Patrol()
		{
            var tempPoints = Object.FindObjectsOfType<WayPoint>();
			_listPoint = tempPoints.Select(o => o.transform.position).ToArray();
		}

        public Vector3 GenericPoint(NavMeshAgent agent, bool isRandom = false)
		{
            if (agent == null) return Vector3.zero;
            Vector3 resultPoint;

            if ((isRandom) || (assignFirstPoint))
            {
                assignFirstPoint = false;
                _indexCurPoint = Random.Range(0, _listPoint.Length);
            }
			else
			{
                if (_indexCurPoint < _listPoint.Length - 1)
				{
					_indexCurPoint++;
				}
				else
				{
                    _indexCurPoint = 0;
				}
				resultPoint = _listPoint[_indexCurPoint];
			}
			agent.stoppingDistance = 0;
            return _listPoint[_indexCurPoint];

		}
	}
}