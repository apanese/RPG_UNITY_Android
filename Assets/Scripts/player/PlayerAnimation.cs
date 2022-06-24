using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMove move;
    private Animation anim;
    private PlayerAttack attack;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<PlayerMove>();
        anim = GetComponent<Animation>();
        attack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
       // Debug.Log(move.State);
        if(attack.state == PlayerState.ControlWalk) {
            if (move.State == ControlWalkState.Moving)
            {
                anim.Play("Run");
            }else if(move.State == ControlWalkState.Idle)
            {
                anim.Play("Idle");
            }
        }
        else if(attack.state == PlayerState.NormalAttack)
        {
            if(attack.attack_state == AttackState.Moving)
            {
                anim.Play("Run");
            }
        }
    }
}
