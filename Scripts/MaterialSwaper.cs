
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonVR.UserStuff
{

    public class MaterialSwaper : UdonSharpBehaviour
    {
        public GameObject[] rootObjects;
        [SerializeField] private MeshRenderer[] _meshRenderers;
        [SerializeField] private int[] _meshRendererInts;

        public Material[] mat1;
        public Material[] mat2;

        void Start()
        {
            Debug.Log("Run Start");
            MeshRenderer[] _tmpArray = new MeshRenderer[0];
            foreach (GameObject _obj in rootObjects)
            {
                _tmpArray = AddArray(_tmpArray, _obj.GetComponentsInChildren<MeshRenderer>());
            }
            _meshRenderers = _tmpArray;
            _meshRendererInts = new int[_meshRenderers.Length];

            Material _tmpMat;
            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                Debug.Log($"Starting check for renderer {i}");
                _tmpMat = _meshRenderers[i].sharedMaterial;
                _meshRendererInts[i] = -1;
                for (int j = 0; j < mat1.Length; j++)
                {
                    if (_tmpMat == mat1[j])
                    {
                        Debug.Log($"Assigning renderer {i} to material {j}");
                        _meshRendererInts[i] = j;
                    }
                    Debug.Log($"Renderer {i} is not material {j}");
                }
            }
        }

        public void SwapTo1()
        {
            Debug.Log("Run SwapTo1");
            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                if (_meshRendererInts[i] == -1) continue;
                _meshRenderers[i].material = mat1[_meshRendererInts[i]];
            }
        }
        public void SwapTo2()
        {
            Debug.Log("Run SwapTo2");
            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                if (_meshRendererInts[i] == -1) continue;
                _meshRenderers[i].material = mat2[_meshRendererInts[i]];
            }
        }

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
