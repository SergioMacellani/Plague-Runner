using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTile : MonoBehaviour
{
    public Vector2 biomeSizeTile, spawnBiomeSizeTile;
    public GameObject RunePrefab, OldTile;
    public GameObject[] TilesM, TilesC, TilesL, TileTrasition, Group;
    public float zLocate, timer;
    public int rotate, biomeSize, spawnBiomeSize;
    public char biome = 'M', biomeAtt = 'M', biomeNext; //Troca de bioma
    public bool biomeSpawner, startRun;
    public int randomSpawn;
    public fps FPS;
    void Start()
    {
        biome = 'M';
        biomeSpawner = false;
        biomeSize = Random.Range(System.Convert.ToInt32(biomeSizeTile.x), System.Convert.ToInt32(biomeSizeTile.y));
    }

    void Update()
    {
        if(biomeSize <= 0) //Biome Selector
        {
            biomeAtt = biome;
            char[] biomeSelect = Group[Random.Range(0, Group.Length)].name.Substring(0, 1).ToCharArray();
            if(biomeSelect[0] != biomeAtt)
            {
                biomeNext = biomeSelect[0];
                biome = 'T'; //Transição
                biomeSize = Random.Range(System.Convert.ToInt32(biomeSizeTile.x), System.Convert.ToInt32(biomeSizeTile.y));
                randomSpawn = Random.Range(0, 101);
                if (randomSpawn <= 33)
                {
                    spawnBiomeSize = Random.Range(System.Convert.ToInt32(spawnBiomeSizeTile.x), System.Convert.ToInt32(spawnBiomeSizeTile.y));
                    biomeSize += spawnBiomeSize;
                    biomeSpawner = true;
                }
                else { biomeSpawner = false; spawnBiomeSize = 0; }
            }
        }

    }

    public void GenerateTile(int spawnZ)
    {
        //Tile Generator
        if (biome == 'M') //Mansion
        {
            if (biomeSpawner == false)
            {
                GameObject tile = (GameObject)Instantiate(TilesM[Random.Range(0, TilesM.Length - 4)]);
                if (rotate == 1 && tile.transform.GetComponent<tileScript>().isRotate)
                {
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                tile.transform.eulerAngles = new Vector3(0, 180, 0);
                tile.transform.position = new Vector3(0, 0, spawnZ);
                tile.transform.parent = Group[0].transform;

                //Rune
                GameObject runesSpawner = tile.transform.GetChild(0).gameObject;
                int random;
                random = Random.Range(0, 4);
                if (random > 0)
                {
                    GameObject rune1 = (GameObject)Instantiate(RunePrefab, tile.transform);
                    rune1.transform.position = runesSpawner.transform.GetChild(Random.Range(0, 11)).transform.position;
                    if (random >= 2)
                    {
                        GameObject rune2 = (GameObject)Instantiate(RunePrefab, tile.transform);
                        rune2.transform.position = runesSpawner.transform.GetChild(Random.Range(11, 19)).transform.position;
                    }
                }
                tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                OldTile = tile;
            }
            else
            {
                if (biomeSize - spawnBiomeSize >= 0)
                {
                    GameObject tile = (GameObject)Instantiate(TilesM[Random.Range(0, TilesM.Length - 4)]);
                    if (rotate == 1 && tile.transform.GetComponent<tileScript>().isRotate)
                    {
                        tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[0].transform;

                    //Rune
                    GameObject runesSpawner = tile.transform.GetChild(0).gameObject;
                    int random;
                    random = Random.Range(0, 4);
                    if (random > 0)
                    {
                        GameObject rune1 = (GameObject)Instantiate(RunePrefab, tile.transform);
                        rune1.transform.position = runesSpawner.transform.GetChild(Random.Range(0, 11)).transform.position;
                        if (random >= 2)
                        {
                            GameObject rune2 = (GameObject)Instantiate(RunePrefab, tile.transform);
                            rune2.transform.position = runesSpawner.transform.GetChild(Random.Range(11, 19)).transform.position;
                        }
                    }
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
                else
                {
                    GameObject tile = (GameObject)Instantiate(TilesM[Random.Range(TilesM.Length - 4, TilesM.Length)]);
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[0].transform;
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
            }

        }
        else if (biome == 'C')
        { //Cemetery
            if (biomeSpawner == false)
            {
                GameObject tile = (GameObject)Instantiate(TilesC[Random.Range(0, TilesC.Length - 4)]);
                if (rotate == 1 && tile.transform.GetComponent<tileScript>().isRotate)
                {
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                tile.transform.eulerAngles = new Vector3(0, 180, 0);
                tile.transform.position = new Vector3(0, 0, spawnZ);
                tile.transform.parent = Group[1].transform;

                //Rune
                GameObject runesSpawner = tile.transform.GetChild(0).gameObject;
                int random;
                random = Random.Range(0, 4);
                if (random > 0)
                {
                    GameObject rune1 = (GameObject)Instantiate(RunePrefab, tile.transform);
                    rune1.transform.position = runesSpawner.transform.GetChild(Random.Range(0, 11)).transform.position;
                    if (random >= 2)
                    {
                        GameObject rune2 = (GameObject)Instantiate(RunePrefab, tile.transform);
                        rune2.transform.position = runesSpawner.transform.GetChild(Random.Range(11, 19)).transform.position;
                    }
                }
                tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                OldTile = tile;
            }
            else
            {
                if (biomeSize - spawnBiomeSize >= 0)
                {
                    GameObject tile = (GameObject)Instantiate(TilesC[Random.Range(0, TilesC.Length - 4)]);
                    if (rotate == 1 && tile.transform.GetComponent<tileScript>().isRotate)
                    {
                        tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[1].transform;

                    //Rune
                    GameObject runesSpawner = tile.transform.GetChild(0).gameObject;
                    int random;
                    random = Random.Range(0, 4);
                    if (random > 0)
                    {
                        GameObject rune1 = (GameObject)Instantiate(RunePrefab, tile.transform);
                        rune1.transform.position = runesSpawner.transform.GetChild(Random.Range(0, 11)).transform.position;
                        if (random >= 2)
                        {
                            GameObject rune2 = (GameObject)Instantiate(RunePrefab, tile.transform);
                            rune2.transform.position = runesSpawner.transform.GetChild(Random.Range(11, 19)).transform.position;
                        }
                    }
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
                else
                {
                    GameObject tile = (GameObject)Instantiate(TilesC[Random.Range(TilesC.Length - 4, TilesC.Length)]);
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[1].transform;
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
            }

        }
        else if (biome == 'L')
        { //Laboratory
            if (biomeSpawner == false)
            {
                GameObject tile = (GameObject)Instantiate(TilesL[Random.Range(0, TilesL.Length - 4)]);
                if (rotate == 1 && tile.transform.GetComponent<tileScript>().isRotate)
                {
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                tile.transform.eulerAngles = new Vector3(0, 180, 0);
                tile.transform.position = new Vector3(0, 0, spawnZ);
                tile.transform.parent = Group[2].transform;

                //Rune
                GameObject runesSpawner = tile.transform.GetChild(0).gameObject;
                int random;
                random = Random.Range(0, 4);
                if (random > 0)
                {
                    GameObject rune1 = (GameObject)Instantiate(RunePrefab, tile.transform);
                    rune1.transform.position = runesSpawner.transform.GetChild(Random.Range(0, 11)).transform.position;
                    if (random >= 2)
                    {
                        GameObject rune2 = (GameObject)Instantiate(RunePrefab, tile.transform);
                        rune2.transform.position = runesSpawner.transform.GetChild(Random.Range(11, 19)).transform.position;
                    }
                }
                tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                OldTile = tile;
            }
            else
            {
                if (biomeSize - spawnBiomeSize >= 0)
                {
                    GameObject tile = (GameObject)Instantiate(TilesL[Random.Range(0, TilesL.Length - 4)]);
                    if (rotate == 1 && tile.transform.GetComponent<tileScript>().isRotate)
                    {
                        tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[2].transform;

                    //Rune
                    GameObject runesSpawner = tile.transform.GetChild(0).gameObject;
                    int random;
                    random = Random.Range(0, 4);
                    if(random > 0)
                    {
                        GameObject rune1 = (GameObject)Instantiate(RunePrefab, tile.transform);
                        rune1.transform.position = runesSpawner.transform.GetChild(Random.Range(0, 11)).transform.position;
                        if (random >= 2)
                        {
                            GameObject rune2 = (GameObject)Instantiate(RunePrefab, tile.transform);
                            rune2.transform.position = runesSpawner.transform.GetChild(Random.Range(11, 19)).transform.position;
                        }
                    }
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
                else
                {
                    GameObject tile = (GameObject)Instantiate(TilesL[Random.Range(TilesL.Length - 4, TilesL.Length)]);
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[1].transform;
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
            }

        }
        else if (biome == 'T') //Transição
        {
            if (biomeAtt == 'M') //Mansão Para
            {
                if (biomeNext == 'C') //Cemiterio
                {
                    GameObject tile = (GameObject)Instantiate(TileTrasition[0]);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[1].transform;
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
                else if (biomeNext == 'L') //Laboratory
                {
                    GameObject tile = (GameObject)Instantiate(TileTrasition[1]);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[2].transform;
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
            }
            else if (biomeAtt == 'C') //Cemiterio Para
            {
                if (biomeNext == 'L') //Laboratory
                {
                    GameObject tile = (GameObject)Instantiate(TileTrasition[2]);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[2].transform;
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
                else if (biomeNext == 'M') //Mansão
                {
                    GameObject tile = (GameObject)Instantiate(TileTrasition[0]);
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[0].transform;
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
            }
            else if (biomeAtt == 'L') //Laboratory Para
            {
                if (biomeNext == 'M') //Mansão
                {
                    GameObject tile = (GameObject)Instantiate(TileTrasition[1]);
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[0].transform;
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
                else if (biomeNext == 'C') //Cemiterio
                {
                    GameObject tile = (GameObject)Instantiate(TileTrasition[2]);
                    tile.transform.eulerAngles = new Vector3(0, 180, 0);
                    tile.transform.position = new Vector3(0, 0, spawnZ);
                    tile.transform.parent = Group[0].transform;
                    tile.GetComponent<tileScript>().tileGen = this.GetComponent<playerTile>();
                    tile.GetComponent<tileScript>().oldTile = OldTile.transform;
                    OldTile = tile;
                }
            }
            biome = biomeNext;
        }
        biomeSize--;
        StartCoroutine(tileTimer());
    }

    public void tileStart()
    {
        startRun = true;
        GenerateTile(475);
    }

    IEnumerator tileTimer()
    {
        if(FPS.frames > 19)
        {
            timer = 1f + ((0.222f * (int)((FPS.frames + 210) / 7)) / 35);
        }else if(FPS.frames < 20)
        {
            timer = 1f + ((0.19f * (int)((FPS.frames + 90) / 7)) / 15);
        }

        yield return new WaitForSeconds(timer);
        GenerateTile(475);
    }
}
