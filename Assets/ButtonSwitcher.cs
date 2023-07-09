using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void DisableButton(Tag tag) {
        foreach (var button in gameObject.GetComponentsInChildren<LaunchableTagButton>()) {
            if (button.TagData.Tag == tag) {
                Debug.Log("disabling!");
                button.MarkAsUsed();
            }
        }
    }

    public void EnableButtons() {
        foreach (var button in gameObject.GetComponentsInChildren<LaunchableTagButton>()) {
            button.MarkAsFree();
        }
        Debug.Log("enabling!");
    }
}
