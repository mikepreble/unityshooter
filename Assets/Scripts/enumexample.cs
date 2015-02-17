using UnityEngine;
using System.Collections;

public class EnumScript : MonoBehaviour 
{
    enum Path{Up, Right, Down, Left};void Start () 
    {
        Path myPath;
        
        myPath = Path.Up;
    }

}
