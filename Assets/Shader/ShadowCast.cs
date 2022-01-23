using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCast : MonoBehaviour
{
    [SerializeField] private Material _shadowMat;
    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _vollight;
    [SerializeField] private Vector3 _volLightDir;

    private void Update()
    {
        _shadowMat.SetVector("LightPosition", _light.transform.position);
        transform.LookAt(_volLightDir);
    }
}
