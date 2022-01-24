using UnityEngine;

namespace FirstExample
{
    public class SaveCollector : MonoBehaviour
    {
        [SerializeField] private ObjectForSave[] objectsForSave;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SaveAll();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadAll();
            }
                
        }

        public void SaveAll()
        {
            var allSave = "";
            foreach (var objectForSave in objectsForSave)
            {
                allSave += objectForSave.Save();
            }

            allSave = allSave.Replace(" ", string.Empty);
            PlayerPrefs.SetString("AllSave", allSave);
            Debug.Log(allSave);
        }

        //Суть в том, что каждый объект сам берет на себя логику загрузки и интерпретации сохранений
        public void LoadAll()
        {
            var allLoads = PlayerPrefs.GetString("AllSave", string.Empty);

            if (allLoads == string.Empty)
            {
                Debug.Log("Сохранений не найдено");
            }
            else
            {
                var ID = string.Empty;
                var saveString = string.Empty;
                var state = 0;

                foreach (var ch in allLoads.ToCharArray())
                {
                    if (state == 0)
                    {
                        if(ch == '(')
                        {
                            state = 1;
                        }
                    }
                    else if(state == 1)
                    {
                        if (ch == ')')
                        {
                            state = 2;
                        }
                        else
                        {
                            ID += ch;
                        }
                    }
                    else if (state == 2)
                    {
                        if(ch == '/')
                        {
                            PassAString(ID, saveString);

                            ID = string.Empty;
                            saveString = string.Empty;
                            state = 1;
                        }
                        else
                        {
                            saveString += ch;
                        }
                    }
                }
            }
        }

        public void LoadingByID(string ID)
        {
            //По хорошему должна быть еще и реализация поиска по ID, что бы не выгружать все данные, т.к некоторые объекты могут не существовать или быть выключенным.
            //Или же для них попросту нет необходимости в данный момент вызывать загрузку данных. Список таких объектов или их идентификаторе можно хранить в массиве и проверять каждый раз,
            //когда пытаешься пойти подгрузить что-то у них. Или же, в идеале, проверять еще на стадии знакомства со строкой сохранения. То есть, если ID не подходит, то идти к следующему, не читая не нужную часть строки   
        }

        private void PassAString(string ID, string value)
        {
            foreach (var objectForSave in objectsForSave)
            {
                if (objectForSave.ID.Equals(ID))
                {
                    objectForSave.Load(value);
                }
            }
        }
    }
}
