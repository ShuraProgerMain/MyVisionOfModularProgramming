namespace FirstExample
{
    public class Account
    {
        public string SaveString
        {
            //В идеале все это обвешать защитой в духе каких-либо ключей и т.д. Но для примера будет так
            set
            {
                if (value != string.Empty)
                    SaveString = value;
            }
        }

        public Account()
        {
            
        }
    }
}
