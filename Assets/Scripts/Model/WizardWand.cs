namespace Geekbrains
{
    public class WizardWand : Wand
    {
        public override void Fire()
        {
            if (!_isFire) return;

            _isFire = false;
            _timer.Start(_rechargeTime);
        }
    }
}