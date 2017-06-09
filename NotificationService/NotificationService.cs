using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Security.Cryptography;
using System.Globalization;
using System.Web;

namespace IAmFine.Notification
{
    public class NotificationService
    {
        public void SendNotification(string MessageText, string MessageSubject)
        {
            string uriText = HttpUtility.UrlEncode(MessageText);
            string uriSubject = HttpUtility.UrlEncode(MessageSubject);
            int LineFeedChar = 0x0A;
            string strKEY = ConfigurationManager.AppSettings["NOTIFICATION_ACCESS_KEY_ID"];
            string strAccountID = ConfigurationManager.AppSettings["NOTIFICATION_ACCOUNT_ID"];
            string strPrivateKey = ConfigurationManager.AppSettings["NOTIFICATION_PRIVATE_KEY"];
            string strTimeStamp = HttpUtility.UrlEncode($"{DateTime.UtcNow:yyyy-MM-ddTHH:mm:ssZ}");
            string strReqParams = "AWSAccessKeyId=" + strKEY + "&Action=Publish&Message=" + uriText + "&SignatureMethod=HmacSHA256&SignatureVersion=2&Subject=" + uriSubject + "&Timestamp=" + strTimeStamp + "&TopicArn=arn%3Aaws%3Asns%3Aus-west-2%3A" + strAccountID + "%3ANSCHackathon";
            string strRequest = "GET" + Char.ConvertFromUtf32(LineFeedChar) + "sns.us-west-2.amazonaws.com" + Char.ConvertFromUtf32(LineFeedChar) + "/" + Char.ConvertFromUtf32(LineFeedChar) + strReqParams + Char.ConvertFromUtf32(LineFeedChar);
            string strHash = HashHMACHex(strPrivateKey, strRequest); 
            string uriHash = HttpUtility.UrlEncode(strHash);
            string SNSURL = "http://sns.us-west-2.amazonaws.com/?" + strReqParams + "&Signature=" + uriHash;

            var client = new HttpClient();

            Task<string> task = client.GetStringAsync(SNSURL);
            string output = task.Result;
        }

        private static string HashHMACHex(string keyHex, string message)
        {
            byte[] hash = HashHMAC(StringEncode(keyHex), StringEncode(message));
            return Convert.ToBase64String(hash);
        }

        private static byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }


        private static byte[] StringEncode(string text)
        {
            var encoding = System.Text.Encoding.UTF8.GetBytes(text);
            return encoding;
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        private static byte[] HexDecode(string hex)
        {
            return hex.ToCharArray().Select(x=>(byte)x).ToArray();

            var bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = byte.Parse(hex.Substring(i * 2, 2), NumberStyles.HexNumber);
            }
            return bytes;
        }
    }
}
