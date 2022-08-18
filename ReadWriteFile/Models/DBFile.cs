using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class DBFile
    {
        public static string FileName = "Users.txt";
        public static string FilePath = Path.GetTempPath();

        /// <summary>
        /// Записывает тестовый файл.
        /// </summary>
        /// <param name="content">Контент для записи в файл.</param>
        public static void WriteFile(string content)
        {
            File.WriteAllText(FilePath + FileName, content);
        }

        /// <summary>
        /// Читает текстовый файл.
        /// </summary>
        /// <returns>Строку данных из файла.</returns>
        public static string ReadFile()
        {
            return File.ReadAllText(FilePath + FileName);
        }
    }
}
