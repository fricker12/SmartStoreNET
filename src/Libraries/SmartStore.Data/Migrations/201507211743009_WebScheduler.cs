namespace SmartStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
	using SmartStore.Data.Setup;

	public partial class WebScheduler : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleTask", "Alias", c => c.String(maxLength: 4000));
            AddColumn("dbo.ScheduleTask", "NextRunUtc", c => c.DateTime());
            AddColumn("dbo.ScheduleTask", "IsHidden", c => c.Boolean(nullable: false));
            CreateIndex("dbo.ScheduleTask", new[] { "NextRunUtc", "Enabled" }, name: "IX_NextRun_Enabled");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ScheduleTask", "IX_NextRun_Enabled");
            DropColumn("dbo.ScheduleTask", "IsHidden");
            DropColumn("dbo.ScheduleTask", "NextRunUtc");
            DropColumn("dbo.ScheduleTask", "Alias");
        }

		public bool RollbackOnFailure
		{
			get { return false; }
		}

		public void Seed(SmartObjectContext context)
		{
			context.MigrateLocaleResources(MigrateLocaleResources);
		}

		public void MigrateLocaleResources(LocaleResourcesBuilder builder)
		{
			builder.Delete("Admin.System.ScheduleTasks.RestartApplication");

			builder.AddOrUpdate("Admin.System.ScheduleTasks.NextRun",
				"Next Run in",
				"N�chste Ausf�hrung in");
			builder.AddOrUpdate("Admin.System.ScheduleTasks.LastStart",
				"Last Run",
				"Letzte Ausf�hrung");

			builder.AddOrUpdate("Time.Year", "Year", "Jahr");
			builder.AddOrUpdate("Time.Years", "Years", "Jahre");
			builder.AddOrUpdate("Time.Month", "Month", "Monat");
			builder.AddOrUpdate("Time.Months", "Months", "Monate");
			builder.AddOrUpdate("Time.Week", "Week", "Woche");
			builder.AddOrUpdate("Time.Weeks", "Weeks", "Wochen");
			builder.AddOrUpdate("Time.Day", "Day", "Tag");
			builder.AddOrUpdate("Time.Days", "Days", "Tage");
			builder.AddOrUpdate("Time.Hour", "Hour", "Stunde");
			builder.AddOrUpdate("Time.Hours", "Hours", "Stunden");
			builder.AddOrUpdate("Time.Minute", "Minute", "Minute");
			builder.AddOrUpdate("Time.Minutes", "Minutes", "Minuten");
			builder.AddOrUpdate("Time.Second", "Second", "Sekunde");
			builder.AddOrUpdate("Time.Seconds", "Seconds", "Sekunden");

			builder.AddOrUpdate("Time.DayAbbr", "d", "Tg.");
			builder.AddOrUpdate("Time.DaysAbbr", "d", "Tg.");
			builder.AddOrUpdate("Time.HourAbbr", "h", "Std.");
			builder.AddOrUpdate("Time.HoursAbbr", "h", "Std.");
			builder.AddOrUpdate("Time.MinuteAbbr", "min", "Min.");
			builder.AddOrUpdate("Time.MinutesAbbr", "min", "Min.");
			builder.AddOrUpdate("Time.SecondAbbr", "sec", "Sek.");
			builder.AddOrUpdate("Time.SecondsAbbr", "sec", "Sek.");

		}
    }
}