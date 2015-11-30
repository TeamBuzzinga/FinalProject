using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
    PlayerWalkMechanics walkMechanics;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        walkMechanics = GetComponent<PlayerWalkMechanics>();
    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Max(Mathf.Abs(walkMechanics.getHInput()), Mathf.Abs(walkMechanics.getVInput())));
    }
}
