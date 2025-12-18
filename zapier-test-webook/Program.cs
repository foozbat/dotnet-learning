using dotenv.net; 
using System.Net.Http;                        

// Load environment variables from .env file
DotEnv.Load();
var envVars = DotEnv.Read();

string webhookUrl = envVars["WEBHOOK_URL"];

// sample data
var myData = new MyData
{
    Id = "12345",
    Email = "test@test.com",
    Message = "Hello from .NET!"
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