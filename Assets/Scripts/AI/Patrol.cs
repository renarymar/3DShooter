﻿using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Geekbrains.AI
{
	public class Patrol
	{
		private Vector3[] _listPoint;
		private int _indexCurPoint;
        private int _minDistance = 25;
        private int _maxDistance = 150;

		public Patrol()
		{
            var tempPoints = Object.FindObjectsOfType<WayPoint>();
			_listPoint = tempPoints.Select(o => o.transform.position).ToArray();
		}
        public Vector3 GenericPoint(NavMeshAgent agent, bool isRandom = true)
		{
            if (agent == null) return Vector3.zero;

            Vector3 resultPoint;
			if (isRandom)
			{
				var distance = Random.Range(_minDistance, _maxDistance);
				Vector3 randomPoint = Random.insideUnitCircle * distance;
				NavMeshHit hit;
				NavMesh.SamplePosition(agent.transform.position + randomPoint, out hit, distance, NavMesh.AllAreas);
				resultPoint = hit.position;
			}
			else
			{
				if (_indexCurPoint < _listPoint.Length - 1) // свое перемещение
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
            return resultPoint;

		}
	}
}