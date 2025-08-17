// Script by : Trijeux
// Porject : PJPJam

using System;
using Unity.Cinemachine;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    #region Attributs

    [SerializeField] private int priorityCamera = 2;
    [SerializeField] private CinemachineCamera _camera;
    [SerializeField] private Transform _spawnPlayer;

    #endregion

    #region Methods



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

    private void OnTriggerEnter2D(Collider2D other)
    {
        _camera.Priority= priorityCamera;
        other.transform.position = new Vector3(_spawnPlayer.position.x, _spawnPlayer.position.y);
    }

    #endregion
}
