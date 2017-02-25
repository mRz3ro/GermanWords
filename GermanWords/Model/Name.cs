using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GermanWords.Model
{

    public enum Parental
    {
        Father,
        Mother,
        Child
    }

    public class Name : ArticleNameBase
    {

        #region Attributes

        protected Article _article;

        private Parental _parental;

        private List<OtherForms> _otherForms;

        private string _fatherName;

        private string _motherName;

        private string _childName;

        protected string _imagePath;

        private ObservableCollection<Tuple<Name, Name>> _groupedForms;

        #endregion

        #region Properties

        public bool HasArticle
        {
            get { return _article != null ? true : false; }
        }

        public Article Article
        {
            get
            {
                return _article;
            }
            set
            {
                _article = value;
                OnPropertyChanged("Article");
            }
        }

        public Parental Parental
        {
            get
            {
                return _parental;
            }

            set
            {
                _parental = value;
                OnPropertyChanged("Article");
            }
        }

        public string ArticleWithName
        {
            get
            {
                return _article.Description + " " + _description + ".";
            }
        }

        public List<OtherForms> OtherForms
        {
            get
            {
                return _otherForms;
            }

            set
            {
                _otherForms = value;
                OnPropertyChanged("OtherForms");
            }
        }

        public ObservableCollection<Tuple<Name, Name>> GroupedForms
        {
            get
            {
                return _groupedForms;
            }

            set
            {
                _groupedForms = value;
                OnPropertyChanged("GroupedForms");
            }
        }

        public string FatherName
        {
            get
            {
                return _fatherName;
            }

            set
            {
                _fatherName = value;
                OnPropertyChanged("FatherName");
            }
        }

        public string MotherName
        {
            get
            {
                return _motherName;
            }

            set
            {
                _motherName = value;
                OnPropertyChanged("MotherName");
            }
        }

        public string ChildName
        {
            get
            {
                return _childName;
            }

            set
            {
                _childName = value;
                OnPropertyChanged("ChildName");
            }
        }

        public string ImagePath
        {
            get
            {
                return _imagePath;
            }

            set
            {
                _imagePath = value;
            }
        }

        #endregion

        #region Constructors

        public Name() : base()
        {
            _otherForms = new List<OtherForms>();
            //this.groupedForms = new ObservableCollection<Tuple<Name, Name>>();
        }

        public Name(string description, string ptDescription, WordType wordType,
            List<Word> relatedWords, Number number, string example, Genre genre,
            Article article, Parental parental, List<OtherForms> otherForms, Name father,
            Name mother, Name child, string imagePath) :
            base(description, ptDescription, wordType, relatedWords, number, example, genre)
        {
            _article = article;
            _parental = parental;
            _otherForms = otherForms;
            _fatherName = father.Description;
            _motherName = mother.Description;
            _childName = child.Description;
            _imagePath = imagePath;
        }

        public Name(string description, string ptDescription, WordType wordType,
            List<Word> relatedWords, Number number, string example, Genre genre,
            Article article, Parental parental, List<OtherForms> otherForms, string imagePath) :
            base(description, ptDescription, wordType, relatedWords, number, example, genre)
        {
            _article = article;
            _parental = parental;
            _otherForms = otherForms;
            _imagePath = imagePath;
        }

        public Name(string description, string ptDescription, WordType wordType, Number number, string example, Genre genre,
    Article article, Parental parental, List<OtherForms> otherForms, Name father,
    Name mother, Name child, string imagePath) :
    base(description, ptDescription, wordType, number, example, genre)
        {
            _article = article;
            _parental = parental;
            _otherForms = otherForms;
            _fatherName = father.Description;
            _motherName = mother.Description;
            _childName = child.Description;
            _imagePath = imagePath;
        }

        public Name(string description, string ptDescription, WordType wordType, Number number, string example, Genre genre,
    Article article, Parental parental, List<OtherForms> otherForms, string imagePath) :
    base(description, ptDescription, wordType, number, example, genre)
        {
            _article = article;
            _parental = parental;
            _otherForms = otherForms;
            _imagePath = imagePath;
        }

        public Name(string description, string ptDescription, WordType wordType, Number number, string example, Genre genre,
    Article article, Parental parental, Name father,
    Name mother, Name child, string imagePath) :
    base(description, ptDescription, wordType, number, example, genre)
        {
            _article = article;
            _parental = parental;
            _fatherName = father.Description;
            _motherName = mother.Description;
            _childName = child.Description;
            _imagePath = imagePath;
            _otherForms = new List<OtherForms>();
        }

        public Name(string description, string ptDescription, WordType wordType, Number number, string example, Genre genre,
    Article article, Parental parental, string imagePath) :
    base(description, ptDescription, wordType, number, example, genre)
        {
            _article = article;
            _parental = parental;
            _imagePath = imagePath;
            _otherForms = new List<OtherForms>();
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Article.ArticleType + ": " + Article.Description + " " + base.ToString() + ", " + Number;
        }

        #endregion

    }
}
