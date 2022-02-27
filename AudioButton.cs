
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace UdonVR.UserStuff
{
    public class AudioButton : UdonSharpBehaviour
    {
        [Tooltip("Not needed in `Play New` is active")]
        public AudioSource audioSource;
        
        [Tooltip("Audio clip to be played")]
        public AudioClip audioClip;
        
        [Tooltip("If true, the button will start a new clip instead of restarting the existing one")]
        public bool playNew = false;
        
        [Tooltip("The volume the audio source gets set to when playing")]
        [Range(0f,1f)]public float vol;

        public override void Interact()
        {
            PlayAudio();
        }

        public void PlayAudio()
        {
            SendCustomNetworkEvent(NetworkEventTarget.All,"N_PlayAudio");
        }

        public void N_PlayAudio()
        {
            if (playNew)
            {
                AudioSource.PlayClipAtPoint(audioClip,transform.position,vol);
            }
            else
            {
                audioSource.Stop();
                audioSource.volume = vol;
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }   
}