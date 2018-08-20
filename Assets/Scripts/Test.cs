namespace Geekbrains
{
	public sealed class Test : BaseObjectScene
	{
		private void Start()
		{
			Rigidbody.Sleep();
			Rigidbody.isKinematic = true;
			Layer = 2;
		}
	}
}