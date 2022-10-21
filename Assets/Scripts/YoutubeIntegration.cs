using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Net;

public class YoutubeIntegration : MonoBehaviour
{
    public static YoutubeIntegration youtubeIntegration;

    public string jSon;
 
    private string key = "AIzaSyAi3vi-7t-77ORnJakk1j8lm0tCGdc7GHc";
   
    public string liveChatId;
    
    public string videoID;

    private string channelid;

    public string kanalIsmi;

    public string status;
    
    public string videoLink;

    public List<Snippet> superChatUsers;
    
    private const string YoutubeLinkRegex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
    
    private  ExampleIRCListener userList;

    private LiveChatMesages liveChatMesages = new LiveChatMesages();

    private LiveChatKey liveChatKey = new LiveChatKey();

    private ChannelID channelID = new ChannelID();

    public ChannelID channelName = new ChannelID();

    private List<ChatMessages> items;

    private string channeLogoUrl;

    public RawImage profileImage;

    public Text channelNameText;

    public Texture2D texture = null;

    bool isFirstTime;

    // https://www.googleapis.com/youtube/v3/videos?id={YOUR_LIVESTREAM_VIDEO_ID}&key={YOUR_API_KEY}&part=liveStreamingDetails
    // https://www.googleapis.com/youtube/v3/liveChat/messages?liveChatId={LIVE_CHAT_ID}&part=snippet,authorDetails&key={API_KEY}

    private void Awake()
    {
        youtubeIntegration = this;
    }


    private void Start()
    {
        userList = ExampleIRCListener.userList;

      
      


    }

    IEnumerator SetImage(string url)
    {
       

        WWW www = new WWW(url);
        yield return www;

      
        texture = www.texture;
        texture.Apply();

        profileImage.GetComponent<RawImage>().texture = texture;
        profileImage.gameObject.SetActive(true);
        channelNameText.text = kanalIsmi;

        www = null;
    }



    void FindChannelID()
    {
        StartCoroutine(FindChannelIDRoutine());

        IEnumerator FindChannelIDRoutine()
        {

            WWW link = new WWW("https://www.googleapis.com/youtube/v3/videos?part=snippet&id=" + videoID + "&key=" + key);
            //https://www.googleapis.com/youtube/v3/videos?part=snippet&id=v7nd27uGc3E&key=AIzaSyAi3vi-7t-77ORnJakk1j8lm0tCGdc7GHc

            yield return link;
            if (link.error == null)
            {
                channelID = JsonUtility.FromJson<ChannelID>(link.text);

                if(channelID.items.Length > 0)
                {
                    channelid = channelID.items[0].snippet.channelId;
                    StartCoroutine(FindChannelName());
                }
                else
                {
                    status = "Canlý yayýn videosu bulunamadý link kontrol edip tekrar deneyin;";
                }

                

              

            }
          
        }

        IEnumerator FindChannelName()
        {

            WWW link = new WWW("https://www.googleapis.com/youtube/v3/channels?part=snippet&id=" + channelid + "&key=" + key);
            //https://www.googleapis.com/youtube/v3/channels?part=snippet&id=UCh1zT2Pgi5YmR4TV0rvDkpA&key=AIzaSyAi3vi-7t-77ORnJakk1j8lm0tCGdc7GHc

            yield return link;
            if (link.error == null)
            {
              

                channelName = JsonUtility.FromJson<ChannelID>(link.text);

                kanalIsmi = channelName.items[0].snippet.title;

                channeLogoUrl = channelName.items[0].snippet.thumbnails.medium.url;

                StartCoroutine(SetImage(channeLogoUrl));

            }

        }



    }









    public void VideoIDFinder()
    {
        status = "Video ID Bulunuyor";
        
        TwitchIntegrationObject.twitchIntegrationObject.debugText.text = status;
        
        StartCoroutine(FindVideoID());

        IEnumerator FindVideoID()
        {
            yield return new WaitForSeconds(1.5f);
            var regex = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
            foreach (Match match in regex.Matches(videoLink))
            {
                //Console.WriteLine(match);
                foreach (var groupdata in match.Groups.Cast<Group>().Where(groupdata => !groupdata.ToString().StartsWith("http://") && !groupdata.ToString().StartsWith("https://") && !groupdata.ToString().StartsWith("youtu") && !groupdata.ToString().StartsWith("www.")))
                {
                    videoID = groupdata.ToString();
                }
            }
            FindChannelID();

            GetLiveChatId();
        }

           

    }

