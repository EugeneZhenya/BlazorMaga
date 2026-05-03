using System.Text;

namespace BlazorMaga.Helpers
{
    public class StringUtilities
    {
        public static string CustomToUpper(string value) => value.ToUpper();

        public static string Translit(string source)
        {
            StringBuilder ret = new StringBuilder();
            string[] cyr = { " ", "+", "-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h", "I", "i", "J", "j", "K", "k", "L", "l", "M", "m", "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T", "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z", "А", "а", "Б", "б", "В", "в", "Г", "г", "Ґ", "ґ", "Д", "д", "Е", "е", "Є", "є", "Ж", "ж", "З", "з", "И", "и", "І", "і", "Ї", "ї", "Й", "й", "К", "к", "Л", "л", "М", "м", "Н", "н", "О", "о", "П", "п", "Р", "р", "С", "с", "Т", "т", "У", "у", "Ф", "ф", "Х", "х", "Ц", "ц", "Ч", "ч", "Ш", "ш", "Щ", "щ", "Ю", "ю", "Я", "я" };
            string[] lat = { "_", "+", "-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h", "I", "i", "J", "j", "K", "k", "L", "l", "M", "m", "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T", "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z", "A", "a", "B", "b", "V", "v", "H", "h", "G", "g", "D", "d", "E", "e", "Ye", "ie", "Zh", "zh", "Z", "z", "Y", "y", "I", "i", "Yi", "i", "Y", "y", "K", "k", "L", "l", "M", "m", "N", "n", "O", "o", "P", "p", "R", "r", "S", "s", "T", "t", "U", "u", "F", "f", "Kh", "kh", "Ts", "ts", "Ch", "ch", "Sh", "sh", "Shch", "shch", "Yu", "iu", "Ya", "ia" };

            for (int j = 0; j < source.Length; j++)
            {
                for (int i = 0; i < cyr.Length; i++)
                {
                    if (source.Substring(j, 1) == cyr[i]) ret.Append(lat[i]);
                }
            }

            return ret.ToString();
        }

        public static string FormatArticles(int count)
        {
            string word;
            int lastTwoDigits = count % 100;
            int lastDigit = count % 10;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 14)
            {
                word = "статей";
            }
            else
            {
                switch (lastDigit)
                {
                    case 1:
                        word = "стаття";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        word = "статті";
                        break;
                    default:
                        word = "статей";
                        break;
                }
            }

            return $"{count} {word}";
        }

    }
}
