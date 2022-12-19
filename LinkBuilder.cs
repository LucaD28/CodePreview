public class LinkBuilder{
    public static string Build(string link, string version){
            string endOfLink = link;
            int i = endOfLink.IndexOf('{');
            endOfLink = endOfLink.Substring(i+15);
            string startOfLink = link;
            int j = startOfLink.IndexOf('{');
            startOfLink = startOfLink.Substring(0, j);
            string middleOfLink = "v" + version;
            string newLink = startOfLink + middleOfLink + endOfLink;
            return newLink;
    }
}