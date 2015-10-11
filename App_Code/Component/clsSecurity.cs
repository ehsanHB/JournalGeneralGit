using System;
using System.Collections.Generic;
//-----------------
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for clsSecurity
/// </summary>
public class clsSecurity
{
	public clsSecurity()
	{
	}
    //.ToString("x2") returns hexadecimal format 
    //string s= clsSecurity.ComputeMD5("sgsgkjgkjs")
    public static string ComputeMD5(string str)
    {

        string strResult = "";
        MD5 x = new MD5CryptoServiceProvider();
        byte[] bytesToHash = System.Text.Encoding.UTF8.GetBytes(str);
        bytesToHash = x.ComputeHash(bytesToHash);
        foreach (Byte b in bytesToHash)
            strResult += b.ToString("x2");
        return strResult;
        //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");

    }

    public static string ComputeSHA1(string str)
    {
        string strResult = "";
        SHA1 x = new SHA1Managed();
        byte[] bytesToHash = System.Text.Encoding.UTF8.GetBytes(str);
        bytesToHash = x.ComputeHash(bytesToHash);
        foreach (Byte b in bytesToHash)
            strResult += b.ToString("x2");
        return strResult;
        //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1");

    }

    //clsSecurity.getRSAkeys(out s1,out s2)
    public static void getRSAkeys(out string strPublicKey, out string strPublicPrivateKey)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        strPublicKey = rsa.ToXmlString(false);//public
        strPublicPrivateKey = rsa.ToXmlString(true);//public and private
    }

    //encrypt publicKey
    //decrypt public private key

    public static string EncryptRSAwithPublicKey(string strPublicKey, string strText)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(strPublicKey);
        byte[] bs = rsa.Encrypt(Encoding.UTF8.GetBytes(strText), false);
        //ghalat kardi: return Encoding.UTF8.GetString(bs)
        return Convert.ToBase64String(bs);
    }
    public static string DecryptRSAwithPublicPrivateKey(string strPublicPrivateKey, string strEncrypted)
    {
        byte[] bs = Convert.FromBase64String(strEncrypted);
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(strPublicPrivateKey);
        byte[] bs2 = rsa.Decrypt(bs, false);
        return Encoding.UTF8.GetString(bs2);
    }

    //signData public private key
    public static string SignWithRSA(string strPublicPrivateKey, string strText)
    {
        byte[] bs = UTF8Encoding.UTF8.GetBytes(strText);
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(strPublicPrivateKey);
        byte[] bs2 = rsa.SignData(bs, new SHA1CryptoServiceProvider());
        //rsa.SignHash(bs);
        return Convert.ToBase64String(bs2);
    }

    public static bool VerifySignWithRSA(string strPublicKey, string strText, string strSign)
    {
        byte[] bsSign = Convert.FromBase64String(strSign);
        byte[] bsText= UTF8Encoding.UTF8.GetBytes(strText);
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(strPublicKey);
        bool b=rsa.VerifyData(bsText, new SHA1CryptoServiceProvider(), bsSign);
        return b;
    }

    public static string EncryptAES(string plainText, string strKey, string strIV)
    {

        byte[] Key = Encoding.ASCII.GetBytes(strKey);
        byte[] IV = Encoding.ASCII.GetBytes(strIV);


        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("Key");


        // Declare the streams used
        // to encrypt to an in memory
        // array of bytes.
        MemoryStream msEncrypt = null;
        CryptoStream csEncrypt = null;
        StreamWriter swEncrypt = null;

        // Declare the RijndaelManaged object
        // used to encrypt the data.
        RijndaelManaged aesAlg = null;
        // Declare the bytes used to hold the
        // encrypted data.
        byte[] encrypted = null;

        try
        {
            // Create a RijndaelManaged object
            // with the specified key and IV.
            aesAlg = new RijndaelManaged();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create a decrytor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            msEncrypt = new MemoryStream();
            csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            swEncrypt = new StreamWriter(csEncrypt);

            //csEncrypt.Write(byte[] ...)
            
            //Write all data to the stream.
            swEncrypt.Write(plainText);

        }
        finally
        {
            // Clean things up.

            // Close the streams.
            if (swEncrypt != null)
                swEncrypt.Close();
            if (csEncrypt != null)
                csEncrypt.Close();
            if (msEncrypt != null)
                msEncrypt.Close();

            // Clear the RijndaelManaged object.
            if (aesAlg != null)
                aesAlg.Clear();
        }

        // Return the encrypted bytes from the memory stream.
        return Convert.ToBase64String(msEncrypt.ToArray());

    }

    public static string DecryptAES(string str, string strKey, string strIV)
    {

        byte[] Key = Encoding.ASCII.GetBytes(strKey);
        byte[] IV = Encoding.ASCII.GetBytes(strIV);
        byte[] cipherText = Convert.FromBase64String(str);
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("Key");


        // TDeclare the streams used
        // to decrypt to an in memory
        // array of bytes.
        MemoryStream msDecrypt = null;
        CryptoStream csDecrypt = null;
        StreamReader srDecrypt = null;

        // Declare the RijndaelManaged object
        // used to decrypt the data.
        RijndaelManaged aesAlg = null;
        // Declare the string used to hold
        // the decrypted text.
        string plaintext = null;

        try
        {
            // Create a RijndaelManaged object
            // with the specified key and IV.
            aesAlg = new RijndaelManaged();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create a decrytor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            msDecrypt = new MemoryStream(cipherText);
            csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            srDecrypt = new StreamReader(csDecrypt);

            // Read the decrypted bytes from the decrypting stream
            // and place them in a string.
            plaintext = srDecrypt.ReadToEnd();
        }
        finally
        {
            // Clean things up.

            // Close the streams.
            if (srDecrypt != null)
                srDecrypt.Close();
            if (csDecrypt != null)
                csDecrypt.Close();
            if (msDecrypt != null)
                msDecrypt.Close();

            // Clear the RijndaelManaged object.
            if (aesAlg != null)
                aesAlg.Clear();
        }

        return plaintext;

    }


}
