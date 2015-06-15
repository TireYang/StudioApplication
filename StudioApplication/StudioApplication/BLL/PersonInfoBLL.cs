using DapperExtensions;
using StudioApplication.Common;
using StudioApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioApplication.BLL
{
    public class PersonInfoBLL
    {
        private FacadeBase<PersonInfo> _mainFacade;

        public void InsertPerson(PersonInfo personInfo, bool isTeacher)
        {
            if (isTeacher)
                personInfo.Type = 1;
            else
                personInfo.Type = 0;
            _mainFacade.Insert(personInfo);
        }

        public void DeletePerson(PersonInfo personInfo)
        {
            _mainFacade.Delete(personInfo);
        }

        public void UpdatePerson(PersonInfo personInfo)
        {
            _mainFacade.Update(personInfo);
        }

        public PersonInfo GetPersonInfo(string code)
        {
            return _mainFacade.Get(code);
        }

        public string GetNewPersonCode()
        {
            IList<ISort> sort = new List<ISort>();
            sort.Add(new Sort() { Ascending = false, PropertyName = "Code" });
            var lastPerson = _mainFacade.GetList(null, sort).FirstOrDefault();
            var newPersonCode = "P" + Convert.ToInt32(lastPerson.Code.Substring(1)) + 1;
            return newPersonCode;
        }
    }
}
