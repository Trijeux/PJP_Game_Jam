// Script by : Trijeux
// Porject : PJPJam

using System;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    #region Attributs

    [SerializeField] private Transform spawnPoint;
    public bool IsRun { get; private set; } = false;
    private BoxCollider2D _collider;

	#endregion

    #region Methods

	public void End()
	{
		IsRun = false;
		_collider.enabled = false;
	}
	
	public void StartFlame()
	{
		IsRun = true;
		_collider.enabled = true;
	}

    #endregion

    #region InputSystem



    #endregion

    #region Behaviors

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Player")
		{
			other.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y);
		}
    }

    #endregion
}
