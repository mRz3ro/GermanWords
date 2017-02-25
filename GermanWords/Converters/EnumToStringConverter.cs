using GermanWords.Model;
using System;
using Windows.UI.Xaml.Data;

namespace GermanWords.Converters
{
    class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            switch ((string)parameter.ToString())
            {
                case "wordtype":

                    WordType wordType = (WordType)value;

                    switch (wordType)
                    {
                        case WordType.Article:
                            return "Artikel";
                        case WordType.Name:
                            return "Name";
                        case WordType.Verb:
                            return "Verb";
                    }

                    break;
                case "genre":

                    Genre genre = (Genre)value;

                    switch (genre)
                    {
                        case Genre.Female:
                            return "Weiblich";
                        case Genre.Male:
                            return "Männlich";
                        case Genre.Neuter:
                            return "Neutrum";
                    }

                    break;
                case "number":

                    Number number = (Number)value;

                    switch (number.ToString())
                    {
                        case "Singular":
                            return "Einzahl";
                        case "Plural":
                            return "Mehrzahl";
                    }

                    break;
                case "parental":

                    Parental parental = (Parental)value;

                    switch (parental)
                    {
                        case Parental.Mother:
                            return "Mutter";
                        case Parental.Father:
                            return "Vater";
                        case Parental.Child:
                            return "Kind";
                        default: return "";
                    }
                case "articletype":

                    Case articletype = (Case)value;

                    switch (articletype)
                    {
                        case Case.Nominative:
                            return "Nominativ (Active) Wer? Was?";
                        case Case.Accusative:
                            return "Akkusativ (Passive) Wen? Was?";
                        case Case.Dative:
                            return "Dativ (2nd Active) Wem?";
                        case Case.Genitive:
                            return "Genitiv (Wessen?)";
                        default: return "";
                    }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Case.Accusative;
        }
    }
}
