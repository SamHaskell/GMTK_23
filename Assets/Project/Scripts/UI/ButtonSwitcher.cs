using UnityEngine;

public class ButtonSwitcher : MonoBehaviour
{
    public void DisableButton(Tag tag) {
        foreach (var button in gameObject.GetComponentsInChildren<LaunchableTagButton>()) {
            if (button.TagData.Tag == tag) {
                button.MarkAsUsed();
            }
        }
    }

    public void EnableButtons() {
        foreach (var button in gameObject.GetComponentsInChildren<LaunchableTagButton>()) {
            button.MarkAsFree();
        }
    }
}
