using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsContainer : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] spells;
    [SerializeField]
    private GameObject Player;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.GetComponent<Player>();
    }

  
    void FixedUpdate()
    {   
        int spellIndex = player.SpellInUse;
        foreach (SpriteRenderer spell in spells) {
            spell.color = Color.black;
        }
        spells[(int)spellIndex].color = Color.white;
        Debug.Log(spellIndex.ToString());
    }
}
