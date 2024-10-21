using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class send_link_sheet : MonoBehaviour
{
    [SerializeField] private string baseURL = "https://script.google.com/macros/s/AKfycbyK1T5ZyNLVvCGe1vUrwD-p9uwJJjIkS_4nxFIH9l_S0DzrzG7JwqmFN1s9fYKUtn_h/exec"; // Replace with your Google Apps Script URL

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
}
