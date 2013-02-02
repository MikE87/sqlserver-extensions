using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct CountString
{
    public void Init()
    {
        result = 0;
    }

    public void Accumulate(SqlString Value, SqlString expr)
    {
        if (Value.Equals(expr))
            result++;
    }

    public void Merge(CountString Group)
    {
        Group.Terminate();
    }

    public SqlInt32 Terminate()
    {
        return result;
    }

    private int result;

}
