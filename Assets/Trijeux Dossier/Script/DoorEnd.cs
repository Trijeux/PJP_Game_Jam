using System;
using UnityEngine;

public class DoorEnd : MonoBehaviour
{
    [SerializeField] private GameObject Button;
    
    private PlayerController _playerController;
    
    private bool _PlayerInZone;

    private void Update()
    {
        if (_PlayerInZone)
        {
            if (_playerController.InputInteract)
            {
                Debug.LogWarning("Switch End Scene");
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _playerController = other.GetComponent<PlayerController>();
            Button.SetActive(true);
            _PlayerInZone = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Button.SetActive(false);
            _PlayerInZone = false;
        }
    }
}
