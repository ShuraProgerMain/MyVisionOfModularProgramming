namespace ThirdExample
{
    public class SomeSuperGame : EntitySuperGame
    {
        // Если нужны какие-либо колбеки к основной игре, все это делается через Action/UnityEvent в зависимости от требуемой логики
        
        public override void ShowSuperGame(bool withEvents)
        {
            // Логика для открытия супер игры
            
            base.ShowSuperGame();
        }

        public override void HideSuperGame(bool withEvents)
        {
            // Логика для закрытия супер игры
            
            base.HideSuperGame();
        }
    }
}
