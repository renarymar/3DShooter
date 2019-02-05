using UnityEngine;
using UnityEngine.AI;
using Assets.Scripts.Helpers;

namespace Geekbrains.AI
{
	public class Bot : BaseObjectScene, ISetDamage
	{
        [SerializeField] [Range(0, 100)] private float Hp;
        [SerializeField] private float PatrolTimeDelay;
        [SerializeField] private float TargetTimeOut;

        private bool _isDeath;
        private bool _isTarget;

		private float _curTime;
        private float _hitTime;

		public Vision Vision;

        private NavMeshAgent _agent;
        private Patrol _patrol;
		private Transform _target;
		private Weapon _weapon;

		private void Start()
		{
			_agent = GetComponent<NavMeshAgent>();
			_patrol = new Patrol();
			_target = FindObjectOfType<CharacterController>().transform;
			_weapon = GetComponentInChildren<Weapon>();

            GetComponent<Animator>().Play("move_forward");
		}

		private void Update()
		{
			if(_isDeath) 
            {
                
                return;
            }

			if (!_isTarget)
			{
                if (!_agent.hasPath)
				{
					_curTime += Time.deltaTime;
                    if (_curTime >= PatrolTimeDelay)
					{
						_curTime = 0;
                        _agent.SetDestination(_patrol.GenericPoint(_agent));

					}
				}

				if (Vision.VisionMath(transform, _target))
				{
					_isTarget = true;
                    _hitTime = Time.time;
				}
			}
			else
			{
                if ((Time.time - _hitTime) > TargetTimeOut)
                {
                    _isTarget = false;
                    _agent.ResetPath();

                    return;
                }

				_agent.SetDestination(_target.position);
				_agent.stoppingDistance = 1;

				if (Vision.VisionMath(transform, _target))
				{
                    GetComponent<Animator>().Play("attack_short_001");
					_weapon.Fire();
				}
			}
		}

		public void SetDamage(InfoBulletCollision info)
		{
			if(Hp > 0)
			{
                GetComponent<Animator>().Play("damage_001");
				Hp -= info.Damage;
			}

			if (Hp <= 0)
			{
				_isDeath = true;
				_agent.enabled = false;
                GetComponent<Animator>().Play("dead");
                Destroy(this.gameObject, 10);
			}
		}

		private void OnDrawGizmos()
		{
#if UNITY_EDITOR
			Transform t = transform;

			Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.localScale);
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

			var flat = new Vector3(Vision.ActiveDist, 0, Vision.ActiveDist);
			Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
			Gizmos.DrawWireSphere(Vector3.zero, 5);
#endif
		}
	}
}