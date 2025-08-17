// Script by : Trijeux
// Porject : PJPJam

using System;
using UnityEngine;

public class ActivePower : MonoBehaviour
{
    #region Attributs

    [SerializeField] private bool powerJump = false;
    [SerializeField] private bool powerDash = false;
	[SerializeField] private bool powerRun = false;
	[SerializeField] private bool powerSpectral = false;
	[SerializeField] private bool powerVision = false;
	[SerializeField] private bool powerDoubleJump = false;
    

    #endregion

    #region Methods



    #endregion

    #region InputSystem



    #endregion

    #region Behaviors

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.tag == "Player")
	    {
		    if (powerJump) other.GetComponent<PlayerController>().ActiveJumpPower();
		    else if (powerDash) other.GetComponent<PlayerController>().ActiveDashPower();
		    else if (powerRun) other.GetComponent<PlayerController>().ActiveRunPower();
		    else if (powerSpectral) other.GetComponent<PlayerController>().ActiveSpectralPower();
		    else if (powerVision) other.GetComponent<PlayerController>().ActiveVisionPower();
		    else if (powerDoubleJump) other.GetComponent<PlayerController>().ActiveDoubleJumpPower();
		    
		    gameObject.SetActive(false);
	    }
    }

    #endregion
}
