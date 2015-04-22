using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Services.Protocols;
using System.Web.Services.Description;
using System.Net;
using System.IO;
using System.Xml;

namespace MySCM.PivotalTrackerAgent
{
    public class PivotalProject
    {
        public string AddComments(string Token, string ProjectId, string StoryId, string data)
        {
            string url = "http://www.pivotaltracker.com/services/v3/projects/" + ProjectId + "/stories/" + StoryId + "/notes";
            var uri = new Uri(url);              // Create a new HttpWebRequest object. 
 
            string pivotalString = "<note><text>" + data + "</text></note>";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/xml";
            request.Headers.Add("X-TrackerToken: " + Token);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(pivotalString);

            string debugString = "Add comments to a story:" + request.RequestUri;

            // Get Request 
            try
            {
                Stream rStream = request.GetRequestStream();
                rStream.Write(byteArray, 0, byteArray.Length);
                rStream.Close();
            }
            catch (Exception e)
            {
                return debugString + "\r\n" + " Get Request Exception: " + e.Message;
            }

            // Get Response
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rStream = response.GetResponseStream();
                StreamReader objReader = new StreamReader(rStream);
                string sLine = "";
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        Console.WriteLine("{0}:{1}", i, sLine);
                        sb.Append(sLine);
                    }
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                return debugString + "\r\n" + " Get Response Exception: " + e.Message;
            }
        }


        public string UpdateStory_State(string Token, string ProjectId, string StoryId, string data)
        {
            string url = "http://www.pivotaltracker.com/services/v3/projects/" + ProjectId + "/stories/" + StoryId;
            var uri = new Uri(url);              // Create a new HttpWebRequest object.    

            string pivotalString = "<story><current_state>" + data + "</current_state></story>";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/xml";
            request.Headers.Add("X-TrackerToken: " + Token);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Method = "PUT";
            byte[] byteArray = Encoding.UTF8.GetBytes(pivotalString);

            string debugString = "Update Story State: " + request.RequestUri;

            // Get Request 
            try
            {
                Stream rStream = request.GetRequestStream();
                rStream.Write(byteArray, 0, byteArray.Length);
                rStream.Close();
            }
            catch (Exception e)
            {
                return debugString + "\r\n" + " Get Request Exception: " + e.Message;
            }

            // Get Response
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rStream = response.GetResponseStream();
                StreamReader objReader = new StreamReader(rStream);
                string sLine = "";
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        Console.WriteLine("{0}:{1}", i, sLine);
                        sb.Append(sLine);
                    }
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                return " Get Response Exception: " + e.Message;
            }
        }


        public string AddStory(string Token, string ProjectId, string data)
        {
            //string url = "http://www.pivotaltracker.com/services/v3/projects/" + ProjectId + "/stories?token=" + Token;
            string url = "http://www.pivotaltracker.com/services/v3/projects/" + ProjectId + "/stories";
            var uri = new Uri(url);              // Create a new HttpWebRequest object.    

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/xml";
            request.Headers.Add("X-TrackerToken: " + Token);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            string debugString = "\r\nAdd a story:" + request.RequestUri + data;
            try
            {
                Stream rStream = request.GetRequestStream();
                rStream.Write(byteArray, 0, byteArray.Length);
                rStream.Close();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Request Exception: " + e.Message;
                return debugString;
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rStream = response.GetResponseStream();
                StreamReader objReader = new StreamReader(rStream);
                string sLine = "";
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        Console.WriteLine("{0}:{1}", i, sLine);
                        sb.Append(sLine);
                    }
                }
                debugString = debugString + "\r\n" + sb;

                return sb.ToString();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Response Exception: " + e.Message;
                return debugString;
            }
        }


        public string AddTask(string Token, string ProjectId, string StoryId, string data)
        {
            string url = "http://www.pivotaltracker.com/services/v3/projects/" + ProjectId + "/stories/" + StoryId + "/tasks";
            var uri = new Uri(url);              // Create a new HttpWebRequest object.    

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/xml";
            request.Headers.Add("X-TrackerToken: " + Token);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            string debugString = "\r\nAdd a task:" + request.RequestUri + data;
            try
            {
                Stream rStream = request.GetRequestStream();
                rStream.Write(byteArray, 0, byteArray.Length);
                rStream.Close();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Request Exception: " + e.Message;
                return debugString;
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rStream = response.GetResponseStream();
                StreamReader objReader = new StreamReader(rStream);
                string sLine = "";
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        Console.WriteLine("{0}:{1}", i, sLine);
                        sb.Append(sLine);
                    }
                }
                debugString = debugString + "\r\n" + sb;

                return sb.ToString();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Response Exception: " + e.Message;
                return debugString;
            }
        }


        public string UpdateTask(string Token, string ProjectId, string StoryId, string TaskId, string data)
        {
            string url = "http://www.pivotaltracker.com/services/v3/projects/" + ProjectId + "/stories/" + StoryId + "/tasks/" + TaskId;
            var uri = new Uri(url);              // Create a new HttpWebRequest object.    

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/xml";
            request.Headers.Add("X-TrackerToken: " + Token);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Method = "PUT";
            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            string debugString = "\r\nUpdate a task:" + request.RequestUri + data;
            try
            {
                Stream rStream = request.GetRequestStream();
                rStream.Write(byteArray, 0, byteArray.Length);
                rStream.Close();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Request Exception: " + e.Message;
                return debugString;
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rStream = response.GetResponseStream();
                StreamReader objReader = new StreamReader(rStream);
                string sLine = "";
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        Console.WriteLine("{0}:{1}", i, sLine);
                        sb.Append(sLine);
                    }
                }
                debugString = debugString + "\r\n" + sb;

                return sb.ToString();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Response Exception: " + e.Message;
                return debugString;
            }
        }


        public string DeleteTask(string Token, string ProjectId, string StoryId, string TaskId)
        {
            string url = "http://www.pivotaltracker.com/services/v3/projects/" + ProjectId + "/stories/" + StoryId + "/tasks/" + TaskId;
            var uri = new Uri(url);              // Create a new HttpWebRequest object.    
            string data = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/xml";
            request.Headers.Add("X-TrackerToken: " + Token);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Method = "DELETE";
            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            string debugString = "\r\ndelete a task:" + request.RequestUri + data;
            try
            {
                Stream rStream = request.GetRequestStream();
                rStream.Write(byteArray, 0, byteArray.Length);
                rStream.Close();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Request Exception: " + e.Message;
                return debugString;
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rStream = response.GetResponseStream();
                StreamReader objReader = new StreamReader(rStream);
                string sLine = "";
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        Console.WriteLine("{0}:{1}", i, sLine);
                        sb.Append(sLine);
                    }
                }
                debugString = debugString + "\r\n" + sb;

                return sb.ToString();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Response Exception: " + e.Message;
                return debugString;
            }
        }


        public string GetMembers(string Token, string ProjectId)
        {
            string data = "";
            string url = "http://www.pivotaltracker.com/services/v3/projects/" + ProjectId + "/memberships";
            var uri = new Uri(url);              // Create a new HttpWebRequest object.    

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/xml";
            request.Headers.Add("X-TrackerToken: " + Token);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Method = "GET";
            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            string debugString = "\r\nGet All Members:" + request.RequestUri + data;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rStream = response.GetResponseStream();
                StreamReader objReader = new StreamReader(rStream);
                string sLine = "";
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        Console.WriteLine("{0}:{1}", i, sLine);
                        sb.Append(sLine);
                    }
                }
                debugString = debugString + "\r\n" + sb;

                return sb.ToString();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Response Exception: " + e.Message;
                return debugString;
            }
        }


        public bool IsValidMember(string Token, string ProjectId, string memberName)
        {
            string allMembers = GetMembers(Token, ProjectId);
            string membership = "";

            // Load the result xml 
            XmlDocument pivotalXml = new XmlDocument();
            try
            {
                pivotalXml.LoadXml(allMembers);

                // Point Scale 
                XmlNodeList nodes = pivotalXml.DocumentElement.SelectNodes("//memberships/membership/person/name");
                foreach (XmlNode node in nodes)
                {
                    membership = membership + "-" + node.InnerText;
                }
            }
            catch (Exception e)
            {
                string exceptionString = "";
                exceptionString = exceptionString + "\r\n\r\n" + "Program: " + "MySCM.PivotalTrackerAgent.PivotalProject.cs";
                exceptionString = exceptionString + "\r\n\r\n" + "Place: " + "Loading ProjectInfo xml string";
                exceptionString = exceptionString + "\r\n\r\n" + "Exception: " + e.Message;
                return true;
            }

            if (membership.Contains(memberName))
                return true;
            else
                return false;
        }


        public string GetProject(string Token, string ProjectId)
        {
            string data = "";
            string url = "http://www.pivotaltracker.com/services/v3/projects/" + ProjectId;
            var uri = new Uri(url);              // Create a new HttpWebRequest object.    

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/xml";
            request.Headers.Add("X-TrackerToken: " + Token);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Method = "GET";
            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            string debugString = "\r\nGet Project:" + request.RequestUri + data;
            
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream rStream = response.GetResponseStream();
                StreamReader objReader = new StreamReader(rStream);
                string sLine = "";
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        Console.WriteLine("{0}:{1}", i, sLine);
                        sb.Append(sLine);
                    }
                }
                debugString = debugString + "\r\n" + sb;
                return sb.ToString();
            }
            catch (Exception e)
            {
                debugString = debugString + "\r\n" + "Response Exception: " + e.Message;
                return debugString;
            }
        }


        public bool IsValidPoint(string Token, string ProjectId, string Point)
        {
            string projectInfo = GetProject(Token, ProjectId);
            string pointScale = "";

            // Load the result xml 
            XmlDocument pivotalXml = new XmlDocument();
            try
            {
                pivotalXml.LoadXml(projectInfo);

                // Point Scale 
                XmlNode node = pivotalXml.DocumentElement.SelectSingleNode("//project/point_scale");
                if (node != null)
                {
                    pointScale = node.InnerText;
                }
            }
            catch (Exception e)
            {
                string exceptionString = "";
                exceptionString = exceptionString + "\r\n\r\n" + "Program: " + "MySCM.PivotalTrackerAgent.PivotalProject.cs";
                exceptionString = exceptionString + "\r\n\r\n" + "Place: " + "Loading ProjectInfo xml string";
                exceptionString = exceptionString + "\r\n\r\n" + "Exception: " + e.Message;
                return false;
            }

            if (pointScale.Contains(Point))
                return true;
            else
                return false;
        }
    }
}
