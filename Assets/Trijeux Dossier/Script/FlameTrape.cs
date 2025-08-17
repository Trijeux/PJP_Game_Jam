// Script by : Trijeux
// Porject : PJPJam

using System;
using System.Collections;
using UnityEngine;

public class FlameTrape : MonoBehaviour
{
    #region Attributs

    [SerializeField] private float coolDownAttack = 1f;
    private Animator _animator;
    private FlameScript _flameScript;
    private bool _flag = false;

    #endregion

    #region Methods

    #endregion

    #region InputSystem

    #endregion

    #region Behaviors

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _flameScript = GetComponentInChildren<FlameScript>();
    }

    private void Update()
    {
        if (_flameScript.IsRun && !_flag)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _flag = true;
        yield return new WaitForSeconds(coolDownAttack);
        _animator.SetTrigger("Attack");
        _flag = false;
    }

    #endregion
}
