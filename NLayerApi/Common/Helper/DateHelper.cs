namespace Common.Helper;

public static class DateHelper
{
    public static bool IsNewShop(DateTime shopFlagDate)
    {
        return (DateTime.Now - shopFlagDate).Days <= 60;
    }
}
