using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CountryTree
{
    public class DatabaseInitializer
    {
        private readonly string _DatabaseFileName = "CountryDatabase.sqlite";

        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");

            return connection;
        }
        
        private SQLiteCommand GetInitializedCommand(string SQL, SQLiteConnection Connection)
        {
            SQLiteCommand command = new SQLiteCommand(SQL, Connection);

            return command;
        }

        private SQLiteCommand GetInitializedCommand(string SQL)
        {
            var connection = GetConnection();
            SQLiteCommand command = new SQLiteCommand(SQL, connection);

            return command;
        }

        public void InitDatabase()
        {
            if(!File.Exists(_DatabaseFileName))
            {
                SQLiteConnection.CreateFile(_DatabaseFileName);
                CreateDataTables();
            }
        }

        private void CreateDataTables()
        {
            CreateCountryTable();
            CreateSubRegionTable();
            CreateLinkTable();
        }

        private void CreateLinkTable()
        {
            string create_table_sql =
            @"Create Table LinkTable ( 
                'id' INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , 
                FOREIGN KEY (country_id) REFERENCES Country(id) ),
                FOREIGN KEY (subregion_id) REFERENCES SubRegion(id) )
            )";
            var command = GetInitializedCommand(create_table_sql);
            ExecuteCommand(command);
        }

        private void CreateSubRegionTable()
        {
            string create_table_sql =
                @"Create Table Country(
                  'id' INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , 
                  'Name' TEXT NOT NULL  DEFAULT Unknown )";

            var command = GetInitializedCommand(create_table_sql);
            ExecuteCommand(command);
        }

        private void CreateCountryTable()
        {
            string create_table_sql =
                   @"Create Table SubRegion(
                  'id' INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , 
                  'Name' TEXT NOT NULL  DEFAULT Unknown,
                   FOREIGN KEY (c_id) REFERENCES Country(id) )";

            var command = GetInitializedCommand(create_table_sql);
            ExecuteCommand(command);
        }


        private void ExecuteCommand(SQLiteCommand Command)
        {
            try
            {
                if (Command.Connection.State != System.Data.ConnectionState.Open)
                    Command.Connection.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    //this should be logging
            }
            finally
            {
                Command.Connection.Close();
                Command.Dispose();
            }
        }
    }
}
