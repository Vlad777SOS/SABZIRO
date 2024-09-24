using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject panelMain;  // Основная панель
    public GameObject panelInventory;  // Панель инвентаря

    // Метод для открытия инвентаря и закрытия основной панели
    public void OpenInventory()
    {
        panelMain.SetActive(false);
        panelInventory.SetActive(true);
    }

    // Метод для возвращения к основной панели
    public void CloseInventory()
    {
        panelMain.SetActive(true);
        panelInventory.SetActive(false);
    }
}
