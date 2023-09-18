using System;
using System.Net;
using System.Threading.Tasks;
using Homework_4_1.Models;

namespace Homework_4_1
{
    internal sealed class Program
    {
        public static void Main(string[] args) 
        {
            Task t;
            //LIST USERS
            t = ReqresApi.ReqresGetAsync<ReqresPageResponse<ReqresUserRequest>>("/api/users?page=2");
            t.Wait();

            //SINGLE USER
            t = ReqresApi.ReqresGetAsync<ReqresSingleObjectResponse<ReqresUserRequest>>("/api/users/2");
            t.Wait();

            //SINGLE USER NOT FOUND
            t = ReqresApi.ReqresGetAsync<ReqresSingleObjectResponse<ReqresUserRequest>>("/api/users/23");
            t.Wait();

            //LIST <RESOURCE>
            t = ReqresApi.ReqresGetAsync<ReqresPageResponse<ReqresResourceRequest>>("/api/unknown");
            t.Wait();

            //SINGLE <RESOURCE>
            t = ReqresApi.ReqresGetAsync<ReqresSingleObjectResponse<ReqresResourceRequest>>("/api/unknown/2");
            t.Wait();

            //SINGLE <RESOURCE> NOT FOUND
            t = ReqresApi.ReqresGetAsync<ReqresSingleObjectResponse<ReqresResourceRequest>>("/api/unknown/23");
            t.Wait();

            //CREATE
            t = ReqresApi.ReqresPostAsync<CreateUserParametersRequest>("/api/users", new CreateUserParametersRequest { Name = "morpheus", Job = "leader" });
            t.Wait();

            //UPDATE
            t = ReqresApi.ReqresPutAsync("/api/users/2", new CreateUserParametersRequest { Name = "morpheus", Job = "zion resident" });
            t.Wait();

            //UPDATE
            t = ReqresApi.ReqresPatchAsync("/api/users/2", new CreateUserParametersRequest { Name = "morpheus", Job = "zion resident" });
            t.Wait();

            //DELETE
            t = ReqresApi.ReqresDeleteAsync("/api/users/2");
            t.Wait();

            //REGISTER - SUCCESSFUL
            t = ReqresApi.ReqresPostAsync<ReqresVerificationRequest>("/api/register", new ReqresVerificationRequest { Email = "eve.holt@reqres.in", Password = "pistol" });
            t.Wait();

            //REGISTER - UNSUCCESSFUL
            t = ReqresApi.ReqresPostAsync<ReqresVerificationRequest>("/api/register", new ReqresVerificationRequest { Email = "sydney@fife"});
            t.Wait();

            //LOGIN - SUCCESSFUL
            t = ReqresApi.ReqresPostAsync<ReqresVerificationRequest>("/api/login", new ReqresVerificationRequest {Email = "eve.holt@reqres.in", Password = "cityslicka" });
            t.Wait();

            //LOGIN - UNSUCCESSFUL
            t = ReqresApi.ReqresPostAsync<ReqresVerificationRequest>("/api/login", new ReqresVerificationRequest { Email = "peter@klaven"});
            t.Wait();

            //DELAYED RESPONSE
            t = ReqresApi.ReqresGetAsync<ReqresPageResponse<ReqresUserRequest>>("/api/users?delay=3");
            t.Wait();

        }
    }
}
