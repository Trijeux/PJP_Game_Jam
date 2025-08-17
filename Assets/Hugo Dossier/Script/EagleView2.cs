using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EagleView2 : MonoBehaviour
{
    private static readonly int Thickness = Shader.PropertyToID("_OutlineThickness");
    private static readonly int Active = Shader.PropertyToID("_Active");

    [SerializeField] private Material outlineMaterial;
    [SerializeField] private Material outlineMaterialFull;
    [SerializeField] private Material outlineMaterialTransparent;
    [SerializeField] private Material vanishingMaterial;

    private float _outlineBaseValue;
    private int _outlineFullBaseValue;
    private float _outlineTransparentBaseValue;
    private int _vanishingBaseValue;
    
    private bool _flag = false;
    private bool _inputEagleView = false;
    
    private void OnEagleVision(InputValue value)
    {
        _inputEagleView = value.isPressed;
    }
    
    private void Awake()
    {
        _outlineBaseValue = outlineMaterial.GetFloat(Thickness);
        _outlineFullBaseValue = outlineMaterialFull.GetInt(Active);
        _outlineTransparentBaseValue = outlineMaterialTransparent.GetFloat(Thickness);
        _vanishingBaseValue = vanishingMaterial.GetInt(Active);
        
        outlineMaterial.SetFloat(Thickness, 0);
        outlineMaterialFull.SetInt(Active, 0);
        outlineMaterialTransparent.SetFloat(Thickness, 0);
        vanishingMaterial.SetInt(Active, 0);
    }

    private void Update()
    {
        if (_inputEagleView && !_flag)
        {
            outlineMaterial.SetFloat(Thickness, outlineMaterial.GetFloat(Thickness ) == _outlineBaseValue ? 0.0f : _outlineBaseValue);
            outlineMaterialFull.SetInt(Active, outlineMaterialFull.GetInt(Active) == 0 ? 1 : 0);
            outlineMaterialTransparent.SetFloat(Thickness, outlineMaterialTransparent.GetInt(Thickness) == _outlineTransparentBaseValue ? 0.0f : _outlineTransparentBaseValue);
            vanishingMaterial.SetInt(Active, vanishingMaterial.GetInt(Active) == 0 ? 1 : 0);
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
        outlineMaterialFull.SetInt(Active, _outlineFullBaseValue);
        outlineMaterialTransparent.SetFloat(Thickness, _outlineTransparentBaseValue);
        vanishingMaterial.SetInt(Active, _vanishingBaseValue);
    }
}
