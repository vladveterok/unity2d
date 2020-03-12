using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed;

    Material myMaterial;
    Vector2 offSet;
    float playersVectorX;
    Player myPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, scrollSpeed);
        myPlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //offSet.x = myPlayer.GetComponent<Player>().PlayersVectorX();
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
        //Debug.Log("Players Vector X is: " + offSet.x);
    }
}
