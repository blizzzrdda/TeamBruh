using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCast : MonoBehaviour
{
    [SerializeField] private Material _shadowMat;
    [SerializeField] private GameObject _light;

    private void Update()
    {
        _shadowMat.SetVector("LightPosition", _light.transform.position);
    }
}
