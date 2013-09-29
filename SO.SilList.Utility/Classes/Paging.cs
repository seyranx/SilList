using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Utility.Classes
{
    public class Paging
    {
    
        public int pageNumber { get; set; }
        public int totalCount { get; set; }
        
        public Paging()
        {
            pageNumber = 1;
        }

        public int totalPages
        {
            get
            {
                return (int)Math.Ceiling(totalCount / (Decimal)rowCount);
            }
        }

        public int next10Page
        {
            get
            {
                return (int)Math.Min((int)pageNumber+10,totalPages);
            }
        }
        public int prev10Page
        {
            get
            {
                if (pageNumber - 10 <= 0)
                    return 1;
                else
                    return (int)(pageNumber - 10);
            }
        }

        public int startingLinkPage
        {
            get
            {
                if (pageNumber > (int)(pageLinkCount / 2))
                {
                    int tmp = (int)pageNumber - (int)(pageLinkCount / 2);
                    if(tmp+pageLinkCount>totalPages)
                    tmp = (totalPages - pageLinkCount);
                    if (tmp <= 0)
                        tmp = 1;
                    return tmp;
                }
                else
                    return 1;
            }
        }
        public int endingLinkPage
        {
            get
            {
                if (startingLinkPage + pageLinkCount > totalPages)
                    return (totalPages - startingLinkPage) + startingLinkPage;
                else
                    return startingLinkPage + pageLinkCount; ;
            }
        }
        public int skip
        {
            get
            {
                if (pageNumber == null || pageNumber < 2 || rowCount < 1) return 0;

                return ((int)(pageNumber - 1) * (int)rowCount);
            }
        }
        public int pageLinkCount
        {
            get
            {
                return  3;
            }
        }
        public int rowCount
        {
            get
            {
                return 10;
            }
        }

    }
}
