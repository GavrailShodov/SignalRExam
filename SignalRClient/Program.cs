using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
           .WithUrl("http://localhost:7149/chatHub")
           .Build();

connection.On<string, string>("ReceiveMessage", (user, message) =>
{
    Console.WriteLine($"{user}: {message}");
});

await connection.StartAsync();

Console.WriteLine("Connected to the chat. Type a message and press Enter.");

while (true)
{
    var client = Console.ReadLine();
    var message = Console.ReadLine();
    await connection.InvokeAsync("SendMessage", client, message);
}