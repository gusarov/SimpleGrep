# grepl

grepl is a command line tool for searching & replacing file content with RegEx expressions
This tool is inspired by JGS PowerGrep but due to cli nature it is also an attempt to respect unix grep

## Downloading and Installing

_TBD_

```
choco install grepl
```

--OR--

Download a zip file from release page

## Examples

|Example|Description|
|--|--|
|```grepl Version=[\d\.]+ *.csproj -r```|Search for all csproj file references & their versions|

## Documentation

```
grepl [OPTION...] PATTERNS [FILE...]
```

_**NOTE**: a single letter options are not combinable as of today! So, instead of ```-io``` you should specify ```-i -o```_

## Built With

* [.NetCore](https://dotnet.microsoft.com/download)

## Authors

* **Dmitry Gusarov** - *Initial work* - [SimpleGrep](https://github.com/gusarov/SimpleGrep)

See also the list of [contributors](https://github.com/gusarov/SimpleGrep/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Inspired by JGS PowerGrep & unix grep