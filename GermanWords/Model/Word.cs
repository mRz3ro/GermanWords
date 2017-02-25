using System;
using System.Collections.Generic;

namespace GermanWords.Model
{
    public enum WordType
    {
        Name,
        Article,
        Verb
    }

    public enum Number
    {
        Singular,
        Plural
    }

    public abstract class Word : BindableClass, IComparable<Word>
    {

        #region Attributes

        private Int64 _id;

        protected string _description;

        protected string _ptDescription;

        protected WordType _wordType;

        protected List<Word> _relatedWords;

        protected Number _number;

        private string _example;

        #endregion

        #region Properties

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string PtDescription
        {
            get
            {
                return _ptDescription;
            }

            set
            {
                _ptDescription = value;
                OnPropertyChanged("PtDescription");
            }
        }

        public WordType WordType
        {
            get
            {
                return _wordType;
            }

            set
            {
                _wordType = value;
                OnPropertyChanged("PtDescription");
            }
        }

        public Number Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        public List<Word> RelatedWords
        {
            get
            {
                return _relatedWords;
            }

            set
            {
                _relatedWords = value;
                OnPropertyChanged("RelatedWords");
            }
        }

        public string Example
        {
            get
            {
                return _example;
            }

            set
            {
                _example = value;
                OnPropertyChanged("Example");
            }
        }

        public long Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        #endregion

        #region Constructors

        public Word()
        {
            _relatedWords = new List<Word>();
        }

        public Word(string description, string ptDescription, WordType wordType,
    Number number, string example) : this()
        {
            _description = description;
            _ptDescription = ptDescription;
            _wordType = wordType;
            _number = number;
            _example = example;
        }

        public Word(string description, string ptDescription, WordType wordType,
            List<Word> relatedWords, Number number, string example) : this()
        {
            _description = description;
            _ptDescription = ptDescription;
            _wordType = wordType;
            _relatedWords = relatedWords;
            _number = number;
            _example = example;
        }

        #endregion

        #region Methods

        public int CompareTo(Word other)
        {
            if (other == null)
                return 1;
            else
                return _description.CompareTo(other._description);

        }

        public override string ToString()
        {
            return Description;
        }

        #endregion

    }
}
