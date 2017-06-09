using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace IAmFine.Notification
{
    public class NotificationService
    {
        public void SendNotification(string MessageText, string MessageSubject)
        {

            string strKEY = ConfigurationManager.AppSettings["NOTIFICATION_ACCESS_KEY_ID"];
            string strAccountID = ConfigurationManager.AppSettings["NOTIFICATION_ACCOUNT_ID"];
            string strPrivateKey = ConfigurationManager.AppSettings["NOTIFICATION_PRIVATE_KEY"];
//            string strTS = $(date - u "+%Y-%m-%dT%H:%M:%SZ" | sed 's/:/%3A/g')
            //string strRPARMS = "AWSAccessKeyId=" + strKEY + "Action=Publish&Message=" + MessageText + "&SignatureMethod=HmacSHA256&SignatureVersion=2&Subject=" + MessageSubject + "&Timestamp=" + strTimeStamp + "&TopicArn=arn%3Aaws%3Asns%3Aus-west-2%3A" + strAccountID + "%3ANSCHackathon";
//            string REQ = "GET" + Char.ConvertFromUtf32("0x0A") 

//            read - r - d '' REQ << EOF
//GET
//sns.us - west - 2.amazonaws.com
///
//$RPARMS
//EOF
//echo $REQ

//# sign - hash_hmac
//PK = 'kk2D8o8CWENSzhgnBkqLHpjJwzo1iV//2V92DC6u' # private key
//echo $PK

//SR =$(echo - n "$REQ" | openssl dgst - sha256 - hmac $PK - binary | openssl enc - base64 | sed 's/+/%2B/g;s/=/%3D/g;') 
//echo $SR

//R =$(echo - n "http://sns.us-west-2.amazonaws.com/?$RPARMS&Signature=$SR")
//echo $R
//curl "$R"
            ;
        }
    }
}
