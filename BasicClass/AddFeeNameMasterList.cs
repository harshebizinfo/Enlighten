using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class AddFeeNameMasterList
    {
        public int Id { get; set; }
        public string FeeName { get; set; }
        public Boolean RefundableFee { get; set; }
        public Boolean OptionalFee { get; set; }
        public Boolean DiscountOn { get; set; }
        public Boolean Conveyance { get; set; }
        public Boolean FeeDisplay { get; set; }
        public Boolean TransferHead { get; set; }
        public int FeeGroupId { get; set; }
        public Boolean IsActive { get; set; }
    }
}