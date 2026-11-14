using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleSelenium.Tests.Tests;

[TestClass]
public class WebFormularioDesafioTest
{
  private const string UrlFormulario = "https://www.selenium.dev/selenium/web/web-form.html";

  [TestMethod]
  public void Exercicio1_CadastroCompleto_PreenchimentoMisto()
  {
    IWebDriver driver = new ChromeDriver();
    try
    {
      driver.Navigate().GoToUrl(UrlFormulario);
      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

      // 1. Preencher Text input (my-text)
      var textInput = driver.FindElement(By.Name("my-text"));
      textInput.SendKeys("Isaque Gabriel da Silva Guimarães");

      // 2. Preencher Password (my-password)
      var passwordInput = driver.FindElement(By.Name("my-password"));
      passwordInput.SendKeys("SenhaSuperSegura@2026");

      // 3. Preencher Textarea (my-textarea)
      var textareaInput = driver.FindElement(By.Name("my-textarea"));
      textareaInput.SendKeys("Automação de testes end-to-end utilizando C#, MSTest e Selenium WebDriver.");

      // 4. Validar Readonly input
      var readonlyInput = driver.FindElement(By.Name("my-readonly"));
      Assert.AreEqual("Readonly input", readonlyInput.GetAttribute("value"));

      // 5. Submeter e validar mensagem "Received!"
      driver.FindElement(By.TagName("button")).Click();

      var message = driver.FindElement(By.Id("message"));
      Assert.AreEqual("Received!", message.Text);
    }
    finally
    {
      driver.Quit();
    }
  }

  [TestMethod]
  public void Exercicio2_SeletoresEListasInteligentes_DropdownEDatalist()
  {
    IWebDriver driver = new ChromeDriver();
    try
    {
      driver.Navigate().GoToUrl(UrlFormulario);
      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

      // 1. Selecionar "Two" no Dropdown (my-select) usando SelectElement
      var selectElement = new SelectElement(driver.FindElement(By.Name("my-select")));
      selectElement.SelectByText("Two");

      // 2. Validar se o valor da opção selecionada é "2"
      Assert.AreEqual("2", selectElement.SelectedOption.GetAttribute("value"));

      // 3. Enviar cidade no Datalist (my-datalist)
      var datalistInput = driver.FindElement(By.Name("my-datalist"));
      datalistInput.SendKeys("Seattle");

      // 4. Enviar o formulário e validar sucesso
      driver.FindElement(By.TagName("button")).Click();

      var message = driver.FindElement(By.Id("message"));
      Assert.AreEqual("Received!", message.Text);
    }
    finally
    {
      driver.Quit();
    }
  }

  [TestMethod]
  public void Exercicio3_Estados_CheckboxesRadiosEColorPicker()
  {
    IWebDriver driver = new ChromeDriver();
    try
    {
      driver.Navigate().GoToUrl(UrlFormulario);
      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

      // 1. Validar que o primeiro checkbox (my-check-1) já está marcado
      var check1 = driver.FindElement(By.Id("my-check-1"));
      Assert.IsTrue(check1.Selected);

      // 2. Clicar no segundo checkbox (my-check-2) para marcá-lo
      var check2 = driver.FindElement(By.Id("my-check-2"));
      check2.Click();
      Assert.IsTrue(check2.Selected);

      // 3. Alternar seleção para o rádio padrão (my-radio-2)
      var radio2 = driver.FindElement(By.Id("my-radio-2"));
      radio2.Click();
      Assert.IsTrue(radio2.Selected);

      // 4. Alterar a cor no Color picker (my-colors)
      var colorPicker = driver.FindElement(By.Name("my-colors"));
      colorPicker.SendKeys("#ff0000");

      // 5. Submeter o formulário e validar sucesso
      driver.FindElement(By.TagName("button")).Click();

      var message = driver.FindElement(By.Id("message"));
      Assert.AreEqual("Received!", message.Text);
    }
    finally
    {
      driver.Quit();
    }
  }
}