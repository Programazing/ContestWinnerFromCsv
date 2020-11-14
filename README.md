# Contest Winner From CSV

![Project Status](https://img.shields.io/badge/Status-Active-success.svg) ![GitHub last commit](https://img.shields.io/github/last-commit/Programazing/ContestWinnerFromCsv.svg) [![Build Status](https://travis-ci.org/Programazing/ContestWinnerFromCsv.svg?branch=master)](https://travis-ci.org/Programazing/ContestWinnerFromCsv)

## Installation

## Usage

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

## Contributing

## License

[MIT](LICENSE)
