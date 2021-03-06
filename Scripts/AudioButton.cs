/* AudioButton
 * 
 * Plays a single audio clip when interacted with.
 * if playNew is true, then it creates an audio source allowing you to play clips over each other.
 */
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace UdonVR.UserStuff
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
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
            if (audioClip == null)
            {
                Debug.LogError("No Audio Clip attached.");
                return;
            }
            if (playNew)
            {
                AudioSource.PlayClipAtPoint(audioClip,transform.position,vol);
            }
            else
            {
                if (audioSource == null)
                {
                    Debug.LogError("No Audio Source attached.");
                    return;
                }
                audioSource.Stop();
                audioSource.volume = vol;
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }   
}
