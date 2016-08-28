using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using OPCAutomation;

using Petecat.Data.Formatters;
using Petecat.Logging;
using Petecat.Extension;

namespace Dade.Dms.Opc
{
    public class OpcServerObject
    {
        public OpcServerObject(string ip, string name)
        {
            Ip = ip;
            Name = name;
            Server = new OPCServer();
        }

        public string Ip { get; private set; }

        public string Name { get; private set; }

        public OPCServer Server { get; private set; }

        public OPCGroup Group { get; private set; }

        public List<OpcItemInfo> ItemInfos = new List<OpcItemInfo>();

        public bool IsAlive { get; private set; }

        public OpcServerInfo ServerInfo
        {
            get
            {
                return new OpcServerInfo()
                {
                    CurrentTime = Server.CurrentTime,
                    StartTime = Server.StartTime,
                };
            }
        }

        public void Connect()
        {
            try
            {
                Server.Connect(Name, Ip);

                if (Server.ServerState == (int)OPCServerState.OPCRunning)
                {
                    // succeeded

                    // add and configurate groups value and group value
                    AddGroup();

                    // add all items to group
                    AddItems();

                    IsAlive = true;
                }
                else
                {
                    // failed
                    IsAlive = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddGroup()
        {
            Group = Server.OPCGroups.Add("OPCDOTNETGROUP");
            Group.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(Group_DataChange);
            Group.AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(Group_AsyncWriteComplete);

            var opcSettings = new XmlFormatter().ReadObject<Configuration.OpcSettingsConfig>("./Configuration/OpcSettings.config", Encoding.UTF8);
            if (opcSettings.GroupsSettings != null && opcSettings.GroupsSettings.ToList().Exists(x => x.Enable))
            {
                var groupsConfig = opcSettings.GroupsSettings.FirstOrDefault(x => x.Enable);
                if (groupsConfig.DefaultGroupDeadband != -1)
                {
                    Server.OPCGroups.DefaultGroupDeadband = groupsConfig.DefaultGroupDeadband;
                }
                Server.OPCGroups.DefaultGroupIsActive = groupsConfig.DefaultGroupIsActive;
                if (groupsConfig.DefaultGroupLocaleID != -1)
                {
                    Server.OPCGroups.DefaultGroupLocaleID = groupsConfig.DefaultGroupLocaleID;
                }
                if (groupsConfig.DefaultGroupTimeBias != -1)
                {
                    Server.OPCGroups.DefaultGroupTimeBias = groupsConfig.DefaultGroupTimeBias;
                }
                if (groupsConfig.DefaultGroupUpdateRate != -1)
                {
                    Server.OPCGroups.DefaultGroupUpdateRate = groupsConfig.DefaultGroupUpdateRate;
                }
            }
            if (opcSettings.GroupSettings != null && opcSettings.GroupSettings.ToList().Exists(x => x.Enable))
            {
                var groupConfig = opcSettings.GroupSettings.FirstOrDefault(x => x.Enable);
                Group.IsActive = groupConfig.IsActive;
                Group.IsSubscribed = groupConfig.IsSubscribed;
                if (groupConfig.UpdateRate != -1)
                {
                    Group.UpdateRate = groupConfig.UpdateRate;
                }
            }
        }

        private void AddItems()
        {
            var browser = Server.CreateBrowser();
            browser.ShowBranches();
            browser.ShowLeafs(true);
            foreach (object item in browser)
            {
                ItemInfos.Add(new OpcItemInfo(Group.OPCItems.AddItem(item.ToString(), 1234)));
            }
        }

        private void Group_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            // save and upload data
            var package = new Model.DataChangePackage() { TransactionId = TransactionID, Items = new Model.DataChangeItem[NumItems] };
            for (int i = 1; i <= NumItems; i++)
            {
                package.Items[i] = new Model.DataChangeItem()
                {
                    ClientHandle = ClientHandles.GetValue(i).ToString(),
                    ItemValue = ItemValues.GetValue(i).ToString(),
                    Quality = Qualities.GetValue(i).ToString(),
                    Timestamp = Qualities.GetValue(i).ToString(),
                };
            }

            if (!Directory.Exists("opc_data".FullPath()))
            {
                Directory.CreateDirectory("opc_data".FullPath());
            }

            new XmlFormatter().WriteObject(package, Path.Combine("opc_data".FullPath(), DateTime.Now.ToString("datachange_yyyyMMddHHmmssfff") + ".dat"), Encoding.UTF8);
        }

        private void Group_AsyncWriteComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors)
        {
            // write log
            for (int i = 1; i <= NumItems; i++)
            {
                var log = string.Format("ID:{0}.Client:{1}.Error:{2}", TransactionID, ClientHandles.GetValue(i).ToString(), Errors.GetValue(i).ToString());
                LoggerManager.GetLogger().LogEvent("OpcServerObject", LoggerLevel.Error, "failed to write.", log);
            }
        }

        public void AsyncWrite(Model.DataWriterPackage package)
        {
            // save and write data
            if (package.Items != null && package.Items.Length > 0)
            {
                var serverHandles = (new int[] { 0 }).Concat(package.Items.Select(x => x.ServerHandle)) as Array;
                var itemValues = (new object[] { "" }.Concat(package.Items.Select(x => x.ItemValue))) as Array;
                Array errors;
                int cancelId;
                Group.AsyncWrite(package.Items.Length, ref serverHandles, ref itemValues, out errors, package.TransactionId, out cancelId);
                GC.Collect();
            }

            if (!Directory.Exists("opc_data".FullPath()))
            {
                Directory.CreateDirectory("opc_data".FullPath());
            }

            new XmlFormatter().WriteObject(package, Path.Combine("opc_data".FullPath(), DateTime.Now.ToString("datawriter_yyyyMMddHHmmssfff") + ".dat"), Encoding.UTF8);
        }
    }
}
