using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckPoint04
{
    public class DataCollectorUnit
    {
        private string _source_directory;
        private MZDAL _dal;
        private object userOpSync = new object();

        public DataCollectorUnit(string source_directory)
        {
            _source_directory = source_directory;
            _dal = new MZDAL();
            StartMonitoring();
        }

        private Exception StartMonitoring()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"D:\Data";
            }
            catch (Exception e)
            {
                return e;            
            }
            watcher.Filter = "*.csv";
            watcher.Created += watcher_Created;
            watcher.EnableRaisingEvents = true;
            return null;
        }

        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            string filename = Path.GetFileNameWithoutExtension(e.Name);            
            string[] split = filename.Split(new Char[] {'_'});
            if (split.Length == 2)
            {
                OrderUnit OU = new OrderUnit() {ManagerName = split[0], Date = DateTime.ParseExact(split[1], "ddMMyyyy", null)};
                ProcessFile(e.FullPath, OU);
            }            
        }        

        private void ProcessFile(string file_name, OrderUnit ou)
        {            
            var task = new Task(() => CollectorTask(file_name, ou));
            task.Start();            
        }

        private void CollectorTask(string file_name, OrderUnit ou)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(file_name);
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] split = line.Split(new Char[] {' '});
                    if (split.Length == 3)
                    {
                        
                        ou.CustomerName = split[0];
                        ou.ProductName = split[1];
                        ou.Amount = Convert.ToInt32(split[2]);
                        lock (userOpSync)
                        {
                            _dal.AddOrderUnit(ou);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                file.Close();
            }
        }
    }
}
