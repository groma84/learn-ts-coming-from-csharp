using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{

    internal class Todo
    {

    }


    internal class AsyncFetch
    {
        public static async void GetTodos()
        {
            using var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");
            var parsedTodos = JsonConvert.DeserializeObject<Todo>(json);

            System.Console.WriteLine(parsedTodos);
        }
        
    }
}
