using ThirdExample;
using UnityEngine;

namespace SecondExample
{
    [RequireComponent(typeof(SomeMiniGameRewards), typeof(SomeMiniGameView))]
    public class SomeMiniGameLogic : MonoBehaviour
    {
        [SerializeField] private EntitySuperGame superGame;

        private SomeMiniGameView _someMiniGameView;
        private SomeMiniGameRewards _someMiniGameRewards;

        private void Awake()
        {
            _someMiniGameView = GetComponent<SomeMiniGameView>();
            _someMiniGameRewards = GetComponent<SomeMiniGameRewards>();
        }

        public void Initialize()
        {
            superGame.OnGetReward.AddListener(_someMiniGameRewards.AddCurrency);
        }

        private void EndGame()
        {
            //Как он будет использоваться зависит от реализации объектов взаимодействия
        }
    }
}
