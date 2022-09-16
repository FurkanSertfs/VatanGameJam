using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class Test : MonoBehaviour
{


     LiveChatMesages liveChatMesages = new LiveChatMesages();

    public UserMessage userMessage;



    private void Start()
    {
        StartCoroutine(ChechMessage(2));
      
    }

    IEnumerator ChechMessage(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(ChechMessage(2));
        GetMessages();
    }

    void GetMessages()
    {
        StartCoroutine(GetMessageFromWeb());

        IEnumerator GetMessageFromWeb()
        {
            WWW link = new WWW("https://www.googleapis.com/youtube/v3/liveChat/messages?liveChatId=Cg0KC1pqWk9BY0cydjlFKicKGFVDMWdwZmVNMGVSSzJJaGRROHVJeUJjURILWmpaT0FjRzJ2OUU&part=snippet,authorDetails&key=AIzaSyAi3vi-7t-77ORnJakk1j8lm0tCGdc7GHc&pageToken=" + liveChatMesages.nextPageToken);

          
            yield return link;
            if (link.error == null)
            {
                
                Debug.Log(link.text);
                liveChatMesages = JsonUtility.FromJson<LiveChatMesages>(link.text);


                for (int i = 0; i < liveChatMesages.items.Length; i++)
                {
                    userMessage.items.Add(liveChatMesages.items[i]);
                }
            }
            else
            {
                Debug.Log(link.error);
            }

        }
    }

   



    [System.Serializable]
    public class LiveChatMesages
    {
        public  ChatMessages[] items;
        public string nextPageToken;

    }

    [System.Serializable]
    public class UserMessage
    {
        public List<ChatMessages>  items;
       

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
    }
    [System.Serializable]
    public class AuthorDetails
    {
        public string displayName;

    }


}
