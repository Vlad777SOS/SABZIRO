using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public GameObject[] upgradePanels;  // ������ ����-������� ��� ��������
    public Button[] upgradeButtons;  // ������ ������ ��� �������� ����-�������
    public TMP_Text[] prices;  // ������ ������� � ������ ��� TextMeshPro

    public int playerMoney = 500;  // ������ ������ ��� �������

    // ������� ��� �������� ������������� ������
    public int weaponLevel = 0;
    public int healthLevel = 0;
    public int armorLevel = 0;

    private int activePanelIndex = -1;  // ������ �������� ������ (-1, ���� �� ���� �� �������)

    // ����� ��� �������������
    void Start()
    {
        CloseAllUpgradePanels();  // ��������� ��� ������ ��� ������
    }

    // ����� ��� �������� ���� �������
    public void CloseAllUpgradePanels()
    {
        foreach (GameObject panel in upgradePanels)
        {
            panel.SetActive(false);  // �������� ��� ������
        }
        activePanelIndex = -1;  // ���������� ������ �������� ������
    }

    // ����� ��� ��������/�������� ��������������� ����-������
    public void ToggleUpgradePanel(int index)
    {
        if (activePanelIndex == index)
        {
            CloseAllUpgradePanels();  // ���� ������ ��� �������, ��������� �
        }
        else
        {
            CloseAllUpgradePanels();  // ��������� ��� ������ ����� ��������� �����
            upgradePanels[index].SetActive(true);  // ��������� ��������� ������
            activePanelIndex = index;  // ������������� ������ �������� ������
        }
    }

    // ����� ��� ������� ���������
    public void BuyUpgrade(int index)
    {
        int upgradeCost = int.Parse(prices[index].text.Split(' ')[1]);  // �������� ���� �� ������ TMP
        if (playerMoney >= upgradeCost)
        {
            playerMoney -= upgradeCost;  // �������� ���������
            ApplyUpgrade(index);  // ��������� ���������
        }
        else
        {
            Debug.Log("������������ �������!");
        }
    }

    // ����� ��� ���������� ���������
    public void ApplyUpgrade(int index)
    {
        if (index < 3) weaponLevel++;  // �������� ������
        else if (index < 6) healthLevel++;  // �������� ��������
        else armorLevel++;  // �������� �����

        Debug.Log("��������� �������! ������� �������: " + (index < 3 ? weaponLevel : (index < 6 ? healthLevel : armorLevel)));
    }
}
