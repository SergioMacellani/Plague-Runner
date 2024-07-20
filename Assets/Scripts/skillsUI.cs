using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillsUI : MonoBehaviour
{
    bool Life, Infinity, fadeInOut;
    public float value = 100;
    public float val;
    int lifeMax, lifeAtt;
    public Sprite[] heart;
    void Start()
    {
        Life = (PlayerPrefs.GetFloat("Life") >= 1) ? true : false;
        Infinity = (PlayerPrefs.GetInt("Infinidade") >= 1) ? true : false;

        if (Life)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            if(PlayerPrefs.GetFloat("Life") == 1)
            {
                transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                lifeMax = 1;
                lifeAtt = 1;
            }
            else if(PlayerPrefs.GetFloat("Life") == 2)
            {
                transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                lifeMax = 2;
                lifeAtt = 2;
            }
            else if(PlayerPrefs.GetFloat("Life") == 3)
            {
                transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                lifeMax = 3;
                lifeAtt = 3;
            }
        }
        if (Infinity)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            val = PlayerPrefs.GetInt("Infinidade");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (value < 100)
        {
            value = Mathf.Lerp(value, 150, (.0001f * (int)(10 / (val / 3))) - .00005f);
            transform.GetChild(1).GetChild(1).GetComponent<Image>().fillAmount = value/100;
        }

        if (Life)
        {
            if(PlayerPrefs.GetFloat("Life") < lifeAtt)
            {
                StartCoroutine(Fade());
                lifeAtt--;
            }
            if (fadeInOut)
            {
                FadeInLife();
            }
            else
            {
                FadeOutLife();
            }
        }
    }

    public void InfinityActive()
    {
        if (value >= 100)
        {
            transform.GetChild(1).GetChild(1).GetComponent<Image>().fillAmount = 0;
            value = 0;
            StartCoroutine(InfAct());
            PlayerPrefs.SetInt("ActiveInfinity", 1);
        }
    }

    IEnumerator InfAct()
    {
        yield return new WaitForSeconds(PlayerPrefs.GetInt("Infinidade"));
        PlayerPrefs.SetInt("ActiveInfinity", 0);
    }

    IEnumerator Fade()
    {
        fadeInOut = true;
        yield return new WaitForSeconds(.075f);
        fadeInOut = false;
    }

    void FadeOutLife()
    {
        if (lifeMax == 1)
            {
                if(PlayerPrefs.GetFloat("Life") == 0)
                {
                    transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = heart[1];
                }
            }
            else if (lifeMax == 2)
            {
                if (PlayerPrefs.GetFloat("Life") == 1)
                {
                    transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().sprite = heart[1];
                }
                else if(PlayerPrefs.GetFloat("Life") == 0)
                {
                    transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().sprite = heart[1];
                    transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>().sprite = heart[1];
                }
            }
            else if (lifeMax == 3)
            {
                if (PlayerPrefs.GetFloat("Life") == 2)
                {
                    transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().sprite = heart[1];
                }
                else if(PlayerPrefs.GetFloat("Life") == 1)
                {
                    transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().sprite = heart[1];
                    transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().sprite = heart[1];
                }
                else if (PlayerPrefs.GetFloat("Life") == 0)
                {
                    transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().CrossFadeAlpha(0, .2f, false);
                    transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().sprite = heart[1];
                    transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().sprite = heart[1];
                    transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().sprite = heart[1];
                }
            }
    }

    void FadeInLife()
    {
        if (lifeMax == 1)
        {
            if (PlayerPrefs.GetFloat("Life") == 0)
            {
                transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);

                transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = heart[1];
            }
        }
        else if (lifeMax == 2)
        {
            if (PlayerPrefs.GetFloat("Life") == 1)
            {
                transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
                transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);

                transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().sprite = heart[1];
            }
            else if (PlayerPrefs.GetFloat("Life") == 0)
            {
                transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().sprite = heart[1];
                transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>().sprite = heart[1];
            }
        }
        else if (lifeMax == 3)
        {
            if (PlayerPrefs.GetFloat("Life") == 2)
            {
                transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
                transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);

                transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().sprite = heart[1];
            }
            else if (PlayerPrefs.GetFloat("Life") == 1)
            {
                transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().sprite = heart[1];
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().sprite = heart[1];
            }
            else if (PlayerPrefs.GetFloat("Life") == 0)
            {
                transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().CrossFadeAlpha(1, .05f, false);
                transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().sprite = heart[1];
                transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().sprite = heart[1];
                transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().sprite = heart[1];
            }
        }
    }
}
