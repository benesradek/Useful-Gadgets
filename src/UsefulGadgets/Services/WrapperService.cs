namespace UsefulGadgets.Services
{
    public class WrapperService : IWrapperService
    {
        public string Process(string sentence, string list, int counter, char separator)
        {
            if (string.IsNullOrEmpty(sentence) || string.IsNullOrEmpty(list))
                return "";

            var wordSplitter = new WordSplitter();
            var items = list.Split(Environment.NewLine);
            var result = new List<string>();

            foreach (var item in items)
            {
                sentence = sentence.Replace("%%counter%%", counter.ToString());
                var columns = item.Split(separator);
                sentence = wordSplitter.ReplaceWithSplittedWords(sentence, columns);

                result.Add(string.Format(sentence, columns));
                counter++;
            }

            return string.Join(Environment.NewLine, result);
        }
    }
}
