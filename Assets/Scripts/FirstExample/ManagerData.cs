using UnityEngine;

namespace FirstExample
{
    public class ManagerData : MonoBehaviour
    {
        [SerializeField] private SaveCollector saveCollector;
        private Account _account;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
        }
        
        private void Awake()
        {
            _account = new Account();
        }

        public void Save()
        {
            _account.SaveString = saveCollector.SaveAll();
        }

        public void Load()
        {
            saveCollector.LoadAll();
        }
    }
}
