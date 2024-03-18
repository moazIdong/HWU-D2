using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScroll : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Scrollbar scrollbar;
    private void OnEnable()
    {
        StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        yield return null;
        scrollbar.value = 1;
        print("Scroll Value :" + scrollbar.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
