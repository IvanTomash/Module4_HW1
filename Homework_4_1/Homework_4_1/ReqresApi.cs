using Homework_4_1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1
{
    internal sealed class ReqresApi
    {
        private const string ReqresURL = "https://reqres.in";

        public static async Task ReqresGetAsync<T>(string path)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ReqresURL);
                HttpResponseMessage res = await client.GetAsync(path);
                if (res.StatusCode == (HttpStatusCode)200)
                {
                    string responseContent = await res.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                    T pageResponse = JsonConvert.DeserializeObject<T>(responseContent);
                    
                    if (pageResponse != null)
                    {
                        Console.WriteLine(pageResponse.ToString());
                    }
                }
                else if (res.StatusCode == (HttpStatusCode)404)
                {
                    Console.WriteLine("NOT FOUND");
                }
            }
        }

        public static async Task ReqresPostAsync<T>(string path, T user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ReqresURL);

                string serializedUser = JsonConvert.SerializeObject(user, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });

                var stringContent = new StringContent(serializedUser, Encoding.Unicode, "application/json");
                HttpResponseMessage res = await client.PostAsync(path, stringContent);
        
                if (res.StatusCode == (HttpStatusCode)201)
                {
                    Console.WriteLine("StatusCode Created");
                    string content = await res.Content.ReadAsStringAsync();
                    Console.WriteLine(content);

                    UserCreatedResponse userCreatedResponse = JsonConvert.DeserializeObject<UserCreatedResponse>(content);
                    Console.WriteLine(userCreatedResponse.ToString());
                }
                else if (res.StatusCode == (HttpStatusCode)200)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    Console.WriteLine(content);

                    ReqresRegisterResponse response = JsonConvert.DeserializeObject<ReqresRegisterResponse>(content);
                    Console.WriteLine(response.ToString());
                }
                else if (res.StatusCode == (HttpStatusCode)400)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    Console.WriteLine(content);

                    ReqresRegisterResponse response = JsonConvert.DeserializeObject<ReqresRegisterResponse>(content);
                    Console.WriteLine(response.ToString());
                }
            }
        }

        public static async Task ReqresPutAsync(string path, CreateUserParametersRequest user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ReqresURL);

                string serializedUser = JsonConvert.SerializeObject(user, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });

                var stringContent = new StringContent(serializedUser, Encoding.Unicode, "application/json");
                HttpResponseMessage res = await client.PutAsync(path, stringContent);

                if (res.StatusCode == (HttpStatusCode)200)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    UserCreatedResponse userResponse = JsonConvert.DeserializeObject<UserCreatedResponse>(content);
                    Console.WriteLine(userResponse.ToString());

                }
            }
        }

        public static async Task ReqresPatchAsync(string path, CreateUserParametersRequest user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ReqresURL);

                string serializedUser = JsonConvert.SerializeObject(user, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });

                var stringContent = new StringContent(serializedUser, Encoding.Unicode, "application/json");
                HttpResponseMessage res = await client.PatchAsync(path, stringContent);

                if (res.StatusCode == (HttpStatusCode)200)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    UserCreatedResponse userResponse = JsonConvert.DeserializeObject<UserCreatedResponse>(content);
                    Console.WriteLine(userResponse.ToString());

                }
            }
        }

        public static async Task ReqresDeleteAsync(string path)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ReqresURL);
                HttpResponseMessage res = await client.DeleteAsync(path);

                if (res.StatusCode == (HttpStatusCode)204)
                {
                    Console.WriteLine("DELETE");
                }
            }
        }
    }
}
