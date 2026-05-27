using System.Collections;
using TMPro;
using UnityEngine;

public class TrolleyBag : MonoBehaviour
{
    public Transform startPos;
    public Transform rightPos;
    public Transform endPos;

    public GameObject bag;

    public float duration = 3f;
    public float duration2 = 6f;

/*    public TMP_Text weightText;
    public int minAmmount = 20;
    public int maxAmmount = 25;
*/
/*    private void OnEnable()
    {
        StartCoroutine(ExcavatorMoveTop());
    }*/

    public void StratBagSubmit()
    {
        StartCoroutine(ExcavatorMoveTop());
    }

    public IEnumerator ExcavatorMoveTop()
    {
/*        int random = Random.Range(minAmmount, maxAmmount);
        weightText.text = random.ToString();*/

        yield return new WaitForSeconds(2f);

        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            bag.transform.position = Vector3.Lerp(startPos.position, rightPos.position, t);

            yield return null;
        }

        bag.transform.position = rightPos.position;

        float time2 = 0;

        while (time2 < duration2)
        {
            time2 += Time.deltaTime;
            float t = time2 / duration2;

            bag.transform.position = Vector3.Lerp(rightPos.position, endPos.position, t);

            yield return null;
        }

        GameManager.instance.stairsBlockColliderObj[0].gameObject.SetActive(false);
        GameManager.instance.stairsBlockColliderObj[1].gameObject.SetActive(false);
        GameManager.instance.excavatorMove.SetActive(true);
        bag.transform.position = endPos.position;
    }
}
