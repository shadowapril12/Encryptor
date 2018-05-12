using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptorParams
{
    class EncryptorParams
    {
        //Строка, включающщая в себя русский алфавит, пробел и числа от 0 до 9
        protected string ruAlpha = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя 0123456789";

        //Строка включающая в себя английский алфавит, пробел и числа от 0 до 9
        protected string enAlpha = "abcdefghijklmnopqrstuvwxyz 0123456789";

        ///Поле, в котрое присвается значение переменной ruAlpha или enAlpha, в зависимости от выбранного пользователем языка
        ///шифруемого символа
        protected string alpha;

        //Количество букв в русском алфавите
        protected int maxRuAlpha = 32;

        //Количество букв в английском алфавите
        protected int maxEnAlpha = 26;

        //Переменная, в которую будет присвается значение переменной maxRuAlpha либо maxEnAlpha, в зависимости от выбранного языка
        protected int maxAlpha;

        //Переменная, в которую присваивается ключ шифра введенный с консоли
        protected int key;

        //Переменная, в которую посимвольно присваиваются символы уже зашифрованного слова
        protected string encryptedWord = "";

        //Переменная, которой присваивается введное с консоли слово
        protected string incomingWord;

    }
}
