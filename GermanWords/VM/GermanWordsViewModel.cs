using GermanWords.Model;

namespace GermanWords
{
    class GermanWordsViewModel : BindableClass
    {

        #region Attributes

        private WordDictionary wordDictionary;

        private string searchWord;

        #endregion

        #region Properties

        public WordDictionary WordDictionary
        {
            get
            {
                return wordDictionary;
            }

            set
            {
                wordDictionary = value;
                OnPropertyChanged("WordDictionary");
            }
        }

        public string SearchWord
        {
            get
            {
                return searchWord;
            }

            set
            {
                searchWord = value;
                this.wordDictionary.SearchNamesBeginningWith(searchWord);
                OnPropertyChanged("SearchWord");
            }
        }

        #endregion

        #region Constructors

        public GermanWordsViewModel()
        {
            this.WordDictionary = new WordDictionary();
        }

        #endregion

    }
}
