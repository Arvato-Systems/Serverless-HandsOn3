#r "Newtonsoft.Json"
#r "Microsoft.WindowsAzure.Storage"
#load "json.csx"
#load "jobItem.csx"
#load "mapper.csx"

using System;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;


public static void Run(TimerInfo myTimer, ILogger log)
{
    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
    var result = MakeRequest(log);
    if(result != null) {
        var mapper = new JobItemMapper();
        var jobs = mapper.Transform(result, log);
        if(jobs.Count > 0) {
            InsertIntoStorage(jobs, log);
        }
    }
    log.LogInformation($"C# Timer trigger finished");
}

public static RootObject MakeRequest(ILogger log) {
    using (var client = new WebClient()) {
        var jsonData = string.Empty;

            try {
                jsonData = client.DownloadString("https://www.stellenmarkt.nrw.de/openNRWJobs/search.json");
            } catch (Exception ex) {
                log.LogError($"Failure while downloading string from page: {ex}");
            }
        return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<RootObject>(jsonData) : null;
    }
}

public static void InsertIntoStorage(List<JobItem> jobs, ILogger log) {
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
    CloudTable table = storageAccount.CreateCloudTableClient().GetTableReference("raw");
    table.CreateIfNotExistsAsync();

    jobs.ForEach(job => {
        if(!EntityExists(job.PartitionKey, job.RowKey, table, log)) {
        TableOperation insertOperation = TableOperation.Insert(job);
        try {
              table.ExecuteAsync(insertOperation);  
            } catch (Exception ex) {
                log.LogError($"Failure while executing insert: {ex}");
            }
        }
    });   
}

public static bool EntityExists(string partitionKey, string rowKey, CloudTable table, ILogger log) {
            TableOperation retrieveOperation = TableOperation.Retrieve<JobItem>(partitionKey, rowKey);
            var retrievedResult = table.ExecuteAsync(retrieveOperation);
            
            return (retrievedResult.Result != null)? true: false;
}