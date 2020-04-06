using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day02_16.MVC
{
    public class DetpInfo
    {
        public int Did { get; set; }
        public string Dname { get; set; }
    }
    public class UserInfo
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string LoginName { get; set; }
        public DateTime RegistrationTime { get; set; }
        public int DetpId { get; set; }
        public string Dname { get; set; }
    }
    public class PageInfo
    {
        public List<UserInfo> UserInfos { get; set; }
        public int totalpage { get; set; } //总页数
        public int pagesize { get; set; } //每页几条
        public int totalcount { get; set; } //总记录数
        public int currentpage { get; set; } //当前页
    }
}