using System;

namespace CeasarEncryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                //Создание экземпляра класса Encryptor
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
