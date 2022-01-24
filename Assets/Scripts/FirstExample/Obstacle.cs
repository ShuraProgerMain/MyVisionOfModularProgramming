using UnityEngine;

namespace FirstExample
{
    public class Obstacle : ObjectForSave
    {
        //Метод наследник от объекта который может сохранять данные
        protected override string CollectSaves()
        {
            var position = transform.position;
            return $"{position.x}:{position.y}:{position.z}";
        }

        protected override void SetSavedData(string loadString)
        {
            Debug.Log("Вот эти приколы у меня сохранились " + loadString);
        }
    }
}
