using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Data.Access;
using Petecat.IoC.Attributes;
namespace Dade.Dms.Rest.Repository
{
    [AutoResolvable(typeof(IDeviceCheckpointRepository))]
    public class DeviceCheckpointRepository : IDeviceCheckpointRepository
    {
        public int AddCheckpoint(DeviceCheckpointSource deviceCheckpointSource)
        {
            var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("CheckpointInfo_AddCheckpoint");
            dataCommandObject.SetParameterValue("@DeviceNumber", deviceCheckpointSource.DeviceInfo.DeviceNumber);
            dataCommandObject.SetParameterValue("@Description", deviceCheckpointSource.Description);
            dataCommandObject.SetParameterValue("@Flag", deviceCheckpointSource.Flag);
            dataCommandObject.SetParameterValue("@UpperLimit", deviceCheckpointSource.UpperLimit);
            dataCommandObject.SetParameterValue("@LowerLimit", deviceCheckpointSource.LowerLimit);
            dataCommandObject.SetParameterValue("@Remark", deviceCheckpointSource.Remark);
            dataCommandObject.ExecuteNonQuery();
            return (int)dataCommandObject.GetParameterValue("@RetVal");
        }

        public int EditCheckpoint(DeviceCheckpointSource deviceCheckpointSource)
        {
            var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("CheckpointInfo_EditCheckpoint");
            dataCommandObject.SetParameterValue("@Id", deviceCheckpointSource.Id);
            dataCommandObject.SetParameterValue("@Description", deviceCheckpointSource.Description);
            dataCommandObject.SetParameterValue("@Remark", deviceCheckpointSource.Remark);
            dataCommandObject.ExecuteNonQuery();
            return (int)dataCommandObject.GetParameterValue("@RetVal");
        }

        public int DeleteCheckpoint(DeviceCheckpointSource deviceCheckpointSource)
        {
            var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("CheckpointInfo_DeleteCheckpoint");
            dataCommandObject.SetParameterValue("@Id", deviceCheckpointSource.Id);
            dataCommandObject.ExecuteNonQuery();
            return (int)dataCommandObject.GetParameterValue("@RetVal");
        }

        public DeviceCheckpointSource[] QueryDeviceCheckpoints(Paging paging, int id, string deviceNumber)
        {
            var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("CheckpointInfo_QueryCheckpointsByPaging");
            dataCommandObject.SetParameterValue("@PageNumber", paging.PageNumber);
            dataCommandObject.SetParameterValue("@PageSize", paging.PageSize);
            dataCommandObject.SetParameterValue("@DeviceNumber", deviceNumber);
            dataCommandObject.SetParameterValue("@Id", id);
            var result = dataCommandObject.QueryEntities<DeviceCheckpointSource>().ToArray();
            paging.TotalPages = (int)dataCommandObject.GetParameterValue("@TotalPages");
            return result;
        }

        public DeviceCheckpointSource[] QueryDeviceCheckpoints(string[] deviceNumbers)
        {
            var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("CheckpointInfo_QueryCheckpointsByDevices");
            dataCommandObject.SetParameterValues("@DeviceNumbers", deviceNumbers);
            return dataCommandObject.QueryEntities<DeviceCheckpointSource>().ToArray();
        }
    }
}
