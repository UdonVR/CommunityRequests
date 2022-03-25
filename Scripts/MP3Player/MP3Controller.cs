
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonVR.UserStuff.MP3
{
    public class MP3Controller : UdonSharpBehaviour
    {
        [Tooltip("The list of clips used for the speaker.")]
        public AudioClip[] clips;
        
        [Tooltip("The speaker used to play the audio clips.")]
        public AudioSource speaker;

        [Tooltip("default = -1\n\nWill try playing the selected clip when the world starts.")]
        public int playOnStart = -1;
        void Start()
        {
            if (playOnStart <= -1) return; //if playOnStart is equal to or less than -1 it exits.
            PlayClip(playOnStart); //if playOnStart is greater than -1 it tries playing playOnStart
        }

        public void PlayClip(int _clip)
            //Tries to play the clip that's fed to it. This is used for the MP3Button script.
        {
            if (clips.Length >= _clip)
                //checks to see if the clip can exist before try to play.
            {
                
                
                if (clips[_clip] != null) 
                    //checks to see if the clip exists.
                {
                    speaker.Stop();
                    speaker.clip = clips[_clip];
                    speaker.Play();
                }
            }
        }
    }
}
