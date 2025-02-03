using ViewModel;

namespace BusinessService

{
    public class WordService : IWordService
    {
        public List<string> ProcessWords(List<Word> words)
        {
            Dictionary<int, List<Word>> Lines = new Dictionary<int, List<Word>>();

            foreach (var word in words)
            {
                if (!Lines.ContainsKey(word.bbox.Y))
                {
                    Lines.Add(word.bbox.Y, new List<Word> { word });
                }
                else
                {
                    Lines[word.bbox.Y].Add(word);

                }
            }
            List<string> result = new List<string>();
            foreach (var line in Lines)
            {

                result.Add(string.Join(' ', line.Value.OrderBy(c => c.bbox.X).Select(t => t.word)));
            }
            return result;  
        }
    }
}
