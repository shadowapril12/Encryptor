using System;

namespace EncryptorParams
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Encryptor enc = new Encryptor();

                //Считывание строки, выполнение описанных в классе проверок
                enc.GetString();

                //Шифрование слова
                enc.EncryptWord();

                //Вывод слова в консоль
                enc.ShowEncryptedWord();

            }
        }
    }
}
