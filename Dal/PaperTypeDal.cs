using Model;
using System;
using System.Data;
using System.Data.SqlClient;
namespace Dal
{
    public class PaperTypeDal
    {
        public DataTable GetAll(PaperTypeEntity en)
        {
            DataBase db = new DataBase();
            string sql = "select PTID,PTName,PTDesc from PaperType";
            return db.GetDataTable(sql);
        }
        public bool Add(PaperTypeEntity en)
        {
            DataBase db = new DataBase();
            string sql = "insert into PaperType (PTID,PTName,PTDesc) values (@PTID,@PTName,@PTDesc)";
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PTName", SqlDbType.VarChar, 128);
            para[0].Value = en.TypeName;
            para[1] = new SqlParameter("@PTDesc", SqlDbType.VarChar, -1);
            para[1].Value = en.TypeDes;
            para[2] = new SqlParameter("@PTID", SqlDbType.Int);
            para[2].Value = en.PTID;
            return db.ExecuteSql(sql, para) == 1;
        }
        public bool Delete(PaperTypeEntity en)
        {
            DataBase db = new DataBase();
            string sql = "delete PaperType where PTID=@PTID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@PTID", SqlDbType.Int)
			};
            para[0].Value = en.PTID;
            return db.ExecuteSql(sql, para) == 1;
        }
        public bool Update(PaperTypeEntity en)
        {
            DataBase db = new DataBase();
            string sql = "update PaperType set PTName=@PTName,PTDesc=@PTDesc where PTID=@PTID";
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PTName", SqlDbType.VarChar, 128);
            para[0].Value = en.TypeName;
            para[1] = new SqlParameter("@PTDesc", SqlDbType.VarChar, -1);
            para[1].Value = en.TypeDes;
            para[2] = new SqlParameter("@PTID", SqlDbType.Int);
            para[2].Value = en.PTID;
            return db.ExecuteSql(sql, para) == 1;
        }
    }
}
