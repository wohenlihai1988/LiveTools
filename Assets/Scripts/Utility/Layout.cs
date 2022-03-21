using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Layout : MonoBehaviour
{
    public int m_rowCount;
    public int m_border;
    // Start is called before the first frame update
    void OnEnable()
    {
        m_rowCount = Mathf.Max(1, m_rowCount);
    }

    [ContextMenu("Execute")]
    public void Execute()
    {
        var rootRectTrans = GetComponent<RectTransform>();
        var width = rootRectTrans.rect.width / m_rowCount;
        var height = width * 0.6f;
        var xstart = (width - rootRectTrans.rect.width) * 0.5f;
        var ystart = (rootRectTrans.rect.height - height) * 0.5f;
        for(var i = 0; i < transform.childCount; i++)
        {
            var rectTrans = transform.GetChild(i).gameObject.GetComponent<RectTransform>();
            var x = i % m_rowCount;
            var y = i / m_rowCount;
            rectTrans.anchoredPosition = new Vector2(xstart + x * (width), ystart - y * (height));
            rectTrans.sizeDelta = new Vector2((width - m_border), (height -m_border));
        }
    }
}
