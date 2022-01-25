# A Game of Nim

## Setup

Clone the repository.

## Requirements

You must have the .NET framework installed. Supported
versions are **3.1**, **5.0**, and **6.0**. Follow the steps below to
install the proper framework.

### Windows

Installing Visual Studio 2019 or newer is sufficient to meet the framework requirements.

### MacOs

Install [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) if you
do not have it already.

## Verify Requirements

In a terminal (shell), run the following command and note your .NET version

    dotnet --version

## Running

There are several options for running the application. The most common are
with Microsoft Visual Studio, JetBrains Rider, or via the dotnet cli.

### Visual Studio

Open the `sln` file in Visual Studio to launch the project. Visual
Studio will run with the correct framework version.

### Rider

Open the `sln` file to launch the project. Edit the projet configuration and select
the .NET version installed on your system in the "Select Target Framework" dropdown.

![Edit Configuration](/images/edit-config.png)
![Select Target Framework](/images/select-target.png)

### CLI

1. Run the application for your .NET version.

   - For 3.1 - `dotnet run --framework netcoreapp3.1`
   - For 5.0 - `dotnet run --framework net5.0`
   - For 6.0 - `dotnet run --framework net6.0`

2. Use your preferred editor. VSCode has good C# plugins.
