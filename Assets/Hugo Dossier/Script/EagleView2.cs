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
    [SerializeField] private Material dangerMaterial;
    [SerializeField] private Material arrowMaterial;
    [SerializeField] private Material platformMaterial;
    [SerializeField] private Material invisiblePlatformMaterial;
    [SerializeField] private Material textMaterial;
    [SerializeField] private AudioSource audioSource;

    private float _outlineBaseValue;
    private int _outlineFullBaseValue;
    private float _outlineTransparentBaseValue;
    private int _vanishingBaseValue;
    private float _dangerBaseValue;
    private int _arrowBaseValue;
    private float _platformBaseValue;
    private int _invisiblePlatformBaseValue;
    private int _textBaseValue;
    
    
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
        _dangerBaseValue = dangerMaterial.GetFloat(Thickness);
        _arrowBaseValue = arrowMaterial.GetInt(Active);
        _platformBaseValue = platformMaterial.GetFloat(Thickness);
        _invisiblePlatformBaseValue = invisiblePlatformMaterial.GetInt(Active);
        _textBaseValue = textMaterial.GetInt(Active);
            
        
        outlineMaterial.SetFloat(Thickness, 0);
        outlineMaterialFull.SetInt(Active, 0);
        outlineMaterialTransparent.SetFloat(Thickness, 0);
        vanishingMaterial.SetInt(Active, 0);
        dangerMaterial.SetFloat(Thickness, 0);
        arrowMaterial.SetInt(Active, 0);
        platformMaterial.SetFloat(Thickness, 0);
        invisiblePlatformMaterial.SetInt(Active, 0);
        textMaterial.SetInt(Active, 0);
    }

    private void Update()
    {
        if (_inputEagleView && !_flag)
        {
            audioSource.Play();
            _flag = true;
            outlineMaterial.SetFloat(Thickness, outlineMaterial.GetFloat(Thickness ) == _outlineBaseValue ? 0.0f : _outlineBaseValue);
            outlineMaterialFull.SetInt(Active, outlineMaterialFull.GetInt(Active) == 0 ? 1 : 0);
            outlineMaterialTransparent.SetFloat(Thickness, outlineMaterialTransparent.GetFloat(Thickness) == _outlineTransparentBaseValue ? 0.0f : _outlineTransparentBaseValue);
            vanishingMaterial.SetInt(Active, vanishingMaterial.GetInt(Active) == 0 ? 1 : 0);
            dangerMaterial.SetFloat(Thickness, dangerMaterial.GetFloat(Thickness) == _dangerBaseValue ? 0.0f : _dangerBaseValue);
            arrowMaterial.SetInt(Active, arrowMaterial.GetInt(Active) == 0 ? 1 : 0);
            
            if (platformMaterial != null)
            {
                platformMaterial.SetFloat(Thickness, platformMaterial.GetFloat(Thickness) == _platformBaseValue ? 0.0f : _platformBaseValue);
            }

            if (invisiblePlatformMaterial != null)
            {
                invisiblePlatformMaterial.SetInt(Active, invisiblePlatformMaterial.GetInt(Active) == 0 ? 1 : 0);
            }
            
            textMaterial.SetInt(Active, textMaterial.GetInt(Active) == 0 ? 1 : 0);
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
        dangerMaterial.SetFloat(Thickness, _dangerBaseValue);
        arrowMaterial.SetInt(Active, _arrowBaseValue);

        if (platformMaterial != null)
        {
            platformMaterial.SetFloat(Thickness, _platformBaseValue);
        }

        if (invisiblePlatformMaterial != null)
        {
            invisiblePlatformMaterial.SetInt(Active, _invisiblePlatformBaseValue);

        }
        
        textMaterial.SetInt(Active, _textBaseValue);
    }
}
