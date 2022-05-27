namespace UsefulGadgets.Services
{
    public class WrapperService : IWrapperService
    {
        public string Process(string sentence, string list)
        {
            if (string.IsNullOrEmpty(sentence) || string.IsNullOrEmpty(list))
                return "";

            var items = list.Split(Environment.NewLine);
            var result = new List<string>();

            foreach (var item in items)
            {
                result.Add(string.Format(sentence, item));
            }

            return string.Join(Environment.NewLine, result);
        }
    }
}
