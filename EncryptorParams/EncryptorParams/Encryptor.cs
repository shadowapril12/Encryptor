using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptorParams
{
    class Encryptor : StringHandler
    {
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

            for (int i = 0; i < incomingWord.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    ///Если символ под индексом i в строке равен символу под индексом j в алфавите и значение переменной
                    ///incIdx меньше размерности массива, то в массив incomingIndexes записывается индекс данного символа из алфавита
                    if (incomingWord[i] == alpha[j] && incIdx < incomingIndexes.Length)
                    {
                        incomingIndexes[incIdx] = j;
                        //Индекс увеличивается на единицу
                        incIdx++;
                    }
                }
            }

            for (int i = 0; i < incomingIndexes.Length; i++)
            {
                if (incomingWord[i] != ' ' && !(char.IsDigit(incomingWord[i])))
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

            for (int i = 0; i < incomingIndexes.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    ///Если индексы из массива incomingIndexes совпадают с индексами из алфавита, то в переменную encryptedWord
                    ///добавляются символы алфавита под этими индексами
                    if (incomingIndexes[i] == j)
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
