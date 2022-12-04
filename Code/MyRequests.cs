using System.Net.Http.Headers;
using Newtonsoft.Json;

class MyRequests
{
    public static string GetAll()
    {
        IList<User> list = TwitterRequests.UsersByUsernameS(new List<string>{"husssus312,ttimmatti"});
        
        for (int i = 0; i < list.Count(); i++)
        {
            Console.WriteLine($"id:{list.ElementAt(i).id}, username:{list.ElementAt(i).username}");
            list.ElementAt(i) = TwitterRequests.UsersByIdS(list.ElementAt(i).id);
        }
        

        return "1";
    }

    class TwitterRequests
    {
        public static IList<User> UsersByUsernameS(string users, string[] fields = null)
        {
            return Task_UsersByUsernameS(users, fields).Result.Data;
        }

        public static IList<User> UsersByIdS(string ids, string[] fields = null)
        {
            return Task_UsersByIdS(ids, fields).Result.Data;
        }

        public static IList<User> FollowersByID(string id, string[] fields = null)
        {
            return Task_FollowersByID(id, fields).Result.Data;
        }

        public static IList<Tweet> TweetsByIdS(string ids, string[] fields = null)
        {
            return Task_TweetsByIdS(ids, fields).Result.Data;
        }

        //returns profiles with the specified usernames
        protected static async Task<UsersResponse> Task_UsersByUsernameS(string users, string[] fields = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();

            requestMessage.RequestUri = new Uri("https://api.twitter.com/2/users/by?usernames=" + users +
                    (fields == null ? "" : "&user.fields=" + String.Join(",", fields)) );
            
            requestMessage.Method = HttpMethod.Get;
            var httpResponse = await Dependencies.httpClient.SendAsync(requestMessage);

            var readResponse = httpResponse.Content.ReadAsStringAsync().Result;

            UsersResponse response = JsonConvert.DeserializeObject<UsersResponse>(readResponse);
            
            return response;
        }

        //returns profiles with the specified ids
        protected static async Task<UsersResponse> Task_UsersByIdS(string ids, string[] fields = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();

            requestMessage.RequestUri = new Uri("https://api.twitter.com/2/users?ids=" + ids +
                    (fields == null ? "" : "&user.fields=" + String.Join(",", fields)) );

            requestMessage.Method = HttpMethod.Get;
            var httpResponse = await Dependencies.httpClient.SendAsync(requestMessage);

            var readResponse = httpResponse.Content.ReadAsStringAsync().Result;
            
            UsersResponse response = JsonConvert.DeserializeObject<UsersResponse>(readResponse);
            
            return response;
        }

        //returns 
        protected static async Task<UsersResponse> Task_FollowersByID(string id, string[] fields = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();

            requestMessage.RequestUri = new Uri("https://api.twitter.com/2/users/" + id + "/followers" +
                    (fields == null ? "" : "?user.fields=" + String.Join(",", fields)) );

            requestMessage.Method = HttpMethod.Get;
            var httpResponse = await Dependencies.httpClient.SendAsync(requestMessage);

            var readResponse = httpResponse.Content.ReadAsStringAsync().Result;
            
            UsersResponse response = JsonConvert.DeserializeObject<UsersResponse>(readResponse);
            
            return response;
        }

        protected static async Task<TweetsResponse> Task_TweetsByIdS(string ids, string[] fields = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();

            requestMessage.RequestUri = new Uri("https://api.twitter.com/2/tweets?ids=" + ids +
                    (fields == null ? "" : "&tweet.fields=" + String.Join(",", fields)) );

            requestMessage.Method = HttpMethod.Get;
            var httpResponse = await Dependencies.httpClient.SendAsync(requestMessage);

            var readResponse = httpResponse.Content.ReadAsStringAsync().Result;
            
            TweetsResponse response = JsonConvert.DeserializeObject<TweetsResponse>(readResponse);
            
            return response;
        }

        //OVERLOADED METHODS FOR EASIER USE
        public static IList<User> UsersByUsernameS(IList<string> users, string[] fields = null)
        {
            return Task_UsersByUsernameS(String.Join(",", users), fields).Result.Data;
        }

        public static IList<User> UsersByIdS(IList<string> ids, string[] fields = null)
        {
            return Task_UsersByIdS(String.Join(",", ids), fields).Result.Data;
        }

        // no overload for followers func as it only takes one argument - id

        public static IList<Tweet> TweetsByIdS(IList<string> ids, string[] fields = null)
        {
            return Task_TweetsByIdS(String.Join(",", ids), fields).Result.Data;
        }
    }
}

