using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;


class CryptDes
{
    //默认密钥向量
    private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    /// <summary>
    /// DES加密字符串
    /// </summary>
    /// <param name="encryptString">待加密的字符串</param>
    /// <param name="encryptKey">加密密钥,要求为8位</param>
    /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
    public static string EncryptDES(string encryptString, string encryptKey)
    {
        try
        {
            byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] rgbIV = Keys;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
        catch
        {
            return encryptString;
        }
    }

    /// <summary>
    /// DES解密字符串
    /// </summary>
    /// <param name="decryptString">待解密的字符串</param>
    /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
    /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
    public static string DecryptDES(string decryptString, string decryptKey)
    {
        try
        {
            byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
            byte[] rgbIV = Keys;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }
        catch
        {
            return decryptString;
        }
    }


    /// <summary>
    /// 从汉字转换到16进制
    /// </summary>
    /// <param name="s"></param>
    /// <param name="charset">编码,如"utf-8","gb2312"</param>
    /// <param name="fenge">是否每字符用逗号分隔</param>
    /// <returns></returns>
    public static string ToHex(string s, string charset, bool fenge)
    {
        System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);

        byte[] bytes = chs.GetBytes(s);

        string str = "";

        for (int i = 0; i < bytes.Length; i++)
        {
            str += string.Format("{0:X}", bytes[i]);
            if (fenge && (i != bytes.Length - 1))
            {
                str += string.Format("{0}", ",");
            }
        }
        return str.ToLower();
    }

    /// <summary>
    /// 从16进制转换成汉字
    /// </summary>
    /// <param name="hex"></param>
    /// <param name="charset">编码,如"utf-8","gb2312"</param>
    /// <returns></returns>
    public static string UnHex(string hex, string charset)
    {
        if (hex == null)
            throw new ArgumentNullException("hex");
        hex = hex.Replace(",", "");
        hex = hex.Replace("\n", "");
        hex = hex.Replace("\\", "");
        hex = hex.Replace(" ", "");
        if (hex.Length % 2 != 0)
        {
            hex += "20";//空格
            //throw new ArgumentException("hex is not a valid number!", "hex");
        }
        // 需要将 hex 转换成 byte 数组。
        byte[] bytes = new byte[hex.Length / 2];

        for (int i = 0; i < bytes.Length; i++)
        {
            try
            {
                // 每两个字符是一个 byte。
                bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                throw new ArgumentException("hex is not a valid hex number!", "hex");
            }
        }
        System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
        return chs.GetString(bytes);
    }
}