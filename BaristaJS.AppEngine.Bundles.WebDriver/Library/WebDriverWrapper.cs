﻿namespace BaristaJS.AppEngine.Bundles.WebDriver
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using OpenQA.Selenium;

  public class WebDriverWrapper<T> : IWebDriver
    where T : class, IWebDriver
  {
    private readonly T m_webDriver;

    public WebDriverWrapper(T webDriver)
    {
      if (webDriver == null)
        throw new ArgumentNullException("webDriver");

      m_webDriver = webDriver;
    }

    #region Properties
    public T WebDriver 
    {
      get { return m_webDriver; }
    }

    [ScriptMember(Name = "currentWindowHandle")]
    public string CurrentWindowHandle
    {
      get { return m_webDriver.CurrentWindowHandle; }
    }

    [ScriptMember(Name = "pageSource")]
    public string PageSource
    {
      get { return m_webDriver.PageSource; }
    }

    [ScriptMember(Name = "title")]
    public string Title
    {
      get { return m_webDriver.Title; }
    }

    [ScriptMember(Name = "url")]
    public string Url
    {
      get { return m_webDriver.Url; }
      set { m_webDriver.Url = value; }
    }

    //TODO: Figure out what to do with this...
    public ReadOnlyCollection<string> WindowHandles
    {
      get { return m_webDriver.WindowHandles; }
    }
    #endregion

    [ScriptMember(Name="close")]
    public void Close()
    {
      m_webDriver.Close();
    }

    [ScriptMember(Name = "manage")]
    public IOptions Manage()
    {
      return new OptionsWrapper(m_webDriver.Manage());
    }

    public INavigation Navigate()
    {
      return new NavigationWrapper(m_webDriver.Navigate());
    }

    [ScriptMember(Name = "quit")]
    public void Quit()
    {
      m_webDriver.Quit();
    }

    [ScriptMember(Name = "switchTo")]
    public ITargetLocator SwitchTo()
    {
      return new TargetLocatorWrapper(m_webDriver.SwitchTo());
    }

    [ScriptMember(Name = "findElement")]
    public IWebElement FindElement(By by)
    {
      return new WebElementWrapper(m_webDriver.FindElement(by));
    }

    [ScriptMember(Name = "findElements")]
    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
      var result = new List<IWebElement>();
      result.AddRange(m_webDriver.FindElements(by));
      return result.AsReadOnly();
    }

    public void Dispose()
    {
      m_webDriver.Dispose();
    }
  }
}