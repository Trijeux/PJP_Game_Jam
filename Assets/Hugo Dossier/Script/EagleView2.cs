using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EagleView2 : MonoBehaviour
{
    private static readonly int Thickness = Shader.PropertyToID("_OutlineThickness");

    [SerializeField] private Material outlineMaterial;
    [SerializeField] private Material outlineMaterialTransparent;

    private float _outlineBaseValue;
    private float _outlineTransparentBaseValue;
    
    private bool _flag = false;
    private bool _inputEagleView = false;
    
    private void OnEagleVision(InputValue value)
    {
        _inputEagleView = value.isPressed;
    }
    
    private void Start()
    {
        _outlineBaseValue = outlineMaterial.GetFloat(Thickness);
        _outlineTransparentBaseValue = outlineMaterialTransparent.GetFloat(Thickness);
        
        outlineMaterial.SetFloat(Thickness, 0);
        outlineMaterialTransparent.SetFloat(Thickness, 0);
    }

    private void Update()
    {
        if (_inputEagleView && !_flag)
        {
            outlineMaterial.SetFloat(Thickness, outlineMaterial.GetFloat(Thickness ) == _outlineBaseValue ? 0.0f : _outlineBaseValue);
            outlineMaterialTransparent.SetFloat(Thickness, outlineMaterialTransparent.GetFloat(Thickness ) == _outlineTransparentBaseValue ? 0.0f : _outlineTransparentBaseValue);
            _flag = true;
        }
        else if (!_inputEagleView)
        {
            _flag = false;
        }
    }

    private void OnApplicationQuit()
    {
        outlineMaterial.SetFloat(Thickness, _outlineBaseValue);
        outlineMaterialTransparent.SetFloat(Thickness, _outlineTransparentBaseValue);
    }
}
