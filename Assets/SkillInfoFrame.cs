using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillInfoFrame : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] spellStats = new TextMeshProUGUI[3];
    private Spell spell;
    private string dmg, manaCost, durration;

    void RefreshStats() {
        Spell spell = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().SpellCurrentInUse();
        dmg = spell.Damage.ToString();
        manaCost = spell.getManaCost().ToString();
        durration = spell.GetDurrationTime().ToString();
    }

    void FixedUpdate()
    {
        RefreshStats();
        spellStats[0].text = "DMG: " + dmg;
        spellStats[1].text = "Mana: " + manaCost;
        spellStats[2].text = "Durration: " + durration;
    }
}
