using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct MinToMax
{
    private SqlDouble result;
    private SqlDouble min;
    private SqlDouble max;
    private SqlBoolean start;

    public void Init()
    {
        result = 0;
        start = true;
    }

    public void Accumulate(SqlDouble Value)
    {
        if (start)
        {
            min = Value;
            max = Value;
            start = false;
        }
        else
        {
            if (Value < min)
                min = Value;

            if (Value > max)
                max = Value;

            result = max - min;
        }
    }

    public void Merge(MinToMax Group)
    {
        Accumulate(Group.Terminate());
    }

    public SqlDouble Terminate()
    {
        return result;
    }
}
