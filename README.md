# UWS-Application

Приложение, загружает произвольную HTML-страницу посредством HTTP-запроса, находит выдимый текст на странице, разбивает его на слова и выдает статистику по количеству уникальных слов в консоль.

## Технологии

* [.NET 5](https://dotnet.microsoft.com/download)
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core)
* [C# 9](https://docs.microsoft.com/en-us/dotnet/csharp)

### Запуск приложения

<details>
<summary>Командная строка</summary>

#### Зависимости

* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)

#### Шаги

1. В командной строке ввести **cd**, скопировать путь к директории **src\SN\PN** и выполнить.
2. Выполнить **dotnet run**.
3. Следовать инуструкциям в командной строке.

</details>

<details>
<summary>Visual Studio Code</summary>

#### Зависимости

* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)
* [Visual Studio Code](https://code.visualstudio.com)
* [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

#### Шаги

1. Открыть директорию **source** в Visual Studio Code.
2. Нажать **F5**.

</details>

<details>
<summary>Visual Studio</summary>

#### Зависимости

* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Visual Studio](https://visualstudio.microsoft.com)

#### Шаги

1. Открыть **source\SN.sln** в Visual Studio.
2. Нажать **F5**.

</details>

### Nuget пакеты

**HtmlAgilityPack:** [https://www.nuget.org/packages/HtmlAgilityPack](https://www.nuget.org/packages/HtmlAgilityPack)

**NLog:** [https://www.nuget.org/packages/NLog](https://www.nuget.org/packages/NLog)

**EntityFrameworkCore:** [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
