namespace GermanWords.Model
{
    public class OtherForms
    {
        public long NameId { get; set; }
        public Name Name { get; set; }

        public long OtherFormId { get; set; }
        public Name OtherForm { get; set; }

        public override string ToString()
        {
            return OtherForm.ToString();
        }

    }
}
