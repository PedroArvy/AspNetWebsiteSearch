using Indexing.Logic.ValueObjects;

namespace Indexing.Logic.Core.Entities
{
  public class WebPage : Entity
  {

    public TextWithoutHTML Title { get; set; }

    public TextWithoutHTML Content { get; set; }

    public WebPage(Uri address, TextWithoutHTML title, TextWithoutHTML content)
    {
      Uri = address;
      Title = title;
      Content = content;
    }


  }
}