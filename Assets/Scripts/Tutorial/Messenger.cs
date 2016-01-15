using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Experimental.Networking;

public class Messenger : MonoBehaviour
{
    //static public Messenger Instance;
    //void Awake()
    //{
    //    Instance = GetComponent<Messenger>();
    //}

    //static private IEnumerator CheckURL()
    //{
    //    bool foundURL;
    //    string checkThisURL = "http://www.example.com/index.html";
    //    WebAsync webAsync = new WebAsync();

    //    yield return Instance.StartCoroutine(webAsync.CheckForMissingURL(checkThisURL));
    //    Debug.Log("Does " + checkThisURL + " exist? " + webAsync.isURLmissing);
    //}

    //WebAsync webAsync = new WebAsync();
    //void Update()
    //{
    //    StartCoroutine(AreWeConnectedToInternet());
    //}
    //private IEnumerator AreWeConnectedToInternet()
    //{
    //    bool areWe;
    //    WebRequest requestAnyURL = HttpWebRequest.Create("http://www.example.com");
    //    requestAnyURL.Method = "HEAD";

    //    IEnumerator e = webAsync.GetResponse(requestAnyURL);
    //    while (e.MoveNext()) { yield return e.Current; }

    //    areWe = (webAsync.requestState.errorMessage == null);

    //    Debug.Log("Are we connected to the inter webs? " + areWe);
    //}
}
