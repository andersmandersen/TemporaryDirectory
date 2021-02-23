<h1 align="center">Temporary Directory .Net Core</h1>

<p align="center">⚡ Working with temporary directory made easy ☕️</p>

**Temporary Directory ** is a simple to work with temporary directory for .Net Core developers.


## 🔧 Installation

Using the [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/en-us/dotnet/core/tools/):

```bash
$ dotnet add package XXX
```

or with the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```bash
$ Install-Package XXX
```

## 🚀 Usage

### Creating temporary directory
To create a temporary directory at the system temporary directory call the create method:

```
TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().Create();
```

### Naming temporary directory
To create a temporary directory with a specific name:

```
TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().SetName("MyFolder").Create();
```

### Force creating temporary directory
In case the directory already exists you can force create the directory. It will delete the old folder and create the directory againg:

```
TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().SetName("MyFolder").SetForce(true).Create();
```

### Creating temporary directory a custom location
If you wise to create the folder at another location you can specify this in the constructor:

```
TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler(location).Create();
```

### Retrive the path of the temporary directory
You can use the method GetPath to either get the path of the directory or a specific file:

```
TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().Create();
string path = directory.GetPath();
```

```
TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().Create();
string path = directory.GetPath("my-file.txt");
```

### Empty temporary directory 
You can empty a directory with method Empty:

```
TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().Create();
directory.Empty();
```

### Delete temporary directory
You can delete a directory with method Empty:

```
TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().Create();
bool result = directory.Delete();
```


## 🤼 How to Contribute

Feel free to contribute with pull requests, bug reports or enhancement suggestions. We love PR's

## 🎉 Credits

- [Spatie](https://github.com/spatie)