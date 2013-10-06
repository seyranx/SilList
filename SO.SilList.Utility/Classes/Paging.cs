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

        public int nextPagesLinks
        {
            get
            {
                return (int)Math.Min((int)pageNumber + pageLinkCount, totalPages);
            }
        }
        public int prevPagesLinks
        {
            get
            {
                if (pageNumber - pageLinkCount <= 0)
                    return 1;
                else
                    return (int)(pageNumber - pageLinkCount);
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
                    tmp = (totalPages - pageLinkCount)+1;
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
                if (totalPages < pageLinkCount)
                    return totalPages;
                if (startingLinkPage + pageLinkCount-1 > totalPages)
                    return (totalPages - startingLinkPage) + startingLinkPage-1;
                else
                    return startingLinkPage + pageLinkCount -1; ;
            }
        }
        public int skip
        {
            get
            {
                if ( pageNumber < 2 || rowCount < 1) return 0;

                return ((int)(pageNumber - 1) * (int)rowCount);
            }
        }
        public int pageLinkCount
        {
            get
            {
                return  5;
            }
        }
        public int rowCount
        {
            get
            {
                return 2;
            }
        }

    }
}
