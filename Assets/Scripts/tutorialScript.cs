using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public Sprite[] tutorialImages, runes;
    public GameObject mouse, player;
    public int tutorialPart = 0;
    Image TutorBig, TutorMini;
    Text SpeechBig, SpeechMini, Name;

    void Start()
    {
        PlayerPrefs.SetInt("quality", 2);
        TutorBig = transform.GetChild(0).GetChild(2).GetComponent<Image>();
        TutorMini = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        SpeechBig = TutorBig.transform.GetChild(0).GetComponent<Text>();
        SpeechMini = TutorMini.transform.GetChild(0).GetComponent<Text>();
        Name = TutorMini.transform.GetChild(1).GetComponent<Text>();
        TutorBig.transform.parent.gameObject.SetActive(true);
        TutorMini.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTuto()
    {
        tutorialPart++;
        if (tutorialPart == 1)
        {
            TutorBig.sprite = tutorialImages[1];
            SpeechBig.text = "Então vamos para a sala de testes para você começar a correr!";
        }
        else if (tutorialPart == 2)
        {
            TutorBig.transform.parent.gameObject.SetActive(false);
            TutorMini.transform.parent.gameObject.SetActive(true);
            TutorMini.sprite = tutorialImages[0];
            SpeechMini.text = "Esta é a sala principal, e é onde você sempre vai 'renascer'";
            transform.parent.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        else if (tutorialPart == 3)
        {
            TutorMini.sprite = tutorialImages[1];
            SpeechMini.text = "Para começar a correr é só clicar no seu personagem.";
            transform.GetChild(2).gameObject.SetActive(false);
            transform.parent.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        else if (tutorialPart == 4)
        {
            TutorMini.sprite = tutorialImages[2];
            SpeechMini.text = "Você está atras de ratos, então não se distraia!";
            transform.GetChild(2).gameObject.SetActive(true);
            transform.parent.GetChild(0).gameObject.SetActive(false);
            transform.parent.GetChild(1).gameObject.SetActive(true);
            transform.parent.GetChild(1).GetChild(2).gameObject.SetActive(false);

        }
        else if (tutorialPart == 5)
        {
            TutorMini.sprite = tutorialImages[0];
            SpeechMini.text = "Siga em linha reta e pule os obstaculos.";
        }
        else if (tutorialPart == 6)
        {
            TutorMini.sprite = tutorialImages[1];
            SpeechMini.text = "Para pular é simples, clique no meio da tela.";
            transform.GetChild(2).gameObject.SetActive(false);
            transform.parent.GetChild(1).GetChild(2).gameObject.SetActive(true);
        }
        else if (tutorialPart == 7)
        {
            TutorMini.sprite = tutorialImages[2];
            SpeechMini.text = "Muito bem! Agora vamos caçar alguns ratos!";
            transform.GetChild(2).gameObject.SetActive(true);
            transform.parent.GetChild(1).GetChild(2).gameObject.SetActive(false);
        }
        else if (tutorialPart == 8)
        {
            TutorMini.sprite = tutorialImages[0];
            SpeechMini.text = "Bem... Pelo visto estes são os ratos que você irá caçar.";
            mouse.SetActive(true);
        }
        else if (tutorialPart == 9)
        {
            TutorMini.sprite = tutorialImages[1];
            SpeechMini.text = "Estes ratos infectados geralmente ficam em locais com poucos obstaculos.";
        }
        else if (tutorialPart == 10)
        {
            TutorMini.sprite = tutorialImages[0];
            SpeechMini.text = "Os seus ninhos são bem visiveis, eles brilham em vermelho.";
        }
        else if (tutorialPart == 11)
        {
            TutorMini.sprite = tutorialImages[2];
            SpeechMini.text = "Agora... Ataque-o! É só clicar no lado da tela em que ele esta. (Direita)";
            transform.GetChild(2).gameObject.SetActive(false);
            transform.parent.GetChild(1).GetChild(3).gameObject.SetActive(true);
        }
        else if (tutorialPart == 12)
        {
            TutorMini.sprite = tutorialImages[0];
            SpeechMini.text = "Perfeito! Você será um otimo caçador.";
            transform.GetChild(2).gameObject.SetActive(true);
            transform.parent.GetChild(1).GetChild(3).gameObject.SetActive(false);
        }
        else if (tutorialPart == 13)
        {
            TutorMini.sprite = tutorialImages[0];
            SpeechMini.text = "A nossa aula de como caçar termina por aqui, porem tem mais do que aprender.";
            transform.parent.GetChild(0).gameObject.SetActive(true);
            transform.parent.GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.parent.GetChild(1).gameObject.SetActive(false);
            player.transform.GetChild(0).GetComponent<AnimatorScript>().TutoIdle();
            player.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (tutorialPart == 14)
        {
            TutorMini.sprite = tutorialImages[0];
            SpeechMini.text = "Vou chamar agora o Dr. Rime para você aprender sobre as runas.";
        }
        else if (tutorialPart == 15)
        {
            TutorMini.sprite = tutorialImages[3];
            Name.text = "Dr. Rime";
            SpeechMini.text = "Olá! Eu sou o Dr. Rime e eu vou falar sobre as runas.";
        }
        else if (tutorialPart == 16)
        {
            TutorMini.sprite = tutorialImages[4];
            SpeechMini.text = "As runas podem ser usadas para diversas coisas";
        }
        else if (tutorialPart == 17)
        {
            TutorMini.sprite = tutorialImages[3];
            SpeechMini.text = "As 'Blood Runes' tem 25% de conseguir matando um infectado.";
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(4).GetChild(0).GetComponent<Image>().sprite = runes[0];
        }
        else if (tutorialPart == 18)
        {
            TutorMini.sprite = tutorialImages[4];
            SpeechMini.text = "Elas são usadas para ativar e melhorar as Runas de Skill.";
        }
        else if (tutorialPart == 19)
        {
            TutorMini.sprite = tutorialImages[3];
            SpeechMini.text = "Já as 'Mystic Runes' são encontradas pelo mapa.";
            transform.GetChild(4).GetChild(0).GetComponent<Image>().sprite = runes[1];
        }
        else if (tutorialPart == 20)
        {
            TutorMini.sprite = tutorialImages[4];
            SpeechMini.text = "Elas são usadas para desbloquear personagens e suas variações.";
        }
        else if (tutorialPart == 21)
        {
            TutorMini.sprite = tutorialImages[4];
            SpeechMini.text = "E as 'Golden Runes' são usadas para gerar as outras runas.";
            transform.GetChild(4).GetChild(0).GetComponent<Image>().sprite = runes[2];
        }
        else if (tutorialPart == 22)
        {
            TutorMini.sprite = tutorialImages[3];
            SpeechMini.text = "Para obter ela acesse a Loja e encomende algumas 'Golden Runes'.";
        }
        else if (tutorialPart == 23)
        {
            TutorMini.sprite = tutorialImages[0];
            Name.text = "Prof. Molecula";
            SpeechMini.text = "Bem... E agora uma ultima coisa.";
            transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (tutorialPart == 24)
        {
            TutorMini.sprite = tutorialImages[0];
            SpeechMini.text = "O menu é composto de objetos 3D e 2D";
        }
        else if (tutorialPart == 25)
        {
            TutorMini.sprite = tutorialImages[1];
            SpeechMini.text = "Todos os objetos 3D com um contorno colorido são clicaveis.";
        }
        else if (tutorialPart == 26)
        {
            TutorMini.sprite = tutorialImages[0];
            SpeechMini.text = "Por enquanto é tudo!";
        }
        else if (tutorialPart == 27)
        {
            TutorMini.sprite = tutorialImages[2];
            SpeechMini.text = "Agora... Boa caçada!";
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
            PlayServices.UnlockAchievment(PlagueRunner.achievement_hello_world);
        }
    }
    public void GoTo()
    {
        PlayerPrefs.SetInt("Tutorial", 1);
        SceneManager.LoadScene("Game");
    }
}
