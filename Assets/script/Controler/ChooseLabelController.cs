using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChooseLabelController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultcolor;
    public Color hovercolor;
    public StoryScene scene;
    private TextMeshProUGUI textMesh;
    private ChooseController Controller;

    
    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.color = defaultcolor;
    }

    public float GetHeight()
    {
        return textMesh.rectTransform.sizeDelta.y * textMesh.rectTransform.localScale.y;  
    }

    public void Setup(ChooseScene.ChooseLabel label, ChooseController controller ,float y)
    {
        scene = label.nextScene;
        textMesh.text = label.text;
        this.Controller = controller;

        Vector3 position = textMesh.rectTransform.localPosition;
        position.y = y;
        textMesh.rectTransform.localPosition = position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Controller.PerformChoose(scene);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMesh.color = hovercolor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMesh.color = defaultcolor;
    }
}
