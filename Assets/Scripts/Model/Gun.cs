namespace Geekbrains
{
	public class Gun : Weapon
	{
		public override void Fire()
		{
			if (!_isFire) return;
			// реализовать паттерн pool Object
			if (Ammunition == null) return;

			var tempAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.localRotation);
			tempAmmunition.Rigidbody.AddForce(_barrel.forward * _force);

			_isFire = false;
			_timer.Start(_rechargeTime);
		}
	}
}