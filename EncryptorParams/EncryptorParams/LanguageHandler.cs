using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptorParams
{
    class LanguageHandler : EncryptorParams
    {
        /// <summary>
        /// Метод SelectLanguage предлагает выбрать язык пользователю, в зависимости
        /// от нажатой клавиши
        /// </summary>
        protected void SelectLanguage()
        {
            Console.WriteLine("Выберите язык, на котором будет вводиться слово. Нажмите кнопку e - english/r - russian");

            ConsoleKeyInfo button = Console.ReadKey();

            switch (button.Key)
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

        protected void CheckLanguage()
        {
            int mistakes = 0;

            if (alpha == enAlpha)
            {
                for (int i = 0; i < incomingWord.Length; i++)
                {
                    for (int j = 0; j < ruAlpha.Length; j++)
                    {
                        if (incomingWord[i] == ruAlpha[j] && incomingWord[i] != ' ' && !(char.IsDigit(incomingWord[i])))
                        {
                            ///Если символ строки, введенной на английском языке(При выборе языка, в консоли был выбран английский),
                            ///находит совпадение в русском алфавите, и это не число и не пробел, то счетчик ошибок увеличивается
                            ///на единицу
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
                    SelectLanguage();
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
                    SelectLanguage();
                }
            }
        }

    }
}
