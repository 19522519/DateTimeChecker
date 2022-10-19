using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DateTimeChecker;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UnitTest
{
    [TestFixture]
    public class MyTesting
    {
        static IWebDriver driver;

        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver(@"C:\Users\Tan Viet\Downloads\chromedriver_win32");
        }

        [Test]
        public void isCorrectDateTime_Test1()
        {
            driver.Url = "http://www.google.co.in";
            DateTimeChecker.Form1 form1 = new DateTimeChecker.Form1();
            Boolean c = form1.isCorrectDateTime(30,4,1975);
            Assert.That(c, Is.EqualTo(true));
        }

        [Test]
        public void isCorrectDateTime_Test2()
        {
            driver.Url = "http://www.google.co.in";
            DateTimeChecker.Form1 form1 = new DateTimeChecker.Form1();
            Boolean c = form1.isCorrectDateTime(29, 2, 1900);
            Assert.That(c, Is.EqualTo(false));
        }

        [Test]
        public void isOutOfRange_Test1()
        {
            driver.Url = "http://www.google.co.in";
            DateTimeChecker.Form1 form1 = new DateTimeChecker.Form1();
            Boolean c = form1.isOutOfRange(1, 1, 4000);
            Assert.That(c, Is.EqualTo(false));
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
