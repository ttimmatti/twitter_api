using System.Net;
using System.Net.Http.Headers;

//there is a function to add first users that im monitoring
//there is a file, where i store users, that im monitoring for tweets, follows and description change
//each user has a field, which parameteres of the user do i monitor

//i go through the list of users and spread user ids into a few lists, where one is for followers number check, another is for number of posts check and so on
//then i send requests one by one to check the users for desired parameteres
//after i receive all the results i compare them to the previous run, that was stored in the file "Previous file" and analyze them
//if the values changed than i send notifications etc.


class Program
{
    public static void Main()
    {
        StartUp(); // Always present here!!!

        Dependencies.ReInit();

        MyRequests.GetAll();

    }

    public static void StartUp()
    {
        DotNetEnv.Env.Load();
        string bearer_token = Environment.GetEnvironmentVariable("BEARER");

        Dependencies.httpClient = new HttpClient();
        Dependencies.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token);
    }
}
