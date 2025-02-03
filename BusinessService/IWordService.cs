using ViewModel;

namespace BusinessService

{
    public interface IWordService
    {

        List<string> ProcessWords(List<Word> words);

    }
}
