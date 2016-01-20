using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ServerGUI : MonoBehaviour
{
    [Header("Create Servers")]
    public GameObject ServerCreation;
    public InputField ServerName;
    public InputField HostName;

    public GameObject Player;

    void OnServerInitialized()
    {
        SpawnPlayer();
    }

    void OnConnectedToServer()
    {
        SpawnPlayer();
    }

    public void CreateServer()
    {
        Network.InitializeServer(32, 25002, !Network.HavePublicAddress());
        MasterServer.RegisterHost("Networking Demo" , ServerName.text, HostName.text);
    }

    void ClearList(Button[] b)
    {
        for(int i = 0; i < b.Length; i++)
        {
            Destroy(b[i].gameObject);
        }
    }

    void OnGUI()
    {
        if (Network.isServer)
            GUILayout.Label("Running as a server");
        else if (Network.isClient)
            GUILayout.Label("Running as a client");
        //Gets the list of all Host playing the game
        MasterServer.RequestHostList("Networking Demo");
        //Creates a array of all servers in the list
        HostData[] data = MasterServer.PollHostList();

        // Go through all the hosts in the host list
        foreach (var element in data)
        {
            GUILayout.BeginHorizontal();
            var name = element.gameName + " " + element.connectedPlayers + " / " + element.playerLimit;
            GUILayout.Label(name);
            GUILayout.Space(5);
            string hostInfo;
            hostInfo = "[";
            foreach (var host in element.ip)
                hostInfo = hostInfo + host + ":" + element.port + " ";
            hostInfo = hostInfo + "]";
            GUILayout.Label(hostInfo);
            GUILayout.Space(5);
            GUILayout.Label(element.comment);
            GUILayout.Space(5);
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Connect"))
            {
                // Connect to HostData struct, internally the correct method is used (GUID when using NAT).
                Network.Connect(element);
            }

            GUILayout.EndHorizontal();
        }
    }

    void SpawnPlayer()
    {
        Network.Instantiate(Player, Vector3.zero, Quaternion.identity, 0);
    }
}
