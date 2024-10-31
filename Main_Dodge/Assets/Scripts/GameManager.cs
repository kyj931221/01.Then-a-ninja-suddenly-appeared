using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;//UI ���� ���̺귯��
using UnityEngine.SceneManagement;//�� ���� ���� ���̺귯��

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;

    public Text timeText;
    public Text recordText;
    public Text surviveText;

    public ProgressBar Pb;
    public int Valeur = 0;

    public int winScore = 2;

    public float uploadMin;
    public float uploadMax;
    float uploadRate;

    float surviveTime;
    bool isGameover; //���ӿ��� ����(Ʈ��/�޽�)

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        uploadRate = Random.Range(uploadMin, uploadMax);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
            Pb.BarValue = (int)surviveTime / (int)uploadRate;

            if( Pb.BarValue == winScore )
            {
                SceneManager.LoadScene("EndingScene");
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R)) 
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        int bestTimeH = (int)bestTime / 60;
        int bestTimeS = (int)bestTime % 60;

        int surviveH = (int)surviveTime / 60;
        int surviveS = (int)surviveTime % 60;

        recordText.text = "�ְ� ���! : " + bestTimeH + " ��" + bestTimeS + "��";
        timeText.text = "���� ��� : " + surviveH + "��" + surviveS + "��";
        surviveText.text = "���α׷� ���ε� ������.. : " + (int)Pb.BarValue + "%";
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
