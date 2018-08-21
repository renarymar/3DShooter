using UnityEngine;

namespace Geekbrains
{
	public abstract class BaseController : MonoBehaviour
	{
		public bool IsActive { get; private set; }

		public virtual void On()
		{
			IsActive = true;
		}

		public virtual void Off()
		{
			IsActive = false;
		}
	}
}