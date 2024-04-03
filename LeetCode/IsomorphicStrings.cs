// See https://aka.ms/new-console-template for more information

using System.Linq;
using System.Xml.Schema;

bool IsIsomorphic(string s, string t)
{
    if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length != t.Length || s.Distinct().Count() != t.Distinct().Count())
    {
        return false;
    }

    var dictChar = new Dictionary<char, char>();
    for (int i = 0; i < s.Length; i++)
    {
        if (dictChar.ContainsKey(t[i]) && dictChar[t[i]] != s[i])
        {
            return false;
        }

        if (!dictChar.ContainsKey(t[i]))
        {
            dictChar[t[i]] = s[i];
        }
    }

    var newString = string.Empty;
    for (int i = 0; i < s.Length; i++)
    {
        if (dictChar.ContainsKey(t[i]))
        {
            newString += t[i];
        }
        else
        {
            newString += s[i];
        }
    }

    return newString == t;
}

var s = "foo";
var t = "bar";
Console.WriteLine(IsIsomorphic(s, t));