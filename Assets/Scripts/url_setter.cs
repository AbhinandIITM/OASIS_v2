using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class url_setter : MonoBehaviour
{
    public AvatarUrlGetter getter;

    public TextMeshProUGUI UID;
    public TextMeshProUGUI error_msg;
    private OASIS_DB db;
    public void Start(){
        getter = FindObjectOfType<AvatarUrlGetter>();
        if(getter != null){
            Debug.Log("getter found");
        }
    db = FindObjectOfType<OASIS_DB>();
    }
    public string ExtractUidFromUrl(string url)
    {
        string[] parts = url.Split('/');
        
        // Check if the split array contains the expected part
        if (parts.Length > 5)
        {
            return parts[5]; // This is the UID part in the example URL
        }
        else
        {
            Debug.LogError("URL format is incorrect.");
            return null;
        }
    }
    public void try_url(){
        // string url =getter.GetAvatarUrl();
        // Debug.Log(url);
        StartCoroutine(WaitAndGetUrl());
    }
    private IEnumerator WaitAndGetUrl()
    {
        yield return new WaitUntil(() => getter.GetAvatarUrl() != null);
        url(); // Call the url method here after the URL is available
    }
    public void url(){
        string url =getter.GetAvatarUrl();
        Debug.Log(url);
        // string uid = ExtractUidFromUrl(url);
        string uid = UID.text;
        if(uid != "")
        {
            Debug.Log(uid);
            db.AddDataToSheet(uid,url);
        }
        else
        {
            error_msg.text = "Enter valid UID!";
        }
        
    }
    
}
