using System.Collections.Generic;

namespace GermanWords.Model
{

    public enum Genre
    {
        Male,
        Female,
        Neuter
    }

    public abstract class ArticleNameBase : Word
    {

        #region Attributes

        protected Genre _genre;

        #endregion

        #region Properties

        public Genre Genre
        {
            get
            {
                return _genre;
            }

            set
            {
                _genre = value;
                OnPropertyChanged("Genre");
            }
        }

        #endregion

        #region Constructors

        public ArticleNameBase() : base() { }

        public ArticleNameBase(Genre genre)
        {
            _genre = genre;
        }

        public ArticleNameBase(string description, string ptDescription, WordType wordType,
            List<Word> relatedWords, Number number, string example, Genre genre) :
            base(description, ptDescription, wordType, relatedWords, number, example)
        {
            _genre = genre;
        }

        public ArticleNameBase(string description, string ptDescription, WordType wordType,
            Number number, string example, Genre genre) :
            base(description, ptDescription, wordType, number, example)
        {
            _genre = genre;
        }

        #endregion

    }
}
