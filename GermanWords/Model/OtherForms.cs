using System;

namespace GermanWords.Model
{
    public class OtherForms : IComparable
    {
        public long NameId { get; set; }
        public Name Name { get; set; }

        public long OtherFormId { get; set; }
        public Name OtherForm { get; set; }

        public int CompareTo(object obj)
        {
            OtherForms of = (OtherForms)obj;

            if (this.OtherForm.Article.ArticleType < of.OtherForm.Article.ArticleType)
            {
                return -1;
            }
            else if (this.OtherForm.Article.ArticleType > of.OtherForm.Article.ArticleType)
            {
                return 1;
            }
            else
            {
                if (this.OtherForm.Number < of.OtherForm.Number)
                    return -1;
                else
                    return 1;
            }
        }

        public override string ToString()
        {
            return OtherForm.ToString();
        }

    }
}
