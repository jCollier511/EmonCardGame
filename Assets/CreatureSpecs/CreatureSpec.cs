using UnityEngine;



[CreateAssetMenu(fileName = "New Creature", menuName = "Creature Spec")]
public class CreatureSpec : ScriptableObject
{
    public string creatureName;
    public string description;
    public Sprite characterArt;
    //
    public int evolveLevel;
    //
    public int baseAttack;
    public int baseHealth;
    public int baseManaCost;
    //
    public string element;
    public string sub_element;
    //
    //
    public Ability ability1;
    public Ability ability2;

    [System.Serializable]
    public class Ability {
        public string name;
        public string description;
        //
        public bool isAttack;
        public bool isSpecial;
        //
        public int baseManaCost;
        public int baseDamage;
    }
    
}
