using System;

namespace Expire.Models
{
    public class AssetItem
    {
        public string Name
        {
            get;
            set;
        }

        public decimal Price
		{
			get;
			set;
		}

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

		public string Remark
		{
			get;
			set;
		}
    }
}
