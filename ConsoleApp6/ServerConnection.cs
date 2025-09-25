using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class ServerConnection
    {
        HttpClient client = new HttpClient();
       public List<Subject> result = new List<Subject>();
        string baseurl = "";
        public ServerConnection(string url)
        {
            //http://
            if (!url.StartsWith("http://")) throw new ArgumentException("Hibás url http:// megadása kötelező");
            baseurl = url;
        }
        public async Task<List<Subject>> GetSubjects()
        {
            
            //const request = new XMLHttpRequest();
            //request.open('get','/subject')
            string url = baseurl + "/subject";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                result = JsonSerializer.Deserialize<List<Subject>>(await response.Content.ReadAsStringAsync());

            }
            catch (Exception e)
            {

                Console.Write(e.Message);
            }
            return result;
            
        }
        public async Task<List<User>> GetUsers()
        {
            List<User> result = new List<User>();
            string url = baseurl + "/user";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                result = JsonSerializer.Deserialize<List<User>>(await response.Content.ReadAsStringAsync());
               

            }
            catch (Exception e)
            {

                Console.Write(e.Message);
            }
            return result;
           
        }
        public async Task<Message> PostUser(string username,string password)
        {
            Message message = new Message();
            string url = baseurl + "/user";
            try
            {
                var jsondata = new {
                    username = username,
                    password = password
                };
                string jsonstring = JsonSerializer.Serialize(jsondata);
                HttpContent content = new StringContent(jsonstring, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response = await client.PostAsync(url,content);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return message;
        }
        public async Task<Message> PostSubject(string name)
        {
            Message message = new Message();
            string url = baseurl + "/subject";
            try
            {
                var jsondata = new
                {
                    name = name  
                };
                string jsonstring = JsonSerializer.Serialize(jsondata);
                HttpContent content = new StringContent(jsonstring, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return message;
        }
        public async Task<Message> DeleteSubject(int id)
        {
            Message message = new Message();
            string url = baseurl + "/subject/"+ id;
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return message;
        }

    }
}
