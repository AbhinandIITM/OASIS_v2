using UnityEngine;
using Avaturn.Core.Runtime.Scripts.Avatar.Data;

public class AvatarUrlGetter : MonoBehaviour
{
    private DrawAvatarInfo _drawAvatarInfo;

    private void Start()
    {
        _drawAvatarInfo = GetComponent<DrawAvatarInfo>();
        if (_drawAvatarInfo == null)
        {
            Debug.LogError("DrawAvatarInfo component not found on this GameObject.");
        }
    }

    public string GetAvatarUrl()
    {
        return _drawAvatarInfo != null ? _drawAvatarInfo.GetType().GetField("_avatarInfo", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(_drawAvatarInfo) is AvatarInfo avatarInfo ? avatarInfo.Url : null : null;
    }
}
