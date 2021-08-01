﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace FailuresCommon
{
    public static class SQLiteDataAccess
    {
        /// <summary>
        /// loads all records from Options table into list of OptionsModel
        /// </summary>
        /// <returns>
        /// List of OptionsModel
        /// </returns>
        public static List<OptionsModel> LoadOptions()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<OptionsModel>("select * from Options", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// Updates row in table Options if row exists. If not then insserts this row
        /// </summary>
        /// <param name="option">
        /// OptionModel object to update in database
        /// </param>
        public static void UpdateOption(OptionsModel option)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                if (cnn.Execute("update Options set OptionValue = @value where OptionName = @name", option) <= 0 )
                {
                    cnn.Execute("insert into Options (OptionName, OptionValue) values (@name, @value)", option);
                }
            }
        }

        /// <summary>
        /// Loads value of given option 
        /// </summary>
        /// <param name="optionName">
        /// name of option to take value from
        /// </param>
        /// <returns>
        /// "" if select returns no rows
        /// value of option if option exists
        /// </returns>
        public static string LoadOptionValue(string optionName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var query = cnn.Query<string>(String.Format("select OptionValue from Options where optionName = '{0}'", optionName)).ToList();
                if (query.Count > 0)
                {
                    return query[0];
                }
                return "";
            }
        }

        /// <summary>
        /// Takes connection string for database
        /// </summary>
        /// <param name="id">
        /// which connection string get
        /// </param>
        /// <returns>
        /// connection string
        /// </returns>
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
