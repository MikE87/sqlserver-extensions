using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct AvgStringLength
{
    public void Init()
    {
        lengthsSum = 0;
        cnt = 0;
        result = 0;
    }

    public void Accumulate(SqlString Value)
    {
        lengthsSum += Value.Value.Length;
        cnt++;
        result = lengthsSum / cnt;
    }

    public void Merge(AvgStringLength Group)
    {
        Group.Terminate();
    }

    public SqlDouble Terminate()
    {
        return result;
    }

    private int lengthsSum;
    private int cnt;
    private float result;

}
