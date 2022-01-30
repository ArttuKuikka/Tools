string getvideoid(string url)
{
    if (url == null) { throw new ArgumentNullException("url"); }

    var uri = new Uri(url);
    var viewParam = System.Web.HttpUtility.ParseQueryString(uri.Query).Get("v");
    if (viewParam == null)
    {
        if (url.Contains("youtube.com/v/") || url.Contains("youtu.be/"))
        {
            viewParam = url.Substring(url.LastIndexOf("/") + 1);
            if (viewParam.Length > 10)
            {
                char[] charArray = viewParam.ToCharArray();
                Array.Reverse(charArray);
                var tempstr = new string(charArray);
                tempstr = tempstr.Remove(0, tempstr.Length - 11);
                char[] charArray2 = tempstr.ToCharArray();
                Array.Reverse(charArray2);
                viewParam = new string(charArray2);
            }

        }
        else
        {
            throw new Exception("Can't parse the url");
        }
    }

    if (viewParam == null || viewParam == "") { throw new Exception("Can't parse the url"); }

    return viewParam;
}



string GetBetween(string strSource, string strStart, string strEnd)
{
    if (strSource.Contains(strStart) && strSource.Contains(strEnd))
    {
        int Start, End;
        Start = strSource.IndexOf(strStart, 0) + strStart.Length;
        End = strSource.IndexOf(strEnd, Start);
        return strSource.Substring(Start, End - Start);
    }

    return "";
}