﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

    public void clicked()
    {
        SceneManager.LoadScene("start");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
