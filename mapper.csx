#load "json.csx"
#load "jobItem.csx"
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


public class JobItemMapper {

        public List<JobItem> Transform(RootObject rootJson, ILogger log) {

            var jobList = new List<JobItem>();
            rootJson.jobs.ForEach(jobJson => {
                var item = new JobItem()
                {
                    job_id = jobJson.ReleasedJob.job_id,
                    cipher = jobJson.ReleasedJob.cipher,
                    ministry = jobJson.ReleasedJob.ministry,
                    employer = jobJson.ReleasedJob.employer,
                    title = jobJson.ReleasedJob.title,
                    sector = jobJson.ReleasedJob.sector,
                    career = jobJson.ReleasedJob.career,
                    limitation = jobJson.ReleasedJob.limitation,
                    working_hours = jobJson.ReleasedJob.working_hours,
                    publishing_date = jobJson.ReleasedJob.publishing_date,
                    expiration_date = jobJson.ReleasedJob.expiration_date,
                    employer_nrw = jobJson.ReleasedJob.employer_nrw,
                    employer_name = jobJson.ReleasedJob.employer_name,
                    employer_street = jobJson.ReleasedJob.employer_street,
                    employer_country = jobJson.ReleasedJob.employer_country,
                    employer_zip = jobJson.ReleasedJob.employer_zip,
                    employer_city = jobJson.ReleasedJob.employer_city,
                    employer_coord_x = jobJson.ReleasedJob.employer_coord_x,
                    employer_coord_y = jobJson.ReleasedJob.employer_coord_y,
                    content = jobJson.ReleasedJob.content
                };

                jobList.Add(item);
            });

            return jobList;
        }
}
