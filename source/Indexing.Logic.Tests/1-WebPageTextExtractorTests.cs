using HtmlAgilityPack;
using Indexing.Logic.Core.Entities;
using Indexing.Logic.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Indexing.Logic.Tests
{
  [TestClass]
  public class WebPageTextExtractorTests
  {
    [TestMethod]
    public void TestSearchableText()
    {

      string extracted = UriToWebPage.SearchableText(MakeDocument("I am <p>text to be</p> extracted"));
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = UriToWebPage.SearchableText(MakeDocument("I am <div>text <div>to</div> be</<div> extracted"));
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = UriToWebPage.SearchableText(MakeDocument("I am <div>text <div>to</div> <a href=\"http://www.yart.com.au\">be</a></<div> extracted"));
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = UriToWebPage.SearchableText(MakeDocument("I am <div>text <div><div><div>to</div></div></div> <div><a href=\"http://www.yart.com.au\">be</a></div></<div> extracted"));
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = UriToWebPage.SearchableText(MakeDocument("I                am <p>text to be</p> extracted"));
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = UriToWebPage.SearchableText(MakeDocument("        I                am <p>text to be</p> extracted     "));
      Assert.AreEqual(extracted, "I am text to be extracted");

      //invalid html
      extracted = UriToWebPage.SearchableText(MakeDocument("I am <div>text to</div> be</<div> extracted"));
      Assert.AreEqual(extracted, "I am text to be extracted");

      //invalid html
      extracted = UriToWebPage.SearchableText(MakeDocument("I am <div>text to<div> be<div> extracted"));
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = UriToWebPage.SearchableText(MakeDocument(""));
      Assert.AreEqual(extracted, "");

      extracted = UriToWebPage.SearchableText(MakeDocument("   "));
      Assert.AreEqual(extracted, "");

    }


    private HtmlDocument MakeDocument(string str)
    {
      HtmlDocument document = new HtmlDocument();
      document.LoadHtml(str);

      return document;
    }




    [TestMethod]
    public void UriToWebPageTests()
    {
      //Uri uri = new System.Uri("https://www.yart.com.au/blog/woocommerce-hike-pos-plugin-to-improve-synchronisation/");

      WebPage page = UriToWebPage.Make(new Uri("http://www.abc.com"), MakeDocument("<!DOCTYPE html><html><title>The Title</title><body><h1>Heading</h1><p>Text</p></body></html>"));
      Assert.AreEqual(page.Title, "The Title");
      Assert.AreEqual(page.SearchableText, "Heading Text");
      Assert.AreEqual(page.Uri, new Uri("http://www.abc.com"));

    }


  }
}