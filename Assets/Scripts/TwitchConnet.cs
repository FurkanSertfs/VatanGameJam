using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Net.Sockets;
using System.IO;



public class TwitchConnet : MonoBehaviour
{

    public UnityEvent<string, string> OnChatMessage;
    TcpClient Twitch;
    StreamReader Reader;
    StreamWriter Writer;

    const string URL = "irc.chat.twitch.tv";
    const int PORT = 6667;

    string User = "mecetfree";

    string OAuth = "oauth:s27whwnyq05bwrogdsogtlrwxjaqna";
    string Channel = "grimnax";

    float PingCounter = 0;
    private void ConnectToTwitch()
    {
        Twitch = new TcpClient(URL, PORT);
        Reader = new StreamReader(Twitch.GetStream());
        Writer = new StreamWriter(Twitch.GetStream());

        Writer.WriteLine("PASS " + OAuth);
        Writer.WriteLine("NICK " + User.ToLower());
        Writer.WriteLine("JOIN #" + Channel.ToLower());
        Writer.Flush();



    }
    private void Awake()
    {
        ConnectToTwitch();

    }
    void Update()
    {
        PingCounter += Time.deltaTime;
        if(PingCounter > 60)
        {
            Writer.WriteLine("PING" + URL);


        }

        if (!Twitch.Connected)
        {
           
            ConnectToTwitch();

        }
        else
        {
        
        }
       if(Twitch.Available > 0)
        {
          
            string message = Reader.ReadLine();
            print(message);
            if (message.Contains("PRIVMSG"))
            {
                int splitPoint = message.IndexOf("!");
                string chatter = message.Substring(1, splitPoint - 1);

                splitPoint = message.IndexOf(":", 1);
                string msg = message.Substring(splitPoint + 1);

                OnChatMessage?.Invoke(chatter, msg);
                print(message);

            }
        }

    }
}
