using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Indexing.Logic.Utilities
{
  /// <summary>
  /// Utilities for extracting text from HTML
  /// </summary>
  public class WebPageExtracter
  {


    public static string SearchableText(string html)
    {
      HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

      doc.LoadHtml(html);

      string text = SearchableText(doc.DocumentNode);

      text = text.Trim();
      text = Regex.Replace(text, @"\s+", " ");

      return text;
    }

    public static string SearchableText(HtmlNode node)
    {
      string text = "";

      foreach(var child in node.ChildNodes)
      {
        if(child.HasChildNodes)
        {
          text += SearchableText(child);
        }
        else
        {
          text += child.InnerText;
        }
      }

      return text;
    }

  }



}
