using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct CountMinus
{
    public void Init()
    {
        minusy = 0;
    }

    public void Accumulate(SqlDouble Value)
    {
        if (Value < 0)
            minusy++;
    }

    public void Merge(CountMinus Group)
    {
        Group.Terminate();
    }

    public SqlInt32 Terminate()
    {
        return minusy;
    }

    private int minusy;

}
