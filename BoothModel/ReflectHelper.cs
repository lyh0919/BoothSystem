using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;

namespace BoothModel
{
    public class ReflectHelper
    {
        /// <summary>
        /// 反射得到实体类的字段名称和值
        /// var dict = GetProperties(model);
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实例化</param>
        /// <returns></returns>
        public static string[] GetProperties<T>(T t)
        {

            if (t == null) { return null; }
            PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length <= 0) { return null; }
            int i = 0;
            foreach (PropertyInfo item in properties)
            {
                if (!item.Name.Equals("Id"))
                {
                    if (item.GetValue(t, null) != null)
                    {
                        i++;  //获取string[]长度
                    }
                }

            }
            string[] propertyNames = new string[i];
            int j = 0;
            foreach (PropertyInfo item in properties)
            {
                if (!item.Name.Equals("Id"))
                {
                    if (item.GetValue(t, null) != null)
                    {

                        propertyNames[j] = item.Name;  //赋值
                        j++;
                    }
                }

            }


            return propertyNames;
        }

        //获取IP地址
        public string GetIP()
        {
            string HostName = Dns.GetHostName(); //得到主机名
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName); //通过主机名去获取全部ip信息
            string ip = ""; //获取Ipv4
            foreach (var item in IpEntry.AddressList)
            {
                ip = item.ToString();
            }


            return ip;

        }
    }
}
