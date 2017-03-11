using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GermanWords.Model
{
    class WordDictionary : BindableClass
    {

        #region Attributes

        private List<Word> _articles = null;

        private List<Word> _names = null;

        private List<Word> _words = null;

        private List<Word> _verbs = null;

        private ObservableCollection<Word> _wordsToPresent = null;

        private Word _selectedWord = null;

        #endregion

        #region Properties

        public List<Word> Articles
        {
            get
            {
                return _articles;
            }

            set
            {
                _articles = value;
                OnPropertyChanged("Articles");
            }
        }

        public List<Word> Names
        {
            get
            {
                return _names;
            }

            set
            {
                _names = value;
                OnPropertyChanged("Names");
            }
        }

        public ObservableCollection<Word> WordsToPresent
        {
            get
            {
                return _wordsToPresent;
            }

            set
            {
                _wordsToPresent = value;
                OnPropertyChanged("WordsToPresent");
            }
        }

        public Word SelectedWord
        {
            get
            {
                return _selectedWord;
            }

            set
            {
                if (_selectedWord != value)
                {
                    _selectedWord = value;

                    Name selectedName = (Name)SelectedWord;

                    List<OtherForms> temp = selectedName.
                        OtherForms.ToList();

                    temp.Sort();

                    //temp = selectedName.
                    //    OtherForms.OrderBy(of => of.Name.Article.ArticleType).ToList();

                    //selectedName.GroupedForms = new ObservableCollection<Tuple<Name, Name>>
                    //{
                    //    new Tuple<Name, Name>(temp[5].OtherForm,temp[4].OtherForm),
                    //    new Tuple<Name, Name>(temp[3].OtherForm,temp[2].OtherForm),
                    //    new Tuple<Name, Name>(temp[1].OtherForm,temp[0].OtherForm),
                    //    new Tuple<Name, Name>(temp[7].OtherForm,temp[6].OtherForm)
                    //};

                    selectedName.GroupedForms = new ObservableCollection<Tuple<Name, Name>>
                    {
                        new Tuple<Name, Name>(temp[0].OtherForm,temp[1].OtherForm),
                        new Tuple<Name, Name>(temp[2].OtherForm,temp[3].OtherForm),
                        new Tuple<Name, Name>(temp[4].OtherForm,temp[5].OtherForm),
                        new Tuple<Name, Name>(temp[6].OtherForm,temp[7].OtherForm)
                    };

                    OnPropertyChanged("SelectedWord");
                }
            }
        }

        public List<Word> Verbs
        {
            get
            {
                return _verbs;
            }

            set
            {
                _verbs = value;
                OnPropertyChanged("Verbs");
            }
        }
        #endregion

        #region Constructors

        public WordDictionary()
        {

            bool hasData = true;

            WordsToPresent = new ObservableCollection<Word>();

            using (var db = new WordsContext())
                hasData = db.Words.Count() > 0 ? true : false;

            if (!hasData)
            {
                mockArticles();
                mockWords();
            }

            loadWords();

        }

        #endregion

        #region Methods

        //private bool has_articles()
        //{
        //    var has_articles = false;

        //    using (var db = new WordsContext())
        //    {
        //        has_articles = db._articles.Count() > 0 ? true : false;
        //    }

        //    return has_articles;
        //}

        private void mockArticles()
        {
            _articles = new List<Word>();

            //Nominative

            Article article1 = new Article("Der", "O", WordType.Article, Number.Singular, "", Genre.Male, Case.Nominative);
            Article article2 = new Article("Die", "Os", WordType.Article, Number.Plural, "", Genre.Male, Case.Nominative);

            Article article3 = new Article("Die", "A", WordType.Article, Number.Singular, "", Genre.Female, Case.Nominative);
            Article article4 = new Article("Die", "As", WordType.Article, Number.Plural, "", Genre.Female, Case.Nominative);

            Article article5 = new Article("Das", "", WordType.Article, Number.Singular, "", Genre.Neuter, Case.Nominative);
            Article article6 = new Article("Die", "", WordType.Article, Number.Plural, "", Genre.Neuter, Case.Nominative);

            //Akkusative

            Article article7 = new Article("Den", "Do", WordType.Article, Number.Singular, "", Genre.Male, Case.Accusative);
            Article article8 = new Article("Die", "Dos", WordType.Article, Number.Plural, "", Genre.Male, Case.Accusative);

            Article article9 = new Article("Die", "Da", WordType.Article, Number.Singular, "", Genre.Female, Case.Accusative);
            Article article10 = new Article("Die", "Das", WordType.Article, Number.Plural, "", Genre.Female, Case.Accusative);

            Article article11 = new Article("Das", "", WordType.Article, Number.Singular, "", Genre.Neuter, Case.Accusative);
            Article article12 = new Article("Die", "", WordType.Article, Number.Plural, "", Genre.Neuter, Case.Accusative);

            //Dativ

            Article article13 = new Article("Dem", "Seu", WordType.Article, Number.Singular, "", Genre.Male, Case.Dative);
            Article article14 = new Article("Den", "Seus", WordType.Article, Number.Plural, "", Genre.Male, Case.Dative);

            Article article15 = new Article("Der", "Sua", WordType.Article, Number.Singular, "", Genre.Female, Case.Dative);
            Article article16 = new Article("Den", "Suas", WordType.Article, Number.Plural, "", Genre.Female, Case.Dative);

            Article article17 = new Article("Dem", "", WordType.Article, Number.Singular, "", Genre.Neuter, Case.Dative);
            Article article18 = new Article("Den", "", WordType.Article, Number.Plural, "", Genre.Neuter, Case.Dative);

            //Genitiv

            Article article19 = new Article("Des", "", WordType.Article, Number.Singular, "", Genre.Male, Case.Genitive);
            Article article20 = new Article("Der", "Dos", WordType.Article, Number.Plural, "", Genre.Male, Case.Genitive);

            Article article21 = new Article("Der", "Da", WordType.Article, Number.Singular, "", Genre.Female, Case.Genitive);
            Article article22 = new Article("Der", "Das", WordType.Article, Number.Plural, "", Genre.Female, Case.Genitive);

            Article article23 = new Article("Des", "", WordType.Article, Number.Singular, "", Genre.Neuter, Case.Genitive);
            Article article24 = new Article("Der", "", WordType.Article, Number.Plural, "", Genre.Neuter, Case.Genitive);

            _articles.Add(article1);
            _articles.Add(article2);
            _articles.Add(article3);
            _articles.Add(article4);
            _articles.Add(article5);
            _articles.Add(article6);
            _articles.Add(article7);
            _articles.Add(article8);
            _articles.Add(article9);
            _articles.Add(article10);
            _articles.Add(article11);
            _articles.Add(article12);
            _articles.Add(article13);
            _articles.Add(article14);
            _articles.Add(article15);
            _articles.Add(article16);
            _articles.Add(article17);
            _articles.Add(article18);
            _articles.Add(article19);
            _articles.Add(article20);
            _articles.Add(article21);
            _articles.Add(article22);
            _articles.Add(article23);
            _articles.Add(article24);

            //saveArticles();

            // Die Heike liebt Carlos. Wen liebt Heike? Den Carlos.
            // Die Buchen gehoren dem farahs.

        }

        private void mockWords()
        {

            mockNames();

            //mockGVerbs();

            //mockGAdgetives();

        }

        private void mockNames()
        {

            _names = new List<Word>();
            _words = new List<Word>();

            //loadGWords();

            //Nominative

            Name name1 = new Name("Vater", "Pai", WordType.Name, Number.Singular, "Der Vater ist schön",
                Genre.Male, (Article)_articles[0], Parental.Father, "/Assets/WordImages/Vater/father.png");

            Name name2 = new Name("Väter", "Pais", WordType.Name, Number.Plural, "Die Väter sind schön",
                Genre.Male, (Article)_articles[1], Parental.Father, "/Assets/WordImages/Vater/father.png");

            Name name3 = new Name("Mutter", "Mãe", WordType.Name, Number.Singular, "",
                Genre.Female, (Article)_articles[2], Parental.Mother, "/Assets/WordImages/Mutter/mother.png");

            Name name4 = new Name("Mütter", "Mães", WordType.Name, Number.Plural, "",
                Genre.Female, (Article)_articles[3], Parental.Mother, "/Assets/WordImages/Mutter/mother.png");

            Name name5 = new Name("Kind", "Criança", WordType.Name, Number.Singular, "",
                Genre.Neuter, (Article)_articles[4], Parental.Child, "/Assets/WordImages/Kind/child.png");

            Name name6 = new Name("Kinder", "Crianças", WordType.Name, Number.Plural, ""
                , Genre.Neuter, (Article)_articles[5], Parental.Child, "/Assets/WordImages/Kind/child.png");

            //Akkusative

            Name name7 = new Name("Vater", "Pai", WordType.Name, Number.Singular, "",
                Genre.Male, (Article)_articles[6], Parental.Father, "/Assets/WordImages/Vater/father.png");

            Name name8 = new Name("Väter", "Pais", WordType.Name, Number.Plural, "",
                Genre.Male, (Article)_articles[7], Parental.Father, "/Assets/WordImages/Vater/father.png");

            Name name9 = new Name("Mutter", "Mãe", WordType.Name, Number.Singular, "",
                Genre.Female, (Article)_articles[8], Parental.Mother, "/Assets/WordImages/Mutter/mother.png");

            Name name10 = new Name("Mütter", "Mães", WordType.Name, Number.Plural, "",
                Genre.Female, (Article)_articles[9], Parental.Mother, "/Assets/WordImages/Mutter/mother.png");

            Name name11 = new Name("Kind", "Criança", WordType.Name, Number.Singular, "",
                Genre.Neuter, (Article)_articles[10], Parental.Child, "/Assets/WordImages/Kind/child.png");

            Name name12 = new Name("Kinder", "Crianças", WordType.Name, Number.Plural, "",
                Genre.Neuter, (Article)_articles[11], Parental.Child, "/Assets/WordImages/Kind/child.png");

            //Dativ

            Name name13 = new Name("Vater", "Pai", WordType.Name, Number.Singular, "",
                Genre.Male, (Article)_articles[12], Parental.Father, "/Assets/WordImages/Vater/father.png");

            Name name14 = new Name("Vätern", "Pais", WordType.Name, Number.Plural, "",
                Genre.Male, (Article)_articles[13], Parental.Father, "/Assets/WordImages/Vater/father.png");

            Name name15 = new Name("Mutter", "Mãe", WordType.Name, Number.Singular, "",
                Genre.Female, (Article)_articles[14], Parental.Mother, "/Assets/WordImages/Mutter/mother.png");

            Name name16 = new Name("Müttern", "Mães", WordType.Name, Number.Plural, "",
                Genre.Female, (Article)_articles[15], Parental.Mother, "/Assets/WordImages/Mutter/mother.png");

            Name name17 = new Name("Kind", "Criança", WordType.Name, Number.Singular, "",
                Genre.Neuter, (Article)_articles[16], Parental.Child, "/Assets/WordImages/Kind/child.png");

            Name name18 = new Name("Kindern", "Crianças", WordType.Name, Number.Plural, "",
                Genre.Neuter, (Article)_articles[17], Parental.Child, "/Assets/WordImages/Kind/child.png");

            //Genitiv

            Name name19 = new Name("Vaters", "Pai", WordType.Name, Number.Singular, "",
                Genre.Male, (Article)_articles[18], Parental.Father, "/Assets/WordImages/Vater/father.png");

            Name name20 = new Name("Vätern", "Pais", WordType.Name, Number.Plural, "",
                Genre.Male, (Article)_articles[19], Parental.Father, "/Assets/WordImages/Vater/father.png");

            Name name21 = new Name("Mutter", "Mãe", WordType.Name, Number.Singular, "",
                Genre.Female, (Article)_articles[20], Parental.Mother, "/Assets/WordImages/Mutter/mother.png");

            Name name22 = new Name("Müttern", "Mães", WordType.Name, Number.Plural, "",
                Genre.Female, (Article)_articles[21], Parental.Mother, "/Assets/WordImages/Mutter/mother.png");

            Name name23 = new Name("Kindes", "Criança", WordType.Name, Number.Singular, "",
                Genre.Neuter, (Article)_articles[22], Parental.Child, "/Assets/WordImages/Kind/child.png");

            Name name24 = new Name("Kindern", "Crianças", WordType.Name, Number.Plural, "",
                Genre.Neuter, (Article)_articles[23], Parental.Child, "/Assets/WordImages/Kind/child.png");

            this.Names.Add(name1);
            this.Names.Add(name2);
            this.Names.Add(name3);
            this.Names.Add(name4);
            this.Names.Add(name5);
            this.Names.Add(name6);
            this.Names.Add(name7);
            this.Names.Add(name8);
            this.Names.Add(name9);
            this.Names.Add(name10);
            this.Names.Add(name11);
            this.Names.Add(name12);
            this.Names.Add(name13);
            this.Names.Add(name14);
            this.Names.Add(name15);
            this.Names.Add(name16);
            this.Names.Add(name17);
            this.Names.Add(name18);
            this.Names.Add(name19);
            this.Names.Add(name20);
            this.Names.Add(name21);
            this.Names.Add(name22);
            this.Names.Add(name23);
            this.Names.Add(name24);

            //saveWords();

            name1.OtherForms.Add(new OtherForms { Name = name1, OtherForm = name1 });
            name1.OtherForms.Add(new OtherForms { Name = name1, OtherForm = name2 });
            name1.OtherForms.Add(new OtherForms { Name = name1, OtherForm = name7 });
            name1.OtherForms.Add(new OtherForms { Name = name1, OtherForm = name8 });
            name1.OtherForms.Add(new OtherForms { Name = name1, OtherForm = name13 });
            name1.OtherForms.Add(new OtherForms { Name = name1, OtherForm = name14 });
            name1.OtherForms.Add(new OtherForms { Name = name1, OtherForm = name19 });
            name1.OtherForms.Add(new OtherForms { Name = name1, OtherForm = name20 });

            name2.OtherForms.Add(new OtherForms { Name = name2, OtherForm = name1 });
            name2.OtherForms.Add(new OtherForms { Name = name2, OtherForm = name2 });
            name2.OtherForms.Add(new OtherForms { Name = name2, OtherForm = name7 });
            name2.OtherForms.Add(new OtherForms { Name = name2, OtherForm = name8 });
            name2.OtherForms.Add(new OtherForms { Name = name2, OtherForm = name13 });
            name2.OtherForms.Add(new OtherForms { Name = name2, OtherForm = name14 });
            name2.OtherForms.Add(new OtherForms { Name = name2, OtherForm = name19 });
            name2.OtherForms.Add(new OtherForms { Name = name2, OtherForm = name20 });

            name7.OtherForms.Add(new OtherForms { Name = name7, OtherForm = name1 });
            name7.OtherForms.Add(new OtherForms { Name = name7, OtherForm = name2 });
            name7.OtherForms.Add(new OtherForms { Name = name7, OtherForm = name7 });
            name7.OtherForms.Add(new OtherForms { Name = name7, OtherForm = name8 });
            name7.OtherForms.Add(new OtherForms { Name = name7, OtherForm = name13 });
            name7.OtherForms.Add(new OtherForms { Name = name7, OtherForm = name14 });
            name7.OtherForms.Add(new OtherForms { Name = name7, OtherForm = name19 });
            name7.OtherForms.Add(new OtherForms { Name = name7, OtherForm = name20 });

            name8.OtherForms.Add(new OtherForms { Name = name8, OtherForm = name1 });
            name8.OtherForms.Add(new OtherForms { Name = name8, OtherForm = name2 });
            name8.OtherForms.Add(new OtherForms { Name = name8, OtherForm = name7 });
            name8.OtherForms.Add(new OtherForms { Name = name8, OtherForm = name8 });
            name8.OtherForms.Add(new OtherForms { Name = name8, OtherForm = name13 });
            name8.OtherForms.Add(new OtherForms { Name = name8, OtherForm = name14 });
            name8.OtherForms.Add(new OtherForms { Name = name8, OtherForm = name19 });
            name8.OtherForms.Add(new OtherForms { Name = name8, OtherForm = name20 });

            name13.OtherForms.Add(new OtherForms { Name = name13, OtherForm = name1 });
            name13.OtherForms.Add(new OtherForms { Name = name13, OtherForm = name2 });
            name13.OtherForms.Add(new OtherForms { Name = name13, OtherForm = name7 });
            name13.OtherForms.Add(new OtherForms { Name = name13, OtherForm = name8 });
            name13.OtherForms.Add(new OtherForms { Name = name13, OtherForm = name13 });
            name13.OtherForms.Add(new OtherForms { Name = name13, OtherForm = name14 });
            name13.OtherForms.Add(new OtherForms { Name = name13, OtherForm = name19 });
            name13.OtherForms.Add(new OtherForms { Name = name13, OtherForm = name20 });

            name14.OtherForms.Add(new OtherForms { Name = name14, OtherForm = name1 });
            name14.OtherForms.Add(new OtherForms { Name = name14, OtherForm = name2 });
            name14.OtherForms.Add(new OtherForms { Name = name14, OtherForm = name7 });
            name14.OtherForms.Add(new OtherForms { Name = name14, OtherForm = name8 });
            name14.OtherForms.Add(new OtherForms { Name = name14, OtherForm = name13 });
            name14.OtherForms.Add(new OtherForms { Name = name14, OtherForm = name14 });
            name14.OtherForms.Add(new OtherForms { Name = name14, OtherForm = name19 });
            name14.OtherForms.Add(new OtherForms { Name = name14, OtherForm = name20 });

            name19.OtherForms.Add(new OtherForms { Name = name19, OtherForm = name1 });
            name19.OtherForms.Add(new OtherForms { Name = name19, OtherForm = name2 });
            name19.OtherForms.Add(new OtherForms { Name = name19, OtherForm = name7 });
            name19.OtherForms.Add(new OtherForms { Name = name19, OtherForm = name8 });
            name19.OtherForms.Add(new OtherForms { Name = name19, OtherForm = name13 });
            name19.OtherForms.Add(new OtherForms { Name = name19, OtherForm = name14 });
            name19.OtherForms.Add(new OtherForms { Name = name19, OtherForm = name19 });
            name19.OtherForms.Add(new OtherForms { Name = name19, OtherForm = name20 });

            name20.OtherForms.Add(new OtherForms { Name = name20, OtherForm = name1 });
            name20.OtherForms.Add(new OtherForms { Name = name20, OtherForm = name2 });
            name20.OtherForms.Add(new OtherForms { Name = name20, OtherForm = name7 });
            name20.OtherForms.Add(new OtherForms { Name = name20, OtherForm = name8 });
            name20.OtherForms.Add(new OtherForms { Name = name20, OtherForm = name13 });
            name20.OtherForms.Add(new OtherForms { Name = name20, OtherForm = name14 });
            name20.OtherForms.Add(new OtherForms { Name = name20, OtherForm = name19 });
            name20.OtherForms.Add(new OtherForms { Name = name20, OtherForm = name20 });

            name3.OtherForms.Add(new OtherForms { Name = name3, OtherForm = name3 });
            name3.OtherForms.Add(new OtherForms { Name = name3, OtherForm = name4 });
            name3.OtherForms.Add(new OtherForms { Name = name3, OtherForm = name9 });
            name3.OtherForms.Add(new OtherForms { Name = name3, OtherForm = name10 });
            name3.OtherForms.Add(new OtherForms { Name = name3, OtherForm = name15 });
            name3.OtherForms.Add(new OtherForms { Name = name3, OtherForm = name16 });
            name3.OtherForms.Add(new OtherForms { Name = name3, OtherForm = name21 });
            name3.OtherForms.Add(new OtherForms { Name = name3, OtherForm = name22 });

            name4.OtherForms.Add(new OtherForms { Name = name4, OtherForm = name3 });
            name4.OtherForms.Add(new OtherForms { Name = name4, OtherForm = name4 });
            name4.OtherForms.Add(new OtherForms { Name = name4, OtherForm = name9 });
            name4.OtherForms.Add(new OtherForms { Name = name4, OtherForm = name10 });
            name4.OtherForms.Add(new OtherForms { Name = name4, OtherForm = name15 });
            name4.OtherForms.Add(new OtherForms { Name = name4, OtherForm = name16 });
            name4.OtherForms.Add(new OtherForms { Name = name4, OtherForm = name21 });
            name4.OtherForms.Add(new OtherForms { Name = name4, OtherForm = name22 });

            name9.OtherForms.Add(new OtherForms { Name = name9, OtherForm = name3 });
            name9.OtherForms.Add(new OtherForms { Name = name9, OtherForm = name4 });
            name9.OtherForms.Add(new OtherForms { Name = name9, OtherForm = name9 });
            name9.OtherForms.Add(new OtherForms { Name = name9, OtherForm = name10 });
            name9.OtherForms.Add(new OtherForms { Name = name9, OtherForm = name15 });
            name9.OtherForms.Add(new OtherForms { Name = name9, OtherForm = name16 });
            name9.OtherForms.Add(new OtherForms { Name = name9, OtherForm = name21 });
            name9.OtherForms.Add(new OtherForms { Name = name9, OtherForm = name22 });

            name10.OtherForms.Add(new OtherForms { Name = name10, OtherForm = name3 });
            name10.OtherForms.Add(new OtherForms { Name = name10, OtherForm = name4 });
            name10.OtherForms.Add(new OtherForms { Name = name10, OtherForm = name9 });
            name10.OtherForms.Add(new OtherForms { Name = name10, OtherForm = name10 });
            name10.OtherForms.Add(new OtherForms { Name = name10, OtherForm = name15 });
            name10.OtherForms.Add(new OtherForms { Name = name10, OtherForm = name16 });
            name10.OtherForms.Add(new OtherForms { Name = name10, OtherForm = name21 });
            name10.OtherForms.Add(new OtherForms { Name = name10, OtherForm = name22 });

            name15.OtherForms.Add(new OtherForms { Name = name15, OtherForm = name3 });
            name15.OtherForms.Add(new OtherForms { Name = name15, OtherForm = name4 });
            name15.OtherForms.Add(new OtherForms { Name = name15, OtherForm = name9 });
            name15.OtherForms.Add(new OtherForms { Name = name15, OtherForm = name10 });
            name15.OtherForms.Add(new OtherForms { Name = name15, OtherForm = name15 });
            name15.OtherForms.Add(new OtherForms { Name = name15, OtherForm = name16 });
            name15.OtherForms.Add(new OtherForms { Name = name15, OtherForm = name21 });
            name15.OtherForms.Add(new OtherForms { Name = name15, OtherForm = name22 });

            name16.OtherForms.Add(new OtherForms { Name = name16, OtherForm = name3 });
            name16.OtherForms.Add(new OtherForms { Name = name16, OtherForm = name4 });
            name16.OtherForms.Add(new OtherForms { Name = name16, OtherForm = name9 });
            name16.OtherForms.Add(new OtherForms { Name = name16, OtherForm = name10 });
            name16.OtherForms.Add(new OtherForms { Name = name16, OtherForm = name15 });
            name16.OtherForms.Add(new OtherForms { Name = name16, OtherForm = name16 });
            name16.OtherForms.Add(new OtherForms { Name = name16, OtherForm = name21 });
            name16.OtherForms.Add(new OtherForms { Name = name16, OtherForm = name22 });

            name21.OtherForms.Add(new OtherForms { Name = name21, OtherForm = name3 });
            name21.OtherForms.Add(new OtherForms { Name = name21, OtherForm = name4 });
            name21.OtherForms.Add(new OtherForms { Name = name21, OtherForm = name9 });
            name21.OtherForms.Add(new OtherForms { Name = name21, OtherForm = name10 });
            name21.OtherForms.Add(new OtherForms { Name = name21, OtherForm = name15 });
            name21.OtherForms.Add(new OtherForms { Name = name21, OtherForm = name16 });
            name21.OtherForms.Add(new OtherForms { Name = name21, OtherForm = name21 });
            name21.OtherForms.Add(new OtherForms { Name = name21, OtherForm = name22 });

            name22.OtherForms.Add(new OtherForms { Name = name22, OtherForm = name3 });
            name22.OtherForms.Add(new OtherForms { Name = name22, OtherForm = name4 });
            name22.OtherForms.Add(new OtherForms { Name = name22, OtherForm = name9 });
            name22.OtherForms.Add(new OtherForms { Name = name22, OtherForm = name10 });
            name22.OtherForms.Add(new OtherForms { Name = name22, OtherForm = name15 });
            name22.OtherForms.Add(new OtherForms { Name = name22, OtherForm = name16 });
            name22.OtherForms.Add(new OtherForms { Name = name22, OtherForm = name21 });
            name22.OtherForms.Add(new OtherForms { Name = name22, OtherForm = name22 });

            name5.OtherForms.Add(new OtherForms { Name = name5, OtherForm = name5 });
            name5.OtherForms.Add(new OtherForms { Name = name5, OtherForm = name6 });
            name5.OtherForms.Add(new OtherForms { Name = name5, OtherForm = name11 });
            name5.OtherForms.Add(new OtherForms { Name = name5, OtherForm = name12 });
            name5.OtherForms.Add(new OtherForms { Name = name5, OtherForm = name17 });
            name5.OtherForms.Add(new OtherForms { Name = name5, OtherForm = name18 });
            name5.OtherForms.Add(new OtherForms { Name = name5, OtherForm = name23 });
            name5.OtherForms.Add(new OtherForms { Name = name5, OtherForm = name24 });

            name6.OtherForms.Add(new OtherForms { Name = name6, OtherForm = name5 });
            name6.OtherForms.Add(new OtherForms { Name = name6, OtherForm = name6 });
            name6.OtherForms.Add(new OtherForms { Name = name6, OtherForm = name11 });
            name6.OtherForms.Add(new OtherForms { Name = name6, OtherForm = name12 });
            name6.OtherForms.Add(new OtherForms { Name = name6, OtherForm = name17 });
            name6.OtherForms.Add(new OtherForms { Name = name6, OtherForm = name18 });
            name6.OtherForms.Add(new OtherForms { Name = name6, OtherForm = name23 });
            name6.OtherForms.Add(new OtherForms { Name = name6, OtherForm = name24 });

            name11.OtherForms.Add(new OtherForms { Name = name11, OtherForm = name5 });
            name11.OtherForms.Add(new OtherForms { Name = name11, OtherForm = name6 });
            name11.OtherForms.Add(new OtherForms { Name = name11, OtherForm = name11 });
            name11.OtherForms.Add(new OtherForms { Name = name11, OtherForm = name12 });
            name11.OtherForms.Add(new OtherForms { Name = name11, OtherForm = name17 });
            name11.OtherForms.Add(new OtherForms { Name = name11, OtherForm = name18 });
            name11.OtherForms.Add(new OtherForms { Name = name11, OtherForm = name23 });
            name11.OtherForms.Add(new OtherForms { Name = name11, OtherForm = name24 });

            name12.OtherForms.Add(new OtherForms { Name = name12, OtherForm = name5 });
            name12.OtherForms.Add(new OtherForms { Name = name12, OtherForm = name6 });
            name12.OtherForms.Add(new OtherForms { Name = name12, OtherForm = name11 });
            name12.OtherForms.Add(new OtherForms { Name = name12, OtherForm = name12 });
            name12.OtherForms.Add(new OtherForms { Name = name12, OtherForm = name17 });
            name12.OtherForms.Add(new OtherForms { Name = name12, OtherForm = name18 });
            name12.OtherForms.Add(new OtherForms { Name = name12, OtherForm = name23 });
            name12.OtherForms.Add(new OtherForms { Name = name12, OtherForm = name24 });

            name17.OtherForms.Add(new OtherForms { Name = name17, OtherForm = name5 });
            name17.OtherForms.Add(new OtherForms { Name = name17, OtherForm = name6 });
            name17.OtherForms.Add(new OtherForms { Name = name17, OtherForm = name11 });
            name17.OtherForms.Add(new OtherForms { Name = name17, OtherForm = name12 });
            name17.OtherForms.Add(new OtherForms { Name = name17, OtherForm = name17 });
            name17.OtherForms.Add(new OtherForms { Name = name17, OtherForm = name18 });
            name17.OtherForms.Add(new OtherForms { Name = name17, OtherForm = name23 });
            name17.OtherForms.Add(new OtherForms { Name = name17, OtherForm = name24 });

            name18.OtherForms.Add(new OtherForms { Name = name18, OtherForm = name5 });
            name18.OtherForms.Add(new OtherForms { Name = name18, OtherForm = name6 });
            name18.OtherForms.Add(new OtherForms { Name = name18, OtherForm = name11 });
            name18.OtherForms.Add(new OtherForms { Name = name18, OtherForm = name12 });
            name18.OtherForms.Add(new OtherForms { Name = name18, OtherForm = name17 });
            name18.OtherForms.Add(new OtherForms { Name = name18, OtherForm = name18 });
            name18.OtherForms.Add(new OtherForms { Name = name18, OtherForm = name23 });
            name18.OtherForms.Add(new OtherForms { Name = name18, OtherForm = name24 });

            name23.OtherForms.Add(new OtherForms { Name = name23, OtherForm = name5 });
            name23.OtherForms.Add(new OtherForms { Name = name23, OtherForm = name6 });
            name23.OtherForms.Add(new OtherForms { Name = name23, OtherForm = name11 });
            name23.OtherForms.Add(new OtherForms { Name = name23, OtherForm = name12 });
            name23.OtherForms.Add(new OtherForms { Name = name23, OtherForm = name17 });
            name23.OtherForms.Add(new OtherForms { Name = name23, OtherForm = name18 });
            name23.OtherForms.Add(new OtherForms { Name = name23, OtherForm = name23 });
            name23.OtherForms.Add(new OtherForms { Name = name23, OtherForm = name24 });

            name24.OtherForms.Add(new OtherForms { Name = name24, OtherForm = name5 });
            name24.OtherForms.Add(new OtherForms { Name = name24, OtherForm = name6 });
            name24.OtherForms.Add(new OtherForms { Name = name24, OtherForm = name11 });
            name24.OtherForms.Add(new OtherForms { Name = name24, OtherForm = name12 });
            name24.OtherForms.Add(new OtherForms { Name = name24, OtherForm = name17 });
            name24.OtherForms.Add(new OtherForms { Name = name24, OtherForm = name18 });
            name24.OtherForms.Add(new OtherForms { Name = name24, OtherForm = name23 });
            name24.OtherForms.Add(new OtherForms { Name = name24, OtherForm = name24 });

            _words.AddRange(_names);
            sortWordsAlphabetically(_names);
            saveWords();

            name1.MotherName = name3.Description;
            name1.ChildName = name5.Description;
            name1.FatherName = name1.Description;

            name2.MotherName = name3.Description;
            name2.ChildName = name5.Description;
            name2.FatherName = name1.Description;

            name3.MotherName = name3.Description;
            name3.ChildName = name5.Description;
            name3.FatherName = name1.Description;

            name4.MotherName = name3.Description;
            name4.ChildName = name5.Description;
            name4.FatherName = name1.Description;

            name5.MotherName = name3.Description;
            name5.ChildName = name5.Description;
            name5.FatherName = name1.Description;

            name6.MotherName = name3.Description;
            name6.ChildName = name5.Description;
            name6.FatherName = name1.Description;

            name7.MotherName = name3.Description;
            name7.ChildName = name5.Description;
            name7.FatherName = name1.Description;

            name8.MotherName = name3.Description;
            name8.ChildName = name5.Description;
            name8.FatherName = name1.Description;

            name9.MotherName = name3.Description;
            name9.ChildName = name5.Description;
            name9.FatherName = name1.Description;

            name10.MotherName = name3.Description;
            name10.ChildName = name5.Description;
            name10.FatherName = name1.Description;

            name11.MotherName = name3.Description;
            name11.ChildName = name5.Description;
            name11.FatherName = name1.Description;

            name12.MotherName = name3.Description;
            name12.ChildName = name5.Description;
            name12.FatherName = name1.Description;

            name13.MotherName = name3.Description;
            name13.ChildName = name5.Description;
            name13.FatherName = name1.Description;

            name14.MotherName = name3.Description;
            name14.ChildName = name5.Description;
            name14.FatherName = name1.Description;

            name15.MotherName = name3.Description;
            name15.ChildName = name5.Description;
            name15.FatherName = name1.Description;

            name16.MotherName = name3.Description;
            name16.ChildName = name5.Description;
            name16.FatherName = name1.Description;

            name17.MotherName = name3.Description;
            name17.ChildName = name5.Description;
            name17.FatherName = name1.Description;

            name18.MotherName = name3.Description;
            name18.ChildName = name5.Description;
            name18.FatherName = name1.Description;

            name19.MotherName = name3.Description;
            name19.ChildName = name5.Description;
            name19.FatherName = name1.Description;

            name20.MotherName = name3.Description;
            name20.ChildName = name5.Description;
            name20.FatherName = name1.Description;

            name21.MotherName = name3.Description;
            name21.ChildName = name5.Description;
            name21.FatherName = name1.Description;

            name22.MotherName = name3.Description;
            name22.ChildName = name5.Description;
            name22.FatherName = name1.Description;

            name23.MotherName = name3.Description;
            name23.ChildName = name5.Description;
            name23.FatherName = name1.Description;

            name24.MotherName = name3.Description;
            name24.ChildName = name5.Description;
            name24.FatherName = name1.Description;

            //_words.AddRange(_names);            

            updateWords();

        }

        private void sortWordsAlphabetically(List<Word> words)
        {
            words.Sort();
            WordsToPresent.Clear();
            words.ForEach(w => WordsToPresent.Add(w));
        }

        public void SearchNamesBeginningWith(string searchWord)
        {
            List<Word> words = new List<Word>();

            string searchw = searchWord.ToLower();

            words = _words.Where(w => w.Description.ToLower().StartsWith(searchw) ||
            w.PtDescription.ToLower().StartsWith(searchw)
            || (w is Name && ((Name)w).Article.Description.ToLower().StartsWith(searchw))).ToList();

            _wordsToPresent.Clear();
            words.ForEach(w => this.WordsToPresent.Add(w));
            this.WordsToPresent.OrderBy(w => w.Description);
        }

        private void saveArticles()
        {
            using (var db = new WordsContext())
            {
                db.Words.AddRange(_articles);
                db.SaveChanges();
            }
        }

        private void saveWords()
        {
            using (var db = new WordsContext())
            {
                db.Words.AddRange(_words);
                db.SaveChanges();
            }
        }

        private void updateWords()
        {
            using (var db = new WordsContext())
            {
                db.Words.UpdateRange(_words);
                db.SaveChanges();
            }
        }

        private void loadWords()
        {
            using (var db = new WordsContext())
            {
                //_words = new List<Word>(db.Words.ToList());
                _names = new List<Word>(db.Words.Where(n => n is Name).Include(w => ((Name)w).OtherForms)
                    .Include(w => ((Name)w).Article).ToList());
                _articles = new List<Word>(db.Words.Where(n => n is Article).ToList());
                _verbs = new List<Word>(db.Words.Where(n => n is Verb).ToList());
                sortWordsAlphabetically(_names);
            }
        }

        private List<Name> loadNamesFromWordsList(List<Word> names)
        {
            List<Name> result = new List<Name>();
            foreach (Name name in names)
            {
                result.Add(name);
            }
            return result;
        }

        #endregion

    }
}
