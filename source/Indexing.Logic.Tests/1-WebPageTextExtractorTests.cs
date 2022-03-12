using Indexing.Logic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Indexing.Logic.Tests
{
  [TestClass]
  public class WebPageTextExtractorTests
  {
    [TestMethod]
    public void TestMethod1()
    {

      string extracted = WebPageExtracter.SearchableText("I am <p>text to be</p> extracted");
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = WebPageExtracter.SearchableText("I am <div>text <div>to</div> be</<div> extracted");
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = WebPageExtracter.SearchableText("I am <div>text <div>to</div> <a href=\"http://www.yart.com.au\">be</a></<div> extracted");
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = WebPageExtracter.SearchableText("I am <div>text <div><div><div>to</div></div></div> <div><a href=\"http://www.yart.com.au\">be</a></div></<div> extracted");
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = WebPageExtracter.SearchableText("I                am <p>text to be</p> extracted");
      Assert.AreEqual(extracted, "I am text to be extracted");

      extracted = WebPageExtracter.SearchableText("        I                am <p>text to be</p> extracted     ");
      Assert.AreEqual(extracted, "I am text to be extracted");

      //invalid html
      extracted = WebPageExtracter.SearchableText("I am <div>text to</div> be</<div> extracted");
      Assert.AreEqual(extracted, "I am text to be extracted");

      //invalid html
      extracted = WebPageExtracter.SearchableText("I am <div>text to<div> be<div> extracted");
      Assert.AreEqual(extracted, "I am text to be extracted");

    }
  }
}