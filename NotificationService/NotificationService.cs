using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Security.Cryptography;
using System.Globalization;

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
            string strHash = HashHMACHex(strPrivateKey, strRequest); //convert to URI 
            System.Uri uriHash = new System.Uri(strHash);
            string SNSURL = "http://sns.us-west-2.amazonaws.com/?" + strReqParams + "&Signature=" + uriHash;

            var client = new HttpClient();

            Task<string> task = client.GetStringAsync(SNSURL);
            task.Wait();
        }

        private static string HashHMACHex(string keyHex, string message)
        {
            byte[] hash = HashHMAC(HexDecode(keyHex), StringEncode(message));
            return HashEncode(hash);
        }

        private static byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }


        private static byte[] StringEncode(string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        private static byte[] HexDecode(string hex)
        {
            var bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = byte.Parse(hex.Substring(i * 2, 2), NumberStyles.HexNumber);
            }
            return bytes;
        }
    }
}
