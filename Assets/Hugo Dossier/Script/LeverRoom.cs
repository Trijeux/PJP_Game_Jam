using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverRoom : MonoBehaviour
{

    [SerializeField] private GameObject reward;
    [SerializeField] private List<Switch> switches;
    [SerializeField] private int limit = 3;
    private int counter = 0;
    private bool _hasWon;
    private List<bool> switchesTemp = new List<bool>{false, false, false, false};

    private readonly bool[] _solution = {true,false,true,true};
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reward.gameObject.SetActive(false);
        
        for (int i = 0; i < switches.Count; i++)
        {
            switchesTemp[i] = switches[i].IsActive;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < switches.Count; i++)
        {
            if (switches[i].IsActive != switchesTemp[i])
            {
                switchesTemp[i] = switches[i].IsActive;
                counter++;
                Debug.Log(counter);

            }
        }

        if (counter >= limit)
        {
            SceneManager.LoadScene("BSOD");
        }
        
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
