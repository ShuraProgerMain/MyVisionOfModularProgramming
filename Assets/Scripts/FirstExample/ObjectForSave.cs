using UnityEngine;

namespace FirstExample
{
    public abstract class ObjectForSave : MonoBehaviour
    {
        //Здесь может быть логичная претензия относительно того, что придется для каждого объекта создавать свой уникальный идентификатор.
        // Да придется. И это лучше, чем сохранять все в одну строку, потому что можно получать доступ не ко всему сразу, а к конкретной точке. 
        // Разница в количестве символов будет не существенная, а вот разница в производительности и удобстве работы более чем
        [Tooltip("Здесь может быть символ, набор символов и прочее")]
        [CharacterLimit(5)]
        [SerializeField] private string id;

        public string ID => id;
        //Через этот метод будет производиться взаимодействие с другими скриптами
        public string Save()
        {
            var saveString = $"({ID}){CollectSaves()}/";

            return saveString;
        }

        public void Load(string loadString)
        {
            if (loadString != string.Empty)
            {
                SetSavedData(loadString);
            }
        }

        protected abstract string CollectSaves();
        protected abstract void SetSavedData(string loadString);
    }
}