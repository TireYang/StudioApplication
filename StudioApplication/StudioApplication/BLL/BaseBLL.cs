using StudioApplication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioApplication.BLL
{
    public class BaseBLL<T> where T : class, new()
    {
        protected FacadeBase<T> _mainFacade = new FacadeBase<T>(DataBaseConnections.GetMainSqlConString());

        public virtual void InsertModel(T model)
        {
            _mainFacade.Insert(model);
        }

        public virtual void DeleteModel(T model)
        {
            _mainFacade.Delete(model);
        }

        public virtual void UpdateModel(T model)
        {
            _mainFacade.Update(model);
        }

    }
}
