using UnityEngine;

public class SetMenuActive : MonoBehaviour
{
    public GameObject Menu;

    public void ActivateMenu()
    {
        Menu.SetActive(true);
    }

}
