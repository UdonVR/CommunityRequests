using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonVR.UserStuff
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class PickupMaterialSwap : UdonSharpBehaviour
    {
        public MeshRenderer mesh;
        public Material mat1;
        public Material mat2;
        public bool useShared;
        [UdonSynced]public bool state;

        public override void OnPickupUseDown()
        { //Runs when you use an object
            state = (!state); //sets `state` to the opposite of its self
            _SetMaterial();
            RequestSerialization(); //Send the updated bool
        }

        private void _SetMaterial()
        { //sets the material to the synced bool `state`
            if(state) //checks to see if `state` is true
            //if `state` is true
            {
                if (useShared) //checks to see if `useShared` is true
                {
                    mesh.sharedMaterial = mat1; //sets the Shared Material of `mesh` to `mat1`
                } else 
                {
                    mesh.material = mat1; //sets the local Material of `mesh` to `mat1`
                }
            }
            else
            //if `state` is false
            {
                if (useShared) //checks to see if `useShared` is true
                //if `useShared` is true
                {
                    mesh.sharedMaterial = mat2; //sets the Shared Material of `mesh` to `mat2`
                }
                else 
                //if `useShared` is false
                {
                    mesh.material = mat2; //sets the local Material of `mesh` to `mat2`
                }
            }
        }

        public override void OnDeserialization()
        { //runs when the client recives new networking
            _SetMaterial();
        }
    }

}
