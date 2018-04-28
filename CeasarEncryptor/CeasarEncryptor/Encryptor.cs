using System;
using System.Collections.Generic;
using System.Text;

namespace CeasarEncryptor
{
    class Encryptor : IEncryptor
    {
        //Строка, включающщая в себя русский алфавит, пробел и числа от 0 до 9
        private string ruAlpha = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя 0123456789";

        //Строка включающая в себя английский алфавит, пробел и числа от 0 до 9
        private string enAlpha = "abcdefghijklmnopqrstuvwxyz 0123456789";

        ///Поле, в котрое присвается значение переменной ruAlpha или enAlpha, в зависимости от выбранного пользователем языка
        ///шифруемого символа
        private string alpha;

        //Количество букв в русском алфавите
        private int maxRuAlpha = 32;

        //Количество букв в английском алфавите
        private int maxEnAlpha = 26;

        //Переменная, в которую будет присвается значение переменной maxRuAlpha либо maxEnAlpha, в зависимости от выбранного языка
        private int maxAlpha;

        //Переменная, в которую присваивается ключ шифра введенный с консоли
        private int key;

        //Переменная, в которую посимвольно присваиваются символы уже зашифрованного слова
        string encryptedWord = "";

        //Переменная, которой присваивается введное с консоли слово
        string incomingWord;

        /// <summary>
        /// Метод SelectLanguage предлагает выбрать язык пользователю, в зависимости
        /// от нажатой клавиши
        /// </summary>
        private void SelectLanguage()
        {
            Console.WriteLine("Выберите язык, на котором будет вводиться слово. Нажмите кнопку e - english/r - russian");

            ConsoleKeyInfo button = Console.ReadKey();

            switch(button.Key)
            {
                //Если нажата клавиша e, то слово должно вводиться на английском языке
                case ConsoleKey.E:
                    Console.WriteLine("\nВыбран английский язык");
                    alpha = enAlpha;
                    maxAlpha = maxEnAlpha;
                    break;
                //Если нажата клавиша R, то слово должно вводиться на русском языке
                case ConsoleKey.R:
                    Console.WriteLine("\nВыбран русский язык");
                    alpha = ruAlpha;
                    maxAlpha = maxRuAlpha;
                    break;
                ///В любом другом случае, будет выводиться сообщение об ошибке, и метод запускается заново
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nЯзык выбран не верно, попробуйте еще раз\n");
                    Console.ResetColor();
                    SelectLanguage();
                    break;
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
        /// Метод CheckLength проверяет, не пустая ли строка
        /// </summary>
        private void CheckLength()
        {
            //Если длина строки равнв нулю, то выводится сообщение об ошибке и перезапускается мметод GetString
            if(incomingWord.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Пустая строка недопустима\n");
                Console.ResetColor();
                GetString();
            }
        }

        /// <summary>
        /// Метод CheckLanguage проверяет, содержит ли строка символы из другого языка
        /// </summary>
        private void CheckLanguage()
        {
            int mistakes = 0;

            if(alpha == enAlpha)
            {
                for(int i = 0; i < incomingWord.Length; i++)
                {
                    for(int j = 0; j < ruAlpha.Length; j++)
                    {
                        if(incomingWord[i] == ruAlpha[j] && incomingWord[i] != ' ' && !(char.IsDigit(incomingWord[i])))
                        {
                            ///Если символ строки, введенной на английском языке(При выборе языка, в консоли был выбран английский),
                            ///находит совпадение в русском алфавите, и это не число и не пробел, то счетчик ошибок увеличивается
                            ///на единицу
                            mistakes++;
                        }
                    }
                }
                if(mistakes > 0)
                {
                    ///Если количество ошибок больше нуля, то выводится сообщение об ошибке и перезапускается метод GetString
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Не должны использоваться символы из другого языка");
                    Console.ResetColor();
                    GetString();
                }
            }
            else
            {
                for (int i = 0; i < incomingWord.Length; i++)
                {
                    for (int j = 0; j < enAlpha.Length; j++)
                    {
                        //Если символ строки, введенной на русском языке(При выборе языка, в консоли был выбран русский),
                        ///находит совпадение в английском алфавите, и это не число и не пробел, то счетчик ошибок увеличивается
                        ///на единицу
                        if (incomingWord[i] == enAlpha[j] && incomingWord[i] != ' ' && !(char.IsDigit(incomingWord[i])))
                        {
                            mistakes++;
                        }
                    }
                }
                if (mistakes > 0)
                {
                    ///Если количество ошибок больше нуля, то выводится сообщение об ошибке и перезапускается метод GetString
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Не должны использоваться символы из другого языка");
                    Console.ResetColor();
                    GetString();
                }
            }
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
            catch(Exception e)
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
            catch(FormatException ex)
            {
                //Если преобразование не удалось, то выбрасывается исключение метод GetKey перезапускается
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ключ задан в неверном формате, {0}\nПопробуйте задать ключ еще раз\n", ex.Message);
                Console.ResetColor();
                GetKey();
            }
        }

        /// <summary>
        /// Метод EncryptWord отвечает за шифрование слова
        /// </summary>
        public void EncryptWord()
        {
            ///Массив incomingIndexes размерностью равный вводимому с консоли слову. Он будет состоять из индексов символов,
            ///под которыми они находятся в алфавите
            int[] incomingIndexes = new int[incomingWord.Length];

            //Начальный индекс массива incoomingIndexes
            int incIdx = 0;

            for(int i = 0; i < incomingWord.Length; i++)
            {
                for(int j = 0; j < alpha.Length; j++)
                {
                    ///Если символ под индексом i в строке равен символу под индексом j в алфавите и значение переменной
                    ///incIdx меньше размерности массива, то в массив incomingIndexes записывается индекс данного символа из алфавита
                    if(incomingWord[i] == alpha[j] && incIdx < incomingIndexes.Length)
                    {
                        incomingIndexes[incIdx] = j;
                        //Индекс увеличивается на единицу
                        incIdx++;
                    }
                }
            }

            for(int i = 0; i < incomingIndexes.Length; i++)
            {
                if(incomingWord[i] != ' ' && !(char.IsDigit(incomingWord[i])))
                {
                    ///Если i-ый символ в слове не является пробелом и числом, то к его индексу прибаляется значение переменной key, т.е.
                    ///ключ шифра
                    incomingIndexes[i] += key;

                    if (incomingIndexes[i] > maxAlpha)
                    {
                        ///Если значение индекса после прибавления к нему ключа стало больше чем количество букв в алфавите, 
                        ///то из полученного значения вычитается размерность алфавита с вычетом единицы, так как индексация
                        ///начинается с нуля
                        incomingIndexes[i] -= maxAlpha + 1;
                    }
                }
            }

            for(int i = 0; i < incomingIndexes.Length; i++)
            {
                for(int j = 0; j < alpha.Length; j++)
                {
                    ///Если индексы из массива incomingIndexes совпадают с индексами из алфавита, то в переменную encryptedWord
                    ///добавляются символы алфавита под этими индексами
                    if(incomingIndexes[i] == j)
                    {
                        encryptedWord += alpha[j];
                    }
                }
            }
        }
        /// <summary>
        /// Метод ShowEncryptedWord отвечает за отображение зашифрованного слова в консоли
        /// </summary>
        public void ShowEncryptedWord()
        {
            //Вывод в консоль зашифрованного слова
            Console.WriteLine($"Зашифрованное слово {encryptedWord}\n");
        }
    }
}
