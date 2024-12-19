using UnityEngine;

namespace RedwoodTestTask
{
    public class SpriteHealthBar : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer fill;
        [SerializeField] private SpriteRenderer background;
        
        [SerializeField] private bool DisplayOnChange = true;
        [SerializeField, Range(1, 3)] private float displayTime = 2;
        [SerializeField, Range(3, 6)] private float fadeSpeed = 5;
        
        private float fill_X_Scale;
        private float currentAlpha;
        private float targetAlpha;
        
        //===============================================================
        private void Start()
        {
            fill_X_Scale = fill.transform.localScale.x;
        }
        //===============================================================
        public void DisplayHealth(int current, int max)
        {
            fill.transform.localScale = new Vector3(fill_X_Scale * current / max, fill.transform.localScale.y, fill.transform.localScale.z);
            
            if (!DisplayOnChange) return;
            targetAlpha = 1;
            CancelInvoke(nameof(HideHealthBar));
            Invoke(nameof(HideHealthBar), displayTime);
        }
        //===============================================================
        private void HideHealthBar()
        {
            targetAlpha = 0;
        }
        //===============================================================
        private void Update()
        {
            if (DisplayOnChange)
            {
                currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, Time.deltaTime * fadeSpeed);
            }
            else
            {
                currentAlpha = 1;
            }
            
            SetAlpha(fill, currentAlpha);
            SetAlpha(background, currentAlpha);
        }
        //===============================================================
        private static void SetAlpha(SpriteRenderer sprite, float value)
        {
            sprite.color = SetColorElement(sprite.color, 3, value);
        }
        //===============================================================
        private static Color SetColorElement(Color color, int index, float value)
        {
            color[index] = value;
            return color;
        }
        //===============================================================
    }
}