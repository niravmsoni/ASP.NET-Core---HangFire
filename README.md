HangFire - Background processing
	Lengthy operations like DB updates
	Invoice generation
	Monthly reports
	Automatic subscription renewal
	Automatic Email upon signup
	
Background process - Runs BTS without user intervention

Types of background jobs/tasks
	- Fire and Forget - Happen only once. User sign up - welcome email
	- Delayed - Similar to F&F. Scheduled
	- Periodic and Scheduled - Periodically using a schedule
	
Why Hangfire?
	Reliable and Persistent - Once job is created, it's hangfire's responsibility to execute it
	Transparent and Distributed - We have hangfire dashboard and we can use different machines hence leveraging the power of distributed computing
	
	
Search for "HangFire" in Nuget Package
