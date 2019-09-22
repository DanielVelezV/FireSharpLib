# FireSharpLib
This is a library to create, get and delete data from a DB on Firebase.

## Initialize the client.
```C#
FireClient.InitializeClient(YourBaseFirebaseAddress);
FireClient.Token = YourTokenHere;
```

## Get request.

```C#
DataType data = await FireProcessor.GetData<DataType>(Path);
```
Token Auth version:

```C#
DataType data = await FireProcessor.GetDataAuth<DataType>(Path);
```

## Put Request

```C#
bool completed = await FireProcessor.SetData<DataType>(string path, T data);
```
Token Auth version:

```C#
bool completed = await FireProcessor.SetDataAuth<DataType>(string path, T data);
```

## Delete Request
```C#
bool completed = await FireProcessor.Delete(string path)
```
Token Auth version:

```C#
bool completed = await FireProcessor.DeleteAuth(string path)
```

### All those methods are async. This lib uses Newtonsoft.Json lib, so all the datatypes are converted into Json and threated like that.

## ToDo
- [ ] Add the rest of the requests
- [ ] Allow all the datatypes
- [ ] Learn programming :P
