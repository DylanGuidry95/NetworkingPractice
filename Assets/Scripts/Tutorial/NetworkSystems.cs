using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NetworkSystems : MonoBehaviour
{
    public List<Button> connections;
    public List<string> servers;
    public Button bPrefab;
    public Text IP;

    public void CheckForServers()
    {
        ClearServers();
        if(servers.Count > 0)
        {
            for(int i = 0; i <= servers.Count; i++)
            { 
                Button peer = Instantiate(bPrefab);
                peer.GetComponent<Text>().text = Network.connections[i].ipAddress;
                connections.Add(peer);
            }
        }
        PlaceButtons();
    }

    void PlaceButtons()
    {
        if(connections != null || connections.Capacity > 0)
        {
            int x = 90;
            int y = -25;
            foreach (Button b in connections)
            {
                b.transform.position = new Vector3(x, y, 0);
                y -= 10;
                if (y < -55)
                {
                    y = -25;
                    x += 10;
                }
            }
        }
    }

    void SelectServer()
    {
        //bool isClicked;
        //foreach(Button b in connections)
        //{
        //    isClicked = b;
        //    if(isClicked == true)
        //    {
        //        ConnectToServer(b);
        //    }
        //}
    }

    //void ConnectToServer(Button b)
    //{
    //    Network.Connect(b.GetComponent<Text>().text);
    //}

    public void ConnectToServer(string ip)
    {
        string[] parse = ip.Split(':');
        Network.Connect(parse[0], parse[1]);
    }

    void ClearServers()
    {
        if(connections.Count != 0)
        {
            Button[] bTemp = connections.ToArray();
            connections = new List<Button>();
            Debug.Log(bTemp.Length);
            if(bTemp.Length != 0)
            {
                for (int i = 0; i <= bTemp.Length; i++)
                {
                    Destroy(bTemp[i]);
                }
            }
        }
    }

    public void CreateServer(string name)
    {
        bool useNat = !Network.HavePublicAddress();
        Network.InitializeServer(32, 25000,useNat);
        IP.text = Network.natFacilitatorIP;
    }

    void OnServerInitialized()
    {
        IP.gameObject.SetActive(true);
    }
}
