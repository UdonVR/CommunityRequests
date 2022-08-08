
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonVR.UserStuff
{

    public class MaterialSwaper : UdonSharpBehaviour
    {
        public GameObject[] rootObjects;
        private MeshRenderer[] _meshRenderers;
        private int[] _meshRendererInts;

        public Material[] mat1;
        public Material[] mat2;

        void Start()
        {
            Debug.Log("Run Start");
            MeshRenderer[] _tmpArray = new MeshRenderer[0]; //initalize private array
            foreach (GameObject _obj in rootObjects)
                //finds all MeshRenderers in rootObjects and adds them all to _tmpArray
            {
                _tmpArray = AddArray(_tmpArray, _obj.GetComponentsInChildren<MeshRenderer>());
            }

            _meshRenderers = _tmpArray; //save _tmpArray as a perment variable
            _meshRendererInts = new int[_meshRenderers.Length]; //initalize private array

            Material _tmpMat; //tmp material for saving the current material
            for (int i = 0; i < _meshRenderers.Length; i++)
                //start indexing the materials
            {
                Debug.Log($"Starting check for renderer {i}");
                _tmpMat = _meshRenderers[i].sharedMaterial; //save current material as _tempMat
                _meshRendererInts[i] = -1; //set current index to -1. This is used if no material is found
                for (int j = 0; j < mat1.Length; j++)
                {
                    if (_tmpMat == mat1[j])
                        //if material matches the known material, save the index
                    {
                        Debug.Log($"Assigning renderer {i} to material {j}");
                        _meshRendererInts[i] = j;
                    }
                    Debug.Log($"Renderer {i} is not material {j}");
                }
            }
        }


        /// <summary>
        /// Swaps known indexed renderers to Varient 1
        /// </summary>
        public void SwapTo1()
        {
            Debug.Log("Run SwapTo1");
            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                if (_meshRendererInts[i] == -1) continue;
                _meshRenderers[i].material = mat1[_meshRendererInts[i]];
            }
        }

        /// <summary>
        /// Swaps known indexed renderers to Varient 1
        /// </summary>
        public void SwapTo2()
        {
            Debug.Log("Run SwapTo2");
            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                if (_meshRendererInts[i] == -1) continue;
                _meshRenderers[i].material = mat2[_meshRendererInts[i]];
            }
        }

        /// <summary>
        /// adds 2 arrays together
        /// </summary>
        private MeshRenderer[] AddArray(MeshRenderer[] _array1, MeshRenderer[] _array2)
        {
            MeshRenderer[] _tmpArray;

            _tmpArray = new MeshRenderer[_array1.Length + _array2.Length];
            int arrayPlace = 0;

            if (_array1.Length != 0)
            {
                foreach (MeshRenderer MR in _array1)
                {
                    _tmpArray[arrayPlace] = MR;
                    arrayPlace++;
                }
            }

            if (_array2.Length != 0)
            {
                foreach (MeshRenderer MR in _array2)
                {
                    _tmpArray[arrayPlace] = MR;
                    arrayPlace++;
                }
            }

            return _tmpArray;
        }
    }
}
