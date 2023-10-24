using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonCoolDownTileCount : MonoBehaviour
{
    public KeyCode actionKey = KeyCode.Space;
    public int coolDownValue = 5;

    protected Button button;
    protected TMP_Text buttonText;
    protected string startText = "";
    protected int countTarget;
    protected bool test;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        SetUpMember();
    }

    protected void Update()
    {
        test = GameController.instance.placedTilesCount < countTarget;
        if (GameController.instance.placedTilesCount < countTarget)
        {
            WriteCoolDown(countTarget-GameController.instance.placedTilesCount);
        }
        else
        {
            button.interactable = true;
            buttonText.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(actionKey) && button.interactable)
        {
            button.onClick.Invoke();
        }
    }

    public void StartCooldown()
    {
        button.interactable = false;
        buttonText.gameObject.SetActive(true);
        countTarget = coolDownValue + GameController.instance.placedTilesCount;
        WriteCoolDown(coolDownValue);
    }

    protected void SetUpMember()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<TMP_Text>(out buttonText))
            {
                startText = buttonText.text;
                buttonText.gameObject.SetActive(false);
            }
        }
        button = GetComponent<Button>();
    }

    protected void WriteCoolDown(int toWrite)
    {
        if (buttonText) buttonText.text = toWrite.ToString();
    }
}
