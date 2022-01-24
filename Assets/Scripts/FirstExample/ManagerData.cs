using UnityEngine;

namespace FirstExample
{
    public class ManagerData : MonoBehaviour
    {
        private Account _account;
        
        private void Awake()
        {
            _account = new Account();
        }

        public void SetSave(string saveString)
        {
            _account.SaveString = saveString;
        }
    }
}
