using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public GameObject[] upgradePanels;  // Массив мини-панелей для прокачек
    public Button[] upgradeButtons;  // Массив кнопок для открытия мини-панелей
    public TMP_Text[] prices;  // Массив текстов с ценами для TextMeshPro

    public int playerMoney = 500;  // Деньги игрока для примера

    // Массивы для хранения характеристик игрока
    public int weaponLevel = 0;
    public int healthLevel = 0;
    public int armorLevel = 0;

    private int activePanelIndex = -1;  // Индекс активной панели (-1, если ни одна не открыта)

    // Метод для инициализации
    void Start()
    {
        CloseAllUpgradePanels();  // Закрываем все панели при старте
    }

    // Метод для закрытия всех панелей
    public void CloseAllUpgradePanels()
    {
        foreach (GameObject panel in upgradePanels)
        {
            panel.SetActive(false);  // Скрываем все панели
        }
        activePanelIndex = -1;  // Сбрасываем индекс активной панели
    }

    // Метод для открытия/закрытия соответствующей мини-панели
    public void ToggleUpgradePanel(int index)
    {
        if (activePanelIndex == index)
        {
            CloseAllUpgradePanels();  // Если панель уже открыта, закрываем её
        }
        else
        {
            CloseAllUpgradePanels();  // Закрываем все панели перед открытием новой
            upgradePanels[index].SetActive(true);  // Открываем выбранную панель
            activePanelIndex = index;  // Устанавливаем индекс активной панели
        }
    }

    // Метод для покупки улучшений
    public void BuyUpgrade(int index)
    {
        int upgradeCost = int.Parse(prices[index].text.Split(' ')[1]);  // Получаем цену из текста TMP
        if (playerMoney >= upgradeCost)
        {
            playerMoney -= upgradeCost;  // Вычитаем стоимость
            ApplyUpgrade(index);  // Применяем улучшение
        }
        else
        {
            Debug.Log("Недостаточно средств!");
        }
    }

    // Метод для применения улучшений
    public void ApplyUpgrade(int index)
    {
        if (index < 3) weaponLevel++;  // Прокачка оружия
        else if (index < 6) healthLevel++;  // Прокачка здоровья
        else armorLevel++;  // Прокачка брони

        Debug.Log("Улучшение куплено! Текущий уровень: " + (index < 3 ? weaponLevel : (index < 6 ? healthLevel : armorLevel)));
    }
}
