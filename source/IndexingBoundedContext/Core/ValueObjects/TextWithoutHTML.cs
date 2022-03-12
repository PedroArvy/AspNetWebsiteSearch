using System;

namespace Indexing.Logic.ValueObjects
{
  /// <summary>
  /// Text with no tags
  /// </summary>
  public class TextWithoutHTML
  {

    public string Content { get; private set; }


    public TextWithoutHTML(string textWithoutHTML)
    {
      if (HasTags(textWithoutHTML))
      {
        throw new ArgumentException($"{textWithoutHTML} contains HTML tags");
      }

      Content = textWithoutHTML;
    }


    public bool HasTags(string content)
    {
      bool hasTags = false;

      return hasTags;
    }


  }
}