    IEnumerator ChechMessage(float time)
    {
        yield return new WaitForSeconds(time);
      
        if (TwitchIntegrationObject.twitchIntegrationObject.isConnectedYoutube)
        {
            StartCoroutine(ChechMessage(2));
            GetMessages();
        }
        else
        {
            status = "Çýkýþ yapýldý";

            TwitchIntegrationObject.twitchIntegrationObject.debugText.text = status;
        }

    }


    void GetLiveChatId()
    {
        StartCoroutine(GetLiveChatIdRoutinne());

        IEnumerator GetLiveChatIdRoutinne()
        {
            WWW link = new WWW("https://www.googleapis.com/youtube/v3/videos?id="+ videoID + "&key="+key+"&part=liveStreamingDetails");

            yield return link;
            if (link.error == null)
            {

                Debug.Log(link.text);

                status = "Canlý Chat ID'si Bulunuyor...";

                TwitchIntegrationObject.twitchIntegrationObject.debugText.text = status;

                liveChatKey = JsonUtility.FromJson<LiveChatKey>(link.text);

                if (liveChatKey.items.Length>0)
                {
                    liveChatId = liveChatKey.items[0].liveStreamingDetails.activeLiveChatId;
                }

                else
                {
                    status = "Canlý Yayýn Chat ID'si Bulunamadý Linki Kontrol Ediniz";

                    TwitchIntegrationObject.twitchIntegrationObject.debugText.text = status;
                }
               

                StartCoroutine(ChechMessage(0.5f));
            }
            else
            {
                Debug.Log(link.error);
            }

        }
    }



    void GetMessages()
    {
        StartCoroutine(GetMessageFromWeb());

        IEnumerator GetMessageFromWeb()
        {
            WWW link = new WWW("https://www.googleapis.com/youtube/v3/liveChat/messages?liveChatId="+liveChatId+"&part=snippet,authorDetails&key="+key+"&pageToken=" + liveChatMesages.nextPageToken);

            jSon = "https://www.googleapis.com/youtube/v3/liveChat/messages?liveChatId=" + liveChatId + "&part=snippet,authorDetails&key=" + key + "&pageToken=" + liveChatMesages.nextPageToken;

            yield return link;
            if (link.error == null)
            {
                liveChatMesages = JsonUtility.FromJson<LiveChatMesages>(link.text);
                status = "Baðlantý Baþarýlý ";

                TwitchIntegrationObject.twitchIntegrationObject.debugText.text = status;

                if (isFirstTime)
                {
                    for (int i = 0; i < liveChatMesages.items.Length; i++)
                    {
                        Rate(i);
                        Join(i);
                        SuperChatUser(i);

                    }
                }

                isFirstTime = true;




            }
            
            else
            {
                
                Debug.Log(link.error);
            }

        }
    }

    void Join(int i)
    {
        if (liveChatMesages.items[i].snippet.displayMessage == userList.joinCommand)
        {
           

            userList.pcTaskList.Add(liveChatMesages.items[i].authorDetails.displayName);

            ExampleIRCListener.userList.pcTaskList.Add(liveChatMesages.items[i].authorDetails.displayName);

            TwitchIntegrationObject.twitchIntegrationObject.ShowJoinedUser(liveChatMesages.items[i].authorDetails.displayName);

          //  TwitchIRC.twitchIRC.stream.WriteLine("PRIVMSG #" + TwitchIRC.twitchIRC.twitchDetails.channel.ToLower() + " :" + liveChatMesages.items[i].authorDetails.displayName + " katýldý");


        }
    }

