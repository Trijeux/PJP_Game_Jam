using System.Collections.Generic;
using UnityEngine;

public class LeverRoom : MonoBehaviour
{

    [SerializeField] private GameObject reward;
    [SerializeField] private List<Switch> switches;

    private readonly bool[] _solution = {true,false,true,true};
    
    private bool _hasWon = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reward.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasWon)
        {
            int count = 0;
            for (int i = 0; i < switches.Count; i++)
            {
                if (switches[i].IsActive == _solution[i])
                {
                    count++;
                }

                if (count == 4)
                {
                    Win();
                }
            }
        }
    }

    void Win()
    {
        _hasWon = true;
        reward.gameObject.SetActive(true);
    }
}
