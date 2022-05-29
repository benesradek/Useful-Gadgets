namespace UsefulGadgets.Services
{
    public class WrapperService : IWrapperService
    {
        public string Process(string sentence, string list, int counter, char separator)
        {
            if (string.IsNullOrEmpty(sentence) || string.IsNullOrEmpty(list))
                return "";

            var items = list.Split(Environment.NewLine);
            var result = new List<string>();

            foreach (var item in items)
            {
                sentence = sentence.Replace("%%counter%%", counter.ToString());
                result.Add(string.Format(sentence, item.Split(separator)));
                counter++;
            }

            return string.Join(Environment.NewLine, result);
        }
    }
}
