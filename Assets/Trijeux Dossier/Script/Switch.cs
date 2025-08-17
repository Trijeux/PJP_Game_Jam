// Script by : Trijeux
// Porject : PJPJam

using System;
using UnityEngine;

public class Switch : MonoBehaviour
{
    #region Attributs

    [SerializeField] private GameObject switchOn;
    [SerializeField] private GameObject switchOff;
    [SerializeField] private GameObject buttonView;

    private PlayerController _playerController;
    private bool playerInRange = false;
    public bool IsActive { get; private set; } = false;

    private bool flag = false;

    #endregion

    #region Methods

    private void activate()
    {
        IsActive = true;
        switchOn.SetActive(true);
        switchOff.SetActive(false);
    }

    private void desactivate()
    {
        IsActive = false;
        switchOn.SetActive(false);
        switchOff.SetActive(true);
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
        if (playerInRange)
        {
            if (_playerController.InputInteract && !flag)
            {
                flag = true;
                switch (IsActive)
                {
                    case true:
                        desactivate();
                        break;
                    case false:
                        activate();
                        break;
                }
            }
            else if (!_playerController.InputInteract && flag)
            {
                flag = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _playerController = other.GetComponent<PlayerController>();
            playerInRange = true;
            buttonView.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buttonView.SetActive(false);
            playerInRange = false;
            if (flag)
            {
                flag = false;
            }
        }
    }
    
    #endregion
}
