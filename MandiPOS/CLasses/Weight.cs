using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Weight
    {
        public int WeightID { get; set; }

        // Encrypted values stored in DB
        public string FirstWeightEncrypted { get; set; }
        public string SecondWeightEncrypted { get; set; }
        public string NetWeightEncrypted { get; set; }

        // Exposed to app/UI in decrypted decimal format
        [Dapper.Extra.Annotations.IgnoreUpdate] // Not mapped to DB
        [Dapper.Extra.Annotations.IgnoreInsert] // Not mapped to DB
        public decimal FirstWeight
        {
            get => FirstWeightEncrypted.Decrypt().ToDecimal();
            set => FirstWeightEncrypted = value.Encrypt();
        }

        [Dapper.Extra.Annotations.IgnoreUpdate] // Not mapped to DB
        [Dapper.Extra.Annotations.IgnoreInsert] // Not mapped to DB
        public decimal SecondWeight
        {
            get => SecondWeightEncrypted.Decrypt().ToDecimal();
            set => SecondWeightEncrypted = value.Encrypt();
        }

        [Dapper.Extra.Annotations.IgnoreUpdate] // Not mapped to DB
        [Dapper.Extra.Annotations.IgnoreInsert] // Not mapped to DB
        public decimal NetWeight
        {
            get => NetWeightEncrypted.Decrypt().ToDecimal();
            set => NetWeightEncrypted = value.Encrypt();
        }
    }

    public static class encryption
    {
        public static string Encrypt(this object simpleText)
        {
            return string.IsNullOrEmpty(simpleText?.ToString()) ? string.Empty : Eramake.eCryptography.Encrypt(simpleText.ToString());
        }
        public static string Decrypt(this object cipherText)
        {
            return string.IsNullOrEmpty(cipherText?.ToString()) ? string.Empty : Eramake.eCryptography.Decrypt(cipherText.ToString());
        }
        public static decimal ToDecimal(this string input)
        {
            return decimal.TryParse(input, out var result) ? result : 0;
        }
    }

//      var weight = new Weight
//      { 
//        FirstWeight = 100.5m,
//        SecondWeight = 150.0m,
//        NetWeight = 49.5m
//      };

//      Dapper will only save encrypted properties
//      connection.Insert(weight);




//      To Get From Database
//      var weight = connection.Get<Weight>(id);



//      database Table Structure
//      WeightID int (PK)
//      FirstWeightEncrypted   nvarchar(200)
//      SecondWeightEncrypted nvarchar(200)
//      NetWeightEncrypted nvarchar(200)



