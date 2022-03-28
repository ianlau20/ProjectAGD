using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public GameObject textUI;
    public GameObject textBackground;
    protected List<string> lines;
    protected List<List<string>> responses;
    protected int curLine;

    public abstract void Response1();
    public abstract void Response2();
    public abstract void Response3();
}
