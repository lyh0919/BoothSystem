using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BoothModel;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoothAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BoothSysController : ControllerBase
    {
        private IRbac _rbac;
        IWebHostEnvironment _hostingEnvironment;
        public BoothSysController(IRbac rbac, IWebHostEnvironment environment)
        {
            _rbac = rbac;
            _hostingEnvironment = environment;
        }

        //登录
        [HttpGet]
        public RbacAdmin Login(string username,string userpass)
        {
            return _rbac.GetAdminOne(a => a.AccNum.Equals(username) & a.AccPass.Equals(userpass));
        }



        [HttpPost]
        public string UploadImg(string id)
        {

            //返回的文件地址
            string filenames = "";
            //获取当前web目录
            string webRootPath = _hostingEnvironment.WebRootPath + "\\img\\";
            if (!Directory.Exists(webRootPath))
            {
                Directory.CreateDirectory(webRootPath);
            }
            try
            {
                var file = Request.Form.Files[0];


                if (file != null)
                {
                    #region  图片文件的条件判断
                    //文件后缀
                    var fileExtension = Path.GetExtension(file.FileName);

                    //判断后缀是否是图片
                    const string fileFilt = ".gif|.jpg|.jpeg|.png";
                    if (fileExtension == null)
                    {

                        return "上传的文件没有后缀";
                    }
                    if (fileFilt.IndexOf(fileExtension.ToLower(), StringComparison.Ordinal) <= -1)
                    {

                        return "请上传jpg、png、gif格式的图片";
                    }

                    //判断文件大小    
                    long length = file.Length;
                    if (length > 1024 * 1024 * 2) //2M
                    {

                        return "上传的文件不能大于2M";
                    }

                    #endregion

                    var strDateTime = DateTime.Now.ToString("yyMMddhhmmssfff"); //取得时间字符串
                    var strRan = Convert.ToString(new Random().Next(100, 999)); //生成三位随机数
                    var saveName = strDateTime + strRan + fileExtension;

                    var filefullname = webRootPath  + saveName;
                    //插入图片数据                 
                    using (FileStream fs = System.IO.File.Create(filefullname))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                    filenames = saveName;
                    RbacAdmin admin = new RbacAdmin();
                    admin.Id = new Guid(id);
                    admin.AccImg = saveName;
                    admin.UpdateTime = DateTime.Now;
                    string[] propertyNames = new string[] { };
                    propertyNames = ReflectHelper.GetProperties(admin);
                    _rbac.UptAdmin(admin, propertyNames);
                }
                //但会url显示
                return filenames; 
            }
            catch (Exception)
            {
                //这边增加日志，记录错误的原因
                //ex.ToString();
                return "上传失败";
            }
        }



    }
}
