using System.ComponentModel;
using UnityEngine;

public class DijkstraSearch : MonoBehaviour
{
    private int[,] nodes = new int[6, 6]
    {
        {0, 1, 2, 0, 4, 0 },
        {1, 0, 0, 0, 0, 8 },
        {2, 0, 0, 3, 0, 0 },
        {0, 0, 3, 0, 0, 0 },
        {4, 0, 0, 0, 0, 2 },
        {0, 8, 0, 0, 2, 0 },
    };

    private void Start()
    {
        int start = 0;
        int[] dist;
        int[] prev;

        Dijkstra(start,out dist, out prev);

        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            Debug.Log($"{start}���� {i}���� �ִ� �Ÿ�: {dist[i]}, ���: {GetPath(i, prev)}");
        }
    }

    private void Dijkstra(int start, out int[] dist, out int[] prev)
    {
        int n = nodes.GetLength(0);
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n];

        // ������ ������ �ʱ�ȭ
        for (int i = 0; i < n; i++)
        {
            dist[i] = int.MaxValue;
            prev[i] = -1;
            visited[i] = false;
        }
        // 0�� ��忡�� ���� ����
        dist[start] = 0;
        for(int cnt = 0; cnt < n; cnt++)
        {
            int u = -1; //�ִܰŸ� ���
            int min = int.MaxValue; //�ִܰŸ� ����ġ

            //�湮���� ���� ����߿� �ּ� �Ÿ� ���
            for(int j = 0; j < n; j++)
            {
                if (!visited[j] && dist[j] < min)
                {
                    min = dist[j];
                    u = j;
                }
            }

            //�ִ� �Ÿ��� ��尡 ����
            if (u == -1)
                break;

            visited[u] = true;

            for(int k = 0; k < n; k++)
            {
                if (nodes[u, k] > 0 && !visited[k])
                {
                    int newDist = dist[u] + nodes[u, k];
                    if(newDist < dist[k])
                    {
                        dist[k] = newDist;
                        prev[k] = u;
                    }
                }
            }
        }
    }
    private string GetPath(int end, int[] prev)
    {
        if (prev[end] == -1)
            return end.ToString();

        return
            GetPath(prev[end], prev) + " -> " + end;
    }
}
