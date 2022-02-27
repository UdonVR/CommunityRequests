 /* Avatar Proxy
 *
 * a proxy script that changes the user's avatar to the target pedestal.
 * 
 */
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonVR.Avatars
{
    public class AvatarProxy : UdonSharpBehaviour
    {
        public VRC_AvatarPedestal ped;
        public override void Interact()
        {
            ped.SetAvatarUse(Networking.LocalPlayer);
        }
    }
}
