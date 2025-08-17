// Script by : Trijeux
// Porject : PJPJam

using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowPlayerAxeY : MonoBehaviour
{
    #region Attributs

    [SerializeField] private Transform FollowAxeY;

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
        transform.position = new Vector3(0, FollowAxeY.position.y);
    }

	#endregion
}
