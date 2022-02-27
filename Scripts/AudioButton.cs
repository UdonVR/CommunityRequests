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
        [SerializeField]private AudioSource audioSource;
        
        [Tooltip("Audio clip to be played")]
        [SerializeField]private AudioClip audioClip;
        
        [Tooltip("If true, the button will start a new clip instead of restarting the existing one")]
        [SerializeField]private bool playNew = false;
        
        [Tooltip("The volume the audio source gets set to when playing")]
        [Range(0f,1f)][SerializeField]private float vol = 0.5f;

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
