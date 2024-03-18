using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class User
{
    public string LastSecurityPointDirection { get; set; }
    public int LastSecurityPointNumber { get; set; }
    public string LastSecurityPointTime { get; set; }
    public int PersonCode { get; set; }
    public string PersonRole { get; set; }
}

public class ApiResponse
{
    public User[] Users { get; set; }
}

class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main()
    {
        var responseString = await client.GetStringAsync("http://192.168.100.31:5000/users");
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseString);

        foreach (var user in apiResponse.Users)
        {
            Console.WriteLine($"Код пользователя: {user.PersonCode}");
            Console.WriteLine($"Роль пользователя: {user.PersonRole}");
            Console.WriteLine($"Направление последней точки безопасности: {user.LastSecurityPointDirection}");
            Console.WriteLine($"Номер последней точки безопасности: {user.LastSecurityPointNumber}");
            Console.WriteLine($"Время последней точки безопасности: {user.LastSecurityPointTime}");
            Console.WriteLine("-------------------------");
        }
    }
}