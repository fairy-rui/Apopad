namespace Apopad.Common.Search
{
    public interface IAnalyser
    {
        double GetLikenessValue(string needle, string haystack);
    }
}
