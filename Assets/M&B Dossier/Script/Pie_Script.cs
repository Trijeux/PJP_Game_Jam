// Script by : Mute&Blind 
// Porject : PJPJam

using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Pie_Script : MonoBehaviour
{
	[Header("Good answer pie")]
	public GameObject goodAnswer;

	[Header("Dash item")]
	public GameObject dashItem;

	private void Start()
	{
		// On s'assure que l'objet à afficher est désactivé au début
		if (dashItem != null)
			dashItem.SetActive(false);
	}
	private void OnTriggerEnter(Collider other)
	{
		// Vérifie que c'est bien un objet qui doit déclencher (par exemple Player)
		if (other.CompareTag("Player"))
		{
			// Désactiver ou détruire l'objet
			if (goodAnswer != null)
				goodAnswer.SetActive(false); // ou Destroy(objetADetruire);

			// Activer l'autre objet
			if (dashItem != null)
				dashItem.SetActive(true);
		}
	}
}
