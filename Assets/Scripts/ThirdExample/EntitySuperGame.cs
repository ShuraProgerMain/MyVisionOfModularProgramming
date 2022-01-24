using System;
using UnityEngine;
using UnityEngine.Events;

namespace ThirdExample
{
    [RequireComponent(typeof(EntitySuperGameReward))]
    public abstract class EntitySuperGame : MonoBehaviour
    {
        public UnityEvent<int> OnGetReward; // вместо int у нас будет List<Currency>

        protected EntitySuperGameReward _entitySuperGameReward;
        
        private UnityEvent OnShowEvents;
        private UnityEvent OnHideEvents;

        private void Awake()
        {
            _entitySuperGameReward = GetComponent<EntitySuperGameReward>();
        }

        public virtual void ShowSuperGame(bool withEvents = false)
        {
            if(withEvents)
                OnShowEvents?.Invoke();
        }

        public virtual void HideSuperGame(bool withEvents = false)
        {
            OnGetReward?.Invoke(_entitySuperGameReward.GetAwardsReceived());
            if(withEvents)
                OnHideEvents?.Invoke();
        }

        public void AddShowListener(UnityAction action)
        {
            OnShowEvents.AddListener(action);
        }
        
        public void AddHideListener(UnityAction action)
        {
            OnHideEvents.AddListener(action);
        }
    }
}
