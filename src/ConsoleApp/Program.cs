// See https://aka.ms/new-console-template for more information

using JDPlus.WS.Client;

CommunicationManager communicationManager = new();

var version = await communicationManager.GetVersion();

Console.WriteLine(version);
Console.ReadLine();
