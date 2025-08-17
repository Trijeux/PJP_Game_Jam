// Script by : Mute&Blind 
// Porject : PJPJam

using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Pie_Script : MonoBehaviour
{
    [SerializeField] public GameObject goodAnswer;

    [SerializeField] public GameObject dashItem;

    private void Start()
    {
        dashItem.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dashItem.SetActive(true);
            
            goodAnswer.SetActive(false);
        }
    }
}