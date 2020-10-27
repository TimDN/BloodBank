using System;

namespace BloodCenter.Donation
{
    public class Block
    {
        public Block(DateTimeOffset startDate, int daysBlocked)
        {
            StartDate = startDate;
            DaysBlocked = daysBlocked;
        }

        public Block(int daysBlocked)
        {
            StartDate = DateTimeOffset.Now;
            DaysBlocked = daysBlocked;
        }

        public DateTimeOffset StartDate { get; }
        public int DaysBlocked { get; }

        public bool Active => GetEndDate() >= DateTimeOffset.Now;

        public DateTimeOffset GetEndDate()
        {
            return StartDate.AddDays(DaysBlocked);
        }
    }
}