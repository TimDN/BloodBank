using BloodCenter.Employees;

namespace BloodCenter.Donation
{
    interface IReviewable
    {
        bool Reviewed { get; }
        Nurse ReviewBy { get; }

        bool IsBlocked { get; }
        string BlockReason { get; }
        int BlockTimeInDays { get; }

        void Block(Nurse nurse, string reason, int blockTimeInDays);

        void Approve(Nurse nurse);
    }
}
