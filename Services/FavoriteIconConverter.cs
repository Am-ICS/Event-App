using System.Globalization;

namespace EventsApp.Services;

public class FavoriteIconConverter : IValueConverter, IMarkupExtension
{
    public object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        bool isFavorite = value is bool favorite && favorite;

        if (isFavorite)
        {
            return "♥";
        }

        return "♡";
    }

    public object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        return value;
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}