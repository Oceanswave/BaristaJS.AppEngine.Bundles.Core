﻿namespace BaristaJS.AppEngine.Bundles.WebDriver
{
  using System;
  using OpenQA.Selenium;

  public class CookieInstance
  {
    private readonly Cookie m_cookie;

    public CookieInstance(Cookie cookie)
    {
      if (cookie == null)
        throw new ArgumentNullException("cookie");

      m_cookie = cookie;
    }

    public Cookie Cookie
    {
      get
      {
        return m_cookie;
      }
    }

    [ScriptMember(Name = "domain")]
    public string Domain
    {
      get
      {
        return m_cookie.Domain;
      }
    }

    [ScriptMember(Name = "value")]
    public string Value
    {
      get
      {
        return m_cookie.Value;
      }
    }

    [ScriptMember(Name = "toString")]
    public override string ToString()
    {
      return m_cookie.ToString();
    }
  }
}
