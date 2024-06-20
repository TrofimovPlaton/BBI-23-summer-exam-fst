using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_5
{
    public class Task3
    {
        public class Statistic
        {
            public string Input { get; }
            public double Output { get; private set; }

            public Statistic(string input)
            {
                Input = input;
                Output = CalculateAverageSyllables(input);
            }

            private double CalculateAverageSyllables(string text)
            {
                if (string.IsNullOrWhiteSpace(text)) return 0;

                string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                int syllableCount = words.Sum(w => CountSyllables(w));
                return (double)syllableCount / words.Length;
            }

            private int CountSyllables(string word)
            {
                char[] vowels = { 'а', 'б', 'в', 'г', 'д', 'е' };
                return word.Count(c => vowels.Contains(char.ToLower(c)));
            }

            public override string ToString()
            {
                return string.IsNullOrWhiteSpace(Input) ? string.Empty : Output.ToString("F2");
            }
        }
    }
}
