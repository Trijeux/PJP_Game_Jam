// Script by : Trijeux
// Porject : PJPJam

using System;
using UnityEngine;

public class TPDeadZone : MonoBehaviour
{
    #region Attributs

    [SerializeField] private GameObject tpZone;
    [SerializeField] private string playerTag;

    #endregion

    #region Methods



    #endregion

    #region InputSystem



    #endregion

    #region Behaviors

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            other.GetComponent<PlayerController>().DeadSound();
            other.gameObject.transform.position = tpZone.transform.position;
        }
    }

    #endregion
}
