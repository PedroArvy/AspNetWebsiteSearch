using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.Logic.Core.ValueObjects.Parts
{
  internal class Text
  {
    public string Content { get; set; }

    public Text(string text)
    {
      Content = text;
    }

    public string Display()
    {
      return Content;
    }

  }
}
