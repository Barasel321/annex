using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasHandler : MonoBehaviour
{
    public Image blackBar;
    public Image redBar;
    public Image pinkBar;
    public GameObject HP;

    public ThirdPersonAction thirdPersonAction;

    public void ChangeHealthBar(float newHealth){


        float oldFill = pinkBar.fillAmount;
        pinkBar.fillAmount = newHealth/thirdPersonAction.maxHealth;

        if (oldFill > pinkBar.fillAmount){
            //taken damage or lost health
            Shake(0.375f, (oldFill - pinkBar.fillAmount)*10);
        }
        StartCoroutine(RedFlash(oldFill));
    }


    private System.Collections.IEnumerator RedFlash(float oldFill){
        redBar.fillAmount = oldFill;

        yield return new WaitForSeconds(0.75f);

        while (redBar.fillAmount > pinkBar.fillAmount){

            redBar.fillAmount = Mathf.MoveTowards(redBar.fillAmount, pinkBar.fillAmount,Time.deltaTime);
            yield return null;
        }
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
        print("ok");
    }

    private System.Collections.IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        Vector3 originalPosition = HP.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            HP.transform.localPosition += new Vector3(x, y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        HP.transform.localPosition = originalPosition;
    }
}
