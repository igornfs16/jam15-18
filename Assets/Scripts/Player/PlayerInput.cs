using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerAttack))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;
    private PlayerAttack _attack;
    private PlayerAnimationSwitcher _animationSwitcher;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _attack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _mover.MoveByZUp();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _mover.MoveByZDown();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _attack.FlashAttack();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _attack.DropBomb();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _mover.Jump();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        { 
        
        }
    }
}
