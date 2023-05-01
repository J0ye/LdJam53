using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class ButtonCoolDown : MonoBehaviour
{
    public float coolDownTime = 15f;

    protected Button button;
    protected TMP_Text buttonText;
    protected string startText = "";
    protected int timer;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            if(child.TryGetComponent<TMP_Text>(out buttonText))
            {
                startText = buttonText.text;
            }
        }
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if(!button.interactable && timer > 0)
        {
            timer--;
            if(buttonText) buttonText.text = timer.ToString();
        }
        else
        {
            if (buttonText) buttonText.text = startText;
        }
    }

    public void StartCooldown()
    {
        timer = (int)coolDownTime;
        if (buttonText) buttonText.text = timer.ToString();
        StartCoroutine(DoCooldown());
    }

    protected IEnumerator DoCooldown()
    {
        button.interactable = false;
        yield return new WaitForSeconds(coolDownTime);
        button.interactable = true;
    }
}
