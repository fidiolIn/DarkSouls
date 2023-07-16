namespace Sources.Presenter
{
    public class KnightMono : WarriorPresenter
    {
        private void Awake()
        {
            base.Initialize();
        }

        private void Update()
        {
            base.IncreaseStamina();
            base.Move();
            base.Jump();
        }
    }
}
