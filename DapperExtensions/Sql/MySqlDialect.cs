﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DapperExtensions.Sql
{
    [Obsolete("Not ready from primetime - use at your own risk", false)]
    internal class MySqlDialect : SqlDialectBase
    {
        public override char OpenQuote
        {
            get { return '`'; }
        }

        public override char CloseQuote
        {
            get { return '`'; }
        }

        public override string GetIdentitySql(string tableName)
        {
            return "SELECT LAST_INSERT_ID()";
        }

        public override string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            string result = string.Format("{0} LIMIT @pageStartRowNbr, @resultsPerPage", sql);
            int startValue = ((page - 1) * resultsPerPage);
            parameters.Add("@pageStartRowNbr", startValue);
            parameters.Add("@resultsPerPage", resultsPerPage);
            return result;
        }
    }
}