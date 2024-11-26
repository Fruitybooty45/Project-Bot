using UnityEngine;

public class SteamLongArms : MonoBehaviour
{
    public GameObject targetObject;

    private Vector3 originalScale;
    private Vector3 resetScale;

    private void Awake()
    {
        originalScale = targetObject.transform.localScale;
        resetScale = new Vector3(1.7f, 1.7f, 1.7f);
        ResizeObject();
    }

    private void OnEnable()
    {
        ResizeObject();
    }

    private void OnDisable()
    {
        ResetObject();
    }

    private void ResizeObject()
    {
        targetObject.transform.localScale = resetScale;
    }

    private void ResetObject()
    {
        targetObject.transform.localScale = originalScale;
    }
}
