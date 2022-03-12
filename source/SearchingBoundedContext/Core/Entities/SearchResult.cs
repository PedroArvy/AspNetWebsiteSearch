using Searching.Logic.Core.ValueObjects;

namespace Searching.Logic.Core.Entities
{
  /// <summary>

  /// </summary>
  public class SearchResult : Entity
  {

    public IEnumerable<ContextualMatch> ContextualMatches { get; set; }

    public string Title { get; set; }


    public SearchResult(IEnumerable<ContextualMatch> contextualMatches, string title, Uri webPageAddress)
    {
      ContextualMatches = contextualMatches;
      Title = title;
      Uri = webPageAddress;
    }


  }
}