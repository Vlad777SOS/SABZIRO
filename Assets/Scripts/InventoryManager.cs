using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject panelMain;  // �������� ������
    public GameObject panelInventory;  // ������ ���������

    // ����� ��� �������� ��������� � �������� �������� ������
    public void OpenInventory()
    {
        panelMain.SetActive(false);
        panelInventory.SetActive(true);
    }

    // ����� ��� ����������� � �������� ������
    public void CloseInventory()
    {
        panelMain.SetActive(true);
        panelInventory.SetActive(false);
    }
}
