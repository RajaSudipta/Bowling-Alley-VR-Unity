using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

using UnityEngine.SceneManagement;
using TMPro;
public class FinalScore : MonoBehaviour
{

    public TextMeshProUGUI Table;

    public string fpath;
    public void backtomenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public string[] Last10Scores()
    {
        int len=0;
        string[] entries = new string[100];
         Debug.Log("ssds");

        using (StreamReader sr = File.OpenText(fpath))
        {
            string line;
            while ((line = sr.ReadLine()) != null) 
            {
                entries[len] = line;
                len++;
            }
        }
                 Debug.Log("ssds1");

        string[] last10 = new string[10];
        for(int j=0;j<10;j++)
        {
            if(len==0)
                break;
            len=len-1;
            last10[j] = entries[len];
        }
                         Debug.Log(last10[0]);

        return last10;
    }
    

    // Start is called before the first frame update
    public DBUpdate scoredb;
  
    public void Start()
    {

        fpath = Application.persistentDataPath+"/score.txt";


        
        // List<int> sclis = new List<int>();
        // for(int i=0;i<scoredb.dbscores.Length;i++)
        // {
        //     int s=scoredb.dbscores[i];
        //     if(s!=0)
        //     {
        //         sclis.Add(s);

        //     }

        // }
        // sclis.Sort();
        // string ans="";
        // for(int i = sclis.Count-1;i>=0;i--)
        // {
        //     ans+=sclis[i]+"\n"; 
        // }
	    string[] last10scores = Last10Scores();
        string final = "S.No.  Date   Score\n";
        int i = 1;
        foreach(string s in last10scores )
        {
            string num = i.ToString();
            if(s==null)
            	break;
            string scopy = s;
            Debug.Log(scopy);
            string[] Tentry = scopy.Split('\t');
            // Debug.Log("ssds10111");

            Debug.Log(Tentry[0]);
            Debug.Log(Tentry[1]);
            int len = Tentry.Length;
            final = final + num +"\t" + Tentry[0] + "\t" + Tentry[1] + "\n";
            i++;
       	}
        Debug.Log("ssds10");
        Table.text=final;
     }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
