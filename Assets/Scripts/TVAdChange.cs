using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TVAdChange : MonoBehaviour
{
    public Image targetImage;
    public Sprite[] adImages;
    public int adImagesCount = 0;

    void Start()
    {
        StartCoroutine(ChangeAdImages());
    }

    public IEnumerator ChangeAdImages()
    {
        while (true)
        {
            targetImage.sprite = adImages[adImagesCount];

            yield return new WaitForSeconds(3f);

            adImagesCount++;

            if (adImagesCount >= adImages.Length)
            {
                adImagesCount = 0;
            }
        }
    }
}
