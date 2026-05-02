using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
public class Config
{
    public string? lang { get; set; }
    public string? transfer { get; set; }
    public string? methiod { get; set; }
    public string? confirmation { get; set; }
}
public class BankTrasnferConfig
{
    public Config config;
    public const string filePath = "jsconfig1.json";

    public BankTrasnferConfig()
    {
        try
        {
            readConfig();
        }
        catch
        {
            setDefaultConfig();
            writeConfig();
        }
    }
    
    private void readConfig()
    {
        string configJsonData = File.ReadAllText(filePath);
        config = JsonSerializer.Deserialize<Config>(configJsonData);
    }

    private void writeConfig()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filePath, jsonString);
    }
    public void setDefaultConfig()
    {
        config = new Config();
        config.lang = "en";
        config.transfer = "threshold";
        config.methiod = "[ “RTO (real-time)”, “SKN”, “RTGS”, “BI FAST” ]";
        config.confirmation = "en";
    }
}

public class transfer
{
    public double threshold { get; set; }
    public double low_fee { get; set; }
    public double high_fee { get; set; }

    public void Transfer(double threshold, double low_fee, double high_fee)
    {
        this.threshold = threshold;
        this.low_fee = low_fee;
        this.high_fee = high_fee;
    }

    public transfer()
    {
        threshold = 25000000;
        low_fee = 6500;
        high_fee = 15000;
    }
}
public class Confirmation
{
   public string en { get; set; }
    public string id { get; set; }
    public void confirmation(string en, string id)
    {
        this.en = en;
        this.id = id;
    }
     public Confirmation()
     {
          en = "yes";
          id = "ya";
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankTrasnferConfig bank = new BankTrasnferConfig();
        if (bank.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");

        }
        else if (bank.config.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di transfer: ");
        }

        static void transfer()
        {
            transfer transfer = new transfer();
            Console.WriteLine("Transfer fee: " + (transfer.threshold < 25000000 ? transfer.low_fee : transfer.high_fee));
        }
         static void confirmation()
        {
            Confirmation confirmation = new Confirmation();
            if (confirmation.en == "yes")
            {
                Console.WriteLine("Transfer is successful");
            }
            else if (confirmation.id == "ya")
            {
                Console.WriteLine("Transfer berhasil");
            }
        }


    }

}