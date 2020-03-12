using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectorsSpawner : MonoBehaviour
{
    Defender defender;
    StarsDisplay myStarsDisplay;

    void OnMouseDown()
    {
        if(!defender){return;}
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarsDisplay = FindObjectOfType<StarsDisplay>();
        var defenderCost = defender.GetStarCost();
        if(StarsDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefenders(gridPos);
            StarsDisplay.DeductStars(defenderCost);
        } else return;
    }
    
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        float newX = Mathf.RoundToInt(worldPos.x);
        float newY = Mathf.RoundToInt(worldPos.y);
        return new Vector2(newX, newY);
    }
    
    private void SpawnDefenders(Vector2 worldPos)
    {
        Defender defender = Instantiate(this.defender, worldPos, Quaternion.identity) as Defender;
    }
}
