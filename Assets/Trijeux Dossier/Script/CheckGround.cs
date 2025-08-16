// Script by : Trijeux
// Porject : PJPJam

using System;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    #region Attributs

    [SerializeField] private string groundTag = "Ground";

    public bool IsGrounded { get; private set; } = false;

    #endregion

    #region Methods

    #endregion

    #region InputSystem

    #endregion

    #region Behaviors

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(groundTag))
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(groundTag))
        {
            IsGrounded = false;
        }
    }

    #endregion
}
