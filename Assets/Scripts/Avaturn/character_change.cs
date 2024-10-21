using Avaturn.Core.Runtime.Scripts.Avatar.Data;
using UnityEngine;

namespace Avaturn.Core.Runtime.Scripts.Avatar
{
  [RequireComponent(typeof(AvaturnIframeController))]
  public class CharacterChange : MonoBehaviour
  {
    public string URL = "https://assets.hub.in3d.io/model_2022_12_22_T182855_939_9f0cea445f.glb";
    private AvaturnIframeController _avaturnIframeController;

    public void Start()
    {
      // Cache the AvaturnIframeController component to avoid repeated GetComponent calls
      _avaturnIframeController = GetComponentInChildren<AvaturnIframeController>();
    }

    public void Update()
    {
      // Check if the "E" key is pressed
      if (Input.GetKeyDown(KeyCode.E))
      {
        // Initiate avatar download when "E" key is pressed
        _avaturnIframeController.DownloadAvatar.Download(
          new AvatarInfo(URL, "", "DownloadAvatarTest", "DownloadAvatarTest", "DownloadAvatarTest"));
      }
    }
  }
}
