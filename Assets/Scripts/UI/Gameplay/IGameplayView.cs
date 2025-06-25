namespace UI.Gameplay
{
    public interface IGameplayView
    {
        public void UpdateCountSheep(int amount);
        public void UpdateTime(int second);
        public void UpdateCoin(int amount);
    }
}
