using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;

namespace Bouwa.Helper.Class
{
    public class HelperClass
    {
        /// <summary>
        /// 8位数密钥
        /// </summary>
        private static string _key = ConfigurationSettings.AppSettings["password"];

        /// <summary>
        /// 空白卡
        /// </summary>
        private static string _card_status = "255";

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDESByKey8(string encryptString)
        {
            //return encode(encryptString);
            return StringEncryption.EncryptDESByKey8(encryptString, _key);
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDESByKey8(string decryptString)
        {
            //return decode(decryptString);
            return StringEncryption.DecryptDESByKey8(decryptString, _key);
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <returns>返回加密后的字符</returns>
        public static string EncryptByString(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            string htext = "";

            for (int i = 0; i < str.Length; i++)
            {
                htext = htext + (char)(str[i] + 10 - 1 * 2);
            }
            return htext;
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="str">需要解密的字符串</param>
        /// <returns>返回解密后的字符串</returns>
        public static string DecryptByString(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            string dtext = "";

            for (int i = 0; i < str.Length; i++)
            {
                dtext = dtext + (char)(str[i] - 10 + 1 * 2);
            }
            return dtext;
        }

        /// <summary>
        /// 获得停车卡的状态
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string getCardStatus(string str)
        {
            int cardStatus = 0;
            try
            {
                cardStatus = Convert.ToInt32(str);
            }
            catch (Exception e)
            {
                cardStatus = Convert.ToInt32(_card_status);
            }
            return cardStatus.ToString();
        }

        /// <summary>
        /// 3DES 加密字符串
        /// </summary>
        /// <param name="a_strString">需要加密的字符串（非中文字符）</param>
        /// <param name="a_strKey">密钥:长度为24位</param>
        /// <returns>返回加密后的字符串</returns>
        public static string Encrypt3DESByKey24(string a_strString, string a_strKey)
        {
            if (string.IsNullOrEmpty(a_strString)) return string.Empty;
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = ASCIIEncoding.ASCII.GetBytes(a_strKey);
            DES.Mode = CipherMode.ECB;

            ICryptoTransform DESEncrypt = DES.CreateEncryptor();

            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(a_strString);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        /// <summary>
        /// 3DES解密字符串
        /// </summary>
        /// <param name="a_strString">需要解密的字符串</param>
        /// <param name="a_strKey">密钥:长度为24位</param>
        /// <returns>返回解密后的字符串</returns>
        public static string Decrypt3DESByKey24(string a_strString, string a_strKey)
        {
            if (string.IsNullOrEmpty(a_strString)) return string.Empty;
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = ASCIIEncoding.ASCII.GetBytes(a_strKey);
            DES.Mode = CipherMode.ECB;
            DES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            string result = "";
            try
            {
                byte[] Buffer = Convert.FromBase64String(a_strString);
                result = ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception e)
            {

            }
            return result;
        }



       
    }
}
