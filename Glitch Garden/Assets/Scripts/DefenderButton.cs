using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    
    SpriteRenderer mySpriteRenderer;
    ProtectorsSpawner protectorsSpawner;

    void Start() 
    {
        protectorsSpawner = FindObjectOfType<ProtectorsSpawner>();
    }
    
    void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(0,0,0,255);
        }
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.color = Color.white;
        protectorsSpawner.SetSelectedDefender(defenderPrefab);
    }
}
