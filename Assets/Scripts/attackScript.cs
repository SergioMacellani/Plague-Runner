using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    public void Attack(bool right)
    {
        if(right)
        {
            StartCoroutine(Right());
        }else
        {
            StartCoroutine(Left());
        }
    }

    IEnumerator Right()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        transform.GetChild(1).gameObject.SetActive(false);
    }
    IEnumerator Left()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
