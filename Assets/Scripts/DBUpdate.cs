using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class DBUpdate : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

[CreateAssetMenu (fileName ="ScoreDB",menuName ="DBUpdate")]

public class DBUpdate : ScriptableObject
{
    public int[] dbscores=new int[10];
    // public int finalscore;
    public int prev;
    public int cur;
}