using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private CreatureSpec spec;
    
    [Header("Wiring")]
    [SerializeField] private SpriteRenderer artImage;
    [SerializeField] private SpriteRenderer blankImage;
    //
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text elementText;
    [SerializeField] private TMP_Text typeText;
    //
    [SerializeField] private TMP_Text AtkDmgText;
    [SerializeField] private TMP_Text A1TitleText;
    [SerializeField] private TMP_Text A1DescText;
    [SerializeField] private TMP_Text A1CostText;
    //
    [SerializeField] private TMP_Text A2TitleText;
    [SerializeField] private TMP_Text A2DescText;
    [SerializeField] private TMP_Text A2CostText;
    //
    [SerializeField] private TMP_Text Passive1Text;
    [SerializeField] private TMP_Text Passive2Text;


    void Start() {
        Debug.Log("CardView Start");        
        if (spec) {
            Debug.Log("UOFDBEUBFBOUE");
            Bind(spec);
        }
    }

    public void SetSpec(CreatureSpec newSpec) {
        spec = newSpec;
        Bind(spec);
    }

    
    public void Bind(CreatureSpec spec) {
        if (spec == null) return;
        // Top info
        if (titleText)  titleText.text  = spec.creatureName;
        if (costText)   costText.text   = spec.baseManaCost.ToString();
        if (elementText) elementText.text = spec.element;
        if (typeText)   typeText.text   = spec.sub_element;
        // Base stats
        if (AtkDmgText) AtkDmgText.text = spec.baseAttack.ToString();
        // Ability 1
        if (spec.ability1 != null) {
            if (A1TitleText) A1TitleText.text = spec.ability1.name;
            if (A1DescText)  A1DescText.text  = spec.ability1.description;
            if (A1CostText)  A1CostText.text  = spec.ability1.baseManaCost.ToString();
        }
        else {
            if (A1TitleText) A1TitleText.text = string.Empty;
            if (A1DescText)  A1DescText.text  = string.Empty;
            if (A1CostText)  A1CostText.text  = string.Empty;
        }
        // Ability 2
        if (spec.ability2 != null) {
            if (A2TitleText) A2TitleText.text = spec.ability2.name;
            if (A2DescText)  A2DescText.text  = spec.ability2.description;
            if (A2CostText)  A2CostText.text  = spec.ability2.baseManaCost.ToString();
        }
        else {
            if (A2TitleText) A2TitleText.text = string.Empty;
            if (A2DescText)  A2DescText.text  = string.Empty;
            if (A2CostText)  A2CostText.text  = string.Empty;
        }
        // Passives / description (map to your layout as desired)
        if (Passive1Text) Passive1Text.text = spec.description;
        if (Passive2Text) Passive2Text.text = string.Empty;
    }
    
}
