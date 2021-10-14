using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.interfaces
{
    public interface IDataRepository
    {
        void CreateDefaultsAccounts();
        bool DeleteAccounts();
        bool CreateDefaultCollectionEvents();
        void DeleteCollectionOfEvents();
        void SaveDatasToJSON();
        void ReadDatasFromJSON();
    }
}
