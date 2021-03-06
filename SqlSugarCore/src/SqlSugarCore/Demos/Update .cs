﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;
using Models;

namespace SqlSugarTest.Demos
{
    public class Update : IDemos
    {
        public void Init()
        {
            int id = 10;
            using (var db = SugarDao.GetInstance())
            {
                //指定列更新
                db.Update<School>(new { name = "蓝翔2" }, it => it.id == id);
                db.Update<School, int>(new { name = "蓝翔2" }, 10, 13, 12);
                db.Update<School, string>(new { name = "蓝翔2" }, new string[] { "11", "12" });

                //整个实体更新
                db.Update(new School { id = id, name = "蓝翔2" });
                db.Update<School>(new School { id = id, name = "蓝翔2" }, it => it.id == id);


                //设置不更新列
                db.DisableUpdateColumns = new string[] { "CreateTime" };//设置CreateTime不更新

                TestUpdateColumns updObj = new TestUpdateColumns()
                {
                    VGUID = Guid.Parse("542b5a27-6984-47c7-a8ee-359e483c8470"),
                    Name = "xx",
                    Name2 = "xx2",
                    IdentityField = 0,
                    CreateTime = null
                };

                //CreateTime将不会被更新
                db.Update(updObj);
                //以前实现这种更新需要用指定列的方式实现，现在就简单多了。

            }
        }
    }
}
