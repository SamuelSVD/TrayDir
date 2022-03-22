[![GitHub release](https://img.shields.io/github/release/SamuelSVD/TrayDir.svg)](../../releases/latest)

# TrayDir
A windows application that gives the user the ability to access files and folders from the system tray.

## How To Use

When you first start up TrayDir, you will be greeted with the form containing one instance, New Instance. Each instance will have its own icon in the system tray. 
Each instance can be configured to have multiple items inside which work as shortcuts to different file or folder locations. 

However you configure the items in the form is how the menu will look when you right click on the icon down in the system tray, meaning you can have custom links in whatever structure you want.

### Adding New Items

You can add new items by making use of the top buttons. You can add a new file link, new folder link, or new virtual folder to the tree of items.

![image](https://user-images.githubusercontent.com/36249705/124690601-72649b00-dea8-11eb-81f7-2de9e0b47c08.png)

### Creating New Instances

You can create a new instance by clicking on the + tab, or by clicking on Instance | New from the menu bar

## Example

Below we have an example of an instance called New Instance. It has a file link, a folder link, and a virtual folder with two file links inside.

![image](https://user-images.githubusercontent.com/36249705/124690456-392c2b00-dea8-11eb-9511-393a1566618e.png)

The right-click tray menu appears in the same order as the tree view above, and when you hover over the tray icon, it shows the instance name "New Instance"


![image](https://user-images.githubusercontent.com/36249705/124690464-3b8e8500-dea8-11eb-8183-6bf2798ce7ed.png)
![image](https://user-images.githubusercontent.com/36249705/124691926-a5a82980-deaa-11eb-9e1d-e484f65d80d2.png)

Note: you can change the icon that appears in the tray by clicking on the `Options...` button, then browse for the icon that you would like to use.

![image](https://user-images.githubusercontent.com/36249705/124692192-1bac9080-deab-11eb-97a0-e7a00282d0a1.png)
![image](https://user-images.githubusercontent.com/36249705/124692198-1ea78100-deab-11eb-9564-9292c349480c.png)



## Supported Platforms

Currently TrayDir is only supported/tested on Windows 10.

## Download Latest

Download the installer for the latest release by following this link:

[http://github.com/samuelSVD/TrayDir/releases/latest](http://github.com/samuelSVD/TrayDir/releases/latest);

## RegEx Filtering

You can add a RegEx pattern to ignore certain files or folders from being included in the tray menu. 

Every new line is treated as a new pattern.

| Pattern | Description |
| --- | --- |
| `$(?<=\.(gif\|png\|jpg))` | This pattern will ignore all files ending with `.gif`, `.png`, or `.jpg` |

For more information on RegEx and creating your own filters see [Regular Expressions](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference)

## Plugins

Plugins work as a way to run external programs and make use of their [CLI](https://www.w3schools.com/whatis/whatis_cli.asp). You can add a plugin to TrayDir through the Plugin Manager, and navigate to the program or executable that you want to run when plugin items are selected from the menu item. Each plugin can be configured to have multiple parameters that can then each be configured to have an optional name, or be considered a flag (and appears as a checkbox when configured as such).

For example, Window's Internet Explorer could be configured as a plugin. Looking through its [CLI](https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/general-info/hh826025(v=vs.85)?redirectedfrom=MSDN) we can see that it accepts several parameters, but we will set up two parameters. The first will be URL, and the second will be the Private Browsing parameter, -private.

| Description | Image |
| --- | --- |
| Configuring the plugin | ![image](https://user-images.githubusercontent.com/36249705/145105241-7e26f6a6-b312-4a0f-a7cc-a8622524a54c.png) |
| Configuring the URL parameter | ![image](https://user-images.githubusercontent.com/36249705/145105259-369ee20b-002e-47c6-bc35-a1f8ad190fc1.png) |
| Configuring the Private Browsing parameter | ![image](https://user-images.githubusercontent.com/36249705/145105252-a51fc3d8-c28c-4ef5-8e6d-612cc719d62c.png) |
| Using the plugin in a menu item. Note that the parameters are displayed in the order they are configured in the plugin. | ![image](https://user-images.githubusercontent.com/36249705/145105271-037b53a0-6bb5-4b57-a7e7-951f24f3312e.png) |
