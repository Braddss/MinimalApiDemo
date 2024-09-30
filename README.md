# MinimalApiDemo - Overview

This is a small ASP.NET Core Web-Api containing some string functionalities:

1. Count words in a text.
2. Check if words are contained.
3. Count characters in a text.
4. Check if characters are contained.
5. Check if a string is Base64.
6. Check the validity of an E-Mail adress.
7. Convert an input string to a decimal.

## Projects

This repo consists of multiple projects.

1. [MinimalApiDemo](#project-minimalapidemo) - This contains the Web-Api.
2. [MinimalApiDemo.UnitTests](#project-minimalapidemounittests) - This is the unit test project for the MinimalApiDemo project.
3. [BenchmarkMinApi](#project-benchmarkminapi) - This is a Benchmark project to benchmark the Web-Api.

### Project: MinimalApiDemo

This project can be started with Visual Studio (2022). First open the MinimalApiDemo.sln file located at `\MinimalApiDemo\MinimalApiDemo.sln`. This contains the MinimalApiDemo and MinimalApiDemo.UnitTests project. The Web-Api can be started inside of Visual Studio via clicking the green arrow (-> https), the f5-button or Debug->Start Debugging.

There are several ways to test the Web-Api endpoints.

1. MinimalApiDemo.http

    Open the inside Visual Studio. All available endpoints are listed here, each with some sample input. Press the **Send request**-button above each endpoint to test each respective endpoint.

2. Hoppscotch Collection - MinimalApiDemo.json

    Search for the file `\MinimalApiDemo\HoppscotchCollection\minimalApiDemo.json`.

    This can be imported into [Hoppscotch](https://hoppscotch.io/) (Webbased alternative to Postman). In hoppscotch all endpoints with sample inputs are listed on the right side inside the MinimalApiDemo-folder.

3. BenchmarkMinApi

    The BencharkMinApi project can be used for testing. The project .sln file is located here: `\MinimalApiDemo\BenchmarkMinApi\BenchmarkMinApi.sln`

### Project: MinimalApiDemo.UnitTests

This project is contained inside the MinimalApiDemo.sln located at `\MinimalApiDemo\MinimalApiDemo.sln`. The tests can be run using the TextExplorer inside of Visual Studio.

### Project: BenchmarkMinApi

This project can be used to benchmark the Web-Api. It is located here: `\MinimalApiDemo\BenchmarkMinApi\BenchmarkMinApi.sln`
It can be opened and started via Visual Studio.
