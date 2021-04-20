using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Com.Cos.Utility
{
    public class DEncryptUtils
    {
        #region DES加密解密
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string DESEncrypt(string strSource)
        {
            byte[] DESKey = System.Text.ASCIIEncoding.ASCII.GetBytes("xhVs6DRXLfUGxw+AhtfQdpQGoa+8SA9d");
            return DESEncrypt(strSource, DESKey);
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="strSource">待加密字串</param>
        /// <param name="key">32位Key值</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string strSource, byte[] key)
        {
            SymmetricAlgorithm sa = Rijndael.Create();
            sa.Key = key;
            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.Zeros;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] byt = Encoding.Unicode.GetBytes(strSource);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string DESDecrypt(string strSource)
        {
            byte[] DESKey = System.Text.ASCIIEncoding.ASCII.GetBytes("xhVs6DRXLfUGxw+AhtfQdpQGoa+8SA9d");
            return DESDecrypt(strSource, DESKey);
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="strSource">待解密的字串</param>
        /// <param name="key">32位Key值</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string strSource, byte[] key)
        {
            SymmetricAlgorithm sa = Rijndael.Create();
            sa.Key = key;
            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.Zeros;
            ICryptoTransform ct = sa.CreateDecryptor();
            byte[] byt = Convert.FromBase64String(strSource);
            MemoryStream ms = new MemoryStream(byt);
            CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs, Encoding.Unicode);
            return sr.ReadToEnd();
        }
        #endregion
        #region 3DES加密解密
        /// <summary>
        /// 默认密钥和矢量的3DES加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encrypt3DES(string str)
        {
            //密钥
            string sKey = "xhVs6DRXLfUGxw+AhtfQdpQGoa+8SA9d";
            // //矢量,可为空
            string sIV = "4vHKRj3yfzU=";
            // //构造对称算法
            SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            mCSP.Key = Convert.FromBase64String(sKey);
            mCSP.IV = Convert.FromBase64String(sIV);
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);
            byt = Encoding.UTF8.GetBytes(str);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
        /// <summary>
        /// 带指定密钥和矢量的3DES加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sKey">32个字符</param>
        /// <param name="sIV">12个字符</param>
        /// <returns></returns>
        public string Encrypt3DES(string str, string sKey, string sIV)
        {
            SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            mCSP.Key = Convert.FromBase64String(sKey);
            mCSP.IV = Convert.FromBase64String(sIV);
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);
            byt = Encoding.UTF8.GetBytes(str);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
        /// <summary>
        /// 默认密钥和矢量的3DES解密
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string Decrypt3DES(string Value)
        {
            string sKey = "xhVs6DRXLfUGxw+AhtfQdpQGoa+8SA9d";//32个字符
            string sIV = "4vHKRj3yfzU=";//12个字符  
            SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            mCSP.Key = Convert.FromBase64String(sKey);
            mCSP.IV = Convert.FromBase64String(sIV);
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
            byt = Convert.FromBase64String(Value);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
        /// <summary>
        /// 带指定密钥和矢量的3DES解密
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="sKey">32个字符</param>
        /// <param name="sIV">12个字符</param>
        /// <returns></returns>
        public string Decrypt3DES(string str, string sKey, string sIV)
        {
            SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            mCSP.Key = Convert.FromBase64String(sKey);
            mCSP.IV = Convert.FromBase64String(sIV);
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
            byt = Convert.FromBase64String(str);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
        #endregion

    }
}