namespace Apopad.Common.Search
{
    public interface IFilter
    {
        bool filter_str(string s, string t, int k, string[] s_ary, string[] t_ary);
    }
}
