﻿using UnityEngine;

namespace Assets.Scripts.Helpers
{
	public struct InfoBulletCollision
	{
		private readonly float _damage;
		private readonly Vector3 _dir;

		public InfoBulletCollision(float damage, Vector3 dir)
		{
			_damage = damage;
			_dir = dir;
		}

		public float Damage
		{
			get
			{
				return _damage;
			}
		}

		public Vector3 Dir
		{
			get
			{
				return _dir;
			}
		}
	}
}