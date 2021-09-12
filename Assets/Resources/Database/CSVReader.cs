using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CSVReader : MonoBehaviour
{
    [SerializeField] TextAsset csvAsset;

    [SerializeField] private List<string> header;
    [SerializeField] private List<List<string>> csvData;

    private Dictionary<string, int> mapTable;
    
    void Start()
    {
         LoadCSVData();
         Debug.Log("ready");
    }

    async void LoadCSVData()
    {
        csvData = new List<List<string>>();
        mapTable = new Dictionary<string, int>();
        string[] comma = new[] { "," };
        string[] newLine = new[] { "\n" };
        
        List<string> rows = csvAsset.text.Split(newLine, StringSplitOptions.RemoveEmptyEntries).ToList();
        
        await Task.Run(() =>
        {
            for (int i1 = 0; i1 < 10000; i1++)
            {
                Debug.Log("Nothing");
            }
        

            int i = -1;
            foreach (string row in rows)
            {
                csvData.Add(row.Split(comma, StringSplitOptions.None).ToList());
                mapTable.Add(row.Split(comma, StringSplitOptions.None)[0], i);
                i++;
            }
        });
        header = csvData[0];
        csvData.RemoveAt(0);
    }

    public string FetchValue(string name, string column)
    {
        int columnIndex = header.IndexOf(column);
        if (columnIndex == -1)
        {
            Debug.LogError($"Column {column} Not found");
            return "";
        }

        int entry = -1;
        if (mapTable.TryGetValue(name, out entry))
        {
            return csvData[entry][columnIndex];
        }
        else
        {
            Debug.LogWarning($"Entry {name} not found");
        }

        return "?";
    }
}
