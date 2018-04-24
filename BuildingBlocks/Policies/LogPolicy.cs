using System;
using System.Collections.Generic;

namespace BuildingBlocks.Policies
{
    public class LogPolicy
    {
        readonly List<string> _exceptions = new List<string>();

        public void LogException(Exception ex)
        {
            _exceptions.Add(ex.Message);
        }
    }
}