import React from "react";
import jobsJson from "../jobs.json";
import JobListing from "./JobListing";

const JobListings = ({ maxLimit = 0, heading = "Browse Jobs" }) => {
  let jobs = jobsJson;

  if (maxLimit !== 0) jobs = jobs.slice(0, maxLimit);

  return (
    <section className="bg-blue-50 px-4 py-10">
      <div className="container-xl lg:container m-auto">
        <h2 className="text-3xl font-bold text-indigo-500 mb-6 text-center">
          {heading}
        </h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          {jobs.map((job) => (
            <JobListing key={job.id} job={job} />
          ))}
        </div>
      </div>
    </section>
  );
};

export default JobListings;
