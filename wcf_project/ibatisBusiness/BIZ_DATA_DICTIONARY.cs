using ibatisCommon;
using ibatisModel;
using ibatisModel.Entry;
using ibatisPersistence.Persistence.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibatisBusiness
{
    public class BIZ_DATA_DICTIONARY : BIZ_ServiceBase
    {
        private IDATA_DICTIONARYDao _dictionaryDao = null;
        public BIZ_DATA_DICTIONARY()
        {
            _dictionaryDao = GetDao<IDATA_DICTIONARYDao>("DATA_DICTIONARYDao");
        }

        public string GetDictionaryMainInfo()
        {
            List<DATA_DICTIONARY> s = _dictionaryDao.FindAll().ToList();
            JSONObject<List<DATA_DICTIONARY>> objs = new JSONObject<List<DATA_DICTIONARY>>();
            objs.rspCode = "000";
            objs.rspDesc = "成功";
            objs.Result = s;
            string result = JSONHelper.ObjectToJSON(objs);
            return result;
        }

        /// <summary>
        /// 功能：根据id查询数据字典主类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDictionaryInfoById(string id)
        {
            DATA_DICTIONARY obj = _dictionaryDao.Find(id);
            JSONObject<DATA_DICTIONARY> objs = new JSONObject<DATA_DICTIONARY>();
            objs.Result = obj;
            objs.rspCode = "000";
            objs.rspDesc = "成功";
            string result = JSONHelper.ObjectToJSON(objs);
            return result;
        }
        /// <summary>
        /// 功能：修改数据字典类信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string UpdateDictionaryInfo(DATA_DICTIONARY dictionary)
        {
            long intRow = 0;
            if (dictionary != null)
            {
                dictionary.DICTIONARY_CREATED = DateTime.Now.ToString();
                dictionary.DICTIONARY_UPDATED = DateTime.Now.ToString();
                intRow = _dictionaryDao.Update(dictionary);
            }
            
            JSONObject<DATA_DICTIONARY> objs = new JSONObject<DATA_DICTIONARY>();
            if (intRow > 0)
            {
                objs.rspCode = "000";
                objs.rspDesc = "更新数据成功";
            }
            else
            {
                objs.rspCode = "101";
                objs.rspDesc = "更新数据失败";
            }
            string result = JSONHelper.ObjectToJSON(objs);
            return result;
        }

        /// <summary>
        /// 功能：修改数据字典类信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string InsertDictionaryInfo(DATA_DICTIONARY dictionary)
        {
            long intRow = 0;
            if (dictionary != null)
            {
                dictionary.DICTIONARY_CREATED = DateTime.Now.ToString();
                dictionary.DICTIONARY_UPDATED = DateTime.Now.ToString();
                intRow = _dictionaryDao.Insert(dictionary);
            }

            JSONObject<DATA_DICTIONARY> objs = new JSONObject<DATA_DICTIONARY>();
            if (intRow > 0)
            {
                objs.rspCode = "000";
                objs.rspDesc = "新增数据成功";
            }
            else
            {
                objs.rspCode = "101";
                objs.rspDesc = "新增数据失败";
            }
            string result = JSONHelper.ObjectToJSON(objs);
            return result;
        }

    }
}
