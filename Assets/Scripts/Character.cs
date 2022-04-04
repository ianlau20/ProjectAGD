using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public GameObject textUI;
    public GameObject textBackground;
    public GameObject nameUI;
    protected List<string> lines;
    protected List<string> sequence1;
    protected List<string> sequence1_1;
    protected List<string> sequence1_2;
    protected List<List<string>> responses;
    protected int curLine;
    protected int curSeq;

    public abstract void Response1();
    public abstract void Response2();
    public abstract void Response3();
}
