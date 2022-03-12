using SearchingBoundedContext.Core.Entities;
using System;
using System.Collections.Generic;

namespace SearchingBoundedContext.Core.Aggregates
{
  /// <summary>

  /// </summary>
  public class SearchResult
  {

    public IEnumerable<ContextualMatch> ContextualMatches { get; private set; }

    public string Title { get; set; }

    public Uri WebPageAddress { get; private set; }


    public SearchResult(IEnumerable<ContextualMatch> contextualMatches, string title, Uri webPageAddress)
    {
      ContextualMatches = contextualMatches;
      Title = title;
      WebPageAddress = webPageAddress;
    }

  }
}