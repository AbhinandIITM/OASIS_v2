using System.Collections;
using System.Collections.Generic;
using Avaturn.Core.Runtime.Scripts.Avatar;
using UnityEngine;

public class test_retrieve_link : MonoBehaviour
{
    private OASIS_DB oasisDB;
    [SerializeField]
    private string uid;

    void Start()
    {
        oasisDB = FindObjectOfType<OASIS_DB>(); // Find the OASIS_DB instance in the scene
        RetrieveLink(uid); // Replace "user123" with the actual UID you want to query
    }

    private void RetrieveLink(string uid)
    {
        oasisDB.GetLinkByUid(uid, HandleLinkResponse);
    }

    // Callback function to handle the link once retrieved
    private void HandleLinkResponse(string link)
    {
        if (!string.IsNullOrEmpty(link))
        {
            Debug.Log($"Retrieved link: {link}");
            // Further processing with the link can be done here
            set_url(link);
        }
        else
        {
            Debug.LogError("Link retrieval failed or returned no link.");
        }
    }
    private void set_url(string url){
        DownloadAvatarTest go = gameObject.GetComponent<DownloadAvatarTest>();
        go.URL = url;
        go.enabled = true;
    }
}
