using System;

namespace BloodCenter.Donation
{
    public interface IBlockable
    {
        bool IsBlocked { get; }
        string BlockReason { get; }
        int BlockTimeInDays { get; }

        void Block(string reason, int blockTimeInDays);
    }
}