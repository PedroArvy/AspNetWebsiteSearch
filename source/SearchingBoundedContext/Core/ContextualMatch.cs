using SearchingBoundedContext.Core;
using SearchingBoundedContext.Core.Parts;

namespace SearchingBoundedContext
{

  public class ContextualMatch
  {
    /// <summary>
    ///   ...searched for the term <strong>dog</strong> in this website and...
    ///   ...and as you know the <strong>cat</strong> will hate your <strong>dog</strong>...    
    /// </summary>
    public IEnumerable<Line> Lines { get; private set; }


    public ContextualMatch(IEnumerable<Line> lines)
    {
      Lines = lines;
    }


    public string Display()
    {
      string results = "";

      foreach(Line line in Lines)
      {
        results += line.Display();
      }

      return results;
    }
  }
}