using System;
using System.Text;

namespace Algorithms
{
   public class Vijener
    {
        
        private const string alphabet = "abcdefghijklmnopqrstuvwxyzабвгдежзийклмнопрстуфхцчшщьыъэюя";
       
        public string Encryption(string originalText, string secretKey)
        {
            var result = new StringBuilder();

            var abcLength = alphabet.Length; //вычисляем длину
            var lowerOriginalText = originalText.ToLower(); // в нижний регистр заданный текст
            var lowerSecretKey = secretKey.ToLower(); //также с ключом
            Console.WriteLine("Original text: {0}", originalText);

            var newSecretKey = GenerateSecretKeyRelativeToInputString(lowerOriginalText, lowerSecretKey); //генерируем секретный ключ

            Console.WriteLine("New secret key: {0}", newSecretKey);

            for (var i = 0; i < lowerOriginalText.Length; i++)
            {
                if (lowerOriginalText[i] == ' ')//пока не дойдем до конца текста
                {
                    result.Append(lowerOriginalText[i]);//в результат добавляем символы
                    continue;
                }

                var p = GetIndexRelativeToABC(lowerOriginalText[i]);//индекс буквы, согласно нашему алфавиту в тексте
                var k = GetIndexRelativeToABC(newSecretKey[i]);//индекс буквы, согласно нашему алфавиту в ключе
                var charIndex = (p + k)%abcLength;//вычисление индекса буквы зашифрованного сообщения
                result.Append(GetCharFromABCByIndex(charIndex));//в результат кладем букву, возвращенную из функции по индексу
            }

            return result.ToString();
        }

        private int GetIndexRelativeToABC(char inputChar)//возвращает Индекс из алфавита
        {
            return alphabet.IndexOf(inputChar);
        }

        private char GetCharFromABCByIndex(int index)//получаем инlекс из алфавита
        {
            if (index >= alphabet.Length) throw new ArgumentOutOfRangeException("index");
            return alphabet[index];
        }

        private string GenerateSecretKeyRelativeToInputString(string inputString, string secretKey)// генерируем ключ
        {
            StringBuilder result = new StringBuilder();
            for (var i = 0; i < inputString.Length; i++)
            {
                int index;
                if (i >= secretKey.Length) index = i % secretKey.Length;
                else index = i;
                result.Append(secretKey[index]);
            } return result.ToString();
        }
    }
}
