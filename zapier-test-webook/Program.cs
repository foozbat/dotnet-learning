using dotenv.net; 
using System.Net.Http;                        

// Load environment variables from .env file
DotEnv.Load();
var envVars = DotEnv.Read();

string webhookUrl = envVars["WEBHOOK_URL"];

Console.Write("Enter your email: ");
string email = Console.ReadLine() ?? "";
Console.Write("Enter your message: ");
string message = Console.ReadLine() ?? "";

// sample data
var myData = new MyData
{
    Id = Random.Shared.Next(),
    Email = email,
    Message = message
};

// send request to zapier webhook
using var client = new HttpClient();
var response = await client.PostAsync(webhookUrl, new StringContent(
    System.Text.Json.JsonSerializer.Serialize(myData),
    System.Text.Encoding.UTF8,
    "application/json"
));

Console.WriteLine($"Response Status: {response.StatusCode}");
Console.WriteLine($"Response Body: {await response.Content.ReadAsStringAsync()}");