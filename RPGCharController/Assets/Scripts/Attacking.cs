using UnityEngine;
using System.Collections;

public class Attacking : MonoBehaviour {


    Animator anim;
    public enum TypeOfAttack { No_Weapon, Melee_Weapon, Ranged_Weapon}
    public TypeOfAttack typeofAttack;
    public float range, damange;
    void Start () {
        typeofAttack = TypeOfAttack.No_Weapon;
        anim = GetComponent<Animator>();
	}
	
    void Update()
    {
        switch (typeofAttack)
        {
            case TypeOfAttack.No_Weapon:
                range = 1f;
                damange = 2f;
                break;
            case TypeOfAttack.Melee_Weapon:
                range = 1f;
                damange = 5f;
                break;
            case TypeOfAttack.Ranged_Weapon:
                range = 3f;
                damange = 10f;
                break;
        }
    }

    public void Attack()
    {
        anim.SetBool("isShooting", true);
    }

    public void ChangeToMMA()
    {
        typeofAttack = TypeOfAttack.No_Weapon;
    }
    public void ChangeToMelee()
    {
        typeofAttack = TypeOfAttack.Melee_Weapon;
    }
    public void ChangeToRanged()
    {
        typeofAttack = TypeOfAttack.Ranged_Weapon;
    }
}
