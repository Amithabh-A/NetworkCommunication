# NetworkCommunication

## Client(Sender) : 
```
dotnet restore
dotnet build
cd Client
dotnet run <host> <port> <path-to-dll-file>
```

## Server (Receiver) : 
```
dotnet restore
dotnet build
cd Server
dotnet run <port>
```

The `.dll` file received will be saved in `Server/received.dll`

# Prerequisites
You need to install dotnet-cli in your terminal
