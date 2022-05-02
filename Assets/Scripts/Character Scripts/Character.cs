using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
public abstract class Character : MonoBehaviour
{
    public GameObject textUI;
    public GameObject textBackground;
    public GameObject nameUI;
    protected List<string> lines;

    protected List<string> responses;
    protected Action seqMethod;
    protected int curLine;
    protected int session;
    protected string curSeq;
    protected string curName;

    public abstract void Response1();
    public abstract void Response2();
    public abstract void Response3();

    public abstract void SkipText();
}