    void SuperChatUser(int i)
    {
        bool enoughfMoney=false;
        int pcID=-1;

        if (liveChatMesages.items[i].snippet.superChatDetails.amountDisplayString.Length > 0) 
        {
          
             string temp="";

            for (int j = 4; j < liveChatMesages.items[i].snippet.superChatDetails.amountDisplayString.Length; j++)
            {
                if (!Char.IsNumber(liveChatMesages.items[i].snippet.superChatDetails.amountDisplayString[j]))
                {
                    break;
                }

                else
                {
                    temp += liveChatMesages.items[i].snippet.superChatDetails.amountDisplayString[j];

                }
            }

            if (temp != "")
            {

                for (int j = 0; j < GameManager.gameManager.salablePCs.Count; j++)
                {
                    if (int.Parse(temp) >= GameManager.gameManager.salablePCs[j].price)
                    {
                        enoughfMoney = true;
                        pcID = i;
                        if (GameManager.gameManager.salablePCs.Count > 1)
                        {

                            if (liveChatMesages.items[i].snippet.superChatDetails.userComment.Contains(GameManager.gameManager.salablePCs[j].caseName))
                            {
                                AIManager.aiManager.SpawnManager(GameManager.gameManager.salablePCs[j].table, liveChatMesages.items[i].authorDetails.displayName, "Youtube");

                                enoughfMoney = false;
                            }



                        }

                        else if (GameManager.gameManager.salablePCs.Count == 1)
                        {
                            AIManager.aiManager.SpawnManager(GameManager.gameManager.salablePCs[j].table, liveChatMesages.items[i].authorDetails.displayName, "Youtube");
                            enoughfMoney = false;
                        }

                    }

                }

                if (enoughfMoney&& GameManager.gameManager.salablePCs.Count>0)
                {
                    AIManager.aiManager.SpawnManager(GameManager.gameManager.salablePCs[i].table, liveChatMesages.items[i].authorDetails.displayName, "Youtube");
                }
                //

                

            }
                
        }



    }


        void Rate(int i)
    {

        if (liveChatMesages.items[i].snippet.displayMessage.Contains(userList.rateCommand))
        {
            if (TwitchIntegration.twitchIntegration!=null &&TwitchIntegration.twitchIntegration.isVoting)
            {
                string[] msg;
                bool isN = true;
                msg = liveChatMesages.items[i].snippet.displayMessage.Split(' ');

                for (int j = 0; j < msg[1].Length; j++)
                {
                    if (!Char.IsNumber(msg[1][j]))
                    {
                        isN = false;
                    }
                }

                if (isN && msg[1].Length > 0)
                {
                    if (int.Parse(msg[1]) >= 100)

                    {
                        userList.voterList.Add(100);


                    }
                    else if (int.Parse(msg[1]) <= 0)
                    {
                        userList.voterList.Add(0);
                    }
                    else
                    {
                        userList.voterList.Add(int.Parse(msg[1]));
                    }

                    TwitchIntegration.twitchIntegration.UpdateScore();

                }
            }

        }

    }

    [System.Serializable]
    public class ChannelID
    {

        [NonReorderable]
        public ChannelIDItems[] items;


    }



    [System.Serializable]
    public class ChannelIDItems
    {


        public ChannelIDSnippet snippet;
       

    }


    [System.Serializable]
    public class ChannelIDSnippet
    {

        public string channelId;
        public string title;
        public Thumbnails thumbnails;




    }

    [System.Serializable]
    public class Thumbnails
    {
        public Medium medium;
    }

    [System.Serializable]
    public class Medium
    {
        public string url;

    }


    [System.Serializable]
    public class LiveChatKey
    {
        [NonReorderable]
        public LiveChatItems[] items;
      

    }

    [System.Serializable]
    public class LiveChatItems
    {
      
        public LiveStreamingDetails liveStreamingDetails;


    }

    [System.Serializable]
    public class LiveStreamingDetails
    {
        public string name = "activeLiveChatId";
        public string activeLiveChatId;

    }
     



        [System.Serializable]
    public class LiveChatMesages
    {
        public  ChatMessages[] items;
        public string nextPageToken;

    }

  
    [System.Serializable]
    public class ChatMessages
    {
        public string name = "User Message";
        public Snippet snippet;
        public AuthorDetails authorDetails;

    }

    [System.Serializable]
    public class Snippet
    {
        public string displayMessage;
        public SuperChatDetails superChatDetails= new SuperChatDetails();
    }
    [System.Serializable]
    public class SuperChatDetails
    {
        public string amountDisplayString="";
        public string currency;
        public string userComment;
        public string money;
    }
    
    [System.Serializable]
    public class AuthorDetails
    {
        public string displayName;

    }


}
