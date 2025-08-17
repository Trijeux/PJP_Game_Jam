using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EagleView2 : MonoBehaviour
{
    private static readonly int Thickness = Shader.PropertyToID("_OutlineThickness");
    private static readonly int Active = Shader.PropertyToID("_Active");

    [SerializeField] private Material outlineMaterial;
    [SerializeField] private Material outlineMaterialTransparent;

    private float _outlineBaseValue;
    private int _outlineTransparentBaseValue;
    
    private bool _flag = false;
    private bool _inputEagleView = false;
    
    private void OnEagleVision(InputValue value)
    {
        _inputEagleView = value.isPressed;
    }
    
    private void Awake()
    {
        _outlineBaseValue = outlineMaterial.GetFloat(Thickness);
        _outlineTransparentBaseValue = outlineMaterialTransparent.GetInt(Active);
        
        outlineMaterial.SetFloat(Thickness, 0);
        outlineMaterialTransparent.SetInt(Active, 0);
    }

    private void Update()
    {
        if (_inputEagleView && !_flag)
        {
            outlineMaterial.SetFloat(Thickness, outlineMaterial.GetFloat(Thickness ) == _outlineBaseValue ? 0.0f : _outlineBaseValue);
            outlineMaterialTransparent.SetInt(Active, outlineMaterialTransparent.GetInt(Active) == 0 ? 1 : 0);
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
        outlineMaterialTransparent.SetInt("Active", _outlineTransparentBaseValue);
    }
}
