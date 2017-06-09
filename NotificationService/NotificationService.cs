using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;

namespace IAmFine.Notification
{
    public class NotificationService
    {
        public void SendNotification(string MessageText, string MessageSubject)
        {

            int LineFeedChar = 0x0A;
            string strKEY = ConfigurationManager.AppSettings["NOTIFICATION_ACCESS_KEY_ID"];
            string strAccountID = ConfigurationManager.AppSettings["NOTIFICATION_ACCOUNT_ID"];
            string strPrivateKey = ConfigurationManager.AppSettings["NOTIFICATION_PRIVATE_KEY"];
            string strTimeStamp = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "T" + DateTime.Now.Hour + "%3A" + DateTime.Now.Minute + "%3A" + DateTime.Now.Second + "Z";
            string strReqParams = "AWSAccessKeyId=" + strKEY + "Action=Publish&Message=" + MessageText + "&SignatureMethod=HmacSHA256&SignatureVersion=2&Subject=" + MessageSubject + "&Timestamp=" + strTimeStamp + "&TopicArn=arn%3Aaws%3Asns%3Aus-west-2%3A" + strAccountID + "%3ANSCHackathon";
            string strRequest = "GET" + Char.ConvertFromUtf32(LineFeedChar) + "sns.us-west-2.amazonaws.com" + Char.ConvertFromUtf32(LineFeedChar) + "/" + Char.ConvertFromUtf32(LineFeedChar) + strReqParams + Char.ConvertFromUtf32(LineFeedChar);

            string strHash = "";//$(echo - n "$REQ" | openssl dgst - sha256 - hmac $PK - binary | openssl enc - base64 | sed 's/+/%2B/g;s/=/%3D/g;') 

            string SNSURL = "http://sns.us-west-2.amazonaws.com/?" + strReqParams + "&Signature=" + strHash;

            //var client = new HttpClient();

            //Task<string> task = client.GetStringAsync(SNSURL);
            //task.Wait();
            //Console.WriteLine(task.Result)

        }
    }
}
