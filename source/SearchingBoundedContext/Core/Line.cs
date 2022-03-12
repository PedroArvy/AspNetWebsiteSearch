using SearchingBoundedContext.Core.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingBoundedContext.Core
{
  /// <summary>
  ///   ...searched for the term <strong>dog</strong> in this website and...
  /// </summary>
  public class Line
  {
    public bool LeftIsStart { get; private set; }

    public bool RightIsEnd { get; private set; }

    public IEnumerable<IPart> Parts { get; private set; }

    public Line(int dotsBeforeAndAfter, IEnumerable<IPart> parts)
    {
      Parts = parts;
    }

    public string Display()
    {
      string str = "";

      foreach (IPart part in Parts)
      {
        str += part.Display();
      }

      if (!string.IsNullOrWhiteSpace(str))
      {
        if (LeftIsStart)
        {
          str = "..." + str;
        }

        if(RightIsEnd)
        {
          str += "...";
        }
      }

      return str;
    }


  }
}
