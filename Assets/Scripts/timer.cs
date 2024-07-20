using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float scale;
        scale = Mathf.Lerp(transform.localScale.x, 1.1f, .1f);
        transform.localScale = new Vector2(scale, scale);
    }

    public void timerSt()
    {
        StartCoroutine(timerStart());
    }

    IEnumerator timerStart()
    {
        transform.localScale = new Vector2(.7f, .7f);
        this.GetComponent<Text>().text = "3";
        yield return new WaitForSecondsRealtime(1);
        transform.localScale = new Vector2(.7f, .7f);
        this.GetComponent<Text>().text = "2";
        yield return new WaitForSecondsRealtime(1);
        transform.localScale = new Vector2(.7f, .7f);
        this.GetComponent<Text>().text = "1";
        yield return new WaitForSecondsRealtime(1);
        transform.parent.parent.GetComponent<UI>().PauseUI(false);
        transform.parent.GetChild(4).gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
