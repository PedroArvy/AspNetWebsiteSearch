using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingBoundedContext.Core.Parts
{
  /// <summary>
  /// <strong>dog</strong>
  /// </summary>
  internal class MatchedTerm : IPart
  {
    public string Term { get; private set; }
    public string Tag { get; private set; }

    public MatchedTerm(string term, string tag)
    {
      Term = term;
      Tag = tag;
    }

    public string Display()
    {
      return $"<Tag>{Term}</Tag>";
    }

  }
}
