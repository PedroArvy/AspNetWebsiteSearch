using HtmlAgilityPack;
using Indexing.Logic.Core.Entities;
using System.Text.RegularExpressions;


namespace Indexing.Logic.Factories
{
  public class UriToWebPage
  {


    public async static Task<WebPage> Make(Uri uri)
    {
      string html = await GetPageContentAsync(uri);

      HtmlDocument document = new HtmlDocument();
      document.LoadHtml(html);

      return Make(uri, document);
    }


    public static WebPage Make(Uri uri, HtmlDocument document)
    {
      string title = Title(document);
      string searchableText = SearchableText(document.DocumentNode.SelectSingleNode("//html/body"));

      return new WebPage(uri, title, searchableText);
    }


    public async static Task<string> GetPageContentAsync(Uri uri)
    {
      using var client = new HttpClient();
      var content = await client.GetStringAsync(uri);
      return content;
    }


    public static string SearchableText(HtmlDocument document)
    {
      string text = SearchableText(document.DocumentNode);

      text = text.Trim();
      text = Regex.Replace(text, @"\s+", " ");

      return text;
    }


    public static string SearchableText(HtmlNode node)
    {
      string text = "";

      if(node != null)
      {
        foreach (var child in node.ChildNodes)
        {
          if (child.HasChildNodes)
          {
            text += " " + SearchableText(child);
          }
          else
          {
            text += child.InnerText;
          }
        }
      }

      text = text.Trim();
      text = Regex.Replace(text, @"\s+", " ");

      return text;
    }


    private static string Title(HtmlDocument document)
    {
      string title = "";

      var titleNode = document.DocumentNode.SelectSingleNode("//html/title");


      if (titleNode != null)
      {
        title = titleNode.InnerText;
      }

      return title;
    }



  }
}
