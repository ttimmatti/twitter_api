
//here we have all the responses we are planning to get


class UsersResponse
{
    /*
    {
    "data": [
        {
        "id": "878544082485882880",
        "name": "ttimmatti.eth / 📦",
        "username": "ttimmatti"
        },
        {
        "id": "4150238489",
        "name": "Timmati🌱🌐/📦 .eth (💙,🧡) ⛩️(💙,☢️) .hft",
        "username": "husssus312"
        }
    ]
    }
    */
    public List<User> Data { get; set; }
    
}

class User
{
    public string id { get; set; } //default
    public string name { get; set; } //default
    public string username { get; set; } //default
    public string profile_image_url { get; set; } //pfp url
    public string description { get; set; } //description
    public string entities { get; set; } //Contains details about text that has a special meaning in the user's description.
                                         //this is a bit interesting. idk how will this work exactly, but will see
}

class TweetsResponse
{
    /*
    {
    "data": [
        {
        "edit_history_tweet_ids": [
            "1570200728886542336"
        ],
        "id": "1570200728886542336",
        "text": "Yes, we built Social Alpha Trackers.\nYes, there are NFTs.\nYes, it's not too late to join.\n\nWill you retweet?"
        },
        {
        "edit_history_tweet_ids": [
            "1599086445561626625"
        ],
        "id": "1599086445561626625",
        "text": "Did you join Secret @DCentralCon?\n\nWhether you're a dev, investor, creator, or Secret Agent, there's plenty of opportunities to achieve your goals in the network. Jump into the Discord to find your road to success today!\n\nDiscord: https://t.co/EdivuPh0CD\n\n$SCRT #DCentralSCRT https://t.co/8HeACoj4CX"
        }
    ]
    }
    */
    public List<Tweet> Data { get; set; }

}

class Tweet
{
    public List<string> edit_history_tweet_ids { get; set; }
    public string id { get; set; }
    public string text { get; set; }
}

