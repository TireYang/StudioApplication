using StudioApplication.Common;
using StudioApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using DapperExtensions;

namespace StudioApplication
{
    public class SQLHelper<V, M>
        where V : class, new()
        where M : class, new()
    {
        #region att
        private FacadeBase<M> _mainFacade;

        public FacadeBase<M> MainFacade
        {
            get { return _mainFacade; }
            set { _mainFacade = value; }
        }
        #endregion

        #region public

        public SQLHelper()
        {
            var conString = DataBaseConnections.GetMainSqlConString();
            _mainFacade = new FacadeBase<M>(conString);
        }

        public void InsertModel(V model)
        {
            //insert
            M toInsert = new M();
            AutoMapper.Mapper.Map(model, toInsert);
            MainFacade.Insert(toInsert);
        }

        public void UpdateModel(V model, M mainModel)
        {
            AutoMapper.Mapper.Map(model, mainModel);
            MainFacade.Update(mainModel);
        }

        public Guid DeleteModel(Guid queueID)
        {
            Guid result = Guid.Empty;
            var model = MainFacade.GetList(new { QueueID = queueID }).FirstOrDefault();
            if (model != null)
            {
                MainFacade.Delete(model);
            }
            return result;
        }

        #endregion
    }
}

