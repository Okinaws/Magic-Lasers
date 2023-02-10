using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public int LaserId = 0;

    private List<GameObject> lines = new List<GameObject>();
    private List<GameObject> hits = new List<GameObject>();

    void Start()
    {
        //LaserManager.Instance.AddLaser(this);
        Instantiate(LaserManager.Instance.flashPrefabs[LaserId], transform);
    }

    private void RemoveOldLines(int linesCount)
    {
        if (linesCount < lines.Count)
        {
            //PoolManager.Instance.Despawn(lines[lines.Count - 1]);
            Destroy(lines[lines.Count - 1]);
            lines.RemoveAt(lines.Count - 1);
            RemoveOldLines(linesCount);

            //PoolManager.Instance.Despawn(hits[hits.Count - 1]);
            Destroy(hits[hits.Count - 1]);
            hits.RemoveAt(hits.Count - 1);
            RemoveOldLines(linesCount);
        }
    }

    void Update()
    {
        int linesCount = 0;

        linesCount += CalcLaserLine(this.transform.position, this.transform.forward, linesCount, this.LaserId);
        RemoveOldLines(linesCount);

    }

    private int CalcLaserLine(Vector3 startPosition, Vector3 direction, int index, int laserId)
    {
        int result = 1;
        RaycastHit hit;
        Ray ray = new Ray(startPosition, direction);
        bool intersect = Physics.Raycast(ray, out hit, LaserManager.Instance.maxStepDistance, LaserManager.Instance.raycastMask);

        Vector3 hitPosition = hit.point;
        if (!intersect)
        {
            hitPosition = startPosition + direction * LaserManager.Instance.maxStepDistance;
        }
        DrawLine(startPosition, hitPosition, index, laserId);
        if (intersect && hit.collider.gameObject.tag == "Mirror" && laserId == 1)
        {
            result += CalcLaserLine(hitPosition, Vector3.Reflect(direction, hit.normal), index + result, laserId);
        }
        if (intersect && hit.collider.gameObject.tag == "MirrorRed" && laserId != 1)
        {
            Debug.Log(hit.collider.gameObject.tag);
            result += CalcLaserLine(hitPosition, Vector3.Reflect(direction, hit.normal), index + result, laserId);
        }
        if (intersect && hit.collider.gameObject.tag == "Enemy" && laserId == 1)
        {
            StartCoroutine(hit.collider.gameObject.GetComponent<Enemy>().Die());
        }
        if (intersect && hit.collider.gameObject.tag == "EnemyRed" && laserId != 1)
        {
            StartCoroutine(hit.collider.gameObject.GetComponent<Enemy>().Die());
        }
        if (intersect && hit.collider.gameObject.tag == "Cash")
        {
            CashManager.Instance.AddCash(1);
            Destroy(hit.collider.gameObject);
        }
        return result;
    }

    private void DrawLine(Vector3 startPosition, Vector3 finishPosition, int index, int laserId)
    {
        LineRenderer line;
        GameObject hit;
        if (index < lines.Count)
        {
            line = lines[index].GetComponent<LineRenderer>();
            hit = hits[index];
        }
        else
        {
            //GameObject go = PoolManager.Instance.Spawn(linePrefabs[laserId], Vector3.zero, Quaternion.identity);
            GameObject go = Instantiate(LaserManager.Instance.linePrefabs[laserId], Vector3.zero, Quaternion.identity);
            line = go.GetComponent<LineRenderer>();
            lines.Add(go);
            //Debug.Log(laserId);

            //hit = PoolManager.Instance.Spawn(hitPrefabs[laserId], finishPosition, Quaternion.identity);
            hit = Instantiate(LaserManager.Instance.hitPrefabs[laserId], finishPosition, Quaternion.identity);
            hits.Add(hit);
        }

        line.SetPosition(0, startPosition);
        line.SetPosition(1, finishPosition);

        line.GetComponent<Laser>().Tile(Vector3.Distance(startPosition, finishPosition));
        hit.transform.position = finishPosition;
    }
}
