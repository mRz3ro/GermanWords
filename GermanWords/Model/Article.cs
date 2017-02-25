using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GermanWords.Model
{
    public enum Case
    {
        Nominative,
        Accusative,
        Dative,
        Genitive
    }
    
    public class Article : ArticleNameBase
    {

        #region Attributes

        private Case _articleType;

        #endregion

        #region Properties

        public Case ArticleType
        {
            get
            {
                return _articleType;
            }

            set
            {
                _articleType = value;
                OnPropertyChanged("ArticleType");
            }
        }

        #endregion

        #region Constructors

        public Article() : base() { }

        public Article(string description, string ptDescription, WordType wordType,
            List<Word> relatedWords, Number number, string example, Genre genre, Case articleType)
            : base(description, ptDescription, wordType, relatedWords, number, example, genre)
        {
            _articleType = articleType;
        }

        public Article(string description, string ptDescription, WordType wordType
            , Number number, string example, Genre genre, Case articleType)
            : base(description, ptDescription, wordType, number, example, genre)
        {
            _articleType = articleType;
        }

        #endregion

    }
}
