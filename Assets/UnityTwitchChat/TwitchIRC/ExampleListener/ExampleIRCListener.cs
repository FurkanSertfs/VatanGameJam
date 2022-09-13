using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleIRCListener : MonoBehaviour
{
    private TwitchIRC IRC;

    public List<int> voterList;



    public static ExampleIRCListener userList;

    private void Awake()
    {
        userList = this;
    }


    private void Start()
    {
        // This is done just for the sake of simplicity,
        // In your own script, you should instead have a direct reference 
        // to the TwitchIRC component (inspector)
        IRC = GameObject.Find("TwitchIRC").GetComponent<TwitchIRC>();

        // Add an event listener for new chat messages
        IRC.newChatMessageEvent.AddListener(NewMessage);
    }

    // This gets called whenever a new chat message is received
    public void NewMessage(Chatter chatter)
    {
        Debug.Log(
            "<color=cyan>New chatter object received!</color>" 
            + " Chatter's name: " + chatter.tags.displayName
            + " Chatter's message: " + chatter.message);

        // Here are some examples on how you could use the chatter objects...

        if (chatter.tags.displayName == "Lexone")
            Debug.Log("Chat message was sent by Lexone!");

        if (chatter.HasBadge("subscriber"))
            Debug.Log("Chat message sender is a subscriber");

        if (chatter.HasBadge("moderator"))
            Debug.Log("Chat message sender is a channel moderator");

        if (chatter.MessageContainsEmote("25")) //25 = Kappa emote ID
            Debug.Log("Chat message contained the Kappa emote");

        if (chatter.message == "!join")
            Debug.Log(chatter.tags.displayName + " said !join");
      
        if (chatter.message.Contains("!vote"))
        {
            if (TwitchIntegration.twitchIntegration.isVoting)
            {
                string[] msg;
                bool isN = true;
                msg = chatter.message.Split(' ');

                for (int i = 0; i < msg[1].Length; i++)
                {
                    if (!Char.IsNumber(msg[1][i]))
                    {
                        isN = false;
                    }
                }
                if (isN)
                {
                    if (int.Parse(msg[1]) >= 100)

                    {
                        voterList.Add(100);


                    }
                    else if (int.Parse(msg[1]) <= 0)
                    {
                        voterList.Add(0);
                    }
                    else
                    {
                        voterList.Add(int.Parse(msg[1]));
                    }

                  TwitchIntegration.twitchIntegration.UpdateScore();

                }
            }
            
        }

        // Get chatter's name color (RGBA Format)
        Color nameColor = chatter.GetRGBAColor();

        // Check if chatter's display name is "font safe"
        //
        // Most fonts don't support unusual characters
        // If that's the case then you could use their login name instead (chatter.login) or use a fallback font
        // Login name is always lowercase and can only contain characters: a-z, A-Z, 0-9, _
        if (chatter.IsDisplayNameFontSafe())
            Debug.Log("Chatter's displayName is font-safe (only characters: a-z, A-Z, 0-9, _)");


        // Save latest chatter object
        // This is just to show how the Chatter object looks like inside the Inspector
      //  latestChatter.Add(chatter);
    }
}
