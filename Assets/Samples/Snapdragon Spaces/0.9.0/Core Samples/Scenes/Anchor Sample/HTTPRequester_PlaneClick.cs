using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Proyecto26;
using Models;
using Newtonsoft.Json.Linq;

public class HTTPRequester_PlaneClick : MonoBehaviour
{
    string baseURL = Functions.baseURL;
    // float timeCnt = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable(){
        Post();
    }


    public void Post()
    {
        RestClient.Post<Post>(baseURL, new OpenNotificationBoard{
            deep = true
        }).Then(response => {
            Debug.Log("Latest Message"); ////////////////// PESUDO-CODE HERE ///
            //////////////////////////////////////////////
            RestClient.Post<ReturnReadUnreadMail>(baseURL + "unread", new ReadUnreadMail
            {
                readmode = "readone"
            }).Then(res =>
            {
                Debug.Log(
                    JObject.Parse(res.ToString())["unread_count"]
                );
            });
        });
    }
}