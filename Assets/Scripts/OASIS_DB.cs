using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class OASIS_DB : MonoBehaviour
{
    private string baseURL = "https://script.google.com/macros/s/AKfycbyvvng3Tt1qkR2whFhlpNCfHRlR8WWW4FEj3XLO3gYPwGMJvvY6pcnapxrgeXDc_xV6/exec"; // Replace with your Google Apps Script URL

    // Method to initiate the link retrieval
    public void GetLinkByUid(string uid, Action<string> callback)
    {
        StartCoroutine(FetchLinkCoroutine(uid, callback));
    }

    // Coroutine to fetch the link for the given UID, providing the result via callback
    private IEnumerator FetchLinkCoroutine(string uid, Action<string> callback)
    {
        string url = $"{baseURL}?uid={uid}";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;
                LinkResponse response = JsonUtility.FromJson<LinkResponse>(json);
                callback?.Invoke(response.link);
            }
            else
            {
                Debug.LogError("Failed to fetch link: " + request.error);
                callback?.Invoke(null); // Return null if there's an error
            }
        }
    }

    // Method to initiate adding UID and link, to be called from another script
    public void AddDataToSheet(string uid, string link)
    {
        StartCoroutine(PostUidAndLinkCoroutine(uid, link));
    }

    private IEnumerator PostUidAndLinkCoroutine(string uid, string link)
    {
        WWWForm form = new WWWForm();
        form.AddField("uid", uid);
        form.AddField("link", link);

        using (UnityWebRequest request = UnityWebRequest.Post(baseURL, form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Successfully added UID and link to Google Sheets.");
            }
            else
            {
                Debug.LogError("Failed to add UID and link: " + request.error);
            }
        }
    }

    // Public class to handle the link response from JSON
    [Serializable]
    public class LinkResponse
    {
        public string link;
    }
    public void test(){
        string url = "test_url";
        string uid = "test_uid";
        AddDataToSheet(uid, url);
    }
}
