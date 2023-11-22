using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using Protractor;


namespace CSharpNUnit;

public class Tests
{

    public NgWebDriver _ngDriver;
    public IDictionary<string, object> vars { get; private set; }
    public IJavaScriptExecutor js;



    [SetUp]
    public void Setup()
    {
  

        // ChromeOptions
        ChromeOptions options = new ChromeOptions();
        options.BrowserVersion = "latest";
        options.PlatformName = "Windows 10";

        // Set LambdaTest specific capabilities
        options.AddAdditionalOption("user", "LT_USERNAME");
        options.AddAdditionalOption("accessKey", "LT_ACCESS_KEY");
        options.AddAdditionalOption("build", "NUnit Protractor Test");
        options.AddAdditionalOption("name", "CSharpNGTest");

        // Initialize RemoteWebDriver with LambdaTest Hub URL
        RemoteWebDriver remoteWebDriver = new RemoteWebDriver(
            new Uri("https://LT_USERNAME:LT_ACCESS_KEY@hub.lambdatest.com/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));

        // Wrap RemoteWebDriver in NgWebDriver
        _ngDriver = new NgWebDriver(remoteWebDriver);
        js = (IJavaScriptExecutor)_ngDriver.WrappedDriver;
        vars = new Dictionary<string, object>();


    }

    [Test]
    public void Test1()
    {

        _ngDriver.Navigate().GoToUrl("https://todomvc.com/examples/angularjs/");
    

        ((IJavaScriptExecutor)_ngDriver).ExecuteScript("lambda-status=passed");
        ((IJavaScriptExecutor)_ngDriver).ExecuteScript("lambda-file-stats=test.xlsx");




    }

    [TearDown]
    protected void TearDown()
    {
        _ngDriver.Quit();
    }

}
