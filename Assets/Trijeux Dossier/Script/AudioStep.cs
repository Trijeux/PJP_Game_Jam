// Script by : Trijeux
// Porject : PJPJam

using System;
using UnityEngine;

public class AudioStep : MonoBehaviour
{
    #region Attributs

	[SerializeField] private AudioSource _audio;

    #endregion

    #region Methods

	public void PlayAudio()
	{
		_audio.Play();
	}

    #endregion

    #region InputSystem



    #endregion

    #region Behaviors

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

	#endregion
}
