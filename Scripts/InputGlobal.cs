using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

namespace UdonVR.UserStuff
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class InputGlobal : UdonSharpBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Text[] texts;
        [SerializeField] private TextMeshProUGUI[] tmproTexts;

        [UdonSynced] private string _syncedString;

        public override void Interact()
        {
            Networking.SetOwner(Networking.LocalPlayer,gameObject);
            _syncedString = inputField.text;
            foreach (var txt in texts)
            {
                txt.text = _syncedString;
            }
            foreach (var txt in tmproTexts)
            {
                txt.text = _syncedString;
            }
            RequestSerialization();
        }

        public override void OnDeserialization()
        {
            foreach (var txt in texts)
            {
                txt.text = _syncedString;
            }
            foreach (var txt in tmproTexts)
            {
                txt.text = _syncedString;
            }
        }
    }
}
