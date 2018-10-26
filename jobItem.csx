#r "Microsoft.WindowsAzure.Storage"
using System;
using Microsoft.WindowsAzure.Storage.Table;

public class JobItem : TableEntity {
        
    public JobItem (){
        PartitionKey = "JobItem";
    }

    private string _job_id;
    public string job_id { 
        get => _job_id; 
        set { _job_id = RowKey = value;} 
    }
    public string cipher { get; set; }
    public string ministry { get; set; }
    public string employer { get; set; }
    public string title { get; set; }
    public string sector { get; set; }
    public string career { get; set; }
    public string limitation { get; set; }
    public string working_hours { get; set; }
    public string publishing_date { get; set; }
    public string expiration_date { get; set; }
    public bool employer_nrw { get; set; }
    public string employer_name { get; set; }
    public string employer_street { get; set; }
    public string employer_country { get; set; }
    public string employer_zip { get; set; }
    public string employer_city { get; set; }
    public string employer_coord_x { get; set; }
    public string employer_coord_y { get; set; }
    public string content { get; set; }
}