using Indexing.Logic.ValueObjects;

namespace Indexing.Logic.Core.Entities
{
  public class WebPage : Entity
  {

    public string Title { get; set; }

    public string SearchableText { get; set; }

    public WebPage(Uri address, string title, string content)
    {
      Uri = address;
      Title = title;
      SearchableText = content;
    }


  }
}