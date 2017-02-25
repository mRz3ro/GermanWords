using GermanWords.Model;
using System;
using Windows.UI.Xaml.Data;

namespace GermanWords.Converters
{
    class EnumToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            if (value == null)
                return 1.0;

            Genre genre;
            Number number;

            switch ((string)parameter)
            {
                case "Male":

                    genre = (Genre)value;

                    if (genre.ToString().Equals(Genre.Male.ToString()))
                        return 1.0;
                    else
                        return 0.1;

                case "Female":

                    genre = (Genre)value;

                    if (genre.ToString().Equals(Genre.Female.ToString()))
                        return 1.0;
                    else
                        return 0.1;

                case "Singular":

                    number = (Number)value;

                    if (number.ToString().Equals("Singular"))
                        return 1.0;
                    else
                        return 0.1;

                case "Plural":

                    number = (Number)value;

                    if (number.ToString().Equals("Plural"))
                        return 1.0;
                    else
                        return 0.1;
            }

            return 1.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Case.Accusative;
        }
    }
}
