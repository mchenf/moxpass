using Microsoft.Data.Sqlite;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace moxpass_gui.Data
{
    public class ToAuthenticate : IDisposable
    {
        private byte[] salt;
        private byte[] hash;

        public ToAuthenticate(byte[] salt, byte[] hash)
        {
            this.salt = salt;
            this.hash = hash;
        }

        public bool TestPass(string pass)
        {
            byte[] HashToCompare = AuthHandler.GetSha256Hash(salt, pass);

            string HashToCompareStr = Convert.ToBase64String(HashToCompare);
            string HashStr = Convert.ToBase64String(hash);
            Console.WriteLine("Testing password {0}", pass);
            Console.WriteLine(HashToCompareStr);
            Console.WriteLine("⇅");
            Console.WriteLine(HashStr);

            if (hash.Length != HashToCompare.Length)
            {
                return false;
            }

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != HashToCompare[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void Dispose()
        {
            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = byte.MinValue;
            }
            for (int i = 0; i < hash.Length; i++)
            {
                hash[i] = byte.MinValue;
            }
        }
    }
    public class AuthHandler
    {
        private static readonly string dataSrc = @"Data Source=Data/moxpass.db";
        private static byte[] createSalt(int Length)
        {
            byte[] buffer = RandomNumberGenerator.GetBytes(Length);
            return buffer;
        }

        public static byte[] GetSha256Hash(byte[] salt, string Password)
        {
            byte[] saltedByteArray = new byte[Password.Length + salt.Length];

            for (int i = 0; i < Password.Length; i++)
            {
                saltedByteArray[i] = (byte)Password[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                saltedByteArray[Password.Length + i] = salt[i];
            }


            HashAlgorithm algo = SHA256.Create();

            byte[] salthash = algo.ComputeHash(saltedByteArray);

            return salthash;
        }

        public bool Authenticate(string Email, string Password)
        {
            bool Authenticated = false;
            using (var conn = new SqliteConnection(dataSrc))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT email, salt, salthash FROM tbl_accounts WHERE email = $v;";
                cmd.Parameters.AddWithValue("$v", Email);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Debug.Print($"Failed to hit a search with {Email}");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            if (reader[1] is null) break;
                            string saltStr = reader.GetString(1);
                            byte[] salt = Convert.FromBase64String(saltStr);
                            if (reader[2] is null) break;
                            string hashStr = reader.GetString(2);
                            Console.WriteLine("Authenticating...");
                            Console.WriteLine("Salt Base64 is: \r\n{0}", saltStr);
                            Console.WriteLine("Hash Base64 is: \r\n{0}", hashStr);
                            byte[] hash = Convert.FromBase64String(hashStr);
                            using (var auth = new ToAuthenticate(salt, hash))
                            {
                                Authenticated = auth.TestPass(Password);
                            }

                            break;
                        }
                    }
                    
                }
            }

            return Authenticated;
        }

        public bool RegisterAccount(string Email, string Password)
        {
            bool result = false;

            if (CheckAccountExist(Email))
            {
                return false;
            }

            byte[] salt = createSalt(256);

            byte[] salthash = GetSha256Hash(salt, Password);

            using (var conn = new SqliteConnection(dataSrc))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                string saltStr = Convert.ToBase64String(salt);
                string salthashStr = Convert.ToBase64String(salthash);

                Console.WriteLine($"For user {Email} registrations, the salt base64 is:");
                Console.WriteLine(saltStr);
                Console.WriteLine($"Salt hash base64 is:");
                Console.WriteLine(salthashStr);

                cmd.CommandText = "INSERT INTO tbl_accounts (email, salt, salthash) VALUES ($v0, $v1, $v2);";
                cmd.Parameters.AddWithValue("$v0", Email);
                cmd.Parameters.AddWithValue("$v1", saltStr);
                cmd.Parameters.AddWithValue("$v2", salthashStr);

                int rowsAffected = cmd.ExecuteNonQuery();

                result = rowsAffected == 1;
            }


            return result;
        }

        public bool CheckAccountExist(string Email)
        {
            bool result = false;
            using (var conn = new SqliteConnection(dataSrc))
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT email FROM tbl_accounts WHERE email = $v;";
                cmd.Parameters.AddWithValue("$v", Email);
                using (var reader = cmd.ExecuteReader())
                {
                    result = reader.HasRows;
                }
            }
            return result;
        }
    }
}
