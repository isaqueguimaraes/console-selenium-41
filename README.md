# 🧪 ConsoleSelenium41

Solução em **C# / .NET 10** para **automação de testes web com Selenium WebDriver e MSTest**. O projeto automatiza o preenchimento do formulário real [Selenium Web Form](https://www.selenium.dev/selenium/web/web-form.html), interagindo com diferentes tipos de elementos (inputs, dropdowns, datalist, checkboxes, radios e color picker) e validando o fluxo por meio de asserções.

Projeto desenvolvido para a disciplina **Garantia da Qualidade de Software** (Gestão e Qualidade de Software, Ânima Educação), com foco em testes automatizados de interface.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![Selenium](https://img.shields.io/badge/Selenium-WebDriver-43B02A?logo=selenium&logoColor=white)
![MSTest](https://img.shields.io/badge/tests-MSTest-5E2D91)

---

## 📑 Sumário

- [Visão geral](#-visão-geral)
- [Requisitos técnicos](#-requisitos-técnicos)
- [Estrutura do projeto](#-estrutura-do-projeto)
- [Como o projeto foi criado](#-como-o-projeto-foi-criado)
- [Como clonar e compilar](#-como-clonar-e-compilar)
- [Como executar os testes](#-como-executar-os-testes)
- [Cenários de teste automatizados](#-cenários-de-teste-automatizados)
- [Boas práticas adotadas](#-boas-práticas-adotadas)
- [Tecnologias utilizadas](#-tecnologias-utilizadas)
- [Contribuidores](#-contribuidores)

---

## 📖 Visão geral

A solução é composta por dois projetos:

| Projeto | Tipo | Responsabilidade |
|---------|------|------------------|
| `ConsoleSelenium` | Console Application (.NET 10) | Projeto principal, responsável por centralizar scripts e classes auxiliares de automação. |
| `ConsoleSelenium.Tests` | MSTest | Projeto de testes que utiliza **Selenium.WebDriver** e **Selenium.Support** para executar os cenários de automação, referenciando o projeto principal. |

Os testes abrem um navegador real, acessam o formulário de testes oficial do Selenium, preenchem os campos e validam os resultados com `Assert`.

---

## 🛠 Requisitos técnicos

- **[.NET SDK 10.0](https://dotnet.microsoft.com/download)** (ou superior)
- **[Git](https://git-scm.com/downloads)**
- **Google Chrome** instalado (os testes utilizam o `ChromeDriver`)
- **Conexão com a internet** (o formulário testado é um site real e o Selenium baixa automaticamente o driver do navegador, se necessário)
- Terminal (PowerShell, CMD, Bash, Zsh etc.)
- IDE opcional: Visual Studio 2022+, VS Code (com extensão C# Dev Kit) ou JetBrains Rider

Para verificar a versão do .NET instalada:

```bash
dotnet --version
```

---

## 📂 Estrutura do projeto

```text
console-selenium-41/
├── ConsoleSelenium41.slnx
├── ConsoleSelenium/
│   ├── ConsoleSelenium.csproj
│   └── Program.cs
├── ConsoleSelenium.Tests/
│   ├── ConsoleSelenium.Tests.csproj
│   └── WebFormularioDesafioTest.cs
├── .gitignore
└── README.md
```

- **`ConsoleSelenium`**: projeto de console (`net10.0`) com o ponto de entrada e as classes auxiliares de automação.
- **`ConsoleSelenium.Tests`**: projeto de testes MSTest (`net10.0`) com a classe `WebFormularioDesafioTest`, que reúne os cenários automatizados.

---

## 🏗 Como o projeto foi criado

A solução foi criada do zero via .NET CLI, seguindo os passos abaixo:

```bash
# 1. Criar a solution e entrar no diretório
dotnet new sln -n ConsoleSelenium41
cd ConsoleSelenium41

# 2. Criar o projeto principal (Console Application, .NET 10)
dotnet new console -n ConsoleSelenium

# 3. Criar o projeto de testes (MSTest)
dotnet new mstest -n ConsoleSelenium.Tests

# 4. Adicionar os projetos à solution
dotnet sln add ConsoleSelenium/ConsoleSelenium.csproj
dotnet sln add ConsoleSelenium.Tests/ConsoleSelenium.Tests.csproj

# 5. Referenciar o projeto principal no projeto de testes
dotnet add ConsoleSelenium.Tests/ConsoleSelenium.Tests.csproj reference ConsoleSelenium/ConsoleSelenium.csproj

# 6. Instalar os pacotes NuGet de automação no projeto de testes
dotnet add ConsoleSelenium.Tests/ConsoleSelenium.Tests.csproj package Selenium.WebDriver
dotnet add ConsoleSelenium.Tests/ConsoleSelenium.Tests.csproj package Selenium.Support
```

> Esses comandos **não precisam ser executados** para rodar o projeto. Eles documentam como a solução foi montada.

---

## 🚀 Como clonar e compilar

### 1. Clonar o repositório

```bash
git clone https://github.com/isaqueguimaraes/console-selenium-41.git
```

### 2. Acessar a pasta do projeto

```bash
cd console-selenium-41
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Compilar a solução

```bash
dotnet build
```

Se tudo estiver correto, a saída final indicará **Build succeeded** (compilação bem-sucedida), com 0 erros.

---

## ✅ Como executar os testes

Na raiz do repositório, execute:

```bash
dotnet test
```

Para uma saída mais detalhada, com o nome de cada teste executado:

```bash
dotnet test --logger "console;verbosity=detailed"
```

Para executar apenas o projeto de testes:

```bash
dotnet test ConsoleSelenium.Tests/ConsoleSelenium.Tests.csproj
```

Durante a execução, o **Chrome será aberto automaticamente** e controlado pelo Selenium. Ao final, todos os testes devem ser aprovados, com uma saída semelhante a:

```text
Resumo do teste: total: 3; falhou: 0; bem-sucedido: 3; ignorado: 0
```

> 💡 Também é possível executar os testes pela extensão **C# Dev Kit** do VS Code, utilizando o **Test Explorer**.

---

## 🎯 Cenários de teste automatizados

Os testes estão na classe `WebFormularioDesafioTest` e utilizam o atributo `[TestMethod]` do MSTest. O formulário testado é: <https://www.selenium.dev/selenium/web/web-form.html>

### Exercício 1: Cadastro completo (preenchimento misto)

**Objetivo:** automatizar o preenchimento de múltiplos tipos de inputs em uma única submissão.

| Passo | Ação |
|:-----:|------|
| 1 | Navegar até a URL do formulário. |
| 2 | Preencher o campo **Text input** (`my-text`) com o nome completo. |
| 3 | Preencher o campo **Password** (`my-password`) com uma senha segura. |
| 4 | Preencher o campo **Textarea** (`my-textarea`) com uma breve descrição da experiência com testes automatizados. |
| 5 | Validar via `Assert` que o **Readonly input** contém exatamente o valor padrão `"Readonly input"`. |
| 6 | Submeter o formulário e validar que a página de sucesso exibe a mensagem `"Received!"`. |

### Exercício 2: Seletores e listas inteligentes (Dropdown e Datalist)

**Objetivo:** manipular elementos de seleção suspensa com a classe `SelectElement` e listas com autocompletar.

| Passo | Ação |
|:-----:|------|
| 1 | Utilizar `SelectElement` para selecionar a opção **"Two"** no **Dropdown (select)** (`my-select`). |
| 2 | Validar que a opção selecionada possui o valor **2**. |
| 3 | No **Dropdown (datalist)** (`my-datalist`), enviar o texto de uma das cidades disponíveis (ex.: `"Seattle"`). |
| 4 | Acionar o envio do formulário e verificar que o fluxo ocorreu sem exceções. |

### Exercício 3: Estados, checkboxes, radios e color picker

**Objetivo:** alternar estados de elementos de escolha e interagir com seletores visuais avançados.

| Passo | Ação |
|:-----:|------|
| 1 | Validar que o primeiro checkbox (`my-check-1`) já está **marcado** por padrão. |
| 2 | Clicar no segundo checkbox (`my-check-2`) para marcá-lo. |
| 3 | Alternar a seleção para o rádio padrão (`my-radio-2`), garantindo que ele esteja selecionado. |
| 4 | Interagir com o **Color picker**, alterando o valor da cor. |
| 5 | Enviar o formulário e validar o sucesso da operação. |

---

## 🧹 Boas práticas adotadas

- **Clean Code**: solução organizada em projetos separados (automação e testes), com nomes claros para classes e métodos.
- **Asserções**: cada cenário valida o resultado esperado com `Assert` do MSTest.
- **Espera implícita**: uso de `ImplicitWait` para aguardar a presença dos elementos na página.
- **Encerramento do navegador**: o driver é finalizado ao término de cada teste (`Quit()`), evitando processos abertos.
- **Commits semânticos**: o histórico segue o padrão de mensagens semânticas, por exemplo:
  - `feat: adiciona estrutura inicial do projeto`
  - `test: implementa cenario de dropdown`

---

## 🧰 Tecnologias utilizadas

- [C#](https://learn.microsoft.com/dotnet/csharp/)
- [.NET 10](https://dotnet.microsoft.com/)
- [Selenium WebDriver](https://www.selenium.dev/documentation/webdriver/)
- [MSTest](https://learn.microsoft.com/dotnet/core/testing/unit-testing-with-mstest)
- [Git](https://git-scm.com/) e [GitHub](https://github.com/)

---

## 👥 Autor

- Isaque Guimarães
