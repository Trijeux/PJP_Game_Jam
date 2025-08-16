// Script by : Hugo
// Porject : PJPJam


using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class EagleView : MonoBehaviour
{
    
    [SerializeField] private Volume _EagleViewVolume;
    [SerializeField] private Volume _ATRVolume;

    private bool _flag = false;
    private bool _inputEagleView = false;
    
    private void OnEagleVision(InputValue value)
    {
        _inputEagleView = value.isPressed;
    }

    private void Update()
    {
        if (_inputEagleView && !_flag)
        {
            _EagleViewVolume.weight = _EagleViewVolume.weight == 1.0f ? 0.0f : 1.0f;
            _ATRVolume.weight = _ATRVolume.weight == 1.0f ? 0.0f : 1.0f;
            _flag = true;
        }
        else if (!_inputEagleView)
        {
            _flag = false;
        }
    }
}
