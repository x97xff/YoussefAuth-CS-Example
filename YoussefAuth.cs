using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace YoussefAuth
{
    public class api
    {
        public string name { get; set; }
        public string ownerid { get; set; }
        public string secret { get; set; }
        public string version { get; set; }

        private string sessionid;
        private string baseUrl = "https://youssefauth.wuaze.com/api/1.2/";

        public api(string name, string ownerid, string secret, string version)
        {
            this.name = name;
            this.ownerid = ownerid;
            this.secret = secret;
            this.version = version;
        }

        public static string GetHWID()
        {
            return WindowsIdentity.GetCurrent().User.Value;
        }

        public bool init()
        {
            using (var wb = new WebClient())
            {
                var req = new NameValueCollection();
                req["type"] = "init";
                req["ver"] = this.version;
                req["name"] = this.name;
                req["ownerid"] = this.ownerid;

                try
                {
                    byte[] response = wb.UploadValues(baseUrl, req);
                    string res = Encoding.UTF8.GetString(response);
                    if (res.Contains("\"success\":true"))
                    {
                        int sStart = res.IndexOf("\"sessionid\":\"") + 13;
                        int sEnd = res.IndexOf("\"", sStart);
                        this.sessionid = res.Substring(sStart, sEnd - sStart);
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool login(string username, string password)
        {
            using (var wb = new WebClient())
            {
                var req = new NameValueCollection();
                req["type"] = "login";
                req["username"] = username;
                req["pass"] = password;
                req["hwid"] = GetHWID();
                req["sessionid"] = this.sessionid;
                req["name"] = this.name;
                req["ownerid"] = this.ownerid;

                byte[] response = wb.UploadValues(baseUrl, req);
                string res = Encoding.UTF8.GetString(response);
                return res.Contains("\"success\":true");
            }
        }

        public bool license(string key)
        {
            using (var wb = new WebClient())
            {
                var req = new NameValueCollection();
                req["type"] = "license";
                req["key"] = key;
                req["hwid"] = GetHWID();
                req["sessionid"] = this.sessionid;
                req["name"] = this.name;
                req["ownerid"] = this.ownerid;

                byte[] response = wb.UploadValues(baseUrl, req);
                string res = Encoding.UTF8.GetString(response);
                return res.Contains("\"success\":true");
            }
        }
    }
}