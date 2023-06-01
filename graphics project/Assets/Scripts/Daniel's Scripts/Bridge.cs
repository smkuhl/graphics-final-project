using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject seg1, seg2, seg3;
    public GameObject c1, c2, c3;
    private int count;
    private GameObject[] segments;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        segments = new GameObject[] {seg1, seg2, seg3};
        for (int i = 0; i < segments.Length; i++) segments[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementCount() {
        segments[count].SetActive(true);
        count++;
    }
}
