using System;
using System.Collections.Generic;
using System.Text;

namespace CeasarEncryptor
{
    interface IEncryptor
    {
        /// <summary>
        /// Метод GetString - считывает строку введенную с консоли, а также включает в себя ряд
        /// методов для проверки на корректность введенной строки
        /// </summary>
        void GetString();

        /// <summary>
        /// Метод GetKey считывает значение с консоли, которое будет являться ключом к шифру
        /// </summary>
        void GetKey();

        /// <summary>
        /// Метод EncryptWord отвечает за шифрование введенного слова
        /// </summary>
        void EncryptWord();

        /// <summary>
        /// Метод ShowEncryptedWord отображает в консоли зашифрованное слово
        /// </summary>
        void ShowEncryptedWord();        
    }
}
