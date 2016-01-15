using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NetworkSystems : MonoBehaviour
{
    void OnGUI()
    {
        if(GUILayout.Button("Start Server"))
        {
            Network.InitializeServer(32, 25002, !Network.HavePublicAddress());
            MasterServer.RegisterHost("MyGame", "We are playing", "We are family");
        }
    }


}
