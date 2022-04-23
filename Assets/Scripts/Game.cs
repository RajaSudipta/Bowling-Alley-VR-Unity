using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.IO;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ballObj;

    public DBUpdate scoredb;
    public HighScore highScore;

    string fpath;

    public TextMeshProUGUI showScoreCard;
    public TextMeshProUGUI showTotalScoreCard;
    Vector3 ballPosition;
    Quaternion ballRotation;
    Vector3[] pinPositions;

    char[] interScoreString="||   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   ||".ToCharArray();
    char[] totalScoreString="||       |       |       |       |       |       |       |       |       |           ||".ToCharArray();

    Quaternion[] pinRotations;
    int[] scoreCardArr=new int[22];
    int[] finalScoreArr = new int[11];
    int index=1;
        int score = 0;
    int turnCounter = 0;
    GameObject[] pinsObj;
    
    void setScoreString(int a,char scString){
        interScoreString[4*a-1]=scString;
    }

    // void setTotalString(int a,char scString){
    //     totalScoreString[4*a-1]=scString;
    // }


     public void backtomenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    bool checkSpareBool(int score){

        if(score+scoreCardArr[index-1]==10){
        if(index%2==0 && index<19){
            index+=1;
            return true;
        }
        else{
        return false;
        }
        }
        else{
            return false;
        }
    }

    bool checkStrikeBool(int score){
        if(score==10){
        if(index%2==1 && index<19){
            index+=2;
            return true;
        }
        if(index>=19&&index<=21){
            index+=1;
            return true;
        }
        else{
        return false;
        }
        }
        else{
            return false;
        }
    
    }

    int totalScore()
    {
        int score=0;
        int rollIndex=0;
        for(int frame = 0;frame<10;frame++)
        {
            if(checkStrikeBool(scoreCardArr[rollIndex]))
            {
                score += scoreCardArr[rollIndex] + scoreCardArr[rollIndex + 1] + scoreCardArr[rollIndex + 2];
                rollIndex++;
            }
            else if(checkSpareBool(rollIndex))
            {
                score+= scoreCardArr[rollIndex] + scoreCardArr[rollIndex + 1] + scoreCardArr[rollIndex + 2];
                rollIndex+=2;
            }
            else
            {
                score+= scoreCardArr[rollIndex] + scoreCardArr[rollIndex + 1];
                rollIndex+=2;
            }
        }
        return score;
    }
    char mapIntToChar(int a){
        char x='0';
        switch(a)
        {
            case 0:
            x='0';
            break;

            case 1:
            x='1';
            break;

            case 2:
            x='2';
            break;

            case 3:
            x='3';
            break;

            case 4:
            x='4';
            break;

            case 5:
            x='5';
            break;

            case 6:
            x='6';
            break;

            case 7:
            x='7';
            break;

            case 8:
            x='8';
            break;
            
            case 9:
            x='9';
            break;

            case 10:
            x='X';
            break;


            default:
            break;
        }

        return x;
    }

    void Start()
    {
        fpath = Application.persistentDataPath+"/score.txt";
        ballObj=this.gameObject;
        ballPosition = ballObj.transform.position;
        ballRotation = ballObj.transform.rotation;

        pinsObj = GameObject.FindGameObjectsWithTag("Pin");
        pinPositions = new Vector3[pinsObj.Length];
        pinRotations = new Quaternion[pinsObj.Length];
        // Debug.Log(pinsObj.Length);
        for(int i=0; i< pinsObj.Length; i++)
        {
            pinPositions[i] = pinsObj[i].transform.position;
            pinRotations[i] = pinsObj[i].transform.rotation;
            // positions[i] = new Vector3(pinsObj[i].transform.position.x, pinsObj[i].transform.position.y, pinsObj[i].transform.position.z);
            // Debug.Log(pinPositions[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void CountPinsDown()
    {
        for(int i = 0; i < pinsObj.Length; i++)
        {
            if((pinsObj[i].transform.eulerAngles.x > 250))
            {
                continue;
            }
            if((pinsObj[i].transform.eulerAngles.x < -120 || pinsObj[i].transform.eulerAngles.x > -60 )&& pinsObj[i].activeSelf)
            {
                score++;
                // Debug.Log('x');
                // Debug.Log(pinsObj[i].transform.eulerAngles.x);
                // Debug.Log('y');
                // Debug.Log(pinsObj[i].transform.eulerAngles.y);
                // Debug.Log('z');
                // Debug.Log(pinsObj[i].transform.eulerAngles.z);


                // Debug.Log(score);
                pinsObj[i].SetActive(false);
            }
        }
        // setScoreString(index,mapIntToChar(score));
        // string scoreCardString=new string(interScoreString);
        // showScoreCard.text=scoreCardString;

        scoreCardArr[index]=score;
        Debug.Log(index);
        setScoreString(index,mapIntToChar(score));
        string scoreCardString=new string(interScoreString);
        showScoreCard.text=scoreCardString;
        Debug.Log(scoreCardString);
        // showScoreCard.text = score.ToString();
        if(checkStrikeBool(score)){
            Debug.Log("Strike");
            finalScoreArr[(index-1)/2]=10;
        }
        else if(checkSpareBool(score)){
            finalScoreArr[(index-2)/2]=10;
            Debug.Log("Spare");

        }
        else{
            index++;
            finalScoreArr[(index-2)/2]=score+scoreCardArr[index-1];
        }

        Debug.Log(index);

        // if(index>=21){
        //     int totaSc=totalScore();
        //     showTotalScoreCard.SetText(totaSc.ToString());
        //     Debug.Log(totaSc);

        //     if(totaSc > highScore.highScore)
        //     {
        //         highScore.highScore = totaSc;
        //     }
        //     // Application.Quit();
        // }
        
        // scoreCardArr[index]=score;
        // if(score > highScore.highScore)
        // {
        //     highScore.highScore = score;
        // }
        // index++;
        // Debug.Log(highScore.highScore);
        score=0;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "#TOY0003_V2_10_Bowling_Pins")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
            StartCoroutine(gameplay());
        }
    }
    private IEnumerator gameplay()
    {
        yield return new WaitForSeconds(6);
        CountPinsDown();
        ballObj.transform.position = ballPosition;
        // ballObj.transform.rotation = ballRotation;

        ballObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ballObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ballObj.transform.rotation = Quaternion.identity;

        if(index%2==1){
        for(int i = 0; i < pinsObj.Length; i++)
        {
            pinsObj[i].SetActive(true);
            // ball.transform.position = new Vector3(-1.148437e-07f, 0.124f, -0.346f);
            pinsObj[i].transform.position = pinPositions[i];
            pinsObj[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pinsObj[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pinsObj[i].transform.rotation = pinRotations[i];
            //pinsObj[i].transform.rotation = Quaternion.identity;
        }
        }
        else{
        for(int i = 0;i< pinsObj.Length;i++){
            if((pinsObj[i].transform.eulerAngles.x > 250))
            {
                continue;
            }
            if((pinsObj[i].transform.eulerAngles.x < -120 || pinsObj[i].transform.eulerAngles.x > -60 )&& pinsObj[i].activeSelf)
            {
                Destroy(pinsObj[i]);

            }
        }
        }

        if(index>=22){
            int totaSc=totalScore();
            showTotalScoreCard.SetText(totaSc.ToString());
            Debug.Log(totaSc);
            // scoredb.dbscores[scoredb.cur] = totaSc;
            // scoredb.cur+=1;
            // scoredb.cur%=10;
            // scoredb.prev = totaSc;
            // Write to file

            using(StreamWriter sw = File.AppendText(fpath))
            {
                var dateTime = DateTime.Now;
                var today = dateTime.ToShortDateString();
                Debug.Log(today);
                string final = today + "\t" + totaSc.ToString() ;
                sw.WriteLine(final);
            }
            // Application.Quit();

            // yield return new WaitForSeconds(4);

            // SceneManager.LoadScene("MainMenu");

        }
    }
}
