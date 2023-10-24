using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[RequireComponent(typeof(Button))]
public class ButtonCoolDown : MonoBehaviour
{
    public float coolDownTime = 15f;

    protected Button button;
    protected TMP_Text buttonText;
    protected string startText = "";
    protected float timer;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            if(child.TryGetComponent<TMP_Text>(out buttonText))
            {
                startText = buttonText.text;
                buttonText.gameObject.SetActive(false);
                print("starttext: " + startText);
            }
        }
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if(!button.interactable && timer > 0)
        {
            timer -= Time.deltaTime;
            WriteTimer(timer);
        }
        else
        {
            buttonText.text = startText;
        }
    }

    public void StartCooldown()
    {
        timer = coolDownTime;
        WriteTimer(timer);
        StartCoroutine(DoCooldown());
    }

    protected IEnumerator DoCooldown()
    {
        button.interactable = false;
        buttonText.gameObject.SetActive(true);
        yield return new WaitForSeconds(coolDownTime);
        button.interactable = true;
        buttonText.gameObject.SetActive(false);
    }

    protected void WriteTimer(float timeToWrite)
    {
        int tmp = (int)Math.Round(timeToWrite, 0);
        if (buttonText) buttonText.text = tmp.ToString();
    }
}
