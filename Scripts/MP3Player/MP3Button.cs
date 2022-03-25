
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonVR.UserStuff.MP3
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)] //forces the UdonBehaviour to not have any network syncing. This is better for performance.
    public class MP3Button : UdonSharpBehaviour
    {
        public MP3Controller controller;
        public int clip = 0;
        
        public override void Interact()
        //this is called when you use on the object the script is attached to.
        //you can also have UI buttons call this directly.
        {
            controller.PlayClip(clip);
        }
    }
}
