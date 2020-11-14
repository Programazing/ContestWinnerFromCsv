# Contest Winner From CSV

![Project Status](https://img.shields.io/badge/Status-Active-success.svg) ![GitHub last commit](https://img.shields.io/github/last-commit/Programazing/ContestWinnerFromCsv.svg) ![Build Status](https://travis-ci.org/Programazing/ContestWinnerFromCsv.svg?branch=main)

## Installation

Package Manager  
`Install-Package ContestWinnerFromCsv -Version 1.0.0`

.Net CLI  
`dotnet add package ContestWinnerFromCsv --version 1.0.0`

Package Reference  
`<PackageReference Include="ContestWinnerFromCsv" Version="1.0.0" />`

Paket CLI  
`paket add ContestWinnerFromCsv --version 1.0.0`

## Usage

Add `appsettings.json` in the same directory as your application or add the following section to your pre-existing file.

```json
{
  "Settings": {
    "CsvLocation": "",
    "NumberOfWinners": 1,
    "StartDateTimeOfContest": "10/20/2020",
    "EndDateTimeOfContest": "11/20/2020"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

Within `ContestWinnerFromCsv.FormServices` you'll find a list of currently supported services and their maps.

```csharp
using ContestWinnerFromCsv;
using ContestWinnerFromCsv.FormServices;

...

var path = @"c:/path/to.csv";
var contest = new ContestWinner<GoogleFormsCsvModel, GoogleFormsCsvMap>(path);
var entries = contest.GetEntries().ToList();
var results = contest.PickWinners();
```

### Adding your own model and mappings

If you want to add a Form Service that the library doesn't currently have all you have to do is inherit `ICsvModel` then provide a [CsvHelper](https://joshclose.github.io/CsvHelper/) `ClassMap`.

**Note:** You don't have to set the TimeStamp in `SetTimeStampAndValidate` if your mapping can correctly map to `DateTime`.

For an example of this take a look at the [GoogleFormsCsvModel](ContestWinnerFromCsv/FormServices/GoogleForms/GoogleFormsCsvModel.cs). Unfortunately Google Forms does not use a standard `TimeStamp` in their csv export.

## Contributing

## License

[MIT](LICENSE)
