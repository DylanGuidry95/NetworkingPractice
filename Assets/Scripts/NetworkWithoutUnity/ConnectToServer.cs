using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ConnectToServer : MonoBehaviour
{
    public Button confirm;
    public InputField url;


public void ConnectTo()
    {
        WebAsync webAsync = new WebAsync();
        string link = url.text;
        if (!link.Contains("http://www."))
            link = "http://www." + link;

        StartCoroutine(webAsync.CheckForMissingURL(link));
           

        if (webAsync.isURLmissing == false)
            Debug.Log("All Good");
        else
            Debug.Log("fucked up");

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
