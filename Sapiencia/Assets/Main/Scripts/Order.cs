using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {

    public DragonBones.UnityArmatureComponent armature;
    public DragonBones.Armature Armature_2;
	void Start ()
    {
        armature.animation.Play("Idle");
	}
	
	void Update ()
    {
        armature.sortingOrder = (int)(transform.position.y * -10f);
	}
}
