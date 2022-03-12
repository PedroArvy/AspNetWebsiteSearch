using Indexing.Logic.Core.Entities;


namespace Indexing.Logic.Core.Aggregates
{
  public class WebSite
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


    public bool Exists(WebPage webPage) => WebPages.Any(w => w.Uri == webPage.Uri);

    
    public bool Update(WebPage webPage)
    {
      bool updated = false;

      WebPage page = WebPages.FirstOrDefault(w => w.Uri == webPage.Uri);

      if(page != null)
      {
        page.Title = webPage.Title;
        page.Content = webPage.Content;    
      }

      return updated;
    }

  }

}