using Dapper;

using static MandiPOS.SQL;
namespace MandiPOS.CLasses
{
    public class tblConfigs
    {
        public string ConfigName { get; set; }
        public string ConfigValue { get; set; }
    }
    public static class configService
    {
        public static tblConfigs GetConfigByName(string configName)
        {
            return new db().QueryFirstOrDefault<tblConfigs>($"Select Top 1 * from tblConfigs Where ConfigName like '{configName}'");
        }
    }
}
