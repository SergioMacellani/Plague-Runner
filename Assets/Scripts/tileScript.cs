using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    public bool isRotate, start, startIn;
    public playerTile tileGen;
    public Transform oldTile;
    float velIn = 80, vel;
    void Start()
    {
        if (!start)
        {
            StartCoroutine(waitZ());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > -125)
        {
            if (tileGen.startRun && Time.timeScale == 1)
            {
                vel = velIn * Time.smoothDeltaTime;
                transform.position -= new Vector3(0, 0, vel * 2);
            }
        }
        else
        {
            Destroy(this.gameObject);
            if (!startIn)
            {
                PlayerPrefs.SetInt("Distance", PlayerPrefs.GetInt("Distance") + 20);
            }
        }
    }

    IEnumerator waitZ()
    {
        yield return new WaitForSeconds(0.01f);
        transform.position = new Vector3(0, 0, oldTile.position.z + 200);
    }
}
