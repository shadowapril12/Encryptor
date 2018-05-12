using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptorParams
{
    class StringHandler : LanguageHandler
    {
        private void CheckLength()
        {
            //Если длина строки равнв нулю, то выводится сообщение об ошибке и перезапускается мметод GetString
            if (incomingWord.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Пустая строка недопустима\n");
                Console.ResetColor();
                GetString();
            }
        }

        /// <summary>
        /// Метод GetString считывает введенную с консоли строку. Запускает метод для выбора языка, проверки введено ли слово, проверки
        /// слова на наличие символов из другого языка и недопустимых символов
        /// </summary>
        public void GetString()
        {
            //Выбор языка
            SelectLanguage();
            Console.WriteLine("Введите слово для шифрования");
            incomingWord = Console.ReadLine();

            //Приведение значения введенной строки к нижнему регистру
            incomingWord = incomingWord.ToLower();
            //Проверка, не пустая ли строка
            CheckLength();
            //Проврека содержит ди строка символы их другого языка
            CheckLanguage();
            //Проверка строки на недопустимые символы
            CheckString();
            GetKey();
        }

        /// <summary>
        /// Метод CheckString проверяет содержатся ли в строке недопустимые символы
        /// </summary>
        private void CheckString()
        {
            //Счетчик недопустимых символов
            int unknownSymCount = 0;
            try
            {
                for (int i = 0; i < incomingWord.Length; i++)
                {
                    //Если алфавит alpha не содержит i-ый символ строки, то счетчик увеличивается на единицу
                    if (!(alpha.Contains(incomingWord[i] + "")))
                    {
                        unknownSymCount++;
                    }
                }
                if (unknownSymCount > 0)
                {
                    //Если количество недопустимых символов больше нуля, то выбрасывается исключение с сообщением
                    throw new Exception("Строка содержит недопустимый символ");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                GetString();
            }
        }

        //Метод GetKey принимает и записывает в переменную key, ключ для шифра с консоли
        public void GetKey()
        {
            Console.WriteLine("Введите ключ для шифрования (число)");

            try
            {
                //Преобразование строки к числу
                key = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                //Если преобразование не удалось, то выбрасывается исключение метод GetKey перезапускается
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ключ задан в неверном формате, {0}\nПопробуйте задать ключ еще раз\n", ex.Message);
                Console.ResetColor();
                GetKey();
            }
        }

    }
}
