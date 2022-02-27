/* Camera System
 *
 * a 9 camera security system script with polling support
 * if you want to add more cameras, copy and paste one of the "Camera X" regions and increment the number.
 *
 * Warning with adding more cameras:
 * Because of the Udon works, the more Public methods you add the slower the script will become.
 * don't add more camera regions then you need, and removed extras that you dont need.
 */
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Enums;

namespace UdonVR.UserStuff
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class CameraSystem : UdonSharpBehaviour
    {
        public GameObject[] Cameras;
        private bool[] CamerasOn;
        public bool isPolling = false;
        private int _curPoll = 0;
        private int _pastPoll = -1;
        /// <summary>
        /// Turns all of the cameras on, then turns them off next frame when the world loads in.
        /// </summary>
        void Start()
        {
            CamerasOn = new bool[Cameras.Length];
            AllOn();
            SendCustomEventDelayedFrames("AllOff",1);
        }

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            AllOn();
            /*
            for (int i = 0; i < Cameras.Length; i++)
            {
                CamerasOn[i] = Cameras[i].activeSelf;
            }
            */
            SendCustomEventDelayedFrames("OnPlayerJoined2",1);
            SendCustomEventDelayedSeconds("",1f,EventTiming.LateUpdate);
        }

        private void OnPlayerJoined2()
        {
            for (int i = 0; i < Cameras.Length; i++)
            {
                Cameras[i].SetActive(CamerasOn[i]);
            }
        }
        public void PollingToggle()
        {
            isPolling = !isPolling;
        }
        public void PollingOn()
        {
            isPolling = true;
        }
        public void PollingOff()
        {
            isPolling = true;
        }
        public override void PostLateUpdate()
        {
            if (isPolling)
            {
                _curPoll = _curPoll + 1;
                if (_curPoll >= Cameras.Length) _curPoll = 0;
                Cameras[_curPoll].SetActive(true);
                if (_pastPoll != -1 && CamerasOn[_pastPoll] == false)
                {
                    Cameras[_pastPoll].SetActive(false);
                }
                _pastPoll = _curPoll;
            }
        }

        public void PollCamDone()
        {
            Cameras[_curPoll].SetActive(false);
        }

        /// <summary>
        /// Turns all of the cameras on, then turns them off next frame.
        /// </summary>
        public void AllUpdate()
        {
            AllOn();
            SendCustomEventDelayedFrames("AllOff",1);
        }
        /// <summary>
        /// Turns all of the cameras on.
        /// </summary>
        public void AllOn()
        {
            foreach (GameObject _camera in Cameras)
            {
                _camera.SetActive(true);
            }
        }
        /// <summary>
        /// Turns all of the Cameras off.
        /// </summary>
        public void AllOff()
        {
            foreach (GameObject _camera in Cameras)
            {
                _camera.SetActive(false);
            }
        }

        #region Camera 0
        /// <summary>
        /// Sets Camera 0 to ON, then Off on the next frame. </summary>
        public void Camera0_Update()
        {
            Cameras[0].SetActive(true);
            SendCustomEventDelayedFrames("Camera1_Off",1);
        }
        /// <summary>
        /// Sets Camera 0 to ON. </summary>
        public void Camera0_On()
        {
            CamerasOn[0] = true;
            Cameras[0].SetActive(true);
        }
        /// <summary>
        /// Sets Camera 0 to Off. </summary>
        public void Camera0_Off()
        {
            CamerasOn[0] = false;
            Cameras[0].SetActive(false);
        }
        #endregion
        #region Camera 1
        /// <summary>
        /// Sets Camera 1 to ON, then Off on the next frame.
        /// </summary>
        public void Camera1_Update()
        {
            Cameras[1].SetActive(true);
            SendCustomEventDelayedFrames("Camera1_Off",1);
        }
        /// <summary>
        /// Sets Camera 1 to ON.
        /// </summary>
        public void Camera1_On()
        {
            CamerasOn[1] = true;
            Cameras[1].SetActive(true);
        }
        /// <summary>
        /// Sets Camera 1 (1 in the array) to Off.
        /// </summary>
        public void Camera1_Off()
        {
            CamerasOn[1] = false;
            Cameras[1].SetActive(false);
        }
        #endregion
        #region Camera 2
        /// <summary>
        /// Sets Camera 2 to ON, then Off on the next frame.
        /// </summary>
        public void Camera2_Update()
        {
            Cameras[2].SetActive(true);
            SendCustomEventDelayedFrames("Camera2_Off",2);
        }
        /// <summary>
        /// Sets Camera 2 to ON.
        /// </summary>
        public void Camera2_On()
        {
            CamerasOn[2] = true;
            Cameras[2].SetActive(true);
        }
        /// <summary>
        /// Sets Camera 2 (2 in the array) to Off.
        /// </summary>
        public void Camera2_Off()
        {
            CamerasOn[2] = false;
            Cameras[2].SetActive(false);
        }
        #endregion
        #region Camera 3
        /// <summary>
        /// Sets Camera 3 to ON, then Off on the next frame.
        /// </summary>
        public void Camera3_Update()
        {
            Cameras[3].SetActive(true);
            SendCustomEventDelayedFrames("Camera3_Off",3);
        }
        /// <summary>
        /// Sets Camera 3 to ON.
        /// </summary>
        public void Camera3_On()
        {
            CamerasOn[3] = true;
            Cameras[3].SetActive(true);
        }
        /// <summary>
        /// Sets Camera 3 (3 in the array) to Off.
        /// </summary>
        public void Camera3_Off()
        {
            CamerasOn[3] = false;
            Cameras[3].SetActive(false);
        }
        #endregion
        #region Camera 4
        /// <summary>
        /// Sets Camera 4 to ON, then Off on the next frame.
        /// </summary>
        public void Camera4_Update()
        {
            Cameras[4].SetActive(true);
            SendCustomEventDelayedFrames("Camera4_Off",4);
        }
        /// <summary>
        /// Sets Camera 4 to ON.
        /// </summary>
        public void Camera4_On()
        {
            CamerasOn[4] = true;
            Cameras[4].SetActive(true);
        }
        /// <summary>
        /// Sets Camera 4 (4 in the array) to Off.
        /// </summary>
        public void Camera4_Off()
        {
            CamerasOn[4] = false;
            Cameras[4].SetActive(false);
        }
        #endregion
        #region Camera 5
        /// <summary>
        /// Sets Camera 5 to ON, then Off on the next frame.
        /// </summary>
        public void Camera5_Update()
        {
            Cameras[5].SetActive(true);
            SendCustomEventDelayedFrames("Camera5_Off",5);
        }
        /// <summary>
        /// Sets Camera 5 to ON.
        /// </summary>
        public void Camera5_On()
        {
            CamerasOn[5] = true;
            Cameras[5].SetActive(true);
        }
        /// <summary>
        /// Sets Camera 5 (5 in the array) to Off.
        /// </summary>
        public void Camera5_Off()
        {
            CamerasOn[5] = false;
            Cameras[5].SetActive(false);
        }
        #endregion
        #region Camera 6
        /// <summary>
        /// Sets Camera 6 to ON, then Off on the next frame.
        /// </summary>
        public void Camera6_Update()
        {
            Cameras[6].SetActive(true);
            SendCustomEventDelayedFrames("Camera6_Off",6);
        }
        /// <summary>
        /// Sets Camera 6 to ON.
        /// </summary>
        public void Camera6_On()
        {
            CamerasOn[6] = true;
            Cameras[6].SetActive(true);
        }
        /// <summary>
        /// Sets Camera 6 (6 in the array) to Off.
        /// </summary>
        public void Camera6_Off()
        {
            CamerasOn[6] = false;
            Cameras[6].SetActive(false);
        }
        #endregion
        #region Camera 7
        /// <summary>
        /// Sets Camera 7 to ON, then Off on the next frame.
        /// </summary>
        public void Camera7_Update()
        {
            Cameras[7].SetActive(true);
            SendCustomEventDelayedFrames("Camera7_Off",7);
        }
        /// <summary>
        /// Sets Camera 7 to ON.
        /// </summary>
        public void Camera7_On()
        {
            CamerasOn[7] = true;
            Cameras[7].SetActive(true);
        }
        /// <summary>
        /// Sets Camera 7 (7 in the array) to Off.
        /// </summary>
        public void Camera7_Off()
        {
            CamerasOn[7] = false;
            Cameras[7].SetActive(false);
        }
        #endregion
        #region Camera 8
        /// <summary>
        /// Sets Camera 8 to ON, then Off on the next frame.
        /// </summary>
        public void Camera8_Update()
        {
            Cameras[8].SetActive(true);
            SendCustomEventDelayedFrames("Camera8_Off",8);
        }
        /// <summary>
        /// Sets Camera 8 to ON.
        /// </summary>
        public void Camera8_On()
        {
            CamerasOn[8] = true;
            Cameras[8].SetActive(true);
        }
        /// <summary>
        /// Sets Camera 8 (8 in the array) to Off.
        /// </summary>
        public void Camera8_Off()
        {
            CamerasOn[8] = false;
            Cameras[8].SetActive(false);
        }
        #endregion
    }
}
