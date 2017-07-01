using System;
using Realms;

namespace Expire.PersistenceModels
{
    public class AssetItem : RealmObject
    {
        public string Name
        {
            get;
            set;
        }

        public double Price
		{
			get;
			set;
		}

        public DateTimeOffset PurchaseDate
        {
            get;
            set;
        }

        public DateTimeOffset StartDate
        {
            get;
            set;
        }

        public DateTimeOffset EndDate
        {
            get;
            set;
        }

        public DateTimeOffset ExpirationDate
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
