using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Task_13._6._2
{
    class Program
    {

        static void Main(string[] args)
        {
            string file_path = FileSelection(); // метод выбора файла (заглушка)
            var word_List = new List<string>(); // инициализирую коллекцию для хранения слов
            WriteToCollection(file_path, word_List);
            var hSet = new HashSet<string>();
            hSet.UnionWith(word_List);
            var top_word_List = new Dictionary<string, int>();

            int count = 0;
            foreach (string word in word_List)
            {
                if (!hSet.Add(word))
                {
                    count++;
                    top_word_List.Add(word, count);
                }
            }
        }
        static string FileSelection()
        {
            string file_path = @"C:\Users\Professional\Desktop\Text1.txt";
            return file_path;
        }
        public static List<string> WriteToCollection(string file_path, List<string> word_List)
        {
            var temp_charList = new List<char>(); // создаем динамический массив для записи каждого символа из всего текста
            string allText = File.ReadAllText(file_path); // считываю весь текст из файла

            for (int i = 0; i < allText.Length; i++)
            {
                if (!Char.IsPunctuation(allText[i]) & !Char.IsWhiteSpace(allText[i]) & !Char.IsNumber(allText[i]) & !Char.IsSymbol(allText[i]) & !Char.IsSeparator(allText[i])) // проверяем каждый элемент char из массива string всего текста на принадлежность слову
                {
                    temp_charList.Add(allText[i]); // записываем элемент char в  динамический массив
                }
                else
                {
                    if (temp_charList.Count >= 1) // условие минимального слова в один символ
                    {
                        string single_word = new string(temp_charList.ToArray()); // получаю слово из динамического массива символов
                        word_List.Add(single_word); // добавляю полученное слово в главный массив слов
                    }
                    temp_charList.Clear(); // очищаю динамический массив
                }
            }
            return word_List;
        }
    }
}
