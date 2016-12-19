using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfDataService
{
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        Collection<ItemSql> GetItemsFull();

        [OperationContract]
        Collection<ItemSqlSimple> GetItemsShort();

        [OperationContract]
        Collection<ItemSqlSimple> GetItemsShortByDataNames(Collection<string> dataNames);

        [OperationContract]
        ItemSqlTrends GetTrends(string tableName, int type, DateTime dateBegin, DateTime dateEnd, int timePeriod);

        [OperationContract]
        DateTime GetSqlCurrentTime();

        [OperationContract]
        DateTimeOffset GetDateTimeOffset();
        
        [OperationContract]
        bool SetClientInfoFull(string quid, string ipAddress, string version, DateTime clientTime, string browserInformation);

        [OperationContract]
        bool SetClientInfoShort(string quid, DateTime clientTime);

        [OperationContract]
        Collection<TIDELOGEx> GetMTBTIDELOGs(string tableName, DateTime dateBegin, DateTime dateEnd);

        [OperationContract]
        string GetServiceInfo();
    }
}
