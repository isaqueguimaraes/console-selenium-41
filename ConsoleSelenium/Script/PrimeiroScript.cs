using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleSelenium.Script
{
  public class PrimeiroScript
  {
    public static void Automatizar_Envio_Texto_ComSucesso()
    {
      IWebDriver driver = new ChromeDriver();

      driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

      var titulo = driver.Title;
      Console.WriteLine($"Titulo da pagina: {titulo}");

      driver.Manage()
      .Timeouts()
      .ImplicitWait = TimeSpan.FromSeconds(2);

      var textBox = driver.FindElement(By.Name("my-text"));
      textBox.SendKeys("Daniel o melhor professor da minha vida");

      var submitButton = driver.FindElement(By.TagName("button"));
      submitButton.Click();

      var message = driver.FindElement(By.Id("message"));
      Console.WriteLine($"Mensagem de sucesso: {message.Text}");
      Console.ReadLine();
      driver.Quit();
    }
  }
}