using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    public Sprite stars_1;
    public Sprite stars_2;
    public Sprite stars_3;
    //
    [Header("Spec SO")]
    [SerializeField] private CreatureSpec spec;
    
    [Header("Wiring")]
    [SerializeField] private SpriteRenderer artImage;
    [SerializeField] private SpriteRenderer starsImage;
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

#if UNITY_EDITOR
    void OnValidate() {
        if (!Application.isPlaying && spec)
            Bind(spec);
    }
#endif

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
        // art
        artImage.sprite = spec.characterArt;
        if (spec.evolveLevel == 1) {
            starsImage.sprite = stars_1;
        } else if (spec.evolveLevel == 2) {
            starsImage.sprite = stars_2;
        } else {
            starsImage.sprite = stars_3;
        }
            
        // Top info
        titleText.text  = spec.creatureName;
        costText.text   = spec.baseManaCost.ToString();
        elementText.text = spec.element;
        typeText.text   = spec.sub_element;

        // Ability 1
        AtkDmgText.text = spec.baseAttack.ToString();
        if (spec.ability1 != null) {
            A1TitleText.text = spec.ability1.name;
            A1DescText.text  = spec.ability1.description;
            A1CostText.text  = spec.ability1.baseManaCost.ToString();
        }
        else {
            A1TitleText.text = "";
            A1DescText.text  = "";
            A1CostText.text  = "";
        }
        Debug.Log("A");

        // Ability 2
        if (spec.ability2 != null) {
            Debug.Log("a " +spec.ability2.name);
            Debug.Log("1 " +A2TitleText.text);
            A2TitleText.text = spec.ability2.name;
            Debug.Log("2 " +A2TitleText.text);
            A2DescText.text  = spec.ability2.description;
            A2CostText.text  = spec.ability2.baseManaCost.ToString();
        }
        else {
            A2TitleText.text = "";
            A2DescText.text  = "";
            A2CostText.text  = "";
        }

        // Passives / description (map to your layout as desired)
        Passive1Text.text = spec.description;
        Passive2Text.text = "";
    }
    
}
