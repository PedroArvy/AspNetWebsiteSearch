using System;

namespace IndexingBoundedContext.Core.Aggregates
{
  public class WebPage
  {
    public Uri Address { get; private set; }

    public TextWithoutHTML Title { get; set; }

    public TextWithoutHTML Content { get; set; }

    public WebPage(Uri address, TextWithoutHTML title, TextWithoutHTML content)
    {
      Address = address;
      Title = title;
      Content = content;
    }


  }
}