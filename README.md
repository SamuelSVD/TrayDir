[![GitHub release](https://img.shields.io/github/release/SamuelSVD/TrayDir.svg)](../../releases/latest)

# Update Pending! V3 Coming Soon!

# TrayDir
A windows application that gives the user the ability to access files and folders from the system tray.

## Instances

An instance refers to a single system tray icon.
Each instance can point to multiple destinations, which can be either a folder or a file location.

## Supported Platforms

Currently TrayDir is only supported/tested on Windows 10.

## Download Latest

Download the installer for the latest release by following this link:

[http://github.com/samuelSVD/TrayDir/releases/latest](http://github.com/samuelSVD/TrayDir/releases/latest);

## Regex Filtering

You can add a Regex pattern to ignore certain files or folders from being included in the tray menu.

| Pattern | Description |
| --- | --- |
| `$(?<=\.(gif\|png\|jpg))` | This pattern will ignore all files ending with `.gif`, `.png`, or `.jpg` |

For more information on Regex and creating your own filters see [Regular Expressions](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference)
