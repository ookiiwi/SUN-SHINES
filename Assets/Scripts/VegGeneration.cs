using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VegGeneration : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] lil_plantsArr;
    [SerializeField] private int lil_plantsNb;
    [SerializeField] private SpriteRenderer[] big_plantsArr;
    [SerializeField] private int big_plantsNb;
    [SerializeField] private SpriteRenderer[] treesArr;
    [SerializeField] private int treesNb;
    [SerializeField] private SpriteRenderer grass;
    
    
    private int grassNb;
    private float prevGrassPosX;
    private TilemapRenderer groundSprite;
    private Tilemap ground;  
    private float vegYPos;
    private int randomIndex;
    private int randomPosX;
    private float limitX;

    private void Awake()
    {
        ground = GetComponent<Tilemap>();
        groundSprite = GetComponent<TilemapRenderer>();

        limitX = groundSprite.transform.localPosition.x + groundSprite.bounds.extents.x;
        grassNb = (int)(groundSprite.bounds.size.x / grass.bounds.extents.x);
        prevGrassPosX = -limitX + grass.bounds.extents.x;

        //position transform.y - half.y + x * cellsize
        vegYPos = ground.transform.position.y - ground.LocalToWorld(ground.localBounds.extents).y + ground.cellSize.y * (ground.size.y / 3);

        //lil plants
        for (int i = 0; i < lil_plantsNb; ++i)
        {
            randomIndex = Random.Range(0, lil_plantsArr.Length);

            //while (Random.Range(-limitX, limitX) < )

            Instantiate(lil_plantsArr[randomIndex], new Vector3(Random.Range(-limitX, limitX), vegYPos + lil_plantsArr[randomIndex].bounds.extents.y), lil_plantsArr[randomIndex].transform.rotation);
        }
        
        //big_plants
        for (int i = 0; i < big_plantsNb; ++i)
        {
            randomIndex = Random.Range(0, big_plantsArr.Length);
            Instantiate(big_plantsArr[randomIndex], new Vector3(Random.Range(-limitX, limitX), vegYPos + big_plantsArr[randomIndex].bounds.extents.y), big_plantsArr[randomIndex].transform.rotation);
        }
        
        //trees
        for (int i = 0; i < treesNb; ++i)
        {
            randomIndex = Random.Range(0, treesArr.Length);
            Instantiate(treesArr[randomIndex], new Vector3(Random.Range(-limitX, limitX), vegYPos + treesArr[randomIndex].bounds.extents.y), treesArr[randomIndex].transform.rotation);
        }
        
        //grass
        for (int i = 0; i < grassNb; ++i)
        {
            Instantiate(grass, new Vector3(prevGrassPosX, vegYPos + grass.bounds.extents.y), grass.transform.rotation);
            prevGrassPosX += grass.bounds.extents.x;
        }      
    }
}
