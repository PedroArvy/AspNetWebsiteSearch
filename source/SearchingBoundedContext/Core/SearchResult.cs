using SearchingBoundedContext.Core.Parts;

namespace SearchingBoundedContext
{
  /// <summary>

  /// </summary>
  public class SearchResult
  {
    public Uri WebPageAddress { get; private set; }

    public IEnumerable<ContextualMatch> ContextualMatches { get; private set; }

    public SearchResult(Uri webPageAddress, IEnumerable<ContextualMatch> contextualMatches)
    {
      WebPageAddress = webPageAddress;
      ContextualMatches = contextualMatches;
    }

  }
}