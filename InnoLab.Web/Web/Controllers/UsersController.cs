using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace Web.Controllers
{
    public static class ExtensionMethods
    {
        public static string EscapeRegistrationId(this string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (!value.StartsWith("https://android.googleapis.com/gcm/send")) return value;
            var endpointParts = value.Split('/');
            var registrationId = endpointParts[endpointParts.Length - 1];
            return registrationId;
        }
    }

    public class UsersController : Controller
    {
        public static readonly List<string> Registrations = new List<string>();

        public string Add(string id)
        {
            if (!Registrations.Contains(id))
            {
                id = id.EscapeRegistrationId();
                Registrations.Add(id);
            }
            return id;
        }

        public string Get()
        {
            return "notification";
        }

        public string Send()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            request.Method = WebRequestMethods.Http.Post;
            request.KeepAlive = false;

            var postData = "{ \"registration_ids\": [ ";
            foreach (var registration in Registrations)
            {
                postData += "\"" + registration + "\", ";
            }

            postData += "]}";

            var byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "key=AIzaSyAd03kWE-ZfrbMKmq-GBnfN6CkJK0cDr1g");

            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            request.GetResponse();

            return "done";
        }
    }
}