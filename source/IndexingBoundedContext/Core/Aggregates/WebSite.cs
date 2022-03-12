using System;
using System.Collections.Generic;
using System.Linq;

namespace IndexingBoundedContext.Core.Aggregates
{
  public sealed class WebSite
  {
    private List<WebPage> WebPages = new List<WebPage>();

    public WebSite()
    {
    }

    public void Add(WebPage webPage)
    {
      if (Exists(webPage))
      {
        throw new Exception($"{webPage.Title} already exists!");
      }

      WebPages.Add(webPage);
    }


    public void Delete(WebPage webPage)
    {
      WebPages.Remove(webPage);
    }


    public bool Exists(WebPage webPage) => WebPages.Any(w => w.Address == webPage.Address);

    
    public bool Update(WebPage webPage)
    {
      bool updated = false;

      WebPage page = WebPages.FirstOrDefault(w => w.Address == webPage.Address);

      if(page != null)
      {
        page.Title = webPage.Title;
        page.Content = webPage.Content;    
      }

      return updated;
    }

  }

}