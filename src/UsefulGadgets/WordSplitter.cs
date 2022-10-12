using System.Text;
using System.Text.RegularExpressions;

namespace UsefulGadgets
{
    public class WordSplitter
    {
        private static Dictionary<string, string> replaces = new()
        {
            { "Of", "of" },
            { "id", "Id" }
        };

        private IEnumerable<int> GetIndexesForSplitting(string sentence)
        {
            var regex = new Regex("{(\\d+):wordSplit}");

            foreach (Match match in regex.Matches(sentence))
            {
                if (match.Groups.Count > 1)
                    yield return int.Parse(match.Groups[1].Value);
            }
        }

        public string ReplaceWithSplittedWords(string sentence, string[] items)
        {
            foreach (var index in GetIndexesForSplitting(sentence))
            {
                if (items.Length > index)
                {
                    sentence = Regex.Replace(sentence, "{" + index.ToString() + ":wordSplit}", GetSplittedWord(items[index]));
                }
            }
            return sentence;
        }

        private string GetSplittedWord(string itemToSplit)
        {
            var split = Regex.Split(itemToSplit, @"(?<!^)(?=[A-Z])");
            var result = new List<string>();
            var stringBuilder = new StringBuilder();

            foreach (var word in split)
            {
                if (word.Length > 1)
                {
                    if (stringBuilder.Length > 0)
                    {
                        result.Add(stringBuilder.ToString());
                        stringBuilder.Clear();
                    }

                    result.Add(word);
                }
                else
                    stringBuilder.Append(word);
            }

            return String.Join(" ", result.Select(s => replaces.TryGetValue(s, out var replace) ? replace : s));
        }
    }
}